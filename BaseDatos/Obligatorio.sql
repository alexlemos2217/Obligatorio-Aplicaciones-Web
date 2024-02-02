
-- ╔═══════════════════════════════════════════════════════ OBLIGATORIO BASE DE DATOS ═══════════════════════════════════════════════════════╗ --
use master
go
-- ╔═══════════════════════════════════════════════════════ CREACIÓN DE LA BASE DE DATOS ═══════════════════════════════════════════════════════╗ --
-- Determina si está la base de datos Obligatorio --
if exists(select * from SysDataBases where name = 'Obligatorio')
begin
	-- Borra la base de datos --
	drop database Obligatorio
end
go

-- Crea la base de datos Obligatorio --
create database Obligatorio
go

use Obligatorio
go

-- ╔═══════════════════════════════════════════════════════ TABLAS BASE DE DATOS ═══════════════════════════════════════════════════════╗ --

-- COMPANIAS --
create table COMPANIAS
(
	nombre varchar(30) primary key,
	direccion varchar(40) not null,
	telefono varchar(9) not null
)
go

-- TERMINALES --
create table TERMINALES
(
	codigo varchar(6) primary key check(codigo LIKE '[a-z][a-z][a-z][a-z][a-z][a-z]'),
	ciudad varchar(30) not null
)
go

create table NACIONALES
(
	codigo varchar(6) foreign key references TERMINALES(codigo),
	taxis bit not null,

	primary key(codigo)
)
go

create table INTERNACIONALES
(
	codigo varchar(6) foreign key references TERMINALES(codigo),
	pais varchar(30) not null,
	
	primary key(codigo)
)
go

-- VIAJES --
CREATE TABLE VIAJES
(
    nroInterno int identity(1, 1) primary key,
    fecHorSalida datetime not null,
    fecHorLlegada datetime not null, 
    cantPasajeros int check (cantPasajeros >= 1 and cantPasajeros <= 50) not null,
    precioBoleto int check (precioBoleto >= 0) not null,
    anden int check (anden >= 1 and anden <= 35) not null,
    codigoViaje varchar(6) not null,
    nombre varchar(30) not null
    
    foreign key (codigoViaje) references TERMINALES(codigo),
    foreign key (nombre) references COMPANIAS(nombre),
    check(fecHorSalida < fecHorLlegada)
)
go


-- ╔═══════════════════════════════════════════════════════ DATOS DE PRUEBA ═══════════════════════════════════════════════════════╗ --
-- Se insertan datos en la tabla COMPANIAS --
insert into COMPANIAS (nombre, direccion, telefono) values ('Rutas del Plata', 'Virrey Arredondo 3710', '24025372'),
												 ('Núñez', 'Tres Cruces Bv. Artigas 1825', '092334222'),
												 ('Agencia Central', 'Virrey Arredondo 1263', '44748882'),
												 ('Buquebus', 'Avenida 18 de Julio 1299', '29021064'),
												 ('Cauvi', 'Avenida General Rivera 5521', '24018998'),
												 ('Chadre', 'Avenida 8 de Octubre 3744', '098824019'),
												 ('Chevial', 'Avenida Italia 3241', '096777456'),
												 ('Bruno', 'Bulevar Artigas 2276', '2925884'),
												 ('Cita', 'Bulevar España 3321', '29014402'),
												 ('Turismar', 'Avenida Luis Alberto de Herrera 2902', '22035751'),
												 ('Colonia Express', 'Avenida Luis Batlle Berres 2122', '24090999'),
												 ('Turil', 'Avenida Agraciada 980', '099872312'),
												 ('Condor', 'Convención 1399', '24038050'),
												 ('TTL', 'Colonia 1321', '46752291'),
												 ('Copa Turismo', 'Durazno 2750', '46752291'),
												 ('Sabelín', 'Río Branco 1109', '46590212'),
												 ('Copay', 'Paysandú 880', '47287743'),
												 ('Rutas del Sol', 'Río Negro 2345', '099342311'),
												 ('Copsa', 'Ciudadela 2050', '20204912'),
												 ('Nossar', 'Soriano 1234', '091223987'),
												 ('Intertur', 'Andes 779', '46425167'),
												 ('Cot', 'Mercedes 1121', '20306655'),
												 ('Expreso Minuano', 'Cerrito 1234', '092999435'),
												 ('Cotmi', 'Isla de Flores 3102', '096484897'),
												 ('Expreso Chago', 'Carlos Gardel 1590', '29018866'),
												 ('Cromin', 'Constituyente 2052', '20408845'),
												 ('Encon', 'Sarmiento 2064', '099865544'),
												 ('Cut Corporación', 'Cuareim 1133', '09143322'),
												 ('Emdal', 'San José 1321', '095442655'),
												 ('Cynsa', 'Uruguay 588', '20314866'),
												 ('El Rápido Internacional', 'Maldonado 1311', '28912212'),
												 ('El Norteño', '26 de Marzo 3018', '46778232'),
												 ('Ega', 'Avenida Brasil 2290', '47287743')
UPDATE COMPANIAS
SET telefono = '29664533'
WHERE nombre = 'Bruno';
-- Se insertan valores en la tabla TERMINALES -- 
insert into TERMINALES (codigo, ciudad) values ('rutpla', 'Rio Branco'),
											   ('nuneza', 'Melo'),
											   ('agecen', 'Montevideo'),
											   ('buqueb', 'Colonia del Sacramento'),
											   ('cauvia', 'Priápolis'),
											   ('chauno', 'Artigas'),
											   ('cheuno', 'Carmelo'),
											   ('bruuno', 'Rivera'),
											   ('cituno', 'Pando'),
											   ('turmar', 'Chuy'),
											   ('colexp', 'Colonia del Sacramento'),
											   ('turuno', 'Artigas'),
											   ('conuno', 'Tala'),
											   ('ttluno', 'Treinta y Tres'),
											   ('coptur', 'Rincón'),
											   ('sabuno', 'Vergara'),
											   ('copaya', 'Mariscala'),
											   ('rutsol', 'Piriápolis'),
											   ('copsaa', 'Sauce'),
											   ('nossar', 'Ciudad del Plata'),
											   ('intert', 'Atlántida'),
											   ('cotuno', 'El Pinar'),
											   ('expmin', 'Paso de los Toros'),
											   ('cotmia', 'Ansina'),
											   ('expcha', 'Fraile Muerto'),
											   ('cromin', 'Tranqueras'),
											   ('encona', 'Baltasar Brum'),
											   ('cutcor', 'Delta del Tigre'),
											   ('emdala', 'Pinamar'),
											   ('cynsaa', 'Trinidad'),
											   ('elrain', 'Mercedes'),
											   ('elnort', 'Rosario'),
											   ('egauno', 'Rio Branco')

-- Se insertan datos en la tabla (terminales) NACIONALES --
insert into NACIONALES (codigo, taxis) values ('rutpla', 1),
											  ('nuneza', 1),
											  ('agecen', 1),
											  ('cauvia', 0),
											  ('chauno', 0),
											  ('cituno', 1),
											  ('turmar', 0),
											  ('conuno', 0),
											  ('ttluno', 1),
											  ('coptur', 0),
											  ('sabuno', 1),
											  ('copaya', 1),
											  ('rutsol', 1),
											  ('copsaa', 1),
											  ('nossar', 0),
											  ('intert', 1),
											  ('cotuno', 0),
											  ('expmin', 1),
											  ('cotmia', 0),
											  ('expcha', 1),
											  ('cromin', 1),
											  ('encona', 0),
											  ('cutcor', 0),
											  ('emdala', 1),
											  ('cynsaa', 1),
											  ('elnort', 0)

-- Se insertan datos en la tabla (terminales) INTERNACIONALES --
insert into INTERNACIONALES (codigo, pais) values ('buqueb', 'Argentina'),
												  ('cheuno', 'Argentina'),
												  ('bruuno', 'Brasil'),
												  ('colexp', 'Argentina'),
												  ('turuno', 'Brasil'),
												  ('elrain', 'Colombia'),
												  ('egauno','Brasil')

-- Se insertan datos en la tabla VIAJES --
insert into VIAJES (fecHorSalida, fecHorLlegada, cantPasajeros, precioBoleto, anden, codigoViaje, nombre) values ('20230910 07:00:00', '20230910 13:00:00', 32, 1045, 20, 'rutpla', 'Rutas del Plata'),
																											('20230911 08:00:00', '20230911 12:00:00', 40, 780, 11, 'nuneza', 'Núñez'),
																											('20230912 10:30:00', '20230912 15:45:00', 30, 650, 22, 'agecen', 'Agencia Central'),
																											('20230913 09:15:00', '20230913 13:30:00', 33, 870, 12, 'buqueb', 'Buquebus'),
																											('20230914 11:00:00', '20230914 15:00:00', 20, 999, 30, 'cauvia', 'Cauvi'),
																											('20230915 14:45:00', '20230915 19:30:00', 44, 370, 21, 'chauno', 'Chadre'),
																											('20230901 08:00:00', '20230901 12:00:00', 50, 550, 17, 'cheuno', 'Chevial'),
																											('20230902 09:30:00', '20230902 13:30:00', 22, 670, 1, 'bruuno', 'Bruno'),
																											('20230903 10:45:00', '20230903 15:30:00', 39, 887, 5, 'cituno', 'Cita'),
																											('20230904 11:15:00', '20230904 15:45:00', 28, 490, 8, 'turmar', 'Turismar'),
																											('20230905 13:00:00', '20230905 17:30:00', 27, 2200, 10, 'colexp', 'Colonia Express'),
																											('20230906 14:30:00', '20230906 19:15:00', 45, 1100, 2, 'turuno', 'Turil'),
																											('20230907 15:45:00', '20230907 20:00:00', 28, 790, 7, 'conuno', 'Condor'),
																											('20230908 16:30:00', '20230908 21:15:00', 42, 990, 3,'ttluno', 'TTL'),
																											('20230909 17:15:00', '20230909 22:00:00', 31, 740, 13, 'coptur', 'Copa Turismo'),
																											('20230910 18:00:00', '20230910 23:00:00', 29, 599, 15, 'sabuno', 'Sabelín'),
																											('20230911 08:30:00', '20230911 12:30:00', 37, 1290, 14, 'copaya', 'Copay'),
																											('20230912 09:15:00', '20230912 13:45:00', 49, 1100, 18, 'rutsol', 'Rutas del Sol'),
																											('20230913 10:00:00', '20230913 14:00:00', 48, 1300, 16, 'copsaa', 'Copsa'),
																											('20230914 11:30:00', '20230914 16:30:00', 47, 980, 20, 'nossar', 'Nossar'),
																											('20230915 12:45:00', '20230915 17:15:00', 41, 1150, 35, 'intert', 'Intertur'),
																											('20230916 13:15:00', '20230916 18:00:00', 37, 1030, 34, 'cotuno', 'Cot'),
																											('20230917 14:00:00', '20230917 19:30:00', 36, 870, 32, 'expmin', 'Expreso Minuano'),
																											('20230918 15:30:00', '20230918 20:15:00', 39, 516, 33, 'cotmia', 'Cotmi'),
																											('20230919 16:45:00', '20230919 21:30:00', 27, 216, 29, 'expcha', 'Expreso Chago'),
																											('20230920 17:30:00', '20230920 22:45:00', 33, 450, 28, 'cromin', 'Cromin'),
																											('20230921 08:45:00', '20230921 13:30:00', 25, 880, 27, 'encona', 'Encon'),
																											('20230922 09:30:00', '20230922 14:15:00', 38, 930, 26, 'cutcor', 'Cut Corporación'),
																											('20230923 10:15:00', '20230923 15:00:00', 40, 1100, 25, 'emdala', 'Emdal'),
																											('20230924 11:45:00', '20230924 16:30:00', 29, 1312, 24, 'cynsaa', 'Cynsa'),
																											('20230925 12:30:00', '20230925 17:15:00', 48, 1690, 23, 'elrain', 'El Rápido Internacional'),
																											('20230926 13:15:00', '20230926 18:00:00', 28, 870, 19, 'elnort', 'El Norteño'),
																											('20230927 14:45:00', '20230927 19:30:00', 49, 1790, 4, 'egauno', 'Ega')
go
-- ╔═══════════════════════════════════════════════════════ COMPAÑIA ═══════════════════════════════════════════════════════╗ --
 -- Agregar -- 
CREATE PROCEDURE AgregarCompania
@Nombre varchar(30),
@Direccion varchar(40),
@Telefono int
AS
BEGIN 
	if EXISTS (SELECT nombre FROM Companias WHERE nombre = @nombre)
		RETURN -1
	
	INSERT INTO COMPANIAS(nombre, direccion, telefono) VALUES(@Nombre, @Direccion, @Telefono)
	IF(@@Error <> 0)
		RETURN -2
END
GO

-- Modificar --
CREATE PROCEDURE ModificarCompania
@Nombre varchar(30),
@Direccion varchar(30),
@Telefono int
AS
BEGIN
	if NOT EXISTS (SELECT nombre FROM COMPANIAS WHERE nombre = @nombre)
		return -1

	else
	begin
		UPDATE COMPANIAS SET direccion = @Direccion, telefono = @Telefono WHERE nombre = @Nombre
		if @@ERROR <> 0
		return -2

		return 1
	END
END
GO

-- Buscar --
CREATE PROCEDURE BuscarCompania
@nombre varchar(30)
AS
BEGIN
	SELECT *
	FROM COMPANIAS
	WHERE nombre = @nombre
END
GO

-- Eliminar --
CREATE PROCEDURE EliminarCompania
    @nombre VARCHAR(30)
AS
BEGIN
    DECLARE @Error INT;

    -- Verificar si la compañía no existe
    IF NOT EXISTS (SELECT nombre FROM COMPANIAS WHERE nombre = @nombre)
    BEGIN
        SET @Error = -1;
        RETURN @Error;
    END

    -- Verificar si la compañía está asociada a algún viaje
    IF EXISTS (SELECT nombre FROM VIAJES WHERE nombre = @nombre)
    BEGIN
        SET @Error = -2;
        RETURN @Error;
    END

    -- Intentar eliminar la compañía
    BEGIN TRAN

    DELETE COMPANIAS WHERE nombre = @nombre
    SET @Error = @@ERROR;

    -- Verificar si hubo algún error durante la eliminación
    IF (@Error = 0)
    BEGIN
        COMMIT TRAN;
        RETURN 1; -- Éxito
    END
    ELSE
    BEGIN
        ROLLBACK TRAN;
        RETURN -3; -- Error durante la eliminación
    END
END
GO

-- Listar --
CREATE PROCEDURE ListarCompanias
AS
BEGIN
	SELECT *
	FROM COMPANIAS
END
GO
																										
-- ╔═══════════════════════════════════════════════════════ TERMINALES ═══════════════════════════════════════════════════════╗ --
-- Agregar --
CREATE PROCEDURE AgregarTerminalNacional
@Codigo varchar(6),
@NombreCiudad varchar(30),
@Taxi bit
AS
BEGIN
	IF EXISTS (SELECT codigo FROM TERMINALES WHERE codigo = @Codigo)
		RETURN -1

	DECLARE @Error int

	BEGIN TRAN

	INSERT TERMINALES(codigo, ciudad) VALUES(@Codigo, @NombreCiudad)
	SET @Error = @@ERROR

	INSERT NACIONALES(codigo, taxis) VALUES(@Codigo, @Taxi)
	SET @Error += @@ERROR

	IF(@Error = 0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -2
	END	
END
GO

CREATE PROCEDURE AgregarTerminalInternacional
@Codigo varchar(6),
@NombreCiudad varchar(30),
@Pais varchar(50)
AS
BEGIN
	IF EXISTS (SELECT codigo FROM TERMINALES WHERE codigo = @Codigo)
		RETURN -1

	DECLARE @Error int

	BEGIN TRAN

	INSERT TERMINALES(codigo, ciudad) VALUES(@Codigo, @NombreCiudad)
	SET @Error = @@ERROR

	INSERT INTERNACIONALES(codigo, pais) VALUES(@Codigo, @Pais)
	SET @Error += @@ERROR

	IF(@Error = 0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -2
	END	
END
GO

-- Buscar --
CREATE PROCEDURE BuscarTerminalNacional
    @Codigo VARCHAR(6)
AS
BEGIN
    SELECT TER.codigo,
           TER.ciudad,
           NAT.taxis
    FROM Terminales AS TER
    INNER JOIN Nacionales AS NAT
        ON TER.codigo = NAT.codigo
    WHERE TER.codigo = @Codigo;
END
GO

CREATE PROCEDURE BuscarTerminalInternacional
    @Codigo VARCHAR(6)
AS
BEGIN
    SELECT TER.codigo,
           TER.ciudad,
           INT.pais
    FROM Terminales AS TER
    INNER JOIN Internacionales AS INT
        ON TER.codigo = INT.codigo
    WHERE TER.codigo = @Codigo;
END
GO

-- Modificar --
CREATE PROCEDURE ModificarTerminalNacional
@codigo varchar(6),
@NombreCiudad varchar(30),
@taxi bit
AS
BEGIN
	IF NOT EXISTS (SELECT codigo FROM NACIONALES WHERE codigo = @codigo)
		RETURN -1

	DECLARE @Error int
	
	BEGIN TRAN

	UPDATE NACIONALES
	SET taxis = @taxi
	WHERE codigo = @codigo
	SET @Error = @@ERROR

	UPDATE TERMINALES 
	SET ciudad = @NombreCiudad 
	WHERE codigo = @codigo
	SET @Error += @@ERROR

	IF(@Error = 0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -2
	END	
END
GO

CREATE PROCEDURE ModificarTerminalInternacional
@codigo varchar(6),
@NombreCiudad varchar(30),
@Pais varchar (30)
AS
BEGIN
	IF NOT EXISTS (SELECT codigo FROM INTERNACIONALES WHERE codigo = @codigo)
		RETURN -1

	DECLARE @Error int
	
	BEGIN TRAN

	UPDATE INTERNACIONALES
	SET pais = @Pais
	WHERE codigo = @codigo
	SET @Error = @@ERROR

	UPDATE TERMINALES 
	SET ciudad = @NombreCiudad 
	WHERE codigo = @codigo
	SET @Error += @@ERROR

	IF(@Error = 0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END
	
	ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -2
	END	
END
GO

-- Eliminar
CREATE PROCEDURE EliminarTerminal
@codigo varchar(6)
AS
BEGIN
	
	IF NOT EXISTS (SELECT codigo FROM TERMINALES where codigo = @codigo)
		return -1

	IF EXISTS (SELECT codigoViaje FROM VIAJES WHERE codigoViaje = @codigo)
		return -2

	DECLARE @Error int

	BEGIN TRAN
	DELETE NACIONALES WHERE codigo = @codigo
	SET @Error = @@ERROR

	DELETE INTERNACIONALES WHERE codigo = @codigo
	SET @Error += @@Error

	DELETE TERMINALES WHERE codigo = @codigo
	SET @Error += @@Error

	IF(@Error = 0)
	BEGIN
		COMMIT TRAN
		RETURN 1
	END

		ELSE
	BEGIN
		ROLLBACK TRAN
		RETURN -3
	END	

END
GO


-- Listar --
CREATE PROCEDURE ListarTerminalesNacionales
AS
BEGIN 
    SELECT TE.CODIGO, TE.CIUDAD, NAT.taxis
    FROM TERMINALES AS TE 
    INNER JOIN NACIONALES AS NAT ON TE.CODIGO = NAT.CODIGO;
END
GO

CREATE PROCEDURE ListarTerminalesInternacionales
AS
BEGIN 
    SELECT TE.CODIGO, TE.CIUDAD, INT.pais
    FROM TERMINALES AS TE 
    INNER JOIN INTERNACIONALES AS INT ON TE.CODIGO = INT.CODIGO;
END
GO

-- ╔═══════════════════════════════════════════════════════ VIAJE ═══════════════════════════════════════════════════════╗ --
-- Agregar --
CREATE PROCEDURE AgregarViaje
    @fecHoraSalida DATETIME,
    @fecHoraLlegada DATETIME,
    @cantPasajeros INT,
    @precioBoleto DECIMAL(18, 2),
    @anden INT,
    @codigoViaje VARCHAR(6),
    @nombre VARCHAR(50),
    @nroInterno INT OUTPUT
AS
BEGIN
    DECLARE @retorno INT

    -- Verificar si la terminal existe
    IF NOT EXISTS (SELECT * FROM TERMINALES WHERE UPPER(LTRIM(RTRIM(codigo))) = UPPER(LTRIM(RTRIM(@codigoViaje))))
    BEGIN
        SET @retorno = -1
        GOTO Salir
    END

    -- Verificar si la compañía existe
    IF NOT EXISTS (SELECT * FROM COMPANIAS WHERE UPPER(LTRIM(RTRIM(nombre))) = UPPER(LTRIM(RTRIM(@nombre))))
    BEGIN
        SET @retorno = -2
        GOTO Salir
    END

    -- Verificar cantidad de pasajeros
    IF @cantPasajeros < 1 OR @cantPasajeros > 50
    BEGIN
        SET @retorno = -3
        GOTO Salir
    END

    -- Verificar precio del boleto
    IF @precioBoleto < 0
    BEGIN
        SET @retorno = -4
        GOTO Salir
    END

    -- Verificar anden
    IF @anden < 1 OR @anden > 35
    BEGIN
        SET @retorno = -5
        GOTO Salir
    END

    -- Verificar fechas
    IF @fecHoraSalida >= @fecHoraLlegada
    BEGIN
        SET @retorno = -6
        GOTO Salir
    END

    -- Con los controles realizados, se inserta el nuevo viaje
    INSERT INTO VIAJES (fecHorSalida, fecHorLlegada, cantPasajeros, precioBoleto, anden, codigoViaje, nombre)
    VALUES (@fecHoraSalida, @fecHoraLlegada, @cantPasajeros, @precioBoleto, @anden, @codigoViaje, @nombre)

    -- Devolver el número interno como resultado
    SET @nroInterno = SCOPE_IDENTITY()

    -- Devolver el número interno como resultado
    SET @retorno = @nroInterno

    Salir:
    RETURN @retorno
END
GO

-- Modificar --
CREATE PROCEDURE ModificarViaje
@codigoTerminal varchar(6),
@fecHorSalida datetime, 
@fecHoraLlegada datetime,
@cantPasajeros int,
@precioBoleto DECIMAL(18, 2),
@anden int
as
begin
	-- Verificar si el viaje existe
	if NOT exists (select * from VIAJES where codigoViaje = @codigoTerminal)
	begin
		return -1
	end

	-- Verificar si el viaje ya se ha realizado
	if @fecHorSalida < GETDATE()
	begin
		return -2
	end

	-- Modificación del viaje
	UPDATE VIAJES
	SET
		fecHorSalida = @fecHorSalida,
		fecHorLlegada = @fecHoraLlegada,
		cantPasajeros = @cantPasajeros,
		precioBoleto = @precioBoleto,
		anden = @anden
	where
		codigoViaje = @codigoTerminal;
	if (@@ERROR != 0)
	begin
		return -3
	end

	return 1

end
GO

-- Listar --
CREATE PROCEDURE ListadoViajes
    @mes INT,
    @anio INT,
    @codigoTerminal VARCHAR(50)
AS
BEGIN
    SELECT
        VIAJES.nroInterno,
        VIAJES.fecHorSalida,
        VIAJES.fecHorLlegada,
        VIAJES.cantPasajeros,
        VIAJES.precioBoleto,
        VIAJES.anden,
        VIAJES.codigoViaje,
        VIAJES.nombre,
        TERMINALES.ciudad,
        COMPANIAS.direccion,
        COMPANIAS.telefono

    FROM
        VIAJES
    INNER JOIN
        TERMINALES ON VIAJES.codigoViaje = TERMINALES.codigo
    INNER JOIN
        COMPANIAS ON VIAJES.nombre = COMPANIAS.nombre

    WHERE
        MONTH(VIAJES.fecHorSalida) = @mes
        AND YEAR(VIAJES.fecHorSalida) = @anio
        AND TERMINALES.codigo = @codigoTerminal
END
GO

