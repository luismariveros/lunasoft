DROP TRIGGER IF EXISTS taiVentasDetalles ON ventas_detalles;
DROP FUNCTION IF EXISTS taiVentasDetalles() CASCADE;

CREATE FUNCTION taiVentasDetalles() RETURNS TRIGGER AS $$
	
BEGIN
	UPDATE stocks
		SET existencia = existencia - new.cantidad
		WHERE id_producto = new.id_producto and id_deposito = new.id_deposito;

--	update ventas set monto_venta = monto_venta + new.precio_total_venta where id_venta = new.id_venta;

	RETURN new;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER taiVentasDetalles
AFTER INSERT ON ventas_detalles
FOR EACH ROW EXECUTE PROCEDURE taiVentasDetalles();
