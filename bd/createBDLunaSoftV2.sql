/*==============================================================*/
/* DBMS name:      PostgreSQL 8                                 */
/* Created on:     05/08/2010 06:59:35 p.m.                     */
/*==============================================================*/


create sequence SEQUENCE_1;

/*==============================================================*/
/* Domain: CEDULA_RUC                                           */
/*==============================================================*/
create domain CEDULA_RUC as VARCHAR(25);

/*==============================================================*/
/* Domain: CODIGO                                               */
/*==============================================================*/
create domain CODIGO as VARCHAR(100);

/*==============================================================*/
/* Domain: DESCRIPCION                                          */
/*==============================================================*/
create domain DESCRIPCION as VARCHAR(300);

/*==============================================================*/
/* Domain: ESTADO                                               */
/*==============================================================*/
create domain ESTADO as VARCHAR(2);

/*==============================================================*/
/* Domain: FECHA                                                */
/*==============================================================*/
create domain FECHA as DATE;

/*==============================================================*/
/* Domain: FECHA_HORA                                           */
/*==============================================================*/
create domain FECHA_HORA as DATE;

/*==============================================================*/
/* Domain: NOMBRE                                               */
/*==============================================================*/
create domain NOMBRE as VARCHAR(80);

/*==============================================================*/
/* Domain: NUMERO                                               */
/*==============================================================*/
create domain NUMERO as INT4;

/*==============================================================*/
/* Domain: PASSWORD                                             */
/*==============================================================*/
create domain PASSWORD as VARCHAR(80);

/*==============================================================*/
/* Domain: PRECIO                                               */
/*==============================================================*/
create domain PRECIO as FLOAT8;

/*==============================================================*/
/* Domain: STOCK_MINIMO                                         */
/*==============================================================*/
create domain STOCK_MINIMO as INT4;

/*==============================================================*/
/* Domain: TELEFONO                                             */
/*==============================================================*/
create domain TELEFONO as VARCHAR(30);

/*==============================================================*/
/* Table: AJUSTES                                               */
/*==============================================================*/
create table AJUSTES (
   ID_AJUSTE            SERIAL               not null,
   ID_TIPO_AJUSTE       INT4                 not null,
   ID_DEPOSITO          INT4                 not null,
   ID_PRODUCTO          INT4                 not null,
   CANTIDAD             NUMERO               not null default 1 
      constraint CKC_CANTIDAD_AJUSTES check (CANTIDAD >= 1),
   DESCRIPCION          DESCRIPCION          not null,
   constraint PK_AJUSTES primary key (ID_AJUSTE)
);

/*==============================================================*/
/* Index: AJUSTES_PK                                            */
/*==============================================================*/
create unique index AJUSTES_PK on AJUSTES (
ID_AJUSTE
);

/*==============================================================*/
/* Index: SE_AJUSTAN_FK                                         */
/*==============================================================*/
create  index SE_AJUSTAN_FK on AJUSTES (
ID_DEPOSITO,
ID_PRODUCTO
);

/*==============================================================*/
/* Index: TIENE_UN_FK                                           */
/*==============================================================*/
create  index TIENE_UN_FK on AJUSTES (
ID_TIPO_AJUSTE
);

/*==============================================================*/
/* Table: CLIENTES                                              */
/*==============================================================*/
create table CLIENTES (
   ID_CLIENTE           SERIAL               not null,
   NOMBRE               NOMBRE               not null,
   CEDULA_RUC           CEDULA_RUC           not null,
   DIRECCION            DESCRIPCION          null,
   MAIL                 NOMBRE               null,
   TELEFONO             TELEFONO             null,
   CELULAR              TELEFONO             null,
   ESTADO               ESTADO               not null default '1',
   CONTACTO             NOMBRE               null,
   constraint PK_CLIENTES primary key (ID_CLIENTE)
);

/*==============================================================*/
/* Index: CLIENTES_PK                                           */
/*==============================================================*/
create unique index CLIENTES_PK on CLIENTES (
ID_CLIENTE
);

/*==============================================================*/
/* Table: COMPRAS                                               */
/*==============================================================*/
create table COMPRAS (
   ID_COMPRA            SERIAL               not null,
   ID_PROVEEDOR         INT4                 not null,
   FECHA                FECHA                not null,
   MONTO_COMPRA         PRECIO               not null,
   NUMERO_FACTURA       CODIGO               null,
   constraint PK_COMPRAS primary key (ID_COMPRA)
);

/*==============================================================*/
/* Index: COMPRAS_PK                                            */
/*==============================================================*/
create unique index COMPRAS_PK on COMPRAS (
ID_COMPRA
);

/*==============================================================*/
/* Index: RELATIONSHIP_10_FK                                    */
/*==============================================================*/
create  index RELATIONSHIP_10_FK on COMPRAS (
ID_PROVEEDOR
);

/*==============================================================*/
/* Table: COMPRAS_DETALLES                                      */
/*==============================================================*/
create table COMPRAS_DETALLES (
   ID_COMPRA_DETALLE    SERIAL               not null,
   ID_COMPRA            INT4                 not null,
   ID_DEPOSITO          INT4                 not null,
   ID_PRODUCTO          INT4                 not null,
   CANTIDAD             NUMERO               not null default 1 
      constraint CKC_CANTIDAD_COMPRAS_ check (CANTIDAD >= 1),
   PRECIO_UNITARIO_COMPRA PRECIO               not null,
   PRECIO_TOTAL_COMPRA  PRECIO               null,
   constraint PK_COMPRAS_DETALLES primary key (ID_COMPRA_DETALLE)
);

/*==============================================================*/
/* Index: DETALLES_COMPRAS_PK                                   */
/*==============================================================*/
create unique index DETALLES_COMPRAS_PK on COMPRAS_DETALLES (
ID_COMPRA_DETALLE
);

/*==============================================================*/
/* Index: POSEEC_FK                                             */
/*==============================================================*/
create  index POSEEC_FK on COMPRAS_DETALLES (
ID_COMPRA
);

/*==============================================================*/
/* Index: SE_COMPRA_FK                                          */
/*==============================================================*/
create  index SE_COMPRA_FK on COMPRAS_DETALLES (
ID_DEPOSITO,
ID_PRODUCTO
);

/*==============================================================*/
/* Table: DEPOSITOS                                             */
/*==============================================================*/
create table DEPOSITOS (
   ID_DEPOSITO          SERIAL               not null,
   NOMBRE               NOMBRE               not null,
   UBICACION            DESCRIPCION          null,
   OBSERVACION          DESCRIPCION          null,
   constraint PK_DEPOSITOS primary key (ID_DEPOSITO)
);

/*==============================================================*/
/* Index: DEPOSITOS_PK                                          */
/*==============================================================*/
create unique index DEPOSITOS_PK on DEPOSITOS (
ID_DEPOSITO
);

/*==============================================================*/
/* Table: FAMILIAS                                              */
/*==============================================================*/
create table FAMILIAS (
   ID_FAMILIA           SERIAL               not null,
   CODIGO               CODIGO               not null,
   DESCRIPCION          DESCRIPCION          not null,
   constraint PK_FAMILIAS primary key (ID_FAMILIA)
);

/*==============================================================*/
/* Index: FAMILIAS_PK                                           */
/*==============================================================*/
create unique index FAMILIAS_PK on FAMILIAS (
ID_FAMILIA
);

/*==============================================================*/
/* Table: PRODUCTOS                                             */
/*==============================================================*/
create table PRODUCTOS (
   ID_PRODUCTO          SERIAL               not null,
   ID_FAMILIA           INT4                 not null,
   NOMBRE               NOMBRE               not null,
   CODIGO               CODIGO               null,
   STOCK_MINIMO         STOCK_MINIMO         null default 0,
   UNIDAD               NOMBRE               null,
   PRECIO_PROMEDIO_COMPRA PRECIO               null,
   PRECIO_VENTA         PRECIO               null,
   OBSERVACION          DESCRIPCION          null,
   constraint PK_PRODUCTOS primary key (ID_PRODUCTO)
);

/*==============================================================*/
/* Index: PRODUCTOS_PK                                          */
/*==============================================================*/
create unique index PRODUCTOS_PK on PRODUCTOS (
ID_PRODUCTO
);

/*==============================================================*/
/* Index: PERTENECE_FK                                          */
/*==============================================================*/
create  index PERTENECE_FK on PRODUCTOS (
ID_FAMILIA
);

/*==============================================================*/
/* Table: PROVEEDORES                                           */
/*==============================================================*/
create table PROVEEDORES (
   ID_PROVEEDOR         SERIAL               not null,
   NOMBRE               NOMBRE               not null,
   CEDULA_RUC           CEDULA_RUC           not null,
   DIRECCION            DESCRIPCION          null,
   MAIL                 NOMBRE               null,
   TELEFONO             TELEFONO             null,
   CELULAR              TELEFONO             null,
   ESTADO               ESTADO               not null default '1',
   CONTACTO             NOMBRE               null,
   constraint PK_PROVEEDORES primary key (ID_PROVEEDOR)
);

/*==============================================================*/
/* Index: PROVEEDORES_PK                                        */
/*==============================================================*/
create unique index PROVEEDORES_PK on PROVEEDORES (
ID_PROVEEDOR
);

/*==============================================================*/
/* Table: STOCKS                                                */
/*==============================================================*/
create table STOCKS (
   ID_DEPOSITO          INT4                 not null,
   ID_PRODUCTO          INT4                 not null,
   EXISTENCIA           NUMERO               null,
   constraint PK_STOCKS primary key (ID_DEPOSITO, ID_PRODUCTO)
);

/*==============================================================*/
/* Index: STOCKS_PK                                             */
/*==============================================================*/
create unique index STOCKS_PK on STOCKS (
ID_DEPOSITO,
ID_PRODUCTO
);

/*==============================================================*/
/* Index: ESTA_EN_FK                                            */
/*==============================================================*/
create  index ESTA_EN_FK on STOCKS (
ID_DEPOSITO
);

/*==============================================================*/
/* Index: TIENE_FK                                              */
/*==============================================================*/
create  index TIENE_FK on STOCKS (
ID_PRODUCTO
);

/*==============================================================*/
/* Table: TIPOS_AJUSTES                                         */
/*==============================================================*/
create table TIPOS_AJUSTES (
   ID_TIPO_AJUSTE       SERIAL               not null,
   NOMBRE               NOMBRE               not null,
   constraint PK_TIPOS_AJUSTES primary key (ID_TIPO_AJUSTE)
);

/*==============================================================*/
/* Index: TIPOS_AJUSTES_PK                                      */
/*==============================================================*/
create unique index TIPOS_AJUSTES_PK on TIPOS_AJUSTES (
ID_TIPO_AJUSTE
);

/*==============================================================*/
/* Table: TRANSFERENCIAS                                        */
/*==============================================================*/
create table TRANSFERENCIAS (
   ID_TRANSFERENCIA     SERIAL               not null,
   ID_DEP_ORIGEN        INT4                 not null,
   ID_DEP_DESTINO       INT4                 not null,
   ID_PRODUCTO          INT4                 null,
   CANTIDAD             NUMERO               not null default 1 
      constraint CKC_CANTIDAD_TRANSFER check (CANTIDAD >= 1),
   FECHA_HORA           FECHA_HORA           not null,
   OBSERVACION          DESCRIPCION          null,
   constraint PK_TRANSFERENCIAS primary key (ID_TRANSFERENCIA)
);

/*==============================================================*/
/* Index: TRANSFERENCIAS_PK                                     */
/*==============================================================*/
create unique index TRANSFERENCIAS_PK on TRANSFERENCIAS (
ID_TRANSFERENCIA
);

/*==============================================================*/
/* Index: SE_TRANSFIERE_DE_FK                                   */
/*==============================================================*/
create  index SE_TRANSFIERE_DE_FK on TRANSFERENCIAS (
ID_DEP_ORIGEN
);

/*==============================================================*/
/* Index: SE_TRANSFIERE_A_FK                                    */
/*==============================================================*/
create  index SE_TRANSFIERE_A_FK on TRANSFERENCIAS (
ID_DEP_DESTINO
);

/*==============================================================*/
/* Index: DE_FK                                                 */
/*==============================================================*/
create  index DE_FK on TRANSFERENCIAS (
ID_PRODUCTO
);

/*==============================================================*/
/* Table: USUARIOS                                              */
/*==============================================================*/
create table USUARIOS (
   ID_USUARIO           SERIAL               not null,
   NOMBRE               NOMBRE               not null,
   PASSWORD             CODIGO               not null,
   NIVEL                NUMERO               null,
   constraint PK_USUARIOS primary key (ID_USUARIO)
);

/*==============================================================*/
/* Index: USUARIOS_PK                                           */
/*==============================================================*/
create unique index USUARIOS_PK on USUARIOS (
ID_USUARIO
);

/*==============================================================*/
/* Table: VENTAS                                                */
/*==============================================================*/
create table VENTAS (
   ID_VENTA             SERIAL               not null,
   ID_CLIENTE           INT4                 not null,
   FECHA_HORA           FECHA_HORA           null,
   MONTO_VENTA          PRECIO               null,
   constraint PK_VENTAS primary key (ID_VENTA)
);

/*==============================================================*/
/* Index: VENTAS_PK                                             */
/*==============================================================*/
create unique index VENTAS_PK on VENTAS (
ID_VENTA
);

/*==============================================================*/
/* Index: SE_VENDEN_A_FK                                        */
/*==============================================================*/
create  index SE_VENDEN_A_FK on VENTAS (
ID_CLIENTE
);

/*==============================================================*/
/* Table: VENTAS_DETALLES                                       */
/*==============================================================*/
create table VENTAS_DETALLES (
   ID_VENTA_DETALLE     SERIAL               not null,
   ID_VENTA             INT4                 not null,
   ID_DEPOSITO          INT4                 not null,
   ID_PRODUCTO          INT4                 not null,
   CANTIDAD             NUMERO               not null default 1 
      constraint CKC_CANTIDAD_VENTAS_D check (CANTIDAD >= 1),
   PRECIO_UNITARIO_VENTA PRECIO               not null,
   PRECIO_TOTAL_VENTA   PRECIO               null,
   constraint PK_VENTAS_DETALLES primary key (ID_VENTA_DETALLE)
);

/*==============================================================*/
/* Index: DETALLES_VENTAS_PK                                    */
/*==============================================================*/
create unique index DETALLES_VENTAS_PK on VENTAS_DETALLES (
ID_VENTA_DETALLE
);

/*==============================================================*/
/* Index: POSEEV_FK                                             */
/*==============================================================*/
create  index POSEEV_FK on VENTAS_DETALLES (
ID_VENTA
);

/*==============================================================*/
/* Index: SE_VENDEN_FK                                          */
/*==============================================================*/
create  index SE_VENDEN_FK on VENTAS_DETALLES (
ID_DEPOSITO,
ID_PRODUCTO
);

alter table AJUSTES
   add constraint FK_AJUSTES_SE_AJUSTA_STOCKS foreign key (ID_DEPOSITO, ID_PRODUCTO)
      references STOCKS (ID_DEPOSITO, ID_PRODUCTO)
      on delete restrict on update restrict;

alter table AJUSTES
   add constraint FK_AJUSTES_TIENE_UN_TIPOS_AJ foreign key (ID_TIPO_AJUSTE)
      references TIPOS_AJUSTES (ID_TIPO_AJUSTE)
      on delete restrict on update restrict;

alter table COMPRAS
   add constraint FK_COMPRAS_SE_COMPRA_PROVEEDO foreign key (ID_PROVEEDOR)
      references PROVEEDORES (ID_PROVEEDOR)
      on delete restrict on update restrict;

alter table COMPRAS_DETALLES
   add constraint FK_COMPRAS__POSEEC_COMPRAS foreign key (ID_COMPRA)
      references COMPRAS (ID_COMPRA)
      on delete restrict on update restrict;

alter table COMPRAS_DETALLES
   add constraint FK_COMPRAS__SE_COMPRA_STOCKS foreign key (ID_DEPOSITO, ID_PRODUCTO)
      references STOCKS (ID_DEPOSITO, ID_PRODUCTO)
      on delete restrict on update restrict;

alter table PRODUCTOS
   add constraint FK_PRODUCTO_PERTENECE_FAMILIAS foreign key (ID_FAMILIA)
      references FAMILIAS (ID_FAMILIA)
      on delete restrict on update restrict;

alter table STOCKS
   add constraint FK_STOCKS_ESTA_EN_DEPOSITO foreign key (ID_DEPOSITO)
      references DEPOSITOS (ID_DEPOSITO)
      on delete restrict on update restrict;

alter table STOCKS
   add constraint FK_STOCKS_TIENE_PRODUCTO foreign key (ID_PRODUCTO)
      references PRODUCTOS (ID_PRODUCTO)
      on delete restrict on update restrict;

alter table TRANSFERENCIAS
   add constraint FK_TRANSFER_DE_PRODUCTO foreign key (ID_PRODUCTO)
      references PRODUCTOS (ID_PRODUCTO)
      on delete restrict on update restrict;

alter table TRANSFERENCIAS
   add constraint FK_TRANSFER_A_TRANSF_DEPOSITO foreign key (ID_DEP_DESTINO)
      references DEPOSITOS (ID_DEPOSITO)
      on delete restrict on update restrict;

alter table TRANSFERENCIAS
   add constraint FK_TRANSFER_DE_TRANSF_DEPOSITO foreign key (ID_DEP_ORIGEN)
      references DEPOSITOS (ID_DEPOSITO)
      on delete restrict on update restrict;

alter table VENTAS
   add constraint FK_VENTAS_SE_VENDEN_CLIENTES foreign key (ID_CLIENTE)
      references CLIENTES (ID_CLIENTE)
      on delete restrict on update restrict;

alter table VENTAS_DETALLES
   add constraint FK_VENTAS_D_POSEEV_VENTAS foreign key (ID_VENTA)
      references VENTAS (ID_VENTA)
      on delete restrict on update restrict;

alter table VENTAS_DETALLES
   add constraint FK_VENTAS_D_SE_VENDEN_STOCKS foreign key (ID_DEPOSITO, ID_PRODUCTO)
      references STOCKS (ID_DEPOSITO, ID_PRODUCTO)
      on delete restrict on update restrict;

