
USE [GD1C2014]

IF EXISTS (SELECT * FROM sys.schemas WHERE name = N'BE_SHARPS')
DROP SCHEMA [BE_SHARPS]
GO

CREATE SCHEMA BE_SHARPS AUTHORIZATION gd
GO
/* **************************************** FUNCIONES **************************************** */


GO

IF OBJECT_ID('BE_SHARPS.obtenerIDrubro','FUNCTION') IS NOT NULL
BEGIN
	DROP FUNCTION BE_SHARPS.obtenerIDrubro
	PRINT 'Función obtenerIDrubro droppeada.'
END ELSE PRINT 'La función obtenerIDrubro no fue creada aún.'

GO

CREATE FUNCTION BE_SHARPS.obtenerIDrubro(@rubro nvarchar(255))
RETURNS numeric(18,0)
AS
BEGIN
	declare @id numeric(18,0) = (SELECT rubro_id FROM BE_SHARPS.Rubros WHERE rubro_desc = @rubro)
	if @id is null
	begin
		set @id = 9999999
	end		
	return @id
END

/*
PRUEBA
PRINT BE_SHARPS.obtenerIDrubro('Computacdión') 
*/

GO

IF OBJECT_ID('BE_SHARPS.obtenerIDusuario','FUNCTION') IS NOT NULL 
BEGIN
	DROP FUNCTION BE_SHARPS.obtenerIDusuario
	PRINT 'Función obtenerIDusuario droppeada.'
END ELSE PRINT 'La función obtenerIDusuario no fue creada aún.'

GO

CREATE FUNCTION BE_SHARPS.obtenerIDusuario (@cli_doc_tipo nvarchar(10), @cli_doc_nro numeric(18,0), 
								  @cuit_empresa nvarchar(50)) RETURNS numeric(18,0)
AS
BEGIN
	DECLARE @usuario_id numeric(18,0)
	IF @cli_doc_nro IS NULL
	BEGIN
		SET @usuario_id = (SELECT usuario_id FROM BE_SHARPS.Usuarios, BE_SHARPS.Empresas
							WHERE u_emp_id=emp_id AND emp_cuit=@cuit_empresa)		
	END ELSE
	BEGIN
		SET @usuario_id = (SELECT usuario_id FROM BE_SHARPS.Usuarios, BE_SHARPS.Clientes
							WHERE u_cli_id=cli_id AND cli_doc_nro=@cli_doc_nro AND cli_doc_tipo=@cli_doc_tipo)
	END
	RETURN @usuario_id
END

/* 
PRUEBA
SELECT distinct Publicacion_Cod, BE_SHARPS.obtenerIDusuario('DNI',Publ_Cli_Dni,Publ_Empresa_Cuit) as usurio_id 
	from GD1C2014.gd_esquema.Maestra
	where Publicacion_Cod is not null
*/
/*
GO
--YA NO SE USA
IF OBJECT_ID('BE_SHARPS.obtenerIDcliente','FUNCTION') IS NOT NULL
BEGIN 
	DROP FUNCTION BE_SHARPS.obtenerIDcliente
	PRINT 'Funcion obtenerIDusuario droppeada.'
END ELSE PRINT 'La función obtenerIDcliente no fue creada aún.'
	
GO

CREATE FUNCTION BE_SHARPS.obtenerIDcliente (@tipo_doc nvarchar(10), @nro_doc numeric(18,0)) RETURNS numeric(18,0)
AS
BEGIN
	DECLARE @cliente_id numeric(18,0) = (SELECT cli_id FROM BE_SHARPS.Clientes WHERE cli_doc_tipo=@tipo_doc AND
										 cli_doc_nro=@nro_doc)
	RETURN @cliente_id
END
*/

GO

IF OBJECT_ID('BE_SHARPS.generarUsuario','FUNCTION') is not null
begin
	drop function BE_SHARPS.generarUsuario
	print 'Se borro la funcion generarUsuario'
end else print 'Aún no se creo la funcion generarUsuario'

GO

CREATE FUNCTION BE_SHARPS.generarUsuario (@usuario_id numeric(18,0),@usuario_tipo char(1)) RETURNS nvarchar(50)
AS
BEGIN
	return 'be_sharps_'+@usuario_tipo+CONVERT(nvarchar(50),@usuario_id)
END




/* **************************************** CREACIÓN DE TABLAS **************************************** */

/* TABLA Clientes */
GO

IF OBJECT_ID('BE_SHARPS.crear_tablas','P') IS NOT NULL
BEGIN 
	DROP PROC BE_SHARPS.crear_tablas
	PRINT 'Procedimiento crear_tablas droppeada.'
END ELSE PRINT 'El procedimiento crear_tablas no fue creado aún.'

GO

CREATE PROC BE_SHARPS.crear_tablas
AS
BEGIN

CREATE TABLE BE_SHARPS.Clientes (cli_id numeric(18,0) PRIMARY KEY IDENTITY(1,1),
					   cli_doc_tipo nvarchar(10) DEFAULT 'DNI',
					   cli_doc_nro numeric(18,0) NOT NULL, 
					   cli_apellido nvarchar(255),
					   cli_nombre nvarchar(255),
					   cli_fec_nac datetime,
					   cli_mail nvarchar(255),
					   cli_telefono numeric(18,0) UNIQUE,
					   cli_dom_calle nvarchar(255),
					   cli_nro_calle numeric(18,0),
					   cli_piso numeric(18,0),
					   cli_dpto nvarchar(50),
					   cli_localidad nvarchar(50),
					   cli_cp nvarchar(50))


ALTER TABLE BE_SHARPS.Clientes ADD CONSTRAINT cU_doc UNIQUE (cli_doc_tipo,cli_doc_nro)				   
/* TABLA Empresas */					   
				   
CREATE TABLE BE_SHARPS.Empresas (emp_id numeric(18,0) PRIMARY KEY IDENTITY(1,1),
					   emp_rsocial nvarchar(255) UNIQUE NOT NULL,
					   emp_cuit nvarchar(100) UNIQUE NOT NULL,
					   emp_fec_creacion datetime,
					   emp_mail nvarchar(50),
					   emp_telefono numeric(18,0),
					   emp_dom_calle nvarchar(100),
					   emp_nro_calle numeric(18,0),
					   emp_piso numeric(18,0),
					   emp_depto nvarchar(50),	
					   emp_localidad nvarchar(50),				   
					   emp_cp numeric(18,0),
					   emp_ciudad nvarchar(50),
					   emp_contacto nvarchar(50))

					   
/* TABLA Usuarios */

CREATE TABLE BE_SHARPS.Usuarios (usuario_id numeric(18,0) PRIMARY KEY IDENTITY(1,1),
					   usuario_user nvarchar(50) UNIQUE,
					   usuario_pass nvarchar(256),
					   usuario_trys smallint DEFAULT 3 CHECK (usuario_trys in (0,1,2,3)),
					   usuario_last_login datetime DEFAULT NULL,
					   usuario_habilitado bit DEFAULT 1,
					   u_cli_id numeric(18,0) REFERENCES BE_SHARPS.Clientes(cli_id),
					   u_emp_id numeric(18,0) REFERENCES BE_SHARPS.Empresas(emp_id))

					   
/* TABLA Visibilidad */
					   
CREATE TABLE BE_SHARPS.Visibilidad (visib_cod numeric(18,0) PRIMARY KEY, --IDENTITY(1,1),
						  visib_desc nvarchar(255) UNIQUE, -- se puede definir como unique
						  visib_precio numeric(18,2),
						  visib_porcentaje numeric(18,2),
						  visib_dias int DEFAULT 7,
						  visib_habilitada bit DEFAULT 1)

/* TABLA Rubros */						  
-- Si quisiera sub-rubros tendría que agregar una columna tipo rubro_padre

CREATE TABLE BE_SHARPS.Rubros (rubro_id numeric(18,0) PRIMARY KEY IDENTITY(1,1),
					 rubro_desc nvarchar(255), -- se puede definir como unique
					 rubro_habilitado bit DEFAULT 1) -- no se implementa ABM de Rubro asi que este valor no varia


/* TABLA ESTADOS DE PUBLICACION */
CREATE TABLE BE_SHARPS.Estados (estado_id numeric(18,0) PRIMARY KEY IDENTITY(1,1),
								estado_nombre nvarchar(55) UNIQUE,
								estado_habilitado bit DEFAULT 1)
					
					
/* TABLA TIPOS DE PUBLICAION */								
CREATE TABLE BE_SHARPS.Tipo_Pub (tipo_id numeric(18,0) PRIMARY KEY IDENTITY(1,1),
								 tipo_nombre nvarchar(55) UNIQUE,
								 tipo_habilitado bit DEFAULT 1)								


/* TABLA Publicaciones */
					 
CREATE TABLE BE_SHARPS.Publicaciones (pub_cod numeric(18,0) PRIMARY KEY IDENTITY (1,1),
							pub_id_usuario numeric(18,0) REFERENCES BE_SHARPS.Usuarios(usuario_id),
							pub_visibilidad_cod numeric(18,0) REFERENCES BE_SHARPS.Visibilidad(visib_cod),
							pub_desc nvarchar(255),
							pub_stock numeric(18,0) CHECK (pub_stock >-1),
							pub_fecha datetime,
							pub_fec_venc datetime,
							pub_precio numeric(18,2),
							pub_tipo nvarchar(55) REFERENCES BE_SHARPS.Tipo_Pub(tipo_nombre),							
							pub_estado nvarchar(55) REFERENCES BE_SHARPS.Estados(estado_nombre),
							pub_preg_habilitadas nvarchar(3) DEFAULT 'YES' CHECK (pub_preg_habilitadas IN ('NO','YES')))
							
/*
ALTER TABLE BE_SHARPS.Publicaciones ADD CONSTRAINT ck_estado CHECK (pub_estado IN 
														 ('Borrador', 'Publicada', 'Pausada', 'Finalizada'))
														  
ALTER TABLE BE_SHARPS.Publicaciones ADD CONSTRAINT ck_tipo CHECK (pub_tipo IN ('Compra Inmediata', 'Subasta'))

ALTER TABLE BE_SHARPS.Publicaciones ADD CONSTRAINT ck_stock CHECK (pub_stock = (case when pub_tipo = 'Subasta' then 1 else pub_stock end))

--ALTER TABLE BE_SHARPS.Publicaciones ADD CONSTRAINT ck_preguntas CHECK (pub_preg_habilitadas IN ('NO','YES'))
*/

/* TABLA PublicacionXRubro */
							
CREATE TABLE BE_SHARPS.PublicacionXRubro (publi_pub numeric(18,0) NOT NULL REFERENCES BE_SHARPS.Publicaciones(pub_cod),
								publi_rubro numeric(18,0) NOT NULL REFERENCES BE_SHARPS.Rubros(rubro_id))


/* TABLA Calificaciones */
CREATE TABLE BE_SHARPS.Calificaciones (calif_cod numeric(18,0) PRIMARY KEY IDENTITY (1,1),									   
									   calif_estrellas numeric(18,0),
									   calif_desc nvarchar(255))
								
/* TABLA Compras */	

CREATE TABLE BE_SHARPS.Compras (compra_id numeric(18,0) PRIMARY KEY IDENTITY (1,1),
					  comp_pub_cod numeric(18,0) REFERENCES BE_SHARPS.Publicaciones(pub_cod),
					  comp_vendedor_id numeric(18,0) REFERENCES BE_SHARPS.Usuarios(usuario_id),
					  comp_comprador_id numeric(18,0) REFERENCES BE_SHARPS.Usuarios(usuario_id),
					  comp_calif_cod numeric(18,0) REFERENCES BE_SHARPS.Calificaciones(calif_cod),
					  compra_fec datetime,
					  compra_cant numeric(18,0))								   



/* TABLA Preguntas */
							 
CREATE TABLE BE_SHARPS.Preguntas (preg_cod numeric(18,0) PRIMARY KEY IDENTITY(1,1),
						preg_pub_cod numeric(18,0) REFERENCES BE_SHARPS.Publicaciones(pub_cod),
						preg_usuario_id numeric(18,0) REFERENCES BE_SHARPS.Usuarios(usuario_id),
						preg_desc nvarchar(255),
						preg_resp nvarchar(255))


/* TABLA Ofertas */
						
CREATE TABLE BE_SHARPS.Ofertas (oferta_cod numeric(18,0) PRIMARY KEY IDENTITY (1,1),
					  of_usuario_id numeric(18,0) REFERENCES BE_SHARPS.Usuarios(usuario_id),
					  of_pub_cod numeric(18,0) REFERENCES BE_SHARPS.Publicaciones(pub_cod),
					  oferta_fecha datetime,
					  oferta_monto numeric(18,0)) --le saque en ,2


/* TABLA Factura */
					  
CREATE TABLE BE_SHARPS.Factura (factura_nro numeric(18,0) PRIMARY KEY IDENTITY(1,1),
					  fact_usuario_id numeric(18,0) REFERENCES BE_SHARPS.Usuarios(usuario_id),
					  factura_fecha datetime,
					  factura_total numeric(18,2),
					  factura_forma_pago nvarchar(255))

/* TABLA PubliXItem_Factura */	

CREATE TABLE BE_SHARPS.PubliXItem_Factura (publitem_pub_cod numeric(18,0) PRIMARY KEY REFERENCES BE_SHARPS.Publicaciones(pub_cod),							 
								 publitem_fact_nro numeric(18,0) REFERENCES BE_SHARPS.Factura(factura_nro))

					  
/* TABLA Item_Factura */

CREATE TABLE BE_SHARPS.Item_Factura (item_pub_cod numeric(18,0) REFERENCES BE_SHARPS.PubliXItem_Factura(publitem_pub_cod), 
						   item_monto numeric(18,2),
						   item_cantidad numeric(18,0) DEFAULT 1)					   
					   



/* TABLAS DE ROLES */
CREATE TABLE BE_SHARPS.Roles (rol_id numeric(18,0) PRIMARY KEY IDENTITY(1,1),
					rol_nombre nvarchar(35) UNIQUE,
					rol_habilitado bit) 

/* TABLAS DE FUNCIONES */
CREATE TABLE BE_SHARPS.t_funciones (id numeric(18,0) IDENTITY(1,1) NOT NULL,
						  funcion nvarchar(35) primary key) -- ultimos cambios

/* TABLAS DE Rol_Funcion */
CREATE TABLE BE_SHARPS.Rol_Funcion (rfun_rol_id numeric(18,0) REFERENCES BE_SHARPS.Roles(rol_id),
						  rfun_fun nvarchar(35) REFERENCES BE_SHARPS.t_funciones(funcion)) -- ultimos cambios

/* TABLAS DE Usuario_Rol */						  
CREATE TABLE BE_SHARPS.Usuario_Rol (urol_uid numeric(18,0) REFERENCES BE_SHARPS.Usuarios(usuario_id),
						  urol_rolid numeric(18,0) REFERENCES BE_SHARPS.Roles(rol_id))
						  
	
END





							 
/* **************************************** MIGRACIÓN **************************************** */

GO

IF OBJECT_ID('BE_SHARPS.realizar_migracion','P') IS NOT NULL
BEGIN 
	DROP PROC BE_SHARPS.realizar_migracion
	PRINT 'Procedimiento realizar_migracion droppeada.'
END ELSE PRINT 'El procedimiento realizar_migracion no fue creado aún.'

GO

CREATE PROC BE_SHARPS.realizar_migracion
AS
BEGIN

SET IDENTITY_INSERT BE_SHARPS.Clientes ON	
INSERT INTO BE_SHARPS.Clientes (cli_id,cli_doc_tipo,cli_doc_nro,cli_apellido,cli_nombre,cli_fec_nac,cli_mail,cli_telefono,cli_dom_calle,cli_nro_calle,cli_piso,cli_dpto,cli_localidad,cli_cp)
	VALUES(1,'DNI',99999999,'Sharps','Be','2014-01-01','besharps@gmail.com',99999999,'AvenidaSiempreViva',999,9,'Z','CABA',9999)
SET IDENTITY_INSERT BE_SHARPS.Clientes OFF

SET IDENTITY_INSERT BE_SHARPS.Empresas ON						  
INSERT INTO BE_SHARPS.Empresas (emp_id,emp_rsocial,emp_cuit,emp_fec_creacion,emp_mail,emp_telefono,emp_dom_calle,emp_nro_calle,emp_piso,emp_depto,emp_localidad,emp_cp,emp_ciudad,emp_contacto)
	VALUES(1,'BeSharps','9-99999999-9','2014-01-01','besharps@gmail.com',90000009,'AvenidaSiempreViva',999,9,'Z','CABA',9999,'BuenosAires','Jaime')
SET IDENTITY_INSERT BE_SHARPS.Empresas OFF

SET IDENTITY_INSERT BE_SHARPS.Usuarios ON
INSERT INTO BE_SHARPS.Usuarios (usuario_id,usuario_user, usuario_pass, usuario_trys, usuario_habilitado,u_cli_id,u_emp_id, usuario_last_login)
					  VALUES (1,'admin','e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',3,1,1,1,GETDATE())
SET IDENTITY_INSERT BE_SHARPS.Usuarios OFF
-- el GETDATE() está como artimania para que el sistema no me pida de cambiar la contrasenia del usuario admin en su logueo		  	

INSERT INTO BE_SHARPS.Clientes (cli_doc_nro, 
					  cli_apellido,
					  cli_nombre,
					  cli_fec_nac,
					  cli_mail,
					  cli_telefono,
					  cli_dom_calle,
					  cli_nro_calle,
					  cli_piso,
					  cli_dpto,
					  cli_cp)
			SELECT DISTINCT Cli_Dni, Cli_Apeliido, Cli_Nombre, 
							Cli_Fecha_Nac, Cli_Mail, Cli_Dni,
							Cli_Dom_Calle, Cli_Nro_Calle,
							Cli_Piso, Cli_Depto, Cli_Cod_Postal
			FROM GD1C2014.gd_esquema.Maestra
			WHERE Cli_Dni is not null
			
		
		
INSERT INTO BE_SHARPS.Empresas (emp_rsocial,
					  emp_cuit,
					  emp_fec_creacion,
					  emp_mail,
					  emp_dom_calle,
					  emp_nro_calle,
					  emp_piso,
					  emp_depto,
					  emp_cp)
			SELECT DISTINCT Publ_Empresa_Razon_Social, Publ_Empresa_Cuit, Publ_Empresa_Fecha_Creacion,
					Publ_Empresa_Mail, Publ_Empresa_Dom_Calle, Publ_Empresa_Nro_Calle, Publ_Empresa_Piso,
					Publ_Empresa_Depto, Publ_Empresa_Cod_Postal 
			FROM GD1C2014.gd_esquema.Maestra
			WHERE Publ_Empresa_Cuit is not null
			
			
INSERT INTO BE_SHARPS.Usuarios (u_cli_id, usuario_user, usuario_pass)
			select cli_id, BE_SHARPS.generarUsuario(cli_id,'C'), '1b397769df4d42ebb18176c0bca10e5a17d81d07ef0f949866f7954b53a1d403'
			from BE_SHARPS.Clientes where cli_id <> 1
			
INSERT INTO BE_SHARPS.Usuarios (u_emp_id, usuario_user, usuario_pass) 
			select emp_id, BE_SHARPS.generarUsuario(emp_id,'E'), '1b397769df4d42ebb18176c0bca10e5a17d81d07ef0f949866f7954b53a1d403'
			from BE_SHARPS.Empresas where emp_id <> 1
			
			
SET IDENTITY_INSERT BE_SHARPS.Roles ON	
INSERT INTO BE_SHARPS.Roles (rol_id,rol_nombre,rol_habilitado) VALUES (1,'Administrador',1)
INSERT INTO BE_SHARPS.Roles (rol_id,rol_nombre,rol_habilitado) VALUES (2,'Cliente',1)
INSERT INTO BE_SHARPS.Roles (rol_id,rol_nombre,rol_habilitado) VALUES (3,'Empresa',1)
INSERT INTO BE_SHARPS.Roles (rol_id,rol_nombre,rol_habilitado) VALUES (4,'Administrador General',1)
SET IDENTITY_INSERT BE_SHARPS.Roles OFF

-- el 4 es Administrador General
INSERT INTO BE_SHARPS.Usuario_Rol (urol_uid,urol_rolid) VALUES(1,4)
-- el 3 es empresa, el 2 es Cliente (el 1 es administrador)
INSERT INTO BE_SHARPS.Usuario_Rol (urol_uid,urol_rolid) SELECT usuario_id, (case when u_cli_id is null then 3 else 2 end) FROM BE_SHARPS.Usuarios where usuario_id<>1
--INSERT INTO Rol_Funcion (rfun_rol_id, rfun_fun, rfun_fun_id)		
			

--SET IDENTITY_INSERT BE_SHARPS.Visibilidad ON			
INSERT INTO BE_SHARPS.Visibilidad (visib_cod, visib_desc, visib_precio, visib_porcentaje, visib_dias)
			 SELECT DISTINCT Publicacion_Visibilidad_Cod, Publicacion_Visibilidad_Desc, 
							   Publicacion_Visibilidad_Precio, Publicacion_Visibilidad_Porcentaje,
							   (case when Publicacion_Visibilidad_Cod=10006 then 7 else 30 end)
			 FROM GD1C2014.gd_esquema.Maestra
			 WHERE Publicacion_Visibilidad_Cod is not null
			 ORDER BY Publicacion_Visibilidad_Cod
--SET IDENTITY_INSERT BE_SHARPS.Visibilidad OFF
			 
--update BE_SHARPS.Visibilidad set visib_dias = (case when visib_cod=10006 then 7 else 30 end)			 
			 
INSERT INTO BE_SHARPS.Rubros (rubro_desc) SELECT DISTINCT Publicacion_Rubro_Descripcion 
								FROM GD1C2014.gd_esquema.Maestra
								WHERE Publicacion_Rubro_Descripcion IS NOT NULL
								ORDER BY Publicacion_Rubro_Descripcion ASC
								


INSERT INTO BE_SHARPS.Tipo_Pub (tipo_nombre) VALUES ('Compra Inmediata')
INSERT INTO BE_SHARPS.Tipo_Pub (tipo_nombre) VALUES ('Subasta')


INSERT INTO BE_SHARPS.Estados (estado_nombre) VALUES ('Borrador')
INSERT INTO BE_SHARPS.Estados (estado_nombre) VALUES ('Publicada')
INSERT INTO BE_SHARPS.Estados (estado_nombre) VALUES ('Pausada')
INSERT INTO BE_SHARPS.Estados (estado_nombre) VALUES ('Finalizada')


								
SET IDENTITY_INSERT BE_SHARPS.Publicaciones ON								
INSERT INTO BE_SHARPS.Publicaciones (pub_cod,
							pub_id_usuario,
							pub_desc,
							pub_stock,
							pub_fecha,
							pub_fec_venc,
							pub_precio,
							pub_tipo,
							pub_visibilidad_cod,
							pub_estado)
							SELECT Publicacion_Cod,
							BE_SHARPS.obtenerIDusuario('DNI',Publ_Cli_Dni,Publ_Empresa_Cuit) as usurio_id,							 
						    Publicacion_Descripcion, Publicacion_Stock,
							Publicacion_Fecha, Publicacion_Fecha_Venc, Publicacion_Precio,
							Publicacion_Tipo, Publicacion_Visibilidad_Cod,
							(case when Publicacion_Tipo = 'Subasta' then 'Finalizada' else Publicacion_Estado end)							
							FROM GD1C2014.gd_esquema.Maestra
							WHERE Publicacion_Cod is not null
							GROUP BY Publicacion_Cod, Publ_Cli_Dni, Publ_Empresa_Cuit,
							Publicacion_Descripcion, Publicacion_Stock, Publicacion_Fecha, 
							Publicacion_Fecha_Venc, Publicacion_Precio, Publicacion_Tipo, 
							Publicacion_Visibilidad_Cod, Publicacion_Estado,
							Publicacion_Rubro_Descripcion    
							ORDER BY Publicacion_Cod ASC
SET IDENTITY_INSERT BE_SHARPS.Publicaciones OFF
							
						
						
INSERT INTO BE_SHARPS.PublicacionXRubro SELECT DISTINCT Publicacion_Cod, 
									BE_SHARPS.obtenerIDrubro(Publicacion_Rubro_Descripcion) as id_rubro
							  FROM GD1C2014.gd_esquema.Maestra
							  ORDER BY Publicacion_Cod
							  

SET IDENTITY_INSERT BE_SHARPS.Calificaciones ON

INSERT INTO BE_SHARPS.Calificaciones (calif_cod, calif_estrellas, calif_desc)
	 SELECT DISTINCT Calificacion_Codigo, Calificacion_Cant_Estrellas, Calificacion_Descripcion
	 FROM GD1C2014.gd_esquema.Maestra
	 WHERE Calificacion_Codigo is not null
	 
SET IDENTITY_INSERT BE_SHARPS.Calificaciones OFF
	 


INSERT INTO BE_SHARPS.Compras (compra_fec, compra_cant, comp_pub_cod, comp_vendedor_id, comp_comprador_id, comp_calif_cod)
					SELECT DISTINCT					
					Compra_Fecha, 
					Compra_Cantidad, 
					Publicacion_Cod,
					BE_SHARPS.obtenerIDusuario('DNI',Publ_Cli_Dni,Publ_Empresa_Cuit) as vendedor,
					BE_SHARPS.obtenerIDusuario('DNI',Cli_Dni,NULL) as comprador,
					Calificacion_Codigo
					FROM GD1C2014.gd_esquema.Maestra 
					WHERE Compra_Fecha is not null and Calificacion_Codigo is not null					 
					ORDER BY Publicacion_Cod ASC, vendedor ASC			

	
				
INSERT INTO BE_SHARPS.Ofertas (of_usuario_id, of_pub_cod, oferta_fecha, oferta_monto)
			SELECT DISTINCT BE_SHARPS.obtenerIDusuario('DNI',Cli_Dni,NULL) as usuario_id,
				   Publicacion_Cod, Oferta_Fecha, Oferta_Monto
			FROM GD1C2014.gd_esquema.Maestra
			WHERE Oferta_Fecha is not null
			ORDER BY Publicacion_Cod, usuario_id
			
		
		
SET IDENTITY_INSERT BE_SHARPS.Factura ON			
INSERT INTO BE_SHARPS.Factura (factura_nro, fact_usuario_id, factura_fecha, factura_total, factura_forma_pago) 
					SELECT Factura_Nro,	
					BE_SHARPS.obtenerIDusuario('DNI',Publ_Cli_Dni,Publ_Empresa_Cuit) as userr_id,
					Factura_Fecha, Factura_Total, Forma_Pago_Desc
					FROM GD1C2014.gd_esquema.Maestra
					WHERE Factura_Nro IS NOT NULL
					GROUP BY Factura_Nro, Publ_Cli_Dni, Publ_Empresa_Cuit, Factura_Fecha,
					Factura_Total, Forma_Pago_Desc
					ORDER BY Factura_Nro
SET IDENTITY_INSERT BE_SHARPS.Factura OFF


INSERT INTO BE_SHARPS.PubliXItem_Factura (publitem_fact_nro,publitem_pub_cod) 
			select distinct Factura_Nro, Publicacion_Cod from GD1C2014.gd_esquema.Maestra 
			where Factura_Nro is not null and Publicacion_Cod is not null order by Factura_Nro asc
			

INSERT INTO BE_SHARPS.Item_Factura(item_pub_cod, item_cantidad, item_monto)
	select Publicacion_Cod, Item_Factura_Cantidad, Item_Factura_Monto from GD1C2014.gd_esquema.Maestra 
	where Factura_Nro is not null and Publicacion_Cod is not null
	--group by Factura_Nro, Publicacion_Cod, Item_Factura_Cantidad, Item_Factura_Monto
	
	
	
/* LLENO LA TABLA t_funciones */
SET IDENTITY_INSERT BE_SHARPS.t_funciones ON
INSERT INTO BE_SHARPS.t_funciones (id,funcion) values(1,'ABM Cliente')
INSERT INTO BE_SHARPS.t_funciones (id,funcion) values(2,'ABM Empresa')
INSERT INTO BE_SHARPS.t_funciones (id,funcion) values(3,'ABM Rol')
INSERT INTO BE_SHARPS.t_funciones (id,funcion) values(4,'ABM Visibilidad')
INSERT INTO BE_SHARPS.t_funciones (id,funcion) values(5,'Listado estadistico')
INSERT INTO BE_SHARPS.t_funciones (id,funcion) values(6,'Buscar/Comprar')
INSERT INTO BE_SHARPS.t_funciones (id,funcion) values(7,'Generar publicacion')
INSERT INTO BE_SHARPS.t_funciones (id,funcion) values(8,'Editar publicacion')
INSERT INTO BE_SHARPS.t_funciones (id,funcion) values(9,'Facturar publicaciones')
INSERT INTO BE_SHARPS.t_funciones (id,funcion) values(10,'Gestor de preguntas')
INSERT INTO BE_SHARPS.t_funciones (id,funcion) values(11,'Historial')
INSERT INTO BE_SHARPS.t_funciones (id,funcion) values(12,'Calificar compras')
INSERT INTO BE_SHARPS.t_funciones (id,funcion) values(13,'Facturar cliente')
INSERT INTO BE_SHARPS.t_funciones (id,funcion) values(14,'Editar perfil')
SET IDENTITY_INSERT BE_SHARPS.t_funciones OFF	
	
	
-- Administrador
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (1,'ABM Cliente')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (1,'ABM Empresa')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (1,'ABM Rol')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (1,'ABM Visibilidad')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (1,'Listado estadistico')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (1,'Facturar cliente')


-- Cliente
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (2,'Buscar/Comprar')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (2,'Generar publicacion')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (2,'Editar publicacion')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (2,'Facturar publicaciones')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (2,'Gestor de preguntas')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (2,'Historial')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (2,'Calificar compras')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (2,'Editar perfil')


-- Empresa
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (3,'Generar publicacion')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (3,'Editar publicacion')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (3,'Facturar publicaciones')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (3,'Gestor de preguntas')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (3,'Historial')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (3,'Editar perfil')


-- Administrador General, tiene todas las funciones
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (4,'ABM Cliente')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (4,'ABM Empresa')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (4,'ABM Rol')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (4,'ABM Visibilidad')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (4,'Listado estadistico')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (4,'Facturar cliente')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (4,'Buscar/Comprar')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (4,'Generar publicacion')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (4,'Editar publicacion')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (4,'Facturar publicaciones')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (4,'Gestor de preguntas')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (4,'Historial')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (4,'Calificar compras')
INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) VALUES (4,'Editar perfil')


-- VOY A CARGAR LOS DATOS DEL USUARIO ADMINISTRADOR GENERAL
					
END
								
GO

EXEC BE_SHARPS.crear_tablas	

GO		

EXEC BE_SHARPS.realizar_migracion


-- COMIENZO DE DEFINICION DE PROCEDIMIENTOS Y TRIGGERS

GO

IF OBJECT_ID('BE_SHARPS.calificar','P') IS NOT NULL
BEGIN
	DROP PROCEDURE BE_SHARPS.calificar
	PRINT 'procedimiento BE_SHARPS.calificar dropeado'
END ELSE PRINT 'El procedimiento no ha sido creado aún'

GO

CREATE PROC BE_SHARPS.calificar @compra_id numeric(18,0), @estrellas numeric(18,0), @desc nvarchar(255)
AS
BEGIN TRANSACTION
	INSERT INTO BE_SHARPS.Calificaciones VALUES (@estrellas,@desc)
	if @@ERROR != 0 rollback 
	
	UPDATE BE_SHARPS.Compras set comp_calif_cod=@@IDENTITY where compra_id=@compra_id
	if @@ERROR != 0 rollback
	else 	
COMMIT


GO

IF OBJECT_ID('BE_SHARPS.tipoUsuario','P') IS NOT NULL
BEGIN
	DROP PROCEDURE BE_SHARPS.tipoUsuario
	PRINT 'procedimiento TipoUsuario dropeado'
END ELSE PRINT 'El procedimiento no ha sido creado aún'

GO
CREATE PROCEDURE BE_SHARPS.tipoUsuario @usuario numeric(18,0), @tipoVendedor char OUTPUT, @idTipoVendedor numeric(18,0) OUTPUT
	AS
	BEGIN
		declare @cli numeric(18,0)
		declare @emp numeric(18,0)
		SET @cli=(SELECT u_cli_id FROM BE_SHARPS.Usuarios WHERE usuario_id=@usuario)
		SET @emp=(SELECT u_emp_id FROM BE_SHARPS.Usuarios WHERE usuario_id=@usuario)
		IF (@cli is not null)
		BEGIN
			set @tipoVendedor = 'C'
			set @idTipoVendedor = @cli	
			--PRINT 'Es cliente'			
			--RETURN @cli
		END	ELSE IF (@emp is not null)
		BEGIN	
			set @tipoVendedor = 'E'
			set @idTipoVendedor = @emp
			--PRINT 'Es empresa'				
			--RETURN @emp
		END
		--PRINT 'No se conoce ese usuario'
		--RETURN 0
	END



GO

IF OBJECT_ID('BE_SHARPS.modificarPublicacion','P') is not null
	BEGIN
		drop proc BE_SHARPS.modificarPublicacion
		print 'modificarPublicacion fue borrado'
	END	
ELSE print 'modificarPublicacion no fue creado aún' 

GO
CREATE PROCEDURE BE_SHARPS.modificarPublicacion 
			@id_publicacion int,
			@id_visibilidad numeric(18,0),
			@descripcion nvarchar(255),
			@stock numeric(18,0),
			--@fecha_inicio datetime = '',
			--@fecha_vencimiento datetime = '',
			@precio numeric(18,2),
			--@tipo nvarchar(255),
			@estado nvarchar(255),
			@preguntas nvarchar(3),
			@fecha datetime
			
AS
BEGIN
	
	declare @fechaInicioVieja date = (select pub_fecha from BE_SHARPS.Publicaciones where pub_cod = @id_publicacion)
	declare @fechaVencimientoVieja date = (select pub_fec_venc from BE_SHARPS.Publicaciones where pub_cod = @id_publicacion)
		declare @fechaInicio date = null
		declare @fechaVencimiento date = null
		
		declare @duracion int = (SELECT visib_dias FROM BE_SHARPS.Visibilidad where visib_cod=@id_visibilidad)
	
	if(@estado = 'Publicada' and @fechaInicioVieja is null)
	begin
		set @fechaInicio = CONVERT(datetime,@fecha,103)
		set @fechaVencimiento = CONVERT(datetime,@fecha,103)+@duracion  --(le sumo el campo de la tabla visibilidad q tiene los dias)
	end
	if(@estado = 'Finalizada')
	begin
		set @fechaInicio = @fechaInicioVieja
		set @fechaVencimiento = CONVERT(datetime,@fecha,103)
	end
	if(@estado = 'Pausada' or (@estado = 'Publicada' and @fechaInicioVieja is not null))
	begin
		set @fechaInicio = @fechaInicioVieja
		set @fechaVencimiento = @fechaVencimientoVieja
	end	

	UPDATE [BE_SHARPS].[Publicaciones]
   SET 
      [pub_visibilidad_cod] = @id_visibilidad
      ,[pub_desc] = @descripcion
      ,[pub_stock] = @stock
      ,[pub_fecha] = @fechaInicio
      ,[pub_fec_venc] = @fechaVencimiento
      ,[pub_precio] = @precio
      --,[pub_tipo] = <pub_tipo, nvarchar(255),>    -- El tipo de publicacion no se cambia!!
      ,[pub_estado] = @estado
      ,[pub_preg_habilitadas] = @preguntas
 WHERE pub_cod = @id_publicacion

END

GO



go
if OBJECT_ID('BE_SHARPS.insertarEmpresa','P') is not null
BEGIN
 drop proc BE_SHARPS.insertarEmpresa
 print 'BE_SHARPS.insertarEmpresa fue borrado'
END 
ELSE print 'BE_SHARPS.insertarEmpresa no fue creado aún' 

go
create proc BE_SHARPS.insertarEmpresa @quien nvarchar(35), @username nvarchar(35)='pepe', @pass nvarchar(255)='pepe',
       @razon_social nvarchar(255),
       @cuit nvarchar(255),
       @telefono numeric(18,0),
       @nombre_contacto nvarchar(50)='',
       @fec_creacion datetime = '',
       @mail nvarchar(255)='',
       @dom_calle nvarchar(255)='',
       @nro_calle numeric(18,0)=NULL,
       @piso numeric(18,0)=NULL,
       @dpto nvarchar(50)='',
       @localidad nvarchar(50)='',
       @cp numeric(18,0)=NULL,
       @fecha datetime
       --@usuario nvarchar(35) output,
       --@contrasena nvarchar(35) output
       
AS
BEGIN
 INSERT INTO [BE_SHARPS].[Empresas]
           ([emp_rsocial]
           ,[emp_cuit]
           ,[emp_fec_creacion]
           ,[emp_mail]
           ,[emp_telefono]
           ,[emp_dom_calle]
           ,[emp_nro_calle]
           ,[emp_piso]
           ,[emp_depto]
           ,[emp_localidad]
           ,[emp_cp]
           --,[emp_ciudad]
           ,[emp_contacto])
     VALUES
           (@razon_social
           ,@cuit
           ,@fec_creacion
           ,@mail 
           ,@telefono
           ,@dom_calle
           ,@nro_calle 
           ,@piso 
           ,@dpto 
           ,@localidad
           ,@cp
           --,<emp_ciudad, nvarchar(50),>
           ,@nombre_contacto)

 declare @emp_id int  = (select emp_id from BE_SHARPS.Empresas where emp_rsocial = @razon_social)
 /*
 if @quien = 'administrador'
 begin
  set @username = BE_SHARPS.generarUsuario(@emp_id, 'E')
  set @pass = ABS(CAST(NEWID() as binary(3)) % 99999999)
 end
 */
 if @quien = 'administrador'
 begin
	set @fecha = NULL
 end
 
 insert into BE_SHARPS.Usuarios(usuario_user, usuario_pass, u_emp_id, usuario_last_login) VALUES (@username, @pass, @emp_id, convert(datetime,@fecha,103))
 
 INSERT INTO BE_SHARPS.Usuario_Rol (urol_uid, urol_rolid) VALUES(@@IDENTITY,3) -- 3 es Empresa
 
 --set @usuario = @username
 --set @contrasena = @pass
end

GO


-- VARIOS TRIGGERS
-- Este trigger se activa al hacer un update sobre la tabla Publicaciones y verifica si lo que se modifico es una Subasta y si
-- su estado cambio a Finalizada, entonces si esto se cumple y ademas tuvo ofertas, se inserta un nuevo registro en la tabla Compras 

GO 
IF OBJECT_ID('BE_SHARPS.TR_finalizarSubasta') is not null
	drop trigger BE_SHARPS.TR_finalizarSubasta

GO

CREATE TRIGGER BE_SHARPS.TR_finalizarSubasta ON BE_SHARPS.Publicaciones
AFTER UPDATE
AS
BEGIN

	declare cur cursor FOR SELECT pub_cod, pub_tipo, pub_estado FROM inserted
	declare @pub_cod numeric(18,0)
	declare @pub_tipo nvarchar(255)
	declare @pub_estado nvarchar(255)
	
	OPEN cur
	FETCH NEXT FROM cur INTO @pub_cod, @pub_tipo, @pub_estado
	
	WHILE(@@FETCH_STATUS = 0)
	BEGIN
	
		IF (@pub_tipo = 'Subasta' and @pub_estado = 'Finalizada')	
		BEGIN
		
			declare @comp_pub_cod numeric(18,0)
			declare @comprador numeric(18,0)
			declare @compra_fec datetime
			declare @vendedor numeric(18,0)
			SELECT top 1 @comp_pub_cod=pub_cod, @comprador=of_usuario_id, @compra_fec=oferta_fecha, @vendedor=pub_id_usuario
			from BE_SHARPS.Publicaciones, BE_SHARPS.Ofertas
			WHERE pub_cod = of_pub_cod and pub_cod = @pub_cod
			--and not exists (select top 1 comp_pub_cod from BE_SHARPS.Compras where comp_pub_cod=@pub_cod) -- le agregue esto
			GROUP BY pub_cod, of_usuario_id, oferta_fecha, pub_id_usuario
			ORDER BY pub_cod, MAX(oferta_monto) DESC
			
			IF @comp_pub_cod is not null
			BEGIN
				INSERT into BE_SHARPS.Compras (comp_pub_cod, comp_comprador_id, comp_vendedor_id, compra_fec, compra_cant) 
					values (@comp_pub_cod, @comprador, @vendedor, @compra_fec,1)
			END
			
		END	
		
		
		FETCH NEXT FROM cur INTO @pub_cod, @pub_tipo, @pub_estado
	END
	
	CLOSE cur
	DEALLOCATE cur	
END

GO

IF OBJECT_ID('BE_SHARPS.pausarUser','P') is not null
	drop proc BE_SHARPS.pausarUser
GO

CREATE PROCEDURE BE_SHARPS.pausarUser @usuario_id numeric(18,0)
AS
BEGIN
	DECLARE CUR1 CURSOR FOR 
	SELECT pub_cod from BE_SHARPS.Publicaciones where pub_estado = 'Publicada' and pub_id_usuario = @usuario_id
	
	DECLARE @pub_cod numeric(18,0)

	OPEN CUR1
	FETCH NEXT FROM CUR1 INTO @pub_cod
	
	WHILE(@@FETCH_STATUS = 0)
	BEGIN
	
		UPDATE BE_SHARPS.Publicaciones set pub_estado = 'Pausada' where pub_cod = @pub_cod
	
		FETCH NEXT FROM CUR1 INTO @pub_cod
	END
	
	CLOSE CUR1
	DEALLOCATE CUR1
	
END

GO
/* ENTRABA EN UN BUCLE INFINITO */
IF OBJECT_ID('BE_SHARPS.tr_pubSinStock') is not null
	drop trigger BE_SHARPS.tr_pubSinStock
GO

CREATE TRIGGER BE_SHARPS.tr_pubSinStock
ON Publicaciones
FOR UPDATE
AS
BEGIN

	declare cursor1 cursor FOR SELECT pub_cod, pub_stock, pub_tipo FROM inserted
	
	declare @publicacion numeric(18,0)
	declare @pub_stock numeric(18,0)
	declare @pub_tipo nvarchar(25)
	
	OPEN cursor1
	
	FETCH NEXT FROM cursor1 INTO @publicacion, @pub_stock, @pub_tipo
	
	WHILE(@@FETCH_STATUS = 0)
	BEGIN 
	
	IF (@pub_tipo = 'Compra Inmediata')
	BEGIN
		IF (@pub_stock = 0)
			BEGIN
				--PRINT('No hay mas stock')
				UPDATE BE_SHARPS.Publicaciones SET pub_estado = 'Finalizada' WHERE pub_cod=@publicacion			
			END
		--ELSE PRINT ('Queda stock disponible')
	END
	
		FETCH NEXT FROM cursor1 INTO @publicacion, @pub_stock, @pub_tipo
	END
	
	CLOSE cursor1
	DEALLOCATE cursor1
end



GO

--


-- (MODIFICADO 10/07/14)


IF TYPE_ID (N'l_pub') is not null
begin
	IF OBJECT_ID('BE_SHARPS.facturarPublicaciones ','P') is not null
	BEGIN
	 DROP PROC BE_SHARPS.facturarPublicaciones ;
	 PRINT 'Se elimino el proc BE_SHARPS.facturarPublicaciones '
	END
	 ELSE PRINT 'El proc BE_SHARPS.facturarPublicaciones  no fue creado aún'
	drop type l_pub		
END else print 'El tipo l_pub no fue creado aún'

GO
 
CREATE TYPE l_pub AS TABLE
(
 publicacion_codigo int
);

GO

IF OBJECT_ID('BE_SHARPS.facturarPublicaciones ','P') is not null
BEGIN
 DROP PROC BE_SHARPS.facturarPublicaciones ;
 PRINT 'Se elimino el proc BE_SHARPS.facturarPublicaciones '
END
 ELSE PRINT 'El proc BE_SHARPS.facturarPublicaciones  no fue creado aún'

GO


CREATE PROC BE_SHARPS.facturarPublicaciones @lista_Pubs l_pub READONLY, @formaDePago nvarchar(55), @fecha datetime, 
			@facturado numeric(18,2) OUTPUT
AS
BEGIN TRANSACTION
 declare @unaPublicacion int
 declare @usuario_id int 
 declare @fact_nro int
 declare @ventas int
 declare @ofertas int
 declare @tipo_pub bit -- @tipo_pub=1 es Compra Inmediata, @tipo_pub=0 es Subasta
 declare @item_monto numeric(18,2)
 declare @total_factura numeric (18,2) = 0
 declare @porcentaje numeric(18,2)
 BEGIN TRY
 
 set @unaPublicacion = (SELECT TOP 1 publicacion_codigo FROM @lista_Pubs)
 set @usuario_id = (SELECT pub_id_usuario FROM BE_SHARPS.Publicaciones where pub_cod=@unaPublicacion)
 --las dos linea de arriba son para obtener el usuario id y que no tenga que recibirlo el proc por parametro
   
    
 --GENERO LA FACTURA, LUEGO SE LE ACTUALIZA EL TOTAL FACTURA
 INSERT INTO BE_SHARPS.Factura (fact_usuario_id, factura_fecha, factura_forma_pago, factura_total)
  VALUES (@usuario_id, convert(datetime,@fecha,103), @formaDePago, @total_factura)
 
 set @fact_nro = @@IDENTITY
   
 declare recorrer_tabla cursor for 
  select publicacion_codigo from @lista_Pubs
  
  declare @pub_cod int
  
 open recorrer_tabla

 fetch next from recorrer_tabla into @pub_cod
 
 while @@FETCH_STATUS=0
 BEGIN
    
  --print 'Voy a insertar en PubliXItem_Factura, fact_nro: '+convert(nvarchar(55),@fact_nro)+' pub_codigo: '+convert(nvarchar(55),@pub_cod)
  --agregar select para chequear si se va a bonificar (multiplos de 10 se facturan a 0 pesos)
  /* aca creo que habia flasheado
  declare @visibilidad numeric(18,0) = (SELECT TOP 1 pub_visibilidad_cod 
										FROM BE_SHARPS.PubliXItem_Factura, BE_SHARPS.Publicaciones where publitem_pub_cod=pub_cod) */
  declare @visibilidad numeric(18,0) = (SELECT TOP 1 pub_visibilidad_cod from BE_SHARPS.Publicaciones where pub_cod=@pub_cod) 									
  declare @cuenta int= (SELECT COUNT(*) FROM BE_SHARPS.PubliXItem_Factura
						 INNER JOIN BE_SHARPS.Publicaciones on publitem_pub_cod=pub_cod
						 WHERE pub_visibilidad_cod=@visibilidad and pub_id_usuario=@usuario_id)
  /*
  IF ( (@cuenta+1) % 3 = 0 ) -- si se cumple esta condicion, la publicacion se bonifica
  BEGIN
	INSERT INTO BE_SHARPS.PubliXItem_Factura (publitem_fact_nro, publitem_pub_cod) VALUES (@fact_nro, @pub_cod)
	INSERT INTO BE_SHARPS.Item_Factura (item_cantidad, item_monto, item_pub_cod) VALUES(1,0,@pub_cod)
  END  ELSE
  BEGIN*/	  
	  INSERT INTO BE_SHARPS.PubliXItem_Factura (publitem_fact_nro, publitem_pub_cod) VALUES (@fact_nro, @pub_cod)   
	  
	  set @tipo_pub = (SELECT COUNT(*) FROM BE_SHARPS.Publicaciones WHERE pub_tipo='Compra Inmediata' and pub_cod=@pub_cod)  
	  set @ventas = (SELECT SUM(compra_cant) FROM BE_SHARPS.Compras WHERE comp_pub_cod=@pub_cod)
	  set @ofertas = (SELECT COUNT(*) FROM BE_SHARPS.Ofertas WHERE of_pub_cod=@pub_cod)
	  set @porcentaje = (SELECT visib_porcentaje FROM BE_SHARPS.Publicaciones, BE_SHARPS.Visibilidad where pub_visibilidad_cod=visib_cod and pub_cod=@pub_cod)
	  
	  IF (@tipo_pub = 1 and @ventas is not null) -- SI ES COMPRA INMEDIATA (y tuvo compra(s))
	  BEGIN	    
		set @item_monto = (SELECT SUM(compra_cant)*pub_precio FROM BE_SHARPS.Publicaciones, BE_SHARPS.Compras, BE_SHARPS.Visibilidad
		where pub_cod=@pub_cod and pub_visibilidad_cod=visib_cod and comp_pub_cod=pub_cod
		group by pub_cod, pub_precio)
		--print 'Voy a hacer el 1er insert sobre item factura'  
		INSERT INTO BE_SHARPS.Item_Factura (item_cantidad, item_monto, item_pub_cod) VALUES (@ventas, @item_monto*@porcentaje, @pub_cod)   
		set @total_factura = @total_factura + @item_monto*@porcentaje
	  END
	  
	  IF (@tipo_pub =0 and @ofertas > 0) -- SI ES SUBASTA (y tuvo oferta(s))
	  BEGIN
	   set @item_monto =(SELECT TOP 1 oferta_monto FROM BE_SHARPS.Ofertas where of_pub_cod=@pub_cod ORDER BY oferta_monto DESC)
	   --set @item_monto = @item_monto*
	   --(SELECT visib_porcentaje FROM BE_SHARPS.Visibilidad, BE_SHARPS.Publicaciones where pub_visibilidad_cod=visib_cod and pub_cod=@pub_cod)
	   --print 'Voy a hacer el 1er insert sobre item factura'
	   INSERT INTO BE_SHARPS.Item_Factura (item_cantidad, item_monto, item_pub_cod) VALUES (1,@item_monto*@porcentaje,@pub_cod)
	   set @total_factura = @total_factura + @item_monto*@porcentaje
	  END
     
	  --lo pongo arriba
	  -- aca facturo la visibilidad
	  
	  PRINT 'Voy a hacer el 2do insert sobre item factura' 
	  IF ( (@cuenta+1) % 10 = 0 )	  
	  BEGIN
		INSERT INTO BE_SHARPS.Item_Factura (item_cantidad, item_monto, item_pub_cod) VALUES(1,0,@pub_cod)
		set @total_factura = @total_factura + 0
	  END ELSE
	  BEGIN
	  	SET @item_monto = (SELECT visib_precio FROM BE_SHARPS.Visibilidad, BE_SHARPS.Publicaciones where pub_visibilidad_cod=visib_cod and pub_cod=@pub_cod)
		INSERT INTO BE_SHARPS.Item_Factura (item_cantidad, item_monto, item_pub_cod) VALUES(1,@item_monto,@pub_cod) --INSERT DE LA VISIBILIDAD
		set @total_factura = @total_factura + @item_monto
	  END
	  --set @total_factura = @total_factura + @item_monto
  --END
  
  fetch next from recorrer_tabla into @pub_cod 
 END


 close recorrer_tabla
 deallocate recorrer_tabla
 
 set @facturado = @total_factura
 UPDATE BE_SHARPS.Factura SET factura_total = @total_factura WHERE factura_nro=@fact_nro
 
 end try
  begin catch
   if @@TRANCOUNT > 0 
   begin
   rollback
   print 'Hubo un error'
   end
  end catch
   
   if  @@TRANCOUNT > 0

COMMIT



-- (MODIFICADO 09/07/2014)
GO
IF OBJECT_ID('BE_SHARPS.ofertar','P') IS NOT NULL
BEGIN
	DROP PROC BE_SHARPS.ofertar
	PRINT 'El procedimiento BE_SHARPS.ofertar fue creado'	
END ELSE
	PRINT 'El procedimiento BE_SHARPS.ofertar no fue creado aún'

GO

CREATE PROC BE_SHARPS.ofertar @pub_codigo numeric(18,0), @cli_id numeric(18,0), @puja numeric(18,2), @fecha datetime
AS
BEGIN TRANSACTION
	UPDATE BE_SHARPS.Publicaciones SET pub_precio=@puja where pub_cod=@pub_codigo
	if @@ERROR != 0 rollback 
		
	INSERT INTO BE_SHARPS.Ofertas (oferta_fecha, oferta_monto, of_usuario_id, of_pub_cod) 
		VALUES (convert(datetime,@fecha,103), @puja, @cli_id, @pub_codigo)
	if @@ERROR != 0 rollback 
	else	
COMMIT

GO

IF OBJECT_ID('BE_SHARPS.comprar','P') IS NOT NULL
BEGIN
	DROP PROC BE_SHARPS.comprar
	PRINT 'El procedimiento BE_SHARPS.comprar fue creado'	
END ELSE
	PRINT 'El procedimiento BE_SHARPS.comprar no fue creado aún'

GO

CREATE PROC BE_SHARPS.comprar @pub_codigo numeric(18,0), @unidades numeric(18,0), @cliente_id numeric(18,0), @fecha datetime
AS
BEGIN TRANSACTION
	declare @vendedor numeric(18,0) = (SELECT pub_id_usuario from BE_SHARPS.Publicaciones where pub_cod=@pub_codigo)

	UPDATE BE_SHARPS.Publicaciones set pub_stock = (pub_stock-@unidades) where pub_cod=@pub_codigo
	if @@ERROR != 0 rollback 
	
	INSERT INTO BE_SHARPS.Compras (comp_pub_cod, comp_comprador_id, comp_vendedor_id, compra_fec, compra_cant)
				VALUES(@pub_codigo, @cliente_id, @vendedor, convert(datetime,@fecha,103), @unidades)	
	if @@ERROR != 0 rollback 
	else
COMMIT

GO

IF OBJECT_ID('BE_SHARPS.obtenerReputacion','P') IS NOT NULL
BEGIN
	DROP PROC BE_SHARPS.obtenerReputacion
	PRINT 'El procedimiento BE_SHARPS.obtenerReputacion fue creado'	
END ELSE
	PRINT 'El procedimiento BE_SHARPS.obtenerReputacion no fue creado aún' 

GO
		
CREATE PROC BE_SHARPS.obtenerReputacion @usuario_id numeric(18,0), 
     @ventas numeric(18,0) OUTPUT,
     @calificaciones numeric(18,0) OUTPUT,
	 @estrellas numeric(18,0) OUTPUT,
	 @reputacion numeric(18,2) OUTPUT
AS
BEGIN
	set @ventas = (SELECT COUNT(*) FROM BE_SHARPS.Compras, BE_SHARPS.Publicaciones 
	where comp_pub_cod=pub_cod and pub_id_usuario=@usuario_id)
	
	 set @calificaciones = (SELECT COUNT(calif_estrellas)
								FROM BE_SHARPS.Publicaciones, BE_SHARPS.Compras, BE_SHARPS.Calificaciones							
								where comp_pub_cod=pub_cod and comp_calif_cod = calif_cod and pub_id_usuario=@usuario_id)
								
	 set @estrellas = (SELECT SUM(calif_estrellas)
						 FROM BE_SHARPS.Publicaciones, BE_SHARPS.Compras, BE_SHARPS.Calificaciones
						 where comp_calif_cod=calif_cod and comp_pub_cod=pub_cod and pub_id_usuario=@usuario_id)
		
	IF (@estrellas is null)
		set @estrellas = 0	
	
	IF (@calificaciones = 0)
		set @reputacion = 0
	ELSE
		set @reputacion = @estrellas/@calificaciones

END


-- (MODIFICADO 07/07/2014)
GO
IF OBJECT_ID('BE_SHARPS.eliminarEmpresa','P') is not null
BEGIN
	drop proc BE_SHARPS.eliminarEmpresa
	print 'BE_SHARPS.eliminarEmpresa fue borrado'
END
ELSE print 'BE_SHARPS.eliminarEmpresa no fue creado aún'

GO
CREATE PROCEDURE BE_SHARPS.eliminarEmpresa @empresa nvarchar(50)
AS
BEGIN
	--declare @empresa_id numeric(18,0) = (select	u_emp_id from Usuarios where usuario_user = @empresa)	
	UPDATE BE_SHARPS.Usuarios SET usuario_habilitado=0 WHERE usuario_user=@empresa	
	--DELETE Usuarios where usuario_user = @empresa
	--DELETE Empresas where emp_id = @empresa_id 
END



GO
IF OBJECT_ID('BE_SHARPS.modificarEmpresa','P') is not null
BEGIN
	drop proc BE_SHARPS.modificarEmpresa
	print 'BE_SHARPS.modificarEmpresa fue borrado'
END
ELSE print 'BE_SHARPS.modificarEmpresa no fue creado aún'

GO
CREATE PROCEDURE BE_SHARPS.modificarEmpresa
			@username nvarchar(35)='pepe', 
			@pass nvarchar(255),
			@razon_social nvarchar(255),
			@cuit nvarchar(255),
			@telefono numeric(18,0), 
			@nombre_contacto nvarchar(50)='',
			@fec_creacion datetime='',
			@mail nvarchar(255)='',
			@dom_calle nvarchar(255)='',
			@nro_calle numeric(18,0)=NULL,
			@piso numeric(18,0)=NULL,
			@dpto nvarchar(50)='',
			@localidad nvarchar(50)='',
			@cp numeric(18,0)=NULL,
			@habilitado bit
AS
BEGIN
	declare @empresa_id numeric(18,0) = (select	u_emp_id from BE_SHARPS.Usuarios where usuario_user = @username)

UPDATE BE_SHARPS.Empresas
   SET [emp_rsocial] = @razon_social
      ,[emp_cuit] = @cuit
      ,[emp_fec_creacion] = @fec_creacion
      ,[emp_mail] = @mail
      ,[emp_telefono] = @telefono
      ,[emp_dom_calle] = @dom_calle
      ,[emp_nro_calle] = @nro_calle
      ,[emp_piso] = @piso
      ,[emp_depto] = @dpto
      ,[emp_localidad] = @localidad
      ,[emp_cp] = @cp
      --,[emp_ciudad] = @ciudad
      ,[emp_contacto] = @nombre_contacto
 WHERE emp_id = @empresa_id
 /*
 UPDATE Usuarios
	SET usuario_pass = @pass
	WHERE usuario_user = @username
	*/
	if @pass is not null
	begin 
	UPDATE BE_SHARPS.Usuarios
		SET usuario_pass = @pass , usuario_habilitado = @habilitado
		WHERE usuario_user = @username
	end	
	else
	begin 
	UPDATE BE_SHARPS.Usuarios
		SET usuario_habilitado = @habilitado
		WHERE usuario_user = @username
	end	
END



GO
IF OBJECT_ID('BE_SHARPS.crearPublicacion','P') is not null
	BEGIN
		drop proc BE_SHARPS.crearPublicacion
		print 'BE_SHARPS.crearPublicacion fue borrado'
	END	
ELSE print 'BE_SHARPS.crearPublicacion no fue creado aún' 


GO
CREATE PROCEDURE BE_SHARPS.crearPublicacion 
			@usuario nvarchar(35)='pepe', 
			@tipo_publicacion nvarchar(255),
			@descripcion nvarchar(255),
			@stock numeric(18, 0),
			@precio numeric(18, 2),
			@visibilidad nvarchar(255),
			@estado nvarchar(255),
			@preguntas nvarchar(3),
			@fecha datetime,
			@id_publicacion int output
AS
BEGIN
	declare @id_usuario numeric(18,0) = (select usuario_id from BE_SHARPS.Usuarios where usuario_user = @usuario)
	declare @id_visibilidad numeric(18,0) = (select visib_cod from BE_SHARPS.Visibilidad where visib_desc like @visibilidad)
	--declare @id_publicacion integer
	
	declare @duracion int = (SELECT visib_dias FROM BE_SHARPS.Visibilidad where visib_cod=@id_visibilidad)

	INSERT INTO [BE_SHARPS].[Publicaciones]
		   ([pub_id_usuario]
		   ,[pub_visibilidad_cod]
		   ,[pub_desc]
		   ,[pub_stock]
		   ,[pub_fecha]
		   ,[pub_fec_venc]
		   ,[pub_precio]
		   ,[pub_tipo]
		   ,[pub_estado]
		   ,[pub_preg_habilitadas])
	 VALUES
		   (@id_usuario
		   ,@id_visibilidad
		   ,@descripcion
		   ,@stock
		   ,convert(datetime,@fecha,103) --ver como calcular la fecha de vencimiento (Funcion que le pasas la visibilidad??)
		   ,(convert(datetime,@fecha,103)+@duracion)
		   ,@precio
		   ,@tipo_publicacion
		   ,@estado
		   ,@preguntas)
		   
	set @id_publicacion = @@IDENTITY -- es el retorno		
END

GO

IF OBJECT_ID('BE_SHARPS.agregarRubroAPublicacion','P') is not null
	BEGIN
		drop proc BE_SHARPS.agregarRubroAPublicacion
		print 'BE_SHARPS.agregarRubroAPublicacion fue borrado'
	END	
ELSE print 'BE_SHARPS.agregarRubroAPublicacion no fue creado aún' 


GO
CREATE PROCEDURE BE_SHARPS.agregarRubroAPublicacion 
			@id_publicacion int,
			@rubro_id int
		
AS
BEGIN

	INSERT INTO [BE_SHARPS].[PublicacionXRubro]
           ([publi_pub]
           ,[publi_rubro])
     VALUES
           (@id_publicacion
           ,@rubro_id)

END

GO
-- (FIN MODIFICADO 07/07/2014)







IF OBJECT_ID('BE_SHARPS.tr_actualizar_permisos','trigger') is not null
	drop trigger BE_SHARPS.tr_actualizar_permisos
	else print 'el trigger BE_SHARPS.tr_actualizar_permisos no fue creado aún'
	
GO

-- ESTE TRIGGER ESTA MAL SI YO QUIERO HACER LA MIGRACION CON ESTE TRIGGER YA CREADO, HAY QUE HACERLO CON CURSOR ME PARECE
create trigger BE_SHARPS.tr_actualizar_permisos on Usuario_Rol
FOR INSERT
AS
BEGIN TRANSACTION

	IF (SELECT COUNT(*) FROM BE_SHARPS.Usuario_Rol u, inserted i WHERE u.urol_uid=i.urol_uid and u.urol_rolid=i.urol_rolid)>1
	BEGIN	
		PRINT 'Ya existe asi que rollbackeo'
		ROLLBACK
	END	ELSE
	BEGIN		
		PRINT 'No existía asi que commiteo'
		COMMIT	
	END

/*
CREATE TRIGGER BE_SHARPS.tr_actualizar_permisos
ON Usuario_Rol
INSTEAD OF insert
AS
BEGIN
	
	declare @usuario numeric(18,0)
	declare @rol numeric(18,0)		

	declare cursor1 cursor FOR SELECT urol_uid, urol_rolid FROM inserted
	
	OPEN cursor1
	
	FETCH NEXT FROM cursor1 INTO @usuario, @rol
	
	WHILE(@@FETCH_STATUS = 0)
	BEGIN 

		--IF(EXISTS(SELECT 1 FROM Usuario_Rol WHERE urol_uid = @usuario AND urol_rolid = @rol))
		
		IF(SELECT COUNT(*) FROM Usuario_Rol WHERE urol_uid = @usuario and urol_rolid = @rol) > 0
			BEGIN
				PRINT('Ya existe')			
			END
		ELSE
			BEGIN
				INSERT into Usuario_Rol (urol_uid, urol_rolid) values (@usuario,@rol)
			END
			
		FETCH NEXT FROM cursor1 INTO @usuario, @rol
	END
	
	CLOSE cursor1
	DEALLOCATE cursor1
end
*/



GO
IF OBJECT_ID('BE_SHARPS.modificarCliente','P') is not null
BEGIN
 drop proc BE_SHARPS.modificarCliente
 print 'BE_SHARPS.modificarCliente fue borrado'
END
ELSE print 'BE_SHARPS.modificarCliente no fue creado aún'

GO
CREATE PROCEDURE BE_SHARPS.modificarCliente 
   @username nvarchar(35)='pepe', 
   @pass nvarchar(255),
   @doc_tipo nvarchar(10),
   @doc_nro numeric(18,0),
   @telefono numeric(18,0), 
   @apellido nvarchar(255)='',
   @nombre nvarchar(255)='',
   @fec_nac datetime='',
   @mail nvarchar(255)='',
   @dom_calle nvarchar(255)='',
   @nro_calle numeric(18,0)=NULL,
   @piso numeric(18,0)=NULL,
   @dpto nvarchar(50)='',
   @localidad nvarchar(50)='',
   @cp numeric(18,0)=NULL,
   @habilitado bit
AS
BEGIN
 declare @cliente_id numeric(18,0) = (select u_cli_id from BE_SHARPS.Usuarios where usuario_user = @username)

UPDATE BE_SHARPS.Clientes
   SET [cli_doc_tipo] = @doc_tipo
      ,[cli_doc_nro] = @doc_nro
      ,[cli_apellido] = @apellido
      ,[cli_nombre] = @nombre
      ,[cli_fec_nac] = @fec_nac
      ,[cli_mail] = @mail
      ,[cli_telefono] = @telefono
      ,[cli_dom_calle] = @dom_calle
      ,[cli_nro_calle] = @nro_calle
      ,[cli_piso] = @piso
      ,[cli_dpto] = @dpto
      ,[cli_localidad] = @localidad
      ,[cli_cp] = @cp
 WHERE cli_id = @cliente_id
 /*
UPDATE BE_SHARPS.Usuarios
 SET usuario_pass = @pass
 WHERE usuario_user = @username
 */
	if @pass is not null
	begin 
	UPDATE BE_SHARPS.Usuarios
		SET usuario_pass = @pass, usuario_habilitado = @habilitado
		WHERE usuario_user = @username
	end 
	else
	begin
	UPDATE BE_SHARPS.Usuarios
		SET usuario_habilitado = @habilitado
		WHERE usuario_user = @username
	end
END



GO
IF OBJECT_ID('BE_SHARPS.eliminarCliente','P') is not null
BEGIN
 drop proc BE_SHARPS.eliminarCliente
 print 'BE_SHARPS.eliminarCliente fue borrado'
END
ELSE print 'BE_SHARPS.eliminarCliente no fue creado aún'

GO
CREATE PROCEDURE BE_SHARPS.eliminarCliente @cliente nvarchar(50)
AS
BEGIN
 --declare @cliente_id numeric(18,0) = (select u_cli_id from BE_SHARPS.Usuarios where usuario_user = @cliente)
 
 UPDATE BE_SHARPS.Usuarios SET usuario_habilitado=0 where usuario_user=@cliente
 --DELETE Usuarios where usuario_user = @cliente
 --DELETE Clientes where cli_id = @cliente_id 
END


GO
IF OBJECT_ID('BE_SHARPS.insetarCliente','P') is not null
BEGIN
	drop proc BE_SHARPS.insetarCliente
	print 'insertarCliente fue borrado'
END	
ELSE print 'BE_SHARPS.insetarCliente no fue creado aún' 

-- INSERTA UN NUEVO CLIENTE
GO
CREATE PROC BE_SHARPS.insetarCliente @quien nvarchar(35), @username nvarchar(35)='pepe', @pass nvarchar(255)='pepe',
			@doc_tipo nvarchar(10),
			@doc_nro numeric(18,0),
			@telefono numeric(18,0), 
			@apellido nvarchar(255)='',
			@nombre nvarchar(255)='',
			@fec_nac datetime='',
			@mail nvarchar(255)='',
			@dom_calle nvarchar(255)='',
			@nro_calle numeric(18,0)=NULL,
			@piso numeric(18,0)=NULL,
			@dpto nvarchar(50)='',
			@localidad nvarchar(50)='',
			@cp numeric(18,0)=NULL,
			@fecha datetime
AS
BEGIN
	INSERT INTO BE_SHARPS.Clientes (cli_doc_tipo,
						  cli_doc_nro, 
						  cli_apellido,
						  cli_nombre,
						  cli_fec_nac,
						  cli_mail,
						  cli_telefono,
						  cli_dom_calle,
						  cli_nro_calle,
						  cli_piso,
						  cli_dpto,
						  cli_localidad,
						  cli_cp) VALUES
						  (@doc_tipo,
						  @doc_nro, 
						  @apellido,
						  @nombre,
						  @fec_nac,
						  @mail,
						  @telefono,
						  @dom_calle,
						  @nro_calle,
						  @piso,
						  @dpto,
						  @localidad,
						  @cp)
		declare @cli_id int = (SELECT cli_id FROM BE_SHARPS.Clientes where cli_telefono=@telefono)
		/*
		if @quien='administrador' 
		begin
			set @username = BE_SHARPS.generarUsuario(@cli_id,'C')
			set @pass = ABS(CAST(NEWID() as binary(3)) % 99999999)
		end		
		*/
		if @quien='administrador'
		begin
			set @fecha = NULL
		end
		INSERT INTO BE_SHARPS.Usuarios (usuario_user, usuario_pass, u_cli_id, usuario_last_login) VALUES (@username, @pass, @cli_id, convert(datetime,@fecha,103))
		-- El 1 es Administrador, 2 Cliente, 3 Empresa
		INSERT INTO BE_SHARPS.Usuario_Rol (urol_rolid,urol_uid) VALUES (2,@@IDENTITY)				  
END



GO
IF OBJECT_ID('BE_SHARPS.insertarRol_Funcion ','P') is not null
BEGIN
	drop proc BE_SHARPS.insertarRol_Funcion 
	print 'BE_SHARPS.insertarRol_Funcion  fue borrado'
END	
ELSE print 'BE_SHARPS.insertarRol_Funcion  no fue creado aún' 


GO
CREATE PROCEDURE BE_SHARPS.insertarRol_Funcion  @id int, @funcion nvarchar(35)
AS
BEGIN
	INSERT INTO BE_SHARPS.Rol_Funcion (rfun_rol_id, rfun_fun) values (@id,@funcion)
END



GO 
IF OBJECT_ID('BE_SHARPS.obtenerCodigo','P') is not null
BEGIN
	drop proc BE_SHARPS.obtenerCodigo
	print 'BE_SHARPS.obtenerCodigo fue borrado'
END	
ELSE print 'BE_SHARPS.obtenerCodigo no fue creado aún'

GO
CREATE PROCEDURE BE_SHARPS.obtenerCodigo @rol nvarchar(35)
as
begin
	SELECT rol_id from BE_SHARPS.Roles where rol_nombre=@rol
end



GO 
IF OBJECT_ID('BE_SHARPS.p_insertar_visib','P') is not null
BEGIN
	drop proc BE_SHARPS.p_insertar_visib
	print 'BE_SHARPS.p_insertar_visib fue borrado'
END	
ELSE print 'BE_SHARPS.p_insertar_visib no fue creado aún'

GO

CREATE PROC BE_SHARPS.p_insertar_visib @visib_cod numeric(18,0), @visib_desc nvarchar(255), @visib_precio numeric(18,2),
			 @visib_porcentaje numeric(18,2), @visib_dias numeric(18,2)
AS
BEGIN
	INSERT INTO BE_SHARPS.Visibilidad (visib_cod, visib_desc, visib_precio, visib_porcentaje, visib_dias)
					VALUES (@visib_cod, @visib_desc, @visib_precio, @visib_porcentaje, @visib_dias)  
END




GO
IF OBJECT_ID('BE_SHARPS.insertar_pub','P') is not null
BEGIN
	drop proc BE_SHARPS.insertar_pub
	print 'BE_SHARPS.insertar_pub fue borrado'
END	
ELSE print 'BE_SHARPS.insertar_pub no fue creado aún'

GO
create proc BE_SHARPS.insertar_pub @codigo numeric(18,0), @desc nvarchar(255)
as
begin
	INSERT INTO BE_SHARPS.Publicaciones (pub_cod, pub_desc) VALUES (@codigo,@desc)
end

GO