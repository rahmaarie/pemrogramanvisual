CREATE DATABASE kedaimakandb;

USE kedaimakandb;

CREATE TABLE Karyawan (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(100) NOT NULL,
    Password VARCHAR(100) NOT NULL
);


