DROP TRIGGER IF EXISTS tbiProcesosFabricacion ON procesos_fabricacion;
DROP FUNCTION IF EXISTS tbiProcesosFabricacion();

CREATE FUNCTION tbiProcesosFabricacion() RETURNS TRIGGER AS $$
DECLARE
	cantidad REAL;
BEGIN
	IF NOT EXISTS(SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito) THEN
		RAISE EXCEPTION '[tbiProcesosFabricacion] No existe ese Producto en el Dep�sito seleccionado.';
	ELSE
		cantidad := (SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito);
	END IF;
	
	IF (cantidad <= 0) THEN
		RAISE EXCEPTION '[tbiProcesosFabricacion] No existe la cantidad suficiente en el Dep�sito seleccionado para fabricar.';
	END IF;
	
	RETURN new;
END;
$$ language plpgsql;

CREATE TRIGGER tbiProcesosFabricacion
BEFORE INSERT ON procesos_fabricacion
FOR EACH ROW 
EXECUTE PROCEDURE tbiProcesosFabricacion();
