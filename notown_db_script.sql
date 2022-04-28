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


--¿Cuál es el músico mejor pagado y qué instrumento toca?

CREATE OR ALTER VIEW vw_best_payed_musician AS
WITH max_salary AS (SELECT MAX(salary) "value" FROM tb_musician)
SELECT msc.tb_musician_id "id", CONCAT(msc.first_name, ' ', msc.last_name) "musician", msc.inss_number,
	msc.salary, STRING_AGG(inst.name, ', ') "instruments"
FROM max_salary JOIN tb_musician "msc" ON msc.salary = max_salary.value
LEFT JOIN tb_musician_instrument "msc_inst" ON msc_inst.tb_musician_id = msc.tb_musician_id
LEFT JOIN tb_instrument "inst" ON inst.tb_instrument_id = msc_inst.tb_instrument_id
GROUP BY msc.tb_musician_id, msc.first_name, msc.last_name, msc.inss_number, msc.salary;
GO

--¿Cuántos músicos mal pagados (con salario menor a $500) habitan por cada dirección y cuál es el teléfono?

CREATE OR ALTER VIEW vw_bad_payed_musician_addresses AS
SELECT ad.description "address", ad.phone, COUNT(msc.tb_address_id) "musicians"
FROM tb_address "ad" LEFT JOIN tb_musician "msc" ON ad.tb_address_id = msc.tb_address_id
WHERE msc.salary < 500 GROUP BY ad.description, ad.phone;
GO
--¿Cuáles son los instrumentos que son tocados por más de dos músicos?

CREATE OR ALTER VIEW vw_instruments_by_musicians AS
SELECT inst.name "instrument", COUNT(msc_inst.tb_instrument_id) "quantity", STRING_AGG(CONCAT(msc.first_name, ' ', msc.last_name), ', ') "musicians"
FROM tb_instrument "inst" LEFT JOIN tb_musician_instrument "msc_inst" ON msc_inst.tb_instrument_id = inst.tb_instrument_id
LEFT JOIN tb_musician "msc" ON msc.tb_musician_id = msc_inst.tb_musician_id
GROUP BY inst.name HAVING COUNT(msc_inst.tb_instrument_id) > 2;
GO

--¿Cuántas canciones ha interpretado cada músico?

CREATE OR ALTER VIEW vw_songs_by_musicians AS
SELECT CONCAT(msc.first_name, ' ', msc.last_name) "musician", COUNT(msc_sg.tb_song_id) "songs"
FROM tb_song "sg" JOIN tb_musician_song "msc_sg" ON msc_sg.tb_song_id = sg.tb_song_id
JOIN tb_musician "msc" ON msc.tb_musician_id = msc_sg.tb_musician_id
WHERE msc_sg.is_performer = 'T' GROUP BY msc.first_name, msc.last_name;
GO

--¿Qué artistas han grabado en esta casa productora y cuáles son sus álbumes?

CREATE OR ALTER VIEW vw_artists_with_albums AS
SELECT art.alias, CONCAT(art.first_name, ' ', art.last_name) "fullname", STRING_AGG(alb.title, ' | ') "albums"
FROM tb_artist "art" LEFT JOIN tb_artist_album "art_alb" ON art_alb.tb_artist_id = art.tb_artist_id
JOIN tb_album "alb" ON alb.tb_album_id = art_alb.tb_album_id
GROUP BY art.alias, art.first_name, art.last_name;
GO

-- ¿Cuál ha sido la inversión por cada álbum (teniendo en cuenta los gastos en músicos y productores) y cuántas canciones incluye?

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
	password VARCHAR(200) NOT NULL, --Contraseña
	is_active CHAR(1) NOT NULL DEFAULT 'F', --Bandera que indica si un usario está activo o inactivo
	created_at DATETIME NOT NULL DEFAULT SYSDATETIME(), --Fecha de creación
	updated_at DATETIME NOT NULL DEFAULT SYSDATETIME(), --Fecha de actualización
	created_by INT, --Usuario que creo el registro
	updated_by INT, --Usuario que actualizó el registro
	CONSTRAINT check_user_active CHECK (is_active = 'T' OR is_active = 'F'),
	CONSTRAINT UQ_name UNIQUE (name) --Validación para nombre de usuario único
);


TRUNCATE TABLE tb_user; --Vaciando tabla usuarios
GO
BULK INSERT tb_user --Importando datos para la tabla usuarios
FROM 'E:\csv_to_sql\user_data.csv' --Desde un archivo .csv (Valores Separados por Comas)
WITH
(
     FIELDTERMINATOR = ',', --Terminador de campo (coma)
     ROWTERMINATOR = '\n', --Terminador de fila (nueva línea)
	 FIRSTROW = 2 --Especifica el número de la primera fila a cargar
)
GO


CREATE OR ALTER PROCEDURE login_procedure --Declaración del procedimiento almacenado
	@name VARCHAR(20), --Parámetro que recibe el nombre del usuario
	@password VARCHAR(200) --Parámetro que recide la contraseña
AS
	DECLARE @id INT; --Declaración de una variable para guardar el id del usuario encontrado
	
	SET @id = (SELECT u.tb_user_id FROM tb_user u WHERE u.name = @name AND u.password = @password);
	--Asigna el valor del id del usuario encontrado a la variable

	UPDATE tb_user SET is_active = CASE WHEN is_active = 'F' THEN 'T' ELSE 'F' END WHERE tb_user_id = @id;
	--Cambia el estado del usuario (indicado en la bandera "is_active") si el id es válido
GO


EXECUTE login_procedure 'Elwyn', 'user74587';
--Ejecuta procedimiento para iniciar sesión con usuario y contraseña


SELECT alb.title "Álbum", --Selecciona el título del álbum, renombrando el campo con el alias "Álbum"
COUNT(alb_sg.tb_album_id) "# Canciones" --Función de agregación para contar las canciones por álbum
FROM tb_album alb --Selecciona desde la tabla álbum con el alias "alb"
JOIN tb_album_song alb_sg ON alb.tb_album_id = alb_sg.tb_album_id
--Combinando tabla álbum_canciones con el alias "alb_sg" con tabla álbum a través de la llave primaria
GROUP BY alb.title; --Agrupando por la columna título que no está incluida en la función de agregación


ALTER TABLE tb_album ADD songs_quant INT DEFAULT 0;
--Añade columna cantidad de canciones "songs_quant" a tabla álbum con el valor 0 por defecto


CREATE OR ALTER TRIGGER songs_quantity_trigger --Declara el disparador para actualizar el número de canciones
ON tb_album_song --Añadiendo disparador a la tabla álbum canciones
FOR INSERT, UPDATE, DELETE
--Especifica la activación del disparador para las operaciones de inserción, actualización y eliminación
AS
BEGIN
	DECLARE @id INT;
	--Declara una variable para almacenar el id del album sobre el que se realiza la operación

	IF EXISTS (SELECT * FROM INSERTED)
	--Verifica si la tabla virtual INSERTED posee algún valor
	--"INSERTED" contiene los valores recientemente insertados o actualizados
	--"DELETED" contiene los valores recientemente eliminados

		SELECT @id = tb_album_id FROM INSERTED
		--Guarda en la variable el id del álbum insertado o actualizado
	ELSE
		SELECT @id = tb_album_id FROM DELETED
		--Guarda el id del álbum eliminado

	EXEC auxiliar_procedure @id;
	--Ejecuta procedimiento y manda como parametro el id del álbum
END
GO


CREATE OR ALTER PROCEDURE auxiliar_procedure --Declara el procedimiento almacenado a ejecutarse en el trigger
@id INT --Recibe como parámetro el id del álbum a modificar
AS
	BEGIN
		UPDATE tb_album SET songs_quant = --Actualiza la cantidad de canciones en un álbum
		( SELECT COUNT(alb_sg.tb_album_id) FROM  tb_album_song alb_sg WHERE tb_album_id = @id )
		--Utiliza subquery para obtener el total de filas que poseen el id de álbum recibido por parámetro
		WHERE tb_album_id = @id
		--Agrega condición para actualizar sólo el álbum que se recibe por parámetro
	END
GO


DELETE FROM tb_album_song  WHERE tb_album_id = 5;
--Ejecuta una operación sobre la tabla álbum_canciones para probar el trigger



CREATE OR ALTER PROCEDURE songs_procedure --Declara procedimiento para transacciones sobre tabla canciones
	@f INT, --Recibe como parámetro una bandera que utilizada en el condicional decidirá que operación realizar
	@song_id INT, --Recibe como parámetro el id de la canción a actualizar o eliminar
	@title VARCHAR(500), --Recibe el título de la canción
	@created_by INT,  --Recibe el id del usuario que crea el registro
	@updated_by INT --Recibe el usuario que actualiza el registro
AS
BEGIN
	SET NOCOUNT ON;

	IF @f = 1
	--Verifica que el valor de la bandera es 1 para realizar la operación de inserción
	INSERT INTO tb_song (title, created_by, updated_by) VALUES (@title, @created_by, @updated_by);

	IF @f = 2
	--Verifica que la bandera sea igual a 2 para actualizar
	UPDATE tb_song SET title = @title, updated_by = @updated_by WHERE tb_song_id = @song_id;

	ELSE
	--Realiza la operación de eliminación cuando la bandera es diferente de 1 y 2
	DELETE FROM tb_song WHERE tb_song_id = @song_id;

END
GO



EXEC songs_procedure 1, 0, 'Hate me', 1, 1;
--Ejecuta procedimiento para realizar la operación de inserción

EXEC songs_procedure 2, 51, 'That day', 1, 1;
--Ejecuta procedimiento con bandera = 2 para realizar operación de actualización

EXEC songs_procedure 3, 51, '', 1, 1;
--Llamada al procedimiento para operación de eliminación



CREATE OR ALTER FUNCTION fn_get_albums_by_artist (@artist_id INT) --Declara sentencia para crear función con parámetro (id artista)
RETURNS TABLE --Especifica que el valor de retorno es de tipo tabla
AS
RETURN --Define la consulta de la función
(
    SELECT alb.title "Título", alb.format "Formato", YEAR(alb.copyright_date) "Año", --Selecciona título, formato y año del álbum
	CONCAT(prod.first_name, ' ', prod.last_name) "Productor", alb.songs_quant "# Canciones" --Selecciona nombre productor de la tabla músico
 	FROM tb_album alb --Llama datos desde la tabla álbum y asigna alias "alb"
	JOIN tb_musician prod ON prod.tb_musician_id = alb.tb_musician_id --Une las tablas álbum y músico para obtener el productor del álbum
	JOIN tb_artist_album art_alb ON art_alb.tb_album_id = alb.tb_album_id --Une las tabla álbum con la tabla auxiliar álbum artista
	WHERE art_alb.tb_artist_id = @artist_id --Define condición para obtener sólo los álbumes del artista que se recibe como parámetro
);
GO


SELECT * FROM fn_get_albums_by_artist(2);
--Llama la función para obtener los álbumes del artista con id = 2



CREATE OR ALTER VIEW vw_songs_by_year AS --Crea vista
SELECT TOP 1000 STRING_AGG(songs.title, ', ') "Canción", --Selecciona canciones y las junta en una fila con función de agregación
songs.month "Mes" --Selecciona el mes desde la subconsulta
FROM ( --Crea una subconsulta para agrupar las canciones por mes
	SELECT sg.title "title", --Selecciona el título de la canción con el alias "title" para acceder en la consulta principal
	FORMAT(sg.created_at, 'MMMM', 'es-es') "month", --Extrae el nombre del mes en idioma español desde la fecha de creación
	MONTH(sg.created_at) "number" --Extrae el número del mes para luego ordenar los registros
	FROM tb_song sg
	WHERE YEAR(sg.created_at) = 2021 --Extrae el año de la fecha para establecer la condición
) songs --Añade un alias a la subconsulta para acceder a los datos
GROUP BY songs.month, songs.number --Agrupa las filas por el mes
ORDER BY songs.number; --Ordena las filas por el mes de forma ascendente


SELECT * FROM vw_songs_by_year; --Llama la vista para visualizar los datos
