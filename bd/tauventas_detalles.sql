create function tauventas_detalles() returns trigger AS $$
	
begin

	update stocks
	set existencia = existencia + old.cantidad
	where id_producto = old.id_producto and id_deposito = old.id_deposito;


	update ventas
	set monto_venta = monto_venta - old.precio_total_venta
	where id_venta = old.id_venta;

	
	update stocks
	set existencia = existencia - new.cantidad
	where id_producto = new.id_producto and id_deposito = new.id_deposito;


	update ventas
	set monto_venta = monto_venta + new.precio_total_venta
	where id_venta = new.id_venta;

	return new;
end;
$$ language plpgsql;


CREATE TRIGGER tau_ventas_detalles
AFTER UPDATE ON ventas_detalles
FOR EACH ROW EXECUTE PROCEDURE tauventas_detalles();