DROP TRIGGER IF EXISTS taiTransferencias ON transferencias;
DROP FUNCTION IF EXISTS taiTransferencias();

CREATE FUNCTION taiTransferencias() RETURNS TRIGGER AS $$
BEGIN
	-- descontar el stocks del deposito origen
	UPDATE stocks 
		SET existencia = existencia - new.cantidad
		WHERE id_producto = new.id_producto AND id_deposito = new.id_dep_origen;
	
	-- aumentar el stock del deposito destino
	IF NOT EXISTS( SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_dep_destino ) THEN
		INSERT INTO stocks(id_deposito,id_producto,existencia) VALUES(new.id_dep_destino,new.id_producto,new.cantidad);
	ELSE
		UPDATE stocks
			SET existencia = existencia + new.cantidad
			WHERE id_producto = new.id_producto AND id_deposito = new.id_dep_destino;
	END IF;
	
	RETURN new;
END;
$$ language plpgsql;

CREATE TRIGGER taiTransferencias
AFTER INSERT ON transferencias
FOR EACH ROW 
EXECUTE PROCEDURE taiTransferencias();
