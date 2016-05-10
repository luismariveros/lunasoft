create function tbuventas_detalles() returns trigger AS $$
declare
	exis integer;
begin
	if NOT exists(select existencia from stocks where id_producto = new.id_producto and id_deposito = new.id_deposito) then
		raise exception 'No hay ese producto en ese deposito';
	else 
		exis := (select existencia from stocks where id_producto = new.id_producto and id_deposito = new.id_deposito);

		if ((exis+old.cantidad) - new.cantidad) < 0 then
			raise exception 'No hay esa cantidad disponible, Existencia: %', exis;
		end if;
	end if;


	new.precio_total_venta := (new.cantidad * new.precio_uni_venta);
	
	
	return new;
end;
$$ language plpgsql;


CREATE TRIGGER tbu_ventas_detalles
BEFORE UPDATE ON ventas_detalles
FOR EACH ROW EXECUTE PROCEDURE tbuventas_detalles();