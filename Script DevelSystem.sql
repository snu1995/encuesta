
CREATE DATABASE DEVELSYSTEM

use DEVELSYSTEM

CREATE TABLE Usuario(
idUsuario int primary key identity,
NombreUsuario varchar(50),
CorreoUsuario varchar(50),
ClaveUsuario varchar(100)
)

-- Script para crear la tabla Encuesta
CREATE TABLE Encuesta (
    Id int PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(255) NOT NULL,
    Descripcion NVARCHAR(MAX),
    Enlace NVARCHAR(255) NOT NULL DEFAULT ''
);


-- Script para crear la tabla TipoCampo
CREATE TABLE TipoCampo (
    Id int primary key,
    Nombre NVARCHAR(50) NOT NULL
);

-- Script para crear la tabla Campo
CREATE TABLE Campo (
    Id int primary key identity,
    Nombre NVARCHAR(255) NOT NULL,
    Titulo NVARCHAR(255),
    EsRequerido BIT NOT NULL,
    EncuestaId INT FOREIGN KEY REFERENCES Encuesta(Id),
	TipoCampoId INT FOREIGN KEY REFERENCES TipoCampo(Id)
);



-- Insertar valores en la tabla TipoCampo
INSERT INTO TipoCampo(Id, Nombre)
VALUES
    (0, 'Texto'),
    (1, 'Numero'),
    (2, 'Fecha');


-- Script para crear la tabla Respuestas
CREATE TABLE Respuestas (
    Id int PRIMARY KEY IDENTITY,
    NombrePersona NVARCHAR(255),
    Valor NVARCHAR(MAX),
    EncuestaId INT,
    CampoId INT,
    FOREIGN KEY (EncuestaId) REFERENCES Encuesta(Id),
    FOREIGN KEY (CampoId) REFERENCES Campo(Id)
);


	select *from Usuario;
	
	select *from TipoCampo;
	
	select *from Campo;

	select *from Encuesta;

	select *from Usuario;

	select *from Respuestas;
	
