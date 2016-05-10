-- crear el dominio CANTIDAD as REAL
-- volver a cargar los triggers

alter table stocks alter column existencia type cantidad;
alter table ajustes alter column cantidad type cantidad;
alter table compras_detalles alter column cantidad type cantidad;
alter table fabricaciones_detalles alter column cantidad type cantidad;
alter table productos alter column stock_minimo type cantidad;
alter table transferencias alter column cantidad type cantidad;
alter table ventas_detalles alter column cantidad type cantidad;

-- revisar los CHECK de cantidad >= 1, CAMBIAR por cantidad > 0
ALTER TABLE ventas_detalles ADD CONSTRAINT ckc_cantidad_ventas_d CHECK (cantidad::real > 0::double precision);
ALTER TABLE transferencias ADD CONSTRAINT ckc_cantidad_transfe CHECK (cantidad::real > 0::double precision);
ALTER TABLE fabricaciones_detalles ADD CONSTRAINT ckc_cantidad_fabric CHECK (cantidad::real > 0::double precision);
ALTER TABLE compras_detalles ADD CONSTRAINT ckc_cantidad_compras_d CHECK (cantidad::real > 0::double precision);

-- constraint para BORRAR VENTAS
ALTER TABLE ventas_detalles DROP CONSTRAINT fk_ventas_d_poseev_ventas;
ALTER TABLE ventas_detalles
  ADD CONSTRAINT fk_ventas_d_poseev_ventas FOREIGN KEY (id_venta)
      REFERENCES ventas (id_venta) MATCH SIMPLE
      ON UPDATE RESTRICT ON DELETE CASCADE;

-- constraint para BORRAR COMPRAS
ALTER TABLE compras_detalles DROP CONSTRAINT fk_compras__poseec_compras;
ALTER TABLE compras_detalles
  ADD CONSTRAINT fk_compras__poseec_compras FOREIGN KEY (id_compra)
      REFERENCES compras (id_compra) MATCH SIMPLE
      ON UPDATE RESTRICT ON DELETE CASCADE;
	  
-- constraint para BORRAR FABRICACIONES
ALTER TABLE fabricaciones_detalles DROP CONSTRAINT fk_fabricac_fabrica_procesos;
ALTER TABLE fabricaciones_detalles
  ADD CONSTRAINT fk_fabricac_fabrica_procesos FOREIGN KEY (id_proceso_fabricacion)
      REFERENCES procesos_fabricacion (id_proceso_fabricacion) MATCH SIMPLE
      ON UPDATE RESTRICT ON DELETE CASCADE;


