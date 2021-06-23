/*
USE master 

go  

drop database Sanchez_Arostegui_Olsavsky_DB

go
*/

CREATE DATABASE Sanchez_Arostegui_Olsavsky_DB

go

use Sanchez_Arostegui_Olsavsky_DB

go

CREATE TABLE Pacientes(
	ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	DNI varchar(100) null,
	Nombre VARCHAR(100) NOT NULL,
	Apellido VARCHAR(100) NOT NULL, 
	FechaNacimiento DATE NOT NULL CHECK(FechaNacimiento < GETDATE()),
	Domicilio VARCHAR(250) NULL,
	EMail VARCHAR(250) UNIQUE not null,
	Contrasena varchar(20) not null,
	Celular VARCHAR(50) NULL,
    Genero CHAR NOT NULL CHECK (Genero IN ('M', 'F', 'O')),
    NroAfiliado varchar (40) NULL,
    ObraSocial VARCHAR(100) NOT NULL,
	Estado bit not null check(Estado = 1)
	--CONSTRAINT CHK_EMailCelular CHECK(EMail IS NOT NULL OR Celular IS NOT NULL),
)

go

CREATE TABLE Medicos(
	ID INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
	DNI varchar(100) null,
	Nombre VARCHAR(100) NOT NULL,
	Apellido VARCHAR(100) NOT NULL, 
	FechaNacimiento DATE NOT NULL CHECK(FechaNacimiento < GETDATE()),
	Domicilio VARCHAR(250) NULL,
	EMail VARCHAR(250) UNIQUE not null,
	Contrasena varchar(20) not null,
	Celular VARCHAR(50) NULL,
    Genero CHAR NOT NULL CHECK (Genero IN ('M', 'F', 'O')),
    Matricula varchar (50) NULL,
    Especialidad VARCHAR(150) NOT NULL,
	Estado bit not null check(Estado = 1)
)

go

create table Turno(
	IDPaciente int foreign key references Pacientes(ID) NOT NULL,
	IDMedico int foreign key references Medicos(ID) NOT NULL,
	FechaHora datetime not null CHECK(FechaHora > GETDATE()),
	Estado bit not null check(Estado = 1)
	PRIMARY KEY (IDPaciente, IDMedico, FechaHora)
)

--select IDPaciente, IDMedico, FechaHora, Estado from Turno
--update Turno set IDPaciente, IDMedico, FechaHora where IDPaciente, IDMedico, FechaHora

--update Medicos set Estado = 1 where ID = 1

--update Medicos set Nombre = "", Apellido = "", Domicilio = "", EMail = "", Contrasena = "", Celular = "", Especialidad = "", Matricula 

--select ID, DNI, Nombre, Apellido, FechaNacimiento, Domicilio, EMail, Contrasena, Celular, Genero, Matricula, Especialidad, Estado from Medicos

--insert into Medicos (ID, DNI, Nombre, Apellido, FechaNacimiento, Domicilio, EMail, Contrasena, Celular, Celular, Genero, Matricula, Especialidad, Estado) values ()