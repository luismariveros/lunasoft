DROP TRIGGER IF EXISTS tbiAjustes ON ajustes;
DROP FUNCTION IF EXISTS tbiAjustes();

CREATE FUNCTION tbiAjustes() RETURNS TRIGGER AS $$
DECLARE
	cantidad REAL;
BEGIN
	IF NOT EXISTS(SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito) THEN
		INSERT INTO stocks(id_producto, id_deposito, existencia) VALUES(new.id_producto, new.id_deposito, 0);
	ELSE
		cantidad := (SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito);
		IF (cantidad + new.cantidad < 0 ) THEN
			RAISE EXCEPTION '[tbiAjustes] Cantidad menor a 0 (cero).';
		END IF;
	END IF;
	
	
	RETURN new;
END;
$$ language plpgsql;

CREATE TRIGGER tbiAjustes
BEFORE INSERT ON ajustes
FOR EACH ROW 
EXECUTE PROCEDURE tbiAjustes();
