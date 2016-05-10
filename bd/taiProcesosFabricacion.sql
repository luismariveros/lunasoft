DROP TRIGGER IF EXISTS taiProcesosFabricacion ON procesos_fabricacion;
DROP FUNCTION IF EXISTS taiProcesosFabricacion();

CREATE FUNCTION taiProcesosFabricacion() RETURNS TRIGGER AS $$
BEGIN
	-- disminuir en 1(UNO) la existencia del stocks en el deposito seleccionado
	UPDATE stocks
		SET existencia = existencia - 1
		WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito;
	
	RETURN new;
END;
$$ language plpgsql;

CREATE TRIGGER taiProcesosFabricacion
AFTER INSERT ON procesos_fabricacion
FOR EACH ROW 
EXECUTE PROCEDURE taiProcesosFabricacion();
