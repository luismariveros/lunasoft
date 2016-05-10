DROP TRIGGER IF EXISTS tadProcesosFabricacion ON procesos_fabricacion;
DROP FUNCTION IF EXISTS tadProcesosFabricacion();

CREATE FUNCTION tadProcesosFabricacion() RETURNS TRIGGER AS $$
BEGIN
	-- cambiar la existencia del stocks en el deposito seleccionado
	UPDATE stocks 
		SET existencia = existencia + 1
		WHERE id_producto = old.id_producto AND id_deposito = old.id_deposito;
	
	RETURN old;
END;
$$ language plpgsql;

CREATE TRIGGER tadProcesosFabricacion
AFTER DELETE ON procesos_fabricacion
FOR EACH ROW 
EXECUTE PROCEDURE tadProcesosFabricacion();