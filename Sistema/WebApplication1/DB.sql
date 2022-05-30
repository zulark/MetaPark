CREATE DATABASE Estacionamento;
USE Estacionamento;

CREATE TABLE Usuario(
	idUsuario int identity(1,1),
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
	idVeiculo int identity(1,1),
	Marca varchar(30) NOT NULL,
	Modelo varchar(30) NOT NULL,
	Placa varchar(8),
	idUsuario int,
PRIMARY KEY (idVeiculo ASC))

ALTER TABLE Veiculo
ADD FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario);

CREATE TABLE Entrada(
	idAcesso int identity(1,1), 
	idUsuario int,
	idVeiculo int,
	Entrada varchar(20) NOT NULL,
	Saida varchar(20),
	PRIMARY KEY (
		idAcesso ASC
	)
)

select * from Usuario

select * from Veiculo

INSERT INTO Usuario VALUES ('Natália', 'Barros','023.706.406-50',HASHBYTES('MD5','nataliab'), HASHBYTES('MD5','123456'), 1);
INSERT INTO Usuario VALUES ('Noah', 'Barros','317.559.841-20',HASHBYTES('MD5','noahB'),HASHBYTES('MD5','123456'),1);
INSERT INTO Usuario VALUES ('Oliver', 'Ramos','797.620.466-17',HASHBYTES('MD5','OliverR'),HASHBYTES('MD5','123456'),1);
INSERT INTO Usuario VALUES ('Márcia', 'Nunes','068.133.269-70',HASHBYTES('MD5','marciaN'),HASHBYTES('MD5','123456'),1);
INSERT INTO Usuario VALUES ('Marcos', 'Mendes','663.361.084-06',HASHBYTES('MD5','marcosM'),HASHBYTES('MD5','123456'),1);

INSERT INTO Usuario VALUES ('Natália', 'Barros','023.706.406-50','nataliab', '123456', 1);
INSERT INTO Usuario VALUES ('Noah', 'Barros','317.559.841-20','noahB','123456',1);
INSERT INTO Usuario VALUES ('Oliver', 'Ramos','797.620.466-17','OliverR','123456',1);
INSERT INTO Usuario VALUES ('Márcia', 'Nunes','068.133.269-70','marciaN','123456',1);
INSERT INTO Usuario VALUES ('Marcos', 'Mendes','663.361.084-06','marcosM','123456',1);

INSERT INTO Veiculo VALUES ('Peugeot', '206','BVQ7861',1);
INSERT INTO Veiculo VALUES ('Kia', 'Sorento','JVT6953',1);
INSERT INTO Veiculo VALUES ('Nissan', 'Pathfinder','JTK9749',2);
INSERT INTO Veiculo VALUES ('Honda', 'Civic','AQA8517',3);
INSERT INTO Veiculo VALUES ('Toyota', 'Corolla','LVT0928',4);
INSERT INTO Veiculo VALUES ('Toyota', 'Hilux','HQC1626',4);


SELECT idAcesso FROM 'entrada' WHERE idUsuario = 1 and idVeiculo = 0 and Saida IS NULL;