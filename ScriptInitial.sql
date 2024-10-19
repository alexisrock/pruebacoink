

CREATE DATABASE COINK;

use COINK;

CREATE TABLE Pais (
    Id INT IDENTITY PRIMARY KEY,
    Nombre VARCHAR(400) NOT NULL,
);
GO

CREATE TABLE Departamento(
    Id INT IDENTITY PRIMARY KEY,
    Nombre VARCHAR(400) NOT NULL,
    Idpais int
    CONSTRAINT fk_IdpaisDepartamento FOREIGN KEY (Idpais)
    REFERENCES Pais(Id)
);
GO
CREATE TABLE Municipio(
    Id INT  IDENTITY PRIMARY KEY,
    Nombre VARCHAR(400) NOT NULL,
    IdDepartamento int
    CONSTRAINT fk_IdDepartamentoMunicipio FOREIGN KEY (IdDepartamento)
    REFERENCES Departamento(Id)
);

GO
CREATE TABLE Users(
    Id_usuario INT IDENTITY PRIMARY KEY,
    Nombre VARCHAR(400) NOT NULL,
    Telefono VARCHAR(10) NOT NULL,
    Direccion VARCHAR(400) NOT NULL,
	Idpais Int,
	IdDepartamento int,
    IdMunicipio Int
    CONSTRAINT fk_IdMunicipioUsers FOREIGN KEY (IdMunicipio)
    REFERENCES Municipio(Id),
	CONSTRAINT fk_IdDepartamentoUsers FOREIGN KEY (IdDepartamento)
    REFERENCES Departamento(Id),
	CONSTRAINT fk_IdpaisUsers FOREIGN KEY (Idpais)
    REFERENCES Pais(Id)
);

go

insert into Pais values ('Colombia');
insert into Departamento values ('Bogota', 1)
insert into Municipio values ('Bogota', 1)


GO



CREATE or ALTER PROCEDURE SpGetUserById
@IdUser int
AS

	select * from Users where Id_usuario = @IdUser

Go



CREATE or ALTER PROCEDURE SpGetUser
AS

	select * from Users 

Go