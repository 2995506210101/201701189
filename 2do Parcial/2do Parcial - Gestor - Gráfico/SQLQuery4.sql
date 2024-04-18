CREATE DATABASE BaseGestor;

USE BaseGestor;

CREATE TABLE TareasGestor (
    ID INT PRIMARY KEY IDENTITY,
    Curso NVARCHAR(100),
    Tarea NVARCHAR(100),
    Fecha NVARCHAR(50),
    Estado NVARCHAR(50)
);

select * from TareasGestor;