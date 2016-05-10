DROP TRIGGER IF EXISTS tauVentasDetalles ON ventas_detalles;
DROP FUNCTION IF EXISTS tauVentasDetalles();

CREATE FUNCTION tauVentasDetalles() RETURNS TRIGGER AS $$
BEGIN
	UPDATE stocks
		SET existencia = existencia + old.cantidad - new.cantidad
		WHERE id_producto = old.id_producto and id_deposito = old.id_deposito;
		
	RETURN new;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER tauVentasDetalles
AFTER UPDATE ON ventas_detalles
FOR EACH ROW EXECUTE PROCEDURE tauVentasDetalles();