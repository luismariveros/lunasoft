DROP TRIGGER IF EXISTS tbiVentasDetalles ON ventas_detalles;
DROP FUNCTION IF EXISTS tbiVentasDetalles() CASCADE;

CREATE OR REPLACE FUNCTION tbiVentasDetalles() RETURNS TRIGGER AS 
$$
DECLARE
	existencia_actual REAL;
	cantidad_necesaria REAL;
	existencia_general REAL;
	recorrido RECORD;
BEGIN
	IF NOT exists(SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito) THEN
		INSERT INTO stocks(id_deposito,id_producto,existencia) VALUES(new.id_deposito,new.id_producto,0);
	END IF;
	 
	existencia_actual := (SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito);

	IF (existencia_actual - new.cantidad) < 0 THEN
		cantidad_necesaria := new.cantidad - existencia_actual;
		existencia_general := (SELECT existencia FROM existencia_total WHERE id_producto = new.id_producto);
		IF (  existencia_general < cantidad_necesaria ) THEN
			RAISE EXCEPTION '[tbiVentasDetalles] Cantidad no disponible en Stock del Producto: % . Existencia TOTAL en todos los Depósitos: %', (SELECT nombre FROM productos WHERE id_producto = new.id_producto), existencia_general;
		ELSE	
			FOR recorrido IN
						 SELECT *
							FROM
								stocks
							WHERE 
								id_deposito > 1 AND id_producto = new.id_producto
							ORDER BY
								id_deposito
			LOOP
				IF ( recorrido.existencia > 0 AND cantidad_necesaria > 0 ) THEN
					IF ( recorrido.existencia >= cantidad_necesaria ) THEN
						INSERT INTO transferencias(id_dep_origen,id_dep_destino,id_producto,cantidad,observacion,fecha_hora)
							VALUES( recorrido.id_deposito,
								   1,
								   new.id_producto,
								   cantidad_necesaria,
								   'Transferencia Automatica por Venta',
								   current_timestamp);
						cantidad_necesaria := 0;
					ELSE
						INSERT INTO transferencias(id_dep_origen,id_dep_destino,id_producto,cantidad,observacion,fecha_hora)
							VALUES( recorrido.id_deposito,
								   1,
								   new.id_producto,
								   recorrido.existencia,
								   'Transferencia Automatica por Venta',
								   current_timestamp);
						cantidad_necesaria := cantidad_necesaria - recorrido.existencia;
					END IF;
				END IF;
			END LOOP;
		END IF;
	END IF;

	new.precio_total_venta := round(new.cantidad * new.precio_unitario_venta);
	
	RETURN new;
END;
$$ 
language plpgsql;

CREATE TRIGGER tbiVentasDetalles
BEFORE INSERT ON ventas_detalles
FOR EACH ROW EXECUTE PROCEDURE tbiVentasDetalles();
