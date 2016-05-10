CREATE TABLE auditorias
(
  id_auditoria serial NOT NULL,
  fecha_hora fecha_hora,
  descripcion descripcion,
  id_usuario integer,
  CONSTRAINT pk_auditorias PRIMARY KEY (id_auditoria),
  CONSTRAINT fk_audorias_realizan_usuarios FOREIGN KEY (id_usuario)
      REFERENCES usuarios (id_usuario) MATCH SIMPLE
      ON UPDATE NO ACTION ON DELETE NO ACTION
)
WITH (OIDS=FALSE);
ALTER TABLE auditorias OWNER TO postgres;
