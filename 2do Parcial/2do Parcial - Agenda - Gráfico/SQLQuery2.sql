CREATE DATABASE BaseDatosAgenda;

USE BaseDatosAgenda;


CREATE TABLE Contactos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(20) NOT NULL
);

select * from Contactos;