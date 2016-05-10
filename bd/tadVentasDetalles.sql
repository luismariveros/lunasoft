DROP TRIGGER IF EXISTS tadVentasDetalles ON ventas_detalles;
DROP FUNCTION IF EXISTS tadVentasDetalles();

CREATE FUNCTION tadVentasDetalles() RETURNS TRIGGER AS $$
BEGIN
	-- cambiar la existencia del stocks en el deposito seleccionado
	UPDATE stocks 
		SET existencia = existencia + old.cantidad
		WHERE id_producto = old.id_producto AND id_deposito = old.id_deposito;
	
	RETURN old;
END;
$$ language plpgsql;

CREATE TRIGGER tadVentasDetalles
AFTER DELETE ON ventas_detalles
FOR EACH ROW 
EXECUTE PROCEDURE tadVentasDetalles();