CREATE TABLE Pais (
    Id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    Nombre VARCHAR(400) NOT NULL
);

CREATE TABLE Departamento(
    Id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    Nombre VARCHAR(400) NOT NULL,
    Idpais int,
    CONSTRAINT fk_IdpaisDepartamento FOREIGN KEY (Idpais)
    REFERENCES Pais(Id)
);

CREATE TABLE Municipio(
    Id INT GENERATED ALWAYS AS  IDENTITY PRIMARY KEY,
    Nombre VARCHAR(400) NOT NULL,
    IdDepartamento int,
    CONSTRAINT fk_IdDepartamentoMunicipio FOREIGN KEY (IdDepartamento)
    REFERENCES Departamento(Id)
);


CREATE TABLE Users(
    Id_usuario INT  GENERATED ALWAYS AS  IDENTITY PRIMARY KEY,
    Nombre VARCHAR(400) NOT NULL,
    Telefono VARCHAR(10) NOT NULL,
    Direccion VARCHAR(400) NOT NULL,
	Idpais Int,
	IdDepartamento int,
    IdMunicipio Int,
    CONSTRAINT fk_IdMunicipioUsers FOREIGN KEY (IdMunicipio)
    REFERENCES Municipio(Id),
	CONSTRAINT fk_IdDepartamentoUsers FOREIGN KEY (IdDepartamento)
    REFERENCES Departamento(Id),
	CONSTRAINT fk_IdpaisUsers FOREIGN KEY (Idpais)
    REFERENCES Pais(Id)
);


insert into Pais(Nombre) values ('Colombia');
insert into Departamento(Nombre, Idpais) values ('Bogota', 1);
insert into Municipio(Nombre, IdDepartamento) values ('Bogota', 1)



CREATE OR REPLACE FUNCTION SpGetUserById (
    in IdUser int
)
 
RETURNS TABLE(Id INT, Nombre VARCHAR(400),  Telefono VARCHAR(10), Direccion VARCHAR(400), Idpais Int,
	IdDepartamento int,
    IdMunicipio Int) AS $$
BEGIN	

 RETURN QUERY select * from Users where Id_usuario = IdUser;
END;
$$ LANGUAGE plpgsql;



CREATE OR REPLACE FUNCTION SpGetUser () 
RETURNS TABLE(Id INT, Nombre VARCHAR(400),  Telefono VARCHAR(10), Direccion VARCHAR(400), Idpais Int,
	IdDepartamento int,
    IdMunicipio Int) AS $$
BEGIN	
 RETURN QUERY select * from Users ;
END;
$$ LANGUAGE plpgsql;


 

 SELECT * FROM   SpGetUser() ;
 
 SELECT * FROM  SpGetUserById(1);

 