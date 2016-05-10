DROP TRIGGER IF EXISTS tadFabricacionesDetalles ON fabricaciones_detalles;
DROP FUNCTION IF EXISTS tadFabricacionesDetalles();

CREATE FUNCTION tadFabricacionesDetalles() RETURNS TRIGGER AS $$
BEGIN
	-- cambiar la existencia del stocks en el deposito seleccionado
	UPDATE stocks 
		SET existencia = existencia - old.cantidad
		WHERE id_producto = old.id_producto AND id_deposito = old.id_deposito;
	
	RETURN old;
END;
$$ language plpgsql;

CREATE TRIGGER tadFabricacionesDetalles
AFTER DELETE ON fabricaciones_detalles
FOR EACH ROW 
EXECUTE PROCEDURE tadFabricacionesDetalles();