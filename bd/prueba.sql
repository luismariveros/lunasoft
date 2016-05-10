--
-- PostgreSQL database dump
--

-- Started on 2010-08-07 20:56:29

SET client_encoding = 'WIN1252';
SET standard_conforming_strings = off;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET escape_string_warning = off;

SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 1545 (class 1259 OID 27015)
-- Dependencies: 1824 3 300 297 305 305 300 260 258 300
-- Name: proveedores; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE proveedores (
    id_proveedor integer NOT NULL,
    nombre nombre NOT NULL,
    cedula_ruc cedula_ruc NOT NULL,
    direccion descripcion,
    mail nombre,
    telefono telefono,
    celular telefono,
    estado estado DEFAULT '1'::character varying NOT NULL,
    contacto nombre
);


ALTER TABLE public.proveedores OWNER TO postgres;

--
-- TOC entry 1544 (class 1259 OID 27013)
-- Dependencies: 3 1545
-- Name: proveedores_id_proveedor_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE proveedores_id_proveedor_seq
    INCREMENT BY 1
    NO MAXVALUE
    NO MINVALUE
    CACHE 1;


ALTER TABLE public.proveedores_id_proveedor_seq OWNER TO postgres;

--
-- TOC entry 1832 (class 0 OID 0)
-- Dependencies: 1544
-- Name: proveedores_id_proveedor_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE proveedores_id_proveedor_seq OWNED BY proveedores.id_proveedor;


--
-- TOC entry 1823 (class 2604 OID 27018)
-- Dependencies: 1544 1545 1545
-- Name: id_proveedor; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE proveedores ALTER COLUMN id_proveedor SET DEFAULT nextval('proveedores_id_proveedor_seq'::regclass);


--
-- TOC entry 1826 (class 2606 OID 27024)
-- Dependencies: 1545 1545
-- Name: pk_proveedores; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY proveedores
    ADD CONSTRAINT pk_proveedores PRIMARY KEY (id_proveedor);


--
-- TOC entry 1829 (class 2606 OID 27455)
-- Dependencies: 1545 1545
-- Name: unique_cedula_ruc; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY proveedores
    ADD CONSTRAINT unique_cedula_ruc UNIQUE (cedula_ruc);


--
-- TOC entry 1827 (class 1259 OID 27025)
-- Dependencies: 1545
-- Name: proveedores_pk; Type: INDEX; Schema: public; Owner: postgres; Tablespace: 
--

CREATE UNIQUE INDEX proveedores_pk ON proveedores USING btree (id_proveedor);


-- Completed on 2010-08-07 20:56:30

--
-- PostgreSQL database dump complete
--

