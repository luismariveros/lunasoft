DROP TRIGGER IF EXISTS tadComprasDetalles ON compras_detalles;
DROP FUNCTION IF EXISTS tadComprasDetalles();

CREATE FUNCTION tadComprasDetalles() RETURNS TRIGGER AS $$
BEGIN
	-- cambiar la existencia del stocks en el deposito seleccionado
	UPDATE stocks 
		SET existencia = existencia - old.cantidad
		WHERE id_producto = old.id_producto AND id_deposito = old.id_deposito;
	
	RETURN old;
END;
$$ language plpgsql;

CREATE TRIGGER tadComprasDetalles
AFTER DELETE ON compras_detalles
FOR EACH ROW 
EXECUTE PROCEDURE tadComprasDetalles();