CREATE DATABASE TuBaseDeDatos;

USE TuBaseDeDatos;

CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY,
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
    DPI CHAR(13),
    FechaNacimiento DATE,
    Telefono CHAR(8),
    NombreUsuario VARCHAR(50),
    Contraseña VARCHAR(200),
    Email VARCHAR(100)
);

CREATE TABLE Citas (
    Id INT PRIMARY KEY IDENTITY,
    NombreCompleto VARCHAR(100),
    Telefono CHAR(8),
    MotivoCita VARCHAR(200),
    FechaHoraCita DATETIME,
    TieneSeguroMedico VARCHAR(2)
);

CREATE TABLE Suministros (
    Id INT PRIMARY KEY IDENTITY,
    NombreCompleto VARCHAR(100),
    Telefono CHAR(8),
    Medicamento VARCHAR(100),
    FechaPrescripcion DATE,
    Direccion VARCHAR(200),
    MetodoPago VARCHAR(20)
);

SELECT * FROM usuarios;

SELECT * FROM citas;

INSERT INTO Suministros (NombreCompleto, Telefono, Medicamento, FechaPrescripcion, Direccion, MetodoPago) VALUES
('Alexia Langstone', 12345678, 'ACYCLOVIR SODIUM', '2024/03/31', '62887 Union Street', 'Efectivo'),
('Vonni Summerscales', 12345678, 'Camphor, Menthol', '2023/07/11', '4994 Harbort Pass', 'Tarjeta'),
('Shannah Pitherick', 12345678, 'Black Locust', '2023/12/08', '797 Eagle Crest Junction', 'Tarjeta'),
('Kelley Grosier', 12345678, 'ACETAMINOPHEN, PAMABROM, PYRILAMINE MALEATE', '2024/02/05', '882 Briar Crest Lane', 'Efectivo'),
('Bar Hessentaler', 12345678, 'Avobenzone, Octinoxate, and Octisalate', '2023/08/23', '9574 Dayton Parkway', 'Tarjeta'),
('Smitty Gaither', 12345678, 'THYROIDINUM, RHAMNUS FRANGULA, FUCUS VESICULOSUS, KALI IODATUM', '2023/08/07', '71 Carberry Road', 'Efectivo'),
('Virgina Aizlewood', 12345678, 'fibrinogen human and thrombin human', '2023/11/29', '945 Transport Parkway', 'Tarjeta'),
('Witty Parkinson', 12345678, 'Niacinamide', '2023/09/07', '909 Donald Lane', 'Efectivo'),
('Caldwell Steels', 12345678, 'Crataegus Onopordon', '2023/08/29', '51312 Porter Alley', 'Efectivo'),
('Hildagarde Algore', 12345678, 'AGKISTRODON CONTORTRIX VENOM', '2023/05/20', '6292 Old Shore Parkway', 'Tarjeta'),
('Joleen Camp', 12345678, 'Povidone-Iodine', '2023/09/29', '37565 Parkside Terrace', 'Efectivo'),
('Ugo Martindale', 12345678, 'butenafine hydrochloride', '2024/01/29', '77942 Lien Hill', 'Efectivo'),
('Stearn Huguenet', 12345678, 'OCTINOXATE, TITANIUM DIOXIDE, and ZINC OXIDE', '2023/05/24', '712 Nevada Trail', 'Tarjeta'),
('Loren Kubyszek', 12345678, 'pioglitazone', '2024/03/23', '7375 Leroy Lane', 'Tarjeta'),
('Devy Kleiner', 12345678, 'Florbetapir F 18', '2023/09/05', '06 Park Meadow Lane', 'Efectivo'),
('Vernor Babbidge', 12345678, 'Traumeel', '2023/10/02', '9 Michigan Court', 'Efectivo'),
('Theda Southey', 12345678, 'Aluminum Chlorohydrate', '2023/07/25', '5141 Forest Crossing', 'Tarjeta'),
('Beret MacAulay', 12345678, 'divalproex sodium', '2023/08/16', '9 Stoughton Trail', 'Tarjeta'),
('Liam Hinemoor', 12345678, 'Ibuprofen, Pseudoephedrine HCl', '2024/02/16', '71 Carberry Way', 'Efectivo'),
('Ethelbert Ludye', 12345678, 'Paspalum notatum', '2023/09/29', '61588 Jenifer Terrace', 'Efectivo');

SELECT * FROM Usuarios;

