--
-- PostgreSQL database dump
--

-- Started on 2010-08-09 10:27:03

SET client_encoding = 'WIN1252';
SET standard_conforming_strings = off;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET escape_string_warning = off;

SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 1557 (class 1259 OID 27403)
-- Dependencies: 1825 1827 262 303 3 301
-- Name: transferencias; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE transferencias (
    id_transferencia integer NOT NULL,
    id_dep_origen integer NOT NULL,
    id_dep_destino integer NOT NULL,
    id_producto integer,
    cantidad numero DEFAULT 1 NOT NULL,
    fecha_hora fecha_hora,
    observacion descripcion,
    CONSTRAINT ckc_cantidad_transfer CHECK (((cantidad)::integer >= 1))
);


ALTER TABLE public.transferencias OWNER TO postgres;

--
-- TOC entry 1558 (class 1259 OID 27411)
-- Dependencies: 3 1557
-- Name: transferencias_id_transferencia_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE transferencias_id_transferencia_seq
    INCREMENT BY 1
    NO MAXVALUE
    NO MINVALUE
    CACHE 1;


ALTER TABLE public.transferencias_id_transferencia_seq OWNER TO postgres;

--
-- TOC entry 1841 (class 0 OID 0)
-- Dependencies: 1558
-- Name: transferencias_id_transferencia_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE transferencias_id_transferencia_seq OWNED BY transferencias.id_transferencia;


--
-- TOC entry 1826 (class 2604 OID 27413)
-- Dependencies: 1558 1557
-- Name: id_transferencia; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE transferencias ALTER COLUMN id_transferencia SET DEFAULT nextval('transferencias_id_transferencia_seq'::regclass);


--
-- TOC entry 1830 (class 2606 OID 27415)
-- Dependencies: 1557 1557
-- Name: pk_transferencias; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY transferencias
    ADD CONSTRAINT pk_transferencias PRIMARY KEY (id_transferencia);


--
-- TOC entry 1828 (class 1259 OID 27416)
-- Dependencies: 1557
-- Name: de_fk; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX de_fk ON transferencias USING btree (id_producto);


--
-- TOC entry 1831 (class 1259 OID 27417)
-- Dependencies: 1557
-- Name: se_transfiere_a_fk; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX se_transfiere_a_fk ON transferencias USING btree (id_dep_destino);


--
-- TOC entry 1832 (class 1259 OID 27418)
-- Dependencies: 1557
-- Name: se_transfiere_de_fk; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE INDEX se_transfiere_de_fk ON transferencias USING btree (id_dep_origen);


--
-- TOC entry 1833 (class 1259 OID 27419)
-- Dependencies: 1557
-- Name: transferencias_pk; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE UNIQUE INDEX transferencias_pk ON transferencias USING btree (id_transferencia);


--
-- TOC entry 1837 (class 2620 OID 27445)
-- Dependencies: 22 1557
-- Name: taitransferencias; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER taitransferencias
    AFTER INSERT ON transferencias
    FOR EACH ROW
    EXECUTE PROCEDURE taitransferencias();


--
-- TOC entry 1838 (class 2620 OID 27451)
-- Dependencies: 23 1557
-- Name: tbitransferencias; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER tbitransferencias
    BEFORE INSERT ON transferencias
    FOR EACH ROW
    EXECUTE PROCEDURE tbitransferencias();


--
-- TOC entry 1834 (class 2606 OID 27420)
-- Dependencies: 1557 1541
-- Name: fk_transfer_a_transf_deposito; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY transferencias
    ADD CONSTRAINT fk_transfer_a_transf_deposito FOREIGN KEY (id_dep_destino) REFERENCES depositos(id_deposito) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 1835 (class 2606 OID 27425)
-- Dependencies: 1557 1545
-- Name: fk_transfer_de_producto; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY transferencias
    ADD CONSTRAINT fk_transfer_de_producto FOREIGN KEY (id_producto) REFERENCES productos(id_producto) ON UPDATE RESTRICT ON DELETE RESTRICT;


--
-- TOC entry 1836 (class 2606 OID 27430)
-- Dependencies: 1541 1557
-- Name: fk_transfer_de_transf_deposito; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY transferencias
    ADD CONSTRAINT fk_transfer_de_transf_deposito FOREIGN KEY (id_dep_origen) REFERENCES depositos(id_deposito) ON UPDATE RESTRICT ON DELETE RESTRICT;


-- Completed on 2010-08-09 10:27:03

--
-- PostgreSQL database dump complete
--

