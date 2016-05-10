-- View: historial_x_producto

-- DROP VIEW historial_x_producto;

CREATE OR REPLACE VIEW historial_x_producto AS 
((( SELECT 'Compras' AS tipo, c.id_compra AS id, c.fecha, cd.cantidad, cd.precio_unitario_compra AS precio, cd.id_producto
   FROM compras c
   JOIN compras_detalles cd USING (id_compra)
UNION ALL 
 SELECT 'Ventas' AS tipo, v.id_venta AS id, v.fecha_hora AS fecha, vd.cantidad, vd.precio_unitario_venta AS precio, vd.id_producto
   FROM ventas v
   JOIN ventas_detalles vd USING (id_venta))
UNION ALL 
 SELECT 'Ajustes:'::text || ta.nombre::text AS tipo, a.id_ajuste AS id, a.fecha, a.cantidad, 0 AS precio, a.id_producto
   FROM ajustes a
   JOIN tipos_ajustes ta USING (id_tipo_ajuste))
UNION ALL 
 SELECT 'Fabricaciones:Materia Prima' AS tipo, pf.id_proceso_fabricacion AS id, pf.fecha_hora AS fecha, 1 AS cantidad, 0 AS precio, pf.id_producto
   FROM procesos_fabricacion pf)
UNION ALL 
 SELECT 'Fabricaciones:Producto Terminado' AS tipo, pf.id_proceso_fabricacion AS id, pf.fecha_hora AS fecha, fd.cantidad, 0 AS precio, fd.id_producto
   FROM procesos_fabricacion pf
   JOIN fabricaciones_detalles fd USING (id_proceso_fabricacion);

ALTER TABLE historial_x_producto OWNER TO postgres;

