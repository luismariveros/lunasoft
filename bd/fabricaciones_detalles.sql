--
-- PostgreSQL database dump
--

-- Started on 2010-08-19 11:55:04

SET client_encoding = 'WIN1252';
SET standard_conforming_strings = off;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET escape_string_warning = off;

SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 1543 (class 1259 OID 42362)
-- Dependencies: 1830 1831 297 3
-- Name: fabricaciones_detalles; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE fabricaciones_detalles (
    id_fabricacion_detalle integer NOT NULL,
    id_proceso_fabricacion integer NOT NULL,
    id_deposito integer,
    id_producto integer,
    cantidad numero DEFAULT 1,
    CONSTRAINT ckc_cantidad_fabricac CHECK (((cantidad IS NULL) OR ((cantidad)::integer >= 1)))
);


ALTER TABLE public.fabricaciones_detalles OWNER TO postgres;

--
-- TOC entry 1542 (class 1259 OID 42360)
-- Dependencies: 1543 3
-- Name: fabricaciones_detalles_id_fabricacion_detalle_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE fabricaciones_detalles_id_fabricacion_detalle_seq
    START WITH 1
    INCREMENT BY 1
    NO MAXVALUE
    NO MINVALUE
    CACHE 1;


ALTER TABLE public.fabricaciones_detalles_id_fabricacion_detalle_seq OWNER TO postgres;

--
-- TOC entry 1841 (class 0 OID 0)
-- Dependencies: 1542
-- Name: fabricaciones_detalles_id_fabricacion_detalle_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE fabricaciones_detalles_id_fabricacion_detalle_seq OWNED BY fabricaciones_detalles.id_fabricacion_detalle;


--
-- TOC entry 1829 (class 2604 OID 42365)
-- Dependencies: 1542 1543 1543
-- Name: id_fabricacion_detalle; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE fabricaciones_detalles ALTER COLUMN id_fabricacion_detalle SET DEFAULT nextval('fabricaciones_detalles_id_fabricacion_detalle_seq'::regclass);


--
-- TOC entry 1835 (class 2606 OID 42369)
-- Dependencies: 1543 1543
-- Name: pk_fabricaciones_detalles; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY fabricaciones_detalles
    ADD CONSTRAINT pk_fabricaciones_detalles PRIMARY KEY (id_fabricacion_detalle);


--
-- TOC entry 1832 (class 1259 OID 42372)
-- Dependencies: 1543
-- Name: fabrica_fk; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX fabrica_fk ON fabricaciones_detalles USING btree (id_proceso_fabricacion);


--
-- TOC entry 1833 (class 1259 OID 42370)
-- Dependencies: 1543
-- Name: fabricaciones_detalles_pk; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE UNIQUE INDEX fabricaciones_detalles_pk ON fabricaciones_detalles USING btree (id_fabricacion_detalle);


--
-- TOC entry 1836 (class 1259 OID 42371)
-- Dependencies: 1543 1543
-- Name: se_fabrican_fk; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX se_fabrican_fk ON fabricaciones_detalles USING btree (id_deposito, id_producto);


--
-- TOC entry 1837 (class 2606 OID 42520)
-- Dependencies: 1543 1547
-- Name: fk_fabricac_fabrica_procesos; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY fabricaciones_detalles
    ADD CONSTRAINT fk_fabricac_fabrica_procesos FOREIGN KEY (id_proceso_fabricacion) REFERENCES procesos_fabricacion(id_proceso_fabricacion) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 1838 (class 2606 OID 42525)
-- Dependencies: 1543 1552 1543 1552
-- Name: fk_fabricac_se_fabric_stocks; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY fabricaciones_detalles
    ADD CONSTRAINT fk_fabricac_se_fabric_stocks FOREIGN KEY (id_deposito, id_producto) REFERENCES stocks(id_deposito, id_producto) ON UPDATE RESTRICT ON DELETE RESTRICT;


-- Completed on 2010-08-19 11:55:05

--
-- PostgreSQL database dump complete
--

