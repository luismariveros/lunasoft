DROP TRIGGER IF EXISTS tbiComprasDetalles ON compras_detalles;
DROP FUNCTION IF EXISTS tbiComprasDetalles();

CREATE FUNCTION tbiComprasDetalles() RETURNS TRIGGER AS $$
BEGIN
	IF NOT exists(SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito) THEN
		INSERT INTO stocks(id_producto, id_deposito, existencia) VALUES(new.id_producto, new.id_deposito, 0);
	END IF;
		
	RETURN new;
END;
$$ language plpgsql;


CREATE TRIGGER tbiComprasDetalles
BEFORE INSERT ON compras_detalles
FOR EACH ROW EXECUTE PROCEDURE tbiComprasDetalles();
