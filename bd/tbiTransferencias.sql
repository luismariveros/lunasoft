DROP TRIGGER IF EXISTS tbiTransferencias ON transferencias;
DROP FUNCTION IF EXISTS tbiTransferencias();

CREATE FUNCTION tbiTransferencias() RETURNS TRIGGER AS $$
DECLARE
	cantidad REAL;
BEGIN
	IF NOT EXISTS(SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_dep_origen) THEN
		RAISE EXCEPTION '[tbiTransferencias] No existe ese Producto en el Depósito seleccionado.';
	ELSE
		cantidad := (SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_dep_origen);
	END IF;
	
	IF( new.id_dep_origen = new.id_dep_destino) THEN
		RAISE EXCEPTION '[tbiTransferencias] Depósito Origen igual a Destino';
	END IF;
	
	IF (cantidad < new.cantidad) THEN
		RAISE EXCEPTION '[tbiTransferencias] No existe la cantidad suficiente en el Depósito seleccionado. % - %',cantidad, new.cantidad;
	END IF;
	
	RETURN NEW;
END;
$$ language plpgsql;

CREATE TRIGGER tbiTransferencias
BEFORE INSERT ON transferencias
FOR EACH ROW 
EXECUTE PROCEDURE tbiTransferencias();