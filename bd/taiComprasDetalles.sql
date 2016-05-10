DROP TRIGGER IF EXISTS taiComprasDetalles ON compras_detalles;
DROP FUNCTION IF EXISTS taiComprasDetalles();

CREATE FUNCTION taiComprasDetalles() RETURNS TRIGGER AS $$
BEGIN
	UPDATE stocks
		SET existencia = existencia + new.cantidad
		WHERE id_producto = new.id_producto and id_deposito = new.id_deposito;
	
	RETURN new;
END;
$$ language plpgsql;

CREATE TRIGGER taiComprasDetalles
AFTER INSERT ON compras_detalles
FOR EACH ROW EXECUTE PROCEDURE taiComprasDetalles();
