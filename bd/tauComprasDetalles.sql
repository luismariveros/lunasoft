DROP TRIGGER IF EXISTS tauComprasDetalles ON compras_detalles;
DROP FUNCTION IF EXISTS tauComprasDetalles();

CREATE FUNCTION tauComprasDetalles() RETURNS TRIGGER AS $$
BEGIN
	UPDATE stocks
		SET existencia = existencia - old.cantidad + new.cantidad
		WHERE id_producto = old.id_producto and id_deposito = old.id_deposito;
	
	RETURN new;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER tauComprasDetalles
AFTER UPDATE ON compras_detalles
FOR EACH ROW EXECUTE PROCEDURE tauComprasDetalles();