CREATE DATABASE GestorTareas;


USE GestorTareas;


CREATE TABLE Tareas (
    Id INT PRIMARY KEY IDENTITY,
    Curso NVARCHAR(100),
    Tarea NVARCHAR(200),
    FechaEntrega DATE,
    Estado NVARCHAR(20)
);

select * from Tareas; 