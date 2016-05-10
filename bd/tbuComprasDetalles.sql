DROP TRIGGER IF EXISTS tbuComprasDetalles ON compras_detalles;
DROP FUNCTION IF EXISTS tbuComprasDetalles();

CREATE FUNCTION tbuComprasDetalles() RETURNS TRIGGER AS $$
DECLARE
	exis INTEGER;
BEGIN
	IF NOT EXISTS(SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito) THEN
		RAISE EXCEPTION '[tbuComprasDetalles] No hay ese producto en ese deposito';
	END IF;
	
	new.precio_total_compra := new.cantidad * new.precio_unitario_compra;
	
	RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER tbuComprasDetalles
BEFORE UPDATE ON compras_detalles
FOR EACH ROW EXECUTE PROCEDURE tbuComprasDetalles();