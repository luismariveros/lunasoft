DROP TRIGGER IF EXISTS taiAjustes ON ajustes;
DROP FUNCTION IF EXISTS taiAjustes();

CREATE FUNCTION taiAjustes() RETURNS TRIGGER AS $$
BEGIN
	-- cambiar la existencia del stocks en el deposito seleccionado
	UPDATE stocks 
		SET existencia = existencia + new.cantidad
		WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito;
	
	RETURN new;
END;
$$ language plpgsql;

CREATE TRIGGER taiAjustes
AFTER INSERT ON ajustes
FOR EACH ROW 
EXECUTE PROCEDURE taiAjustes();

DROP TRIGGER IF EXISTS taiComprasDetalles ON compras_detalles;
DROP FUNCTION IF EXISTS taiComprasDetalles();

CREATE FUNCTION taiComprasDetalles() RETURNS TRIGGER AS $$
BEGIN
	UPDATE stocks
		SET existencia = existencia + new.cantidad
		WHERE id_producto = new.id_producto and id_deposito = new.id_deposito;
	
	RETURN new;
END;
$$ language plpgsql;

CREATE TRIGGER taiComprasDetalles
AFTER INSERT ON compras_detalles
FOR EACH ROW EXECUTE PROCEDURE taiComprasDetalles();

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

DROP TRIGGER IF EXISTS taiTransferencias ON transferencias;
DROP FUNCTION IF EXISTS taiTransferencias();

CREATE FUNCTION taiTransferencias() RETURNS TRIGGER AS $$
BEGIN
	-- descontar el stocks del deposito origen
	UPDATE stocks 
		SET existencia = existencia - new.cantidad
		WHERE id_producto = new.id_producto AND id_deposito = new.id_dep_origen;
	
	-- aumentar el stock del deposito destino
	IF NOT EXISTS( SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_dep_destino ) THEN
		INSERT INTO stocks(id_deposito,id_producto,existencia) VALUES(new.id_dep_destino,new.id_producto,new.cantidad);
	ELSE
		UPDATE stocks
			SET existencia = existencia + new.cantidad
			WHERE id_producto = new.id_producto AND id_deposito = new.id_dep_destino;
	END IF;
	
	RETURN new;
END;
$$ language plpgsql;

CREATE TRIGGER taiTransferencias
AFTER INSERT ON transferencias
FOR EACH ROW 
EXECUTE PROCEDURE taiTransferencias();

DROP TRIGGER IF EXISTS taiVentasDetalles ON ventas_detalles;
DROP FUNCTION IF EXISTS taiVentasDetalles() CASCADE;

CREATE FUNCTION taiVentasDetalles() RETURNS TRIGGER AS $$
	
BEGIN
	UPDATE stocks
		SET existencia = existencia - new.cantidad
		WHERE id_producto = new.id_producto and id_deposito = new.id_deposito;

--	update ventas set monto_venta = monto_venta + new.precio_total_venta where id_venta = new.id_venta;

	RETURN new;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER tai_ventas_detalles
AFTER INSERT ON ventas_detalles
FOR EACH ROW EXECUTE PROCEDURE taiVentasDetalles();

DROP TRIGGER IF EXISTS tbiAjustes ON ajustes;
DROP FUNCTION IF EXISTS tbiAjustes();

CREATE FUNCTION tbiAjustes() RETURNS TRIGGER AS $$
DECLARE
	cantidad INTEGER;
BEGIN
	IF NOT EXISTS(SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito) THEN
		RAISE EXCEPTION 'No existe ese Producto en el Deposito seleccionado.';
	ELSE
		cantidad := (SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito);
	END IF;
	
	IF (cantidad < new.cantidad) THEN
		RAISE EXCEPTION 'No existe la cantidad suficiente en el Deposito seleccionado.';
	END IF;
	
	RETURN new;
END;
$$ language plpgsql;

CREATE TRIGGER tbiAjustes
BEFORE INSERT ON ajustes
FOR EACH ROW 
EXECUTE PROCEDURE tbiAjustes();

DROP TRIGGER IF EXISTS tbiComprasDetalles ON compras_detalles;
DROP FUNCTION IF EXISTS tbiComprasDetalles();

CREATE FUNCTION tbiComprasDetalles() RETURNS TRIGGER AS $$
BEGIN
	IF NOT exists(SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito) THEN
		INSERT INTO stocks(id_producto, id_deposito, existencia) VALUES(new.id_producto, new.id_deposito, 0);
	END IF;
		
	RETURN new;
END;
$$ language plpgsql;


CREATE TRIGGER tbiComprasDetalles
BEFORE INSERT ON compras_detalles
FOR EACH ROW EXECUTE PROCEDURE tbiComprasDetalles();

DROP TRIGGER IF EXISTS tbiFabricacionesDetalles ON fabricaciones_detalles;
DROP FUNCTION IF EXISTS tbiFabricacionesDetalles();

CREATE FUNCTION tbiFabricacionesDetalles() RETURNS TRIGGER AS $$
BEGIN
	IF NOT exists(select existencia from stocks where id_producto = new.id_producto and id_deposito = new.id_deposito) then
		INSERT INTO stocks(id_producto, id_deposito, existencia) VALUES(new.id_producto, new.id_deposito, 0);
	END IF;
		
	RETURN new;
END;
$$ language plpgsql;


CREATE TRIGGER tbiFabricacionesDetalles
BEFORE INSERT ON fabricaciones_detalles
FOR EACH ROW EXECUTE PROCEDURE tbiFabricacionesDetalles();

DROP TRIGGER IF EXISTS tbiProcesosFabricacion ON procesos_fabricacion;
DROP FUNCTION IF EXISTS tbiProcesosFabricacion();

CREATE FUNCTION tbiProcesosFabricacion() RETURNS TRIGGER AS $$
DECLARE
	cantidad INTEGER;
BEGIN
	IF NOT EXISTS(SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito) THEN
		RAISE EXCEPTION 'No existe ese Producto en el Deposito seleccionado.';
	ELSE
		cantidad := (SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito);
	END IF;
	
	IF (cantidad < 1) THEN
		RAISE EXCEPTION 'No existe la cantidad suficiente en el Deposito seleccionado para fabricar.';
	END IF;
	
	RETURN new;
END;
$$ language plpgsql;

CREATE TRIGGER tbiProcesosFabricacion
BEFORE INSERT ON procesos_fabricacion
FOR EACH ROW 
EXECUTE PROCEDURE tbiProcesosFabricacion();

DROP TRIGGER IF EXISTS tbiTransferencias ON transferencias;
DROP FUNCTION IF EXISTS tbiTransferencias();

CREATE FUNCTION tbiTransferencias() RETURNS TRIGGER AS $$
DECLARE
	cantidad INTEGER;
BEGIN
	IF NOT EXISTS(SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_dep_origen) THEN
		RAISE EXCEPTION 'No existe ese Producto en el Deposito seleccionado.';
	ELSE
		cantidad := (SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_dep_origen);
	END IF;
	
	IF( new.id_dep_origen = new.id_dep_destino) THEN
		RAISE EXCEPTION 'Deposito Origen igual a Destino';
	END IF;
	
	IF (cantidad < new.cantidad) THEN
		RAISE EXCEPTION 'No existe la cantidad suficiente en el Deposito seleccionado.';
	END IF;
	
	RETURN NEW;
END;
$$ language plpgsql;

CREATE TRIGGER tbiTransferencias
BEFORE INSERT ON transferencias
FOR EACH ROW 
EXECUTE PROCEDURE tbiTransferencias();

DROP TRIGGER IF EXISTS tbiVentasDetalles ON ventas_detalles;
DROP FUNCTION IF EXISTS tbiVentasDetalles() CASCADE;

CREATE FUNCTION tbiVentasDetalles() RETURNS TRIGGER AS $$
DECLARE
	exis integer;
BEGIN
	IF NOT exists(SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito) THEN
		RAISE EXCEPTION 'No hay el Producto en el Deposito por defecto';
	ELSE 
		exis := (SELECT existencia FROM stocks WHERE id_producto = new.id_producto AND id_deposito = new.id_deposito);

		IF (exis - new.cantidad) < 0 THEN
			RAISE EXCEPTION 'Cantidad no disponible del Producto. Existencia en Deposito por defecto: %', exis;
		END IF;
	END IF;

	new.precio_total_venta := (new.cantidad * new.precio_unitario_venta);
	
	RETURN new;
END;
$$ language plpgsql;

CREATE TRIGGER tbiVentasDetalles
BEFORE INSERT ON ventas_detalles
FOR EACH ROW EXECUTE PROCEDURE tbiVentasDetalles();
