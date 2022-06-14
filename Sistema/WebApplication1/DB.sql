CREATE DATABASE Estacionamento;
USE Estacionamento;

CREATE TABLE Usuario(
	idUsuario int identity(0,1),
	Nome varchar(50) NOT NULL,
	Sobrenome varchar(50) NULL,
	CPF varchar(14) NULL,
	Login varchar(50) NOT NULL,
	Senha varchar(40) NOT NULL,
	Ativo bit NOT NULL,
PRIMARY KEY 
(
	idUsuario ASC
) 
)

CREATE TABLE Veiculo(
	idVeiculo int,
	Marca varchar(30) NOT NULL,
	Modelo varchar(30) NOT NULL,
	Placa varchar(8),
	idUsuario int,
PRIMARY KEY (idVeiculo ASC))

ALTER TABLE Veiculo
ADD FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario);

CREATE TABLE Acesso(
	idAcesso int identity(0,1), 
	idUsuario int,
	idVeiculo int,
	Entrada datetime NOT NULL,
	Saida datetime
	PRIMARY KEY (
		idAcesso ASC
	)
)

select * from Usuario

select * from Veiculo

INSERT INTO Usuario VALUES ('Nat�lia', 'Barros','023.706.406-50','nataliab', '123456', 1);
INSERT INTO Usuario VALUES ('Noah', 'Barros','317.559.841-20','noahB','123456',1);
INSERT INTO Usuario VALUES ('Oliver', 'Ramos','797.620.466-17','OliverR','123456',1);
INSERT INTO Usuario VALUES ('M�rcia', 'Nunes','068.133.269-70','marciaN','123456',1);
INSERT INTO Usuario VALUES ('Marcos', 'Mendes','663.361.084-06','marcosM','123456',1);

INSERT INTO Usuario VALUES ('Nat�lia', 'Barros','023.706.406-50','nataliab', '123456', 1);
INSERT INTO Usuario VALUES ('Noah', 'Barros','317.559.841-20','noahB','123456',1);
INSERT INTO Usuario VALUES ('Oliver', 'Ramos','797.620.466-17','OliverR','123456',1);
INSERT INTO Usuario VALUES ('M�rcia', 'Nunes','068.133.269-70','marciaN','123456',1);
INSERT INTO Usuario VALUES ('Marcos', 'Mendes','663.361.084-06','marcosM','123456',1);

INSERT INTO Veiculo VALUES (0,'Peugeot', '206','BVQ7861',0);
INSERT INTO Veiculo VALUES (1,'Kia', 'Sorento','JVT6953',0);
INSERT INTO Veiculo VALUES (2,'Nissan', 'Pathfinder','JTK9749',1);
INSERT INTO Veiculo VALUES (3,'Honda', 'Civic','AQA8517',2);
INSERT INTO Veiculo VALUES (4,'Toyota', 'Corolla','LVT0928',3);
INSERT INTO Veiculo VALUES (5,'Toyota', 'Hilux','HQC1626',3);


SELECT idAcesso FROM 'entrada' WHERE idUsuario = 1 and idVeiculo = 0 and Saida IS NULL;