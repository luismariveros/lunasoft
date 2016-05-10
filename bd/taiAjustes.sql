DROP TRIGGER IF EXISTS taiAjustes ON ajustes;
DROP FUNCTION IF EXISTS taiAjustes();

CREATE FUNCTION taiAjustes() RETURNS TRIGGER AS $$
BEGIN
	-- cambiar la existencia del stocks en el deposito seleccionado
	UPDATE stocks 
		SET existencia = existencia + new.cantidad
		WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito;
	
	RETURN new;
END;
$$ language plpgsql;

CREATE TRIGGER taiAjustes
AFTER INSERT ON ajustes
FOR EACH ROW 
EXECUTE PROCEDURE taiAjustes();
