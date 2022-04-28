/****************************************************************************************************************************
												CREATES DATABASE
****************************************************************************************************************************/

USE master;
GO

IF DB_ID (N'notown') IS NOT NULL DROP DATABASE notown;
GO

CREATE DATABASE notown COLLATE Latin1_general_CI_AI;
GO

USE notown;
GO

/****************************************************************************************************************************
												CREATES TABLES
****************************************************************************************************************************/

CREATE TABLE tb_address (
	tb_address_id INT PRIMARY KEY IDENTITY (1,1),
	description VARCHAR(MAX) NOT NULL,
	phone VARCHAR(15) NOT NULL,
	created_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	updated_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	created_by INT,
	updated_by INT
	CONSTRAINT UQ_phone UNIQUE (phone)
);

CREATE TABLE tb_musician (
	tb_musician_id INT PRIMARY KEY IDENTITY (1,1),
	inss_number VARCHAR(20) NOT NULL,
	first_name VARCHAR(500) NOT NULL,
	last_name VARCHAR(500) NOT NULL,
	salary FLOAT NOT NULL,
	tb_address_id INT NOT NULL,
	created_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	updated_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	created_by INT,
	updated_by INT
	FOREIGN KEY (tb_address_id) REFERENCES tb_address (tb_address_id),
	CONSTRAINT UQ_inss_number UNIQUE (inss_number)
);

CREATE TABLE tb_instrument (
	tb_instrument_id INT PRIMARY KEY IDENTITY (1,1),
	name VARCHAR(500) NOT NULL,
	music_key VARCHAR(100) NOT NULL,
	created_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	updated_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	created_by INT,
	updated_by INT
);

CREATE TABLE tb_musician_instrument (
	tb_musician_id INT NOT NULL,
	tb_instrument_id INT NOT NULL,
	created_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	updated_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	created_by INT,
	updated_by INT,
	FOREIGN KEY (tb_musician_id) REFERENCES tb_musician (tb_musician_id),
	FOREIGN KEY (tb_instrument_id) REFERENCES tb_instrument (tb_instrument_id)
);

CREATE TABLE tb_album (
	tb_album_id INT PRIMARY KEY IDENTITY (1,1),
	title VARCHAR(500) NOT NULL,
	format VARCHAR(50) NOT NULL,
	copyright_date DATETIME NOT NULL,
	identifier VARCHAR(100) NOT NULL,
	tb_musician_id INT NOT NULL,
	created_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	updated_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	created_by INT,
	updated_by INT,
	FOREIGN KEY (tb_musician_id) REFERENCES tb_musician (tb_musician_id)
);


CREATE TABLE tb_song (
	tb_song_id INT PRIMARY KEY IDENTITY (1,1),
	title VARCHAR(500) NOT NULL,
	created_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	updated_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	created_by INT,
	updated_by INT
);


CREATE TABLE tb_musician_song (
	tb_musician_id INT NOT NULL,
	tb_song_id INT NOT NULL,
	is_author CHAR(1),
	is_performer CHAR(1),
	created_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	updated_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	created_by INT,
	updated_by INT,
	CONSTRAINT CHECK_is_author CHECK (is_author = 'F' OR is_author = 'T'),
	CONSTRAINT CHECK_is_performer CHECK (is_performer = 'F' OR is_performer = 'T'),
	FOREIGN KEY (tb_musician_id) REFERENCES tb_musician (tb_musician_id),
	FOREIGN KEY (tb_song_id) REFERENCES tb_song (tb_song_id)
);


CREATE TABLE tb_album_song (
	tb_album_id INT NOT NULL,
	tb_song_id INT NOT NULL,
	created_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	updated_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	created_by INT,
	updated_by INT,
	FOREIGN KEY (tb_album_id) REFERENCES tb_album (tb_album_id),
	FOREIGN KEY (tb_song_id) REFERENCES tb_song (tb_song_id)
);

CREATE TABLE tb_artist (
	tb_artist_id INT PRIMARY KEY IDENTITY (1,1),
	alias VARCHAR(500) NOT NULL,
	first_name VARCHAR(500) NOT NULL,
	last_name VARCHAR(500) NOT NULL,
	type VARCHAR(50) NOT NULL,
	created_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	updated_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	created_by INT,
	updated_by INT
	CONSTRAINT UQ_alias UNIQUE (alias),
	CONSTRAINT CHECK_type CHECK (type = 'Solista' OR type = 'Banda')
);

CREATE TABLE tb_artist_album (
	tb_artist_id INT NOT NULL,
	tb_album_id INT NOT NULL,
	created_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	updated_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	created_by INT,
	updated_by INT,
	FOREIGN KEY (tb_artist_id) REFERENCES tb_artist (tb_artist_id),
	FOREIGN KEY (tb_album_id) REFERENCES tb_album (tb_album_id)
);

CREATE TABLE tb_artist_song (
	tb_artist_id INT NOT NULL,
	tb_song_id INT NOT NULL,
	is_author CHAR(1),
	is_performer CHAR(1),
	is_guest CHAR(1),
	created_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	updated_at DATETIME NOT NULL DEFAULT SYSDATETIME(),
	created_by INT,
	updated_by INT,
	CONSTRAINT CHECK_artist_is_author CHECK (is_author = 'F' OR is_author = 'T'),
	CONSTRAINT CHECK_artist_is_performer CHECK (is_performer = 'F' OR is_performer = 'T'),
	CONSTRAINT CHECK_artist_is_guest CHECK (is_guest = 'F' OR is_guest = 'T'),
	FOREIGN KEY (tb_artist_id) REFERENCES tb_artist (tb_artist_id),
	FOREIGN KEY (tb_song_id) REFERENCES tb_song (tb_song_id)
);

/****************************************************************************************************************************
												INSERTS DATA
****************************************************************************************************************************/

DELETE FROM tb_address;
GO
BULK INSERT tb_address
FROM 'E:\csv_to_sql\address_data.csv'
WITH
(
     FIELDTERMINATOR = ',', 
     ROWTERMINATOR = '\n', 
	 FIRSTROW = 2
)
GO


DELETE FROM tb_musician;
GO
BULK INSERT tb_musician
FROM 'E:\csv_to_sql\musician_data.csv'
WITH
(
     FIELDTERMINATOR = ',', 
     ROWTERMINATOR = '\n', 
	 FIRSTROW = 2
)
GO


DELETE FROM tb_instrument;
GO
BULK INSERT tb_instrument
FROM 'E:\csv_to_sql\instrument_data.csv'
WITH
(
     FIELDTERMINATOR = ',', 
     ROWTERMINATOR = '\n', 
	 FIRSTROW = 2,
	 CODEPAGE = '65001'
)
GO


TRUNCATE TABLE tb_musician_instrument;
GO
BULK INSERT tb_musician_instrument
FROM 'E:\csv_to_sql\instrument_musician_data.csv'
WITH
(
     FIELDTERMINATOR = ',', 
     ROWTERMINATOR = '\n', 
	 FIRSTROW = 2
)
GO


DELETE FROM tb_artist;
GO
BULK INSERT tb_artist
FROM 'E:\csv_to_sql\artist_data.csv'
WITH
(
     FIELDTERMINATOR = ',', 
     ROWTERMINATOR = '\n', 
	 FIRSTROW = 2,
	 CODEPAGE = '65001'
)
GO


DELETE FROM tb_album;
GO
BULK INSERT tb_album
FROM 'E:\csv_to_sql\album_data.csv'
WITH
(
     FIELDTERMINATOR = ',', 
     ROWTERMINATOR = '\n', 
	 FIRSTROW = 2,
	 CODEPAGE = '65001'
)
GO


DELETE FROM tb_song;
GO
BULK INSERT tb_song
FROM 'E:\csv_to_sql\song_data.csv'
WITH
(
     FIELDTERMINATOR = ',', 
     ROWTERMINATOR = '\n', 
	 FIRSTROW = 2,
	 CODEPAGE = '65001'
)
GO


TRUNCATE TABLE tb_album_song;
GO
BULK INSERT tb_album_song
FROM 'E:\csv_to_sql\album_song_data.csv'
WITH
(
     FIELDTERMINATOR = ',', 
     ROWTERMINATOR = '\n', 
	 FIRSTROW = 2
)
GO


TRUNCATE TABLE tb_musician_song;
GO
BULK INSERT tb_musician_song
FROM 'E:\csv_to_sql\musician_song_data.csv'
WITH
(
     FIELDTERMINATOR = ',', 
     ROWTERMINATOR = '\n', 
	 FIRSTROW = 2
)
GO


TRUNCATE TABLE tb_artist_album;
GO
BULK INSERT tb_artist_album
FROM 'E:\csv_to_sql\artist_album_data.csv'
WITH
(
     FIELDTERMINATOR = ',', 
     ROWTERMINATOR = '\n', 
	 FIRSTROW = 2
)
GO


TRUNCATE TABLE tb_artist_song;
GO
BULK INSERT tb_artist_song
FROM 'E:\csv_to_sql\artist_song_data.csv'
WITH
(
     FIELDTERMINATOR = ',', 
     ROWTERMINATOR = '\n', 
	 FIRSTROW = 2
)
GO


/****************************************************************************************************************************
												CREATES VIEWS
****************************************************************************************************************************/


--�Cu�l es el m�sico mejor pagado y qu� instrumento toca?

CREATE OR ALTER VIEW vw_best_payed_musician AS
WITH max_salary AS (SELECT MAX(salary) "value" FROM tb_musician)
SELECT msc.tb_musician_id "id", CONCAT(msc.first_name, ' ', msc.last_name) "musician", msc.inss_number,
	msc.salary, STRING_AGG(inst.name, ', ') "instruments"
FROM max_salary JOIN tb_musician "msc" ON msc.salary = max_salary.value
LEFT JOIN tb_musician_instrument "msc_inst" ON msc_inst.tb_musician_id = msc.tb_musician_id
LEFT JOIN tb_instrument "inst" ON inst.tb_instrument_id = msc_inst.tb_instrument_id
GROUP BY msc.tb_musician_id, msc.first_name, msc.last_name, msc.inss_number, msc.salary;
GO

--�Cu�ntos m�sicos mal pagados (con salario menor a $500) habitan por cada direcci�n y cu�l es el tel�fono?

CREATE OR ALTER VIEW vw_bad_payed_musician_addresses AS
SELECT ad.description "address", ad.phone, COUNT(msc.tb_address_id) "musicians"
FROM tb_address "ad" LEFT JOIN tb_musician "msc" ON ad.tb_address_id = msc.tb_address_id
WHERE msc.salary < 500 GROUP BY ad.description, ad.phone;
GO
--�Cu�les son los instrumentos que son tocados por m�s de dos m�sicos?

CREATE OR ALTER VIEW vw_instruments_by_musicians AS
SELECT inst.name "instrument", COUNT(msc_inst.tb_instrument_id) "quantity", STRING_AGG(CONCAT(msc.first_name, ' ', msc.last_name), ', ') "musicians"
FROM tb_instrument "inst" LEFT JOIN tb_musician_instrument "msc_inst" ON msc_inst.tb_instrument_id = inst.tb_instrument_id
LEFT JOIN tb_musician "msc" ON msc.tb_musician_id = msc_inst.tb_musician_id
GROUP BY inst.name HAVING COUNT(msc_inst.tb_instrument_id) > 2;
GO

--�Cu�ntas canciones ha interpretado cada m�sico?

CREATE OR ALTER VIEW vw_songs_by_musicians AS
SELECT CONCAT(msc.first_name, ' ', msc.last_name) "musician", COUNT(msc_sg.tb_song_id) "songs"
FROM tb_song "sg" JOIN tb_musician_song "msc_sg" ON msc_sg.tb_song_id = sg.tb_song_id
JOIN tb_musician "msc" ON msc.tb_musician_id = msc_sg.tb_musician_id
WHERE msc_sg.is_performer = 'T' GROUP BY msc.first_name, msc.last_name;
GO

--�Qu� artistas han grabado en esta casa productora y cu�les son sus �lbumes?

CREATE OR ALTER VIEW vw_artists_with_albums AS
SELECT art.alias, CONCAT(art.first_name, ' ', art.last_name) "fullname", STRING_AGG(alb.title, ' | ') "albums"
FROM tb_artist "art" LEFT JOIN tb_artist_album "art_alb" ON art_alb.tb_artist_id = art.tb_artist_id
JOIN tb_album "alb" ON alb.tb_album_id = art_alb.tb_album_id
GROUP BY art.alias, art.first_name, art.last_name;
GO

-- �Cu�l ha sido la inversi�n por cada �lbum (teniendo en cuenta los gastos en m�sicos y productores) y cu�ntas canciones incluye?

CREATE OR ALTER VIEW vw_albums_with_costs AS
SELECT alb.title "album", COUNT(alb_sg.tb_song_id) "songs", prod.salary "producer_cost", COALESCE(SUM(perf.salary), 0) "musicians_costs"
FROM tb_album "alb" LEFT JOIN tb_album_song "alb_sg" ON alb_sg.tb_album_id = alb.tb_album_id
LEFT JOIN tb_song "sg" ON sg.tb_song_id = alb_sg.tb_song_id
JOIN tb_musician "prod" ON prod.tb_musician_id = alb.tb_musician_id
LEFT JOIN tb_musician_song "msc_sg" ON msc_sg.tb_song_id = sg.tb_song_id
LEFT JOIN tb_musician "perf" ON perf.tb_musician_id = msc_sg.tb_musician_id
GROUP BY alb.title, prod.salary;
GO

/****************************************************************************************************************************
												TRANSACTIONS
****************************************************************************************************************************/


CREATE TABLE tb_user ( --Creando tabla de usuarios
	tb_user_id INT PRIMARY KEY IDENTITY (1,1), --Llave primaria autoincrementable
	name VARCHAR(20) NOT NULL, --Nombre de usuario
	password VARCHAR(200) NOT NULL, --Contrase�a
	is_active CHAR(1) NOT NULL DEFAULT 'F', --Bandera que indica si un usario est� activo o inactivo
	created_at DATETIME NOT NULL DEFAULT SYSDATETIME(), --Fecha de creaci�n
	updated_at DATETIME NOT NULL DEFAULT SYSDATETIME(), --Fecha de actualizaci�n
	created_by INT, --Usuario que creo el registro
	updated_by INT, --Usuario que actualiz� el registro
	CONSTRAINT check_user_active CHECK (is_active = 'T' OR is_active = 'F'),
	CONSTRAINT UQ_name UNIQUE (name) --Validaci�n para nombre de usuario �nico
);


TRUNCATE TABLE tb_user; --Vaciando tabla usuarios
GO
BULK INSERT tb_user --Importando datos para la tabla usuarios
FROM 'E:\csv_to_sql\user_data.csv' --Desde un archivo .csv (Valores Separados por Comas)
WITH
(
     FIELDTERMINATOR = ',', --Terminador de campo (coma)
     ROWTERMINATOR = '\n', --Terminador de fila (nueva l�nea)
	 FIRSTROW = 2 --Especifica el n�mero de la primera fila a cargar
)
GO


CREATE OR ALTER PROCEDURE login_procedure --Declaraci�n del procedimiento almacenado
	@name VARCHAR(20), --Par�metro que recibe el nombre del usuario
	@password VARCHAR(200) --Par�metro que recide la contrase�a
AS
	DECLARE @id INT; --Declaraci�n de una variable para guardar el id del usuario encontrado
	
	SET @id = (SELECT u.tb_user_id FROM tb_user u WHERE u.name = @name AND u.password = @password);
	--Asigna el valor del id del usuario encontrado a la variable

	UPDATE tb_user SET is_active = CASE WHEN is_active = 'F' THEN 'T' ELSE 'F' END WHERE tb_user_id = @id;
	--Cambia el estado del usuario (indicado en la bandera "is_active") si el id es v�lido
GO


EXECUTE login_procedure 'Elwyn', 'user74587';
--Ejecuta procedimiento para iniciar sesi�n con usuario y contrase�a


SELECT alb.title "�lbum", --Selecciona el t�tulo del �lbum, renombrando el campo con el alias "�lbum"
COUNT(alb_sg.tb_album_id) "# Canciones" --Funci�n de agregaci�n para contar las canciones por �lbum
FROM tb_album alb --Selecciona desde la tabla �lbum con el alias "alb"
JOIN tb_album_song alb_sg ON alb.tb_album_id = alb_sg.tb_album_id
--Combinando tabla �lbum_canciones con el alias "alb_sg" con tabla �lbum a trav�s de la llave primaria
GROUP BY alb.title; --Agrupando por la columna t�tulo que no est� incluida en la funci�n de agregaci�n


ALTER TABLE tb_album ADD songs_quant INT DEFAULT 0;
--A�ade columna cantidad de canciones "songs_quant" a tabla �lbum con el valor 0 por defecto


CREATE OR ALTER TRIGGER songs_quantity_trigger --Declara el disparador para actualizar el n�mero de canciones
ON tb_album_song --A�adiendo disparador a la tabla �lbum canciones
FOR INSERT, UPDATE, DELETE
--Especifica la activaci�n del disparador para las operaciones de inserci�n, actualizaci�n y eliminaci�n
AS
BEGIN
	DECLARE @id INT;
	--Declara una variable para almacenar el id del album sobre el que se realiza la operaci�n

	IF EXISTS (SELECT * FROM INSERTED)
	--Verifica si la tabla virtual INSERTED posee alg�n valor
	--"INSERTED" contiene los valores recientemente insertados o actualizados
	--"DELETED" contiene los valores recientemente eliminados

		SELECT @id = tb_album_id FROM INSERTED
		--Guarda en la variable el id del �lbum insertado o actualizado
	ELSE
		SELECT @id = tb_album_id FROM DELETED
		--Guarda el id del �lbum eliminado

	EXEC auxiliar_procedure @id;
	--Ejecuta procedimiento y manda como parametro el id del �lbum
END
GO


CREATE OR ALTER PROCEDURE auxiliar_procedure --Declara el procedimiento almacenado a ejecutarse en el trigger
@id INT --Recibe como par�metro el id del �lbum a modificar
AS
	BEGIN
		UPDATE tb_album SET songs_quant = --Actualiza la cantidad de canciones en un �lbum
		( SELECT COUNT(alb_sg.tb_album_id) FROM  tb_album_song alb_sg WHERE tb_album_id = @id )
		--Utiliza subquery para obtener el total de filas que poseen el id de �lbum recibido por par�metro
		WHERE tb_album_id = @id
		--Agrega condici�n para actualizar s�lo el �lbum que se recibe por par�metro
	END
GO


DELETE FROM tb_album_song  WHERE tb_album_id = 5;
--Ejecuta una operaci�n sobre la tabla �lbum_canciones para probar el trigger



CREATE OR ALTER PROCEDURE songs_procedure --Declara procedimiento para transacciones sobre tabla canciones
	@f INT, --Recibe como par�metro una bandera que utilizada en el condicional decidir� que operaci�n realizar
	@song_id INT, --Recibe como par�metro el id de la canci�n a actualizar o eliminar
	@title VARCHAR(500), --Recibe el t�tulo de la canci�n
	@created_by INT,  --Recibe el id del usuario que crea el registro
	@updated_by INT --Recibe el usuario que actualiza el registro
AS
BEGIN
	SET NOCOUNT ON;

	IF @f = 1
	--Verifica que el valor de la bandera es 1 para realizar la operaci�n de inserci�n
	INSERT INTO tb_song (title, created_by, updated_by) VALUES (@title, @created_by, @updated_by);

	IF @f = 2
	--Verifica que la bandera sea igual a 2 para actualizar
	UPDATE tb_song SET title = @title, updated_by = @updated_by WHERE tb_song_id = @song_id;

	ELSE
	--Realiza la operaci�n de eliminaci�n cuando la bandera es diferente de 1 y 2
	DELETE FROM tb_song WHERE tb_song_id = @song_id;

END
GO



EXEC songs_procedure 1, 0, 'Hate me', 1, 1;
--Ejecuta procedimiento para realizar la operaci�n de inserci�n

EXEC songs_procedure 2, 51, 'That day', 1, 1;
--Ejecuta procedimiento con bandera = 2 para realizar operaci�n de actualizaci�n

EXEC songs_procedure 3, 51, '', 1, 1;
--Llamada al procedimiento para operaci�n de eliminaci�n



CREATE OR ALTER FUNCTION fn_get_albums_by_artist (@artist_id INT) --Declara sentencia para crear funci�n con par�metro (id artista)
RETURNS TABLE --Especifica que el valor de retorno es de tipo tabla
AS
RETURN --Define la consulta de la funci�n
(
    SELECT alb.title "T�tulo", alb.format "Formato", YEAR(alb.copyright_date) "A�o", --Selecciona t�tulo, formato y a�o del �lbum
	CONCAT(prod.first_name, ' ', prod.last_name) "Productor", alb.songs_quant "# Canciones" --Selecciona nombre productor de la tabla m�sico
 	FROM tb_album alb --Llama datos desde la tabla �lbum y asigna alias "alb"
	JOIN tb_musician prod ON prod.tb_musician_id = alb.tb_musician_id --Une las tablas �lbum y m�sico para obtener el productor del �lbum
	JOIN tb_artist_album art_alb ON art_alb.tb_album_id = alb.tb_album_id --Une las tabla �lbum con la tabla auxiliar �lbum artista
	WHERE art_alb.tb_artist_id = @artist_id --Define condici�n para obtener s�lo los �lbumes del artista que se recibe como par�metro
);
GO


SELECT * FROM fn_get_albums_by_artist(2);
--Llama la funci�n para obtener los �lbumes del artista con id = 2



CREATE OR ALTER VIEW vw_songs_by_year AS --Crea vista
SELECT TOP 1000 STRING_AGG(songs.title, ', ') "Canci�n", --Selecciona canciones y las junta en una fila con funci�n de agregaci�n
songs.month "Mes" --Selecciona el mes desde la subconsulta
FROM ( --Crea una subconsulta para agrupar las canciones por mes
	SELECT sg.title "title", --Selecciona el t�tulo de la canci�n con el alias "title" para acceder en la consulta principal
	FORMAT(sg.created_at, 'MMMM', 'es-es') "month", --Extrae el nombre del mes en idioma espa�ol desde la fecha de creaci�n
	MONTH(sg.created_at) "number" --Extrae el n�mero del mes para luego ordenar los registros
	FROM tb_song sg
	WHERE YEAR(sg.created_at) = 2021 --Extrae el a�o de la fecha para establecer la condici�n
) songs --A�ade un alias a la subconsulta para acceder a los datos
GROUP BY songs.month, songs.number --Agrupa las filas por el mes
ORDER BY songs.number; --Ordena las filas por el mes de forma ascendente


SELECT * FROM vw_songs_by_year; --Llama la vista para visualizar los datos
