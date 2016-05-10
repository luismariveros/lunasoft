DROP TRIGGER IF EXISTS tbuVentasDetalles ON ventas_detalles;
DROP FUNCTION IF EXISTS tbuVentasDetalles();

CREATE FUNCTION tbuVentasDetalles() RETURNS TRIGGER AS $$
DECLARE
	existencia_actual REAL;
BEGIN
	IF NOT EXISTS(SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito) THEN
		RAISE EXCEPTION '[tbuVentasDetalles] No hay ese producto en ese deposito';
	ELSE
		existencia_actual := (SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito);

		IF (existencia_actual - new.cantidad) < 0 THEN
			RAISE EXCEPTION '[tbuVentasDetalles] Cantidad no disponible en el Salón de Ventas del producto %. Realizar transferencias del producto.', (SELECT nombre FROM productos WHERE id_producto = new.id_producto);
		END IF;

		new.precio_total_venta := round(new.cantidad * new.precio_unitario_venta);
		
		RETURN new;
	END IF;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER tbuVentasDetalles
BEFORE UPDATE ON ventas_detalles
FOR EACH ROW EXECUTE PROCEDURE tbuVentasDetalles();