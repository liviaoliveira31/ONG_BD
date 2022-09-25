CREATE DATABASE ONG
USE ONG

CREATE TABLE Pessoa(
 CPF CHAR(11)  NOT NULL,
 Nome varchar (50) not null,
 Telefone varchar(14) not null,
 Sexo varchar (9) not null,
 Rua varchar(20)not null,
 Bairro varchar (20) not null,
 Numero int not null,
 Cidade varchar (20) not null,
 Estado char (2) not null,
 CONSTRAINT PK_CPF_PESSOA PRIMARY KEY (CPF)
);




CREATE TABLE Animal(
CHIP INT  NOT NULL,
Familia varchar (20) NOT NULL,
Raca varchar(20) not null,
Sexo varchar (9) not null,
Nome varchar (20) null,
CONSTRAINT PK_CHIP_ANIMAL PRIMARY KEY (CHIP)
);

CREATE TABLE Adotar(
CPF CHAR(11) NOT NULL,
CHIP INT  NOT NULL,
FOREIGN KEY (CPF) REFERENCES Pessoa (CPF),
FOREIGN KEY (CHIP) REFERENCES Animal(CHIP)
);


INSERT INTO Pessoa(cpf, nome, sexo, rua, bairro, numero, cidade, estado)
VALUES(47152270880, 'Livia', 'Fem', 'Carlos Anselmo','JD. Santa Julia', 271, 'Araraquara', 'SP')

INSERT INTO Animal(CHIP, Familia, Raca, Sexo, Nome)
VALUES(1,'Cachorro', 'SRD', 'Fem', 'Chiquinha')
INSERT INTO Animal(CHIP, Familia, Raca, Sexo, Nome)
VALUES(2,'Cachorro', 'SRD', 'Fem', 'Pantera')

insert into adotar(cpf, chip)
values(47152270880, 2)


