--
-- PostgreSQL database dump
--

-- Started on 2010-08-19 11:54:00

SET client_encoding = 'WIN1252';
SET standard_conforming_strings = off;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET escape_string_warning = off;

SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 1547 (class 1259 OID 42387)
-- Dependencies: 295 3
-- Name: procesos_fabricacion; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE procesos_fabricacion (
    id_proceso_fabricacion integer NOT NULL,
    id_deposito integer,
    id_producto integer,
    fecha_hora fecha_hora
);


ALTER TABLE public.procesos_fabricacion OWNER TO postgres;

--
-- TOC entry 1546 (class 1259 OID 42385)
-- Dependencies: 1547 3
-- Name: procesos_fabricacion_id_proceso_fabricacion_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE procesos_fabricacion_id_proceso_fabricacion_seq
    START WITH 1
    INCREMENT BY 1
    NO MAXVALUE
    NO MINVALUE
    CACHE 1;


ALTER TABLE public.procesos_fabricacion_id_proceso_fabricacion_seq OWNER TO postgres;

--
-- TOC entry 1837 (class 0 OID 0)
-- Dependencies: 1546
-- Name: procesos_fabricacion_id_proceso_fabricacion_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE procesos_fabricacion_id_proceso_fabricacion_seq OWNED BY procesos_fabricacion.id_proceso_fabricacion;


--
-- TOC entry 1829 (class 2604 OID 42390)
-- Dependencies: 1546 1547 1547
-- Name: id_proceso_fabricacion; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE procesos_fabricacion ALTER COLUMN id_proceso_fabricacion SET DEFAULT nextval('procesos_fabricacion_id_proceso_fabricacion_seq'::regclass);


--
-- TOC entry 1831 (class 2606 OID 42392)
-- Dependencies: 1547 1547
-- Name: pk_procesos_fabricacion; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY procesos_fabricacion
    ADD CONSTRAINT pk_procesos_fabricacion PRIMARY KEY (id_proceso_fabricacion);


--
-- TOC entry 1832 (class 1259 OID 42393)
-- Dependencies: 1547
-- Name: procesos_fabricacion_pk; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE UNIQUE INDEX procesos_fabricacion_pk ON procesos_fabricacion USING btree (id_proceso_fabricacion);


--
-- TOC entry 1833 (class 1259 OID 42394)
-- Dependencies: 1547 1547
-- Name: tiene_mp_fk; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX tiene_mp_fk ON procesos_fabricacion USING btree (id_deposito, id_producto);


--
-- TOC entry 1834 (class 2606 OID 42530)
-- Dependencies: 1552 1547 1547 1552
-- Name: fk_procesos_tiene_mp_stocks; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY procesos_fabricacion
    ADD CONSTRAINT fk_procesos_tiene_mp_stocks FOREIGN KEY (id_deposito, id_producto) REFERENCES stocks(id_deposito, id_producto) ON UPDATE RESTRICT ON DELETE RESTRICT;


-- Completed on 2010-08-19 11:54:01

--
-- PostgreSQL database dump complete
--

