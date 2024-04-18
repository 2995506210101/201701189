CREATE DATABASE AgendaContactos;

USE AgendaContactos;

CREATE TABLE Contactos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Telefono NVARCHAR(20)
);

Select * from Contactos; 