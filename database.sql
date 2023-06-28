/*bd_biblioteca

tbl_usuario
  id_usuario
  nombre_completo_usuario
  carnet_usuario
  correo_usuario
  celular_usuario
  estado_usuario

tbl_libro
  id_libro
  titulo_libro
  autor_libro
  anio_libro
  estado_libro

tbl_prestamo
  id_prestamo
  id_usuario_prestamo
  id_libro_prestamo
  fecha_retiro
  fecha_devolucion
  estado_prestamo*/



/*CREATE TABLE USUARIO
(
  "ID"                          INT IDENTITY(1,1),
  "NOMBRE_COMPLETO"             VARCHAR(50) NOT NULL,
  "CARNET"			            VARCHAR(10) NOT NULL,
  "CORREO"			            VARCHAR(50) NOT NULL,
  "CELULAR"			            VARCHAR(50) NOT NULL,
  "FECHA_REGISTRO"              DATETIME DEFAULT getdate() NOT NULL,
  "ESTADO_REGISTRO"				INT DEFAULT 1 NOT NULL, 
  CONSTRAINT USUARIO_PK			PRIMARY KEY (ID)
);*/


/*CREATE TABLE LIBRO
(
  "ID"                          INT IDENTITY(1,1),
  "TITULO"				        VARCHAR(50) NOT NULL,
  "AUTOR"			            VARCHAR(30) NOT NULL,
  "ANIO"			            VARCHAR(5) NOT NULL,
  "FECHA_REGISTRO"              DATETIME DEFAULT getdate() NOT NULL,
  "ESTADO_REGISTRO"				INT DEFAULT 1 NOT NULL, 
  CONSTRAINT LIBRO_PK			PRIMARY KEY (ID)
);*/

/*CREATE TABLE PRESTAMO
(
  "ID"                          INT IDENTITY(1,1),
  "ID_USUARIO"				    INT NOT NULL,
  "ID_LIBRO"			        INT NOT NULL,
  "FECHA_RETIRO"				DATE NOT NULL,
  "FECHA_DEVOLUCION"            DATE NOT NULL,
  "FECHA_REGISTRO"              DATETIME DEFAULT getdate() NOT NULL,
  "ESTADO_REGISTRO"				INT DEFAULT 1 NOT NULL, 
  CONSTRAINT PRESTAMO_PK		PRIMARY KEY (ID)
);*/

/*ALTER TABLE PRESTAMO
  ADD CONSTRAINT "FK_PRESTAMO_TO_USUARIO" 
  FOREIGN KEY("ID_USUARIO")
  REFERENCES USUARIO("ID");*/


/*ALTER TABLE PRESTAMO
  ADD CONSTRAINT "FK_PRESTAMO_TO_LIBRO" 
  FOREIGN KEY("ID_LIBRO")
  REFERENCES LIBRO("ID");*/


/*select * from USUARIO*/
/*select * from LIBRO*/
/*select * from PRESTAMO*/


/*DROP TABLE USUARIO;*/
/*DROP TABLE LIBRO;*/
/*DROP TABLE PRESTAMO;*/

/*UPDATE USUARIO SET ESTADO_REGISTRO = 1*/
/*UPDATE LIBRO SET ESTADO_REGISTRO = 1*/
/*UPDATE PRESTAMO SET ESTADO_REGISTRO = 0*/






/*INSERT INTO [dbo].[LIBRO]([TITULO], [AUTOR], [ANIO]) VALUES ('La Divina comedia', 'Dante Alighieri', '1472') 
INSERT INTO [dbo].[LIBRO]([TITULO], [AUTOR], [ANIO]) VALUES ('El Alquimista', 'Paulo Coelho', '1988') 
INSERT INTO [dbo].[LIBRO]([TITULO], [AUTOR], [ANIO]) VALUES ('El Código da Vinci', 'Dan Brown', '2003')*/


/*INSERT INTO [dbo].[USUARIO]([NOMBRE_COMPLETO], [CARNET], [CORREO], [CELULAR]) VALUES ('Alejandro Gonzales Viera', '11325913', 'alejandro.g280211@gmail.com', '78138077')
INSERT INTO [dbo].[USUARIO]([NOMBRE_COMPLETO], [CARNET], [CORREO], [CELULAR]) VALUES ('Vanessa Florez Poma', '8989990', 'vanessa_fdg_sm@hotmail.com', '76645292')*/


/*INSERT INTO [dbo].[PRESTAMO]([ID_USUARIO], [ID_LIBRO], [FECHA_RETIRO], [FECHA_DEVOLUCION]) VALUES (1, 3, '2023-06-23', '2023-06-26')*/