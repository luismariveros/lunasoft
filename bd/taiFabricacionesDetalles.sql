DROP TRIGGER IF EXISTS taiFabricacionesDetalles ON fabricaciones_detalles;
DROP FUNCTION IF EXISTS taiFabricacionesDetalles();

CREATE FUNCTION taiFabricacionesDetalles() RETURNS TRIGGER AS $$
BEGIN
	UPDATE stocks
		SET existencia = existencia + new.cantidad
		WHERE id_producto = new.id_producto and id_deposito = new.id_deposito;
	
	RETURN new;
END;
$$ language plpgsql;

CREATE TRIGGER taiFabricacionesDetalles
AFTER INSERT ON fabricaciones_detalles
FOR EACH ROW EXECUTE PROCEDURE taiFabricacionesDetalles();