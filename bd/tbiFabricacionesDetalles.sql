DROP TRIGGER IF EXISTS tbiFabricacionesDetalles ON fabricaciones_detalles;
DROP FUNCTION IF EXISTS tbiFabricacionesDetalles();

CREATE FUNCTION tbiFabricacionesDetalles() RETURNS TRIGGER AS $$
BEGIN
	IF NOT exists(select existencia from stocks where id_producto = new.id_producto and id_deposito = new.id_deposito) then
		INSERT INTO stocks(id_producto, id_deposito, existencia) VALUES(new.id_producto, new.id_deposito, 0);
	END IF;
		
	RETURN new;
END;
$$ language plpgsql;


CREATE TRIGGER tbiFabricacionesDetalles
BEFORE INSERT ON fabricaciones_detalles
FOR EACH ROW EXECUTE PROCEDURE tbiFabricacionesDetalles();