DROP TRIGGER IF EXISTS tbiVentasDetalles ON ventas_detalles;
DROP FUNCTION IF EXISTS tbiVentasDetalles() CASCADE;

CREATE OR REPLACE FUNCTION tbiVentasDetalles() RETURNS TRIGGER AS 
$$
DECLARE
	existencia_actual REAL;
BEGIN
	IF NOT exists(SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito) THEN
		INSERT INTO stocks(id_deposito,id_producto,existencia) VALUES(new.id_deposito,new.id_producto,0);
	END IF;
	 
	existencia_actual := (SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito);

	IF (existencia_actual - new.cantidad) < 0 THEN
		RAISE EXCEPTION '[tbiVentasDetalles] Cantidad no disponible en el Salón de Ventas del producto %. Realizar transferencias del producto.', (SELECT nombre FROM productos WHERE id_producto = new.id_producto);
	END IF;
	
	new.precio_total_venta := round(new.cantidad * new.precio_unitario_venta);
	
	RETURN new;
END;
$$ 
language plpgsql;

CREATE TRIGGER tbiVentasDetalles
BEFORE INSERT ON ventas_detalles
FOR EACH ROW EXECUTE PROCEDURE tbiVentasDetalles();
