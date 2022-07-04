CREATE DATABASE Estacionamento;
USE Estacionamento;

CREATE TABLE Usuario(
	idUsuario int identity(0,1),
	Nome varchar(50) NOT NULL,
	Sobrenome varchar(50) NULL,
	Saldo decimal(4,2) NOT NULL,
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
	idAcesso int, 
	idUsuario int,
	idVeiculo int,
	idLocalEst int,
	Entrada datetime NOT NULL,
	Saida datetime
	PRIMARY KEY (
		idAcesso ASC
	)
)

ALTER TABLE Acesso
ADD FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario);

ALTER TABLE Acesso
ADD FOREIGN KEY (idVeiculo) REFERENCES Veiculo(idVeiculo);

CREATE TABLE LocalEst(
	idLocal int,
	nome varchar(80),
	qtdVagas int,
	vagasDisp int,
	valorHora decimal(4,2),
	linkFoto text,
	horarioFunc varchar(80),
	
PRIMARY KEY (idLocal ASC))

select * from Usuario

select * from Acesso

select * from Veiculo

select * from localEst

INSERT INTO Usuario VALUES ('Usuario', 'Usuario','123.456.789-10','user', '123456', 1);
INSERT INTO Usuario VALUES ('Noah', 'Barros','317.559.841-20','noahB','123456',1);
INSERT INTO Usuario VALUES ('Oliver', 'Ramos','797.620.466-17','OliverR','123456',1);
INSERT INTO Usuario VALUES ('Márcia', 'Nunes','068.133.269-70','marciaN','123456',1);
INSERT INTO Usuario VALUES ('Marcos', 'Mendes','663.361.084-06','marcosM','123456',1);

INSERT INTO Usuario VALUES ('Natália','Barros',53.95,'023.706.406-50','nataliab', '123456', 1);
INSERT INTO Usuario VALUES ('Noah', 'Barros',12.95,'317.559.841-20','noahB','123456',1);
INSERT INTO Usuario VALUES ('Oliver', 'Ramos',10.00,'797.620.466-17','OliverR','123456',1);
INSERT INTO Usuario VALUES ('Márcia', 'Nunes',0,'068.133.269-70','marciaN','123456',1);
INSERT INTO Usuario VALUES ('Marcos', 'Mendes',26.5,'663.361.084-06','marcosM','123456',1);

INSERT INTO LocalEst VALUES (0, 'Park Shopping Barigui', 100, 100, 6.50,'http://www.parkshoppingbarigui.com.br/sites/pkb/files/upload/shopping/foto_1.jpg', '10:00 às 22:00');
INSERT INTO LocalEst VALUES (1, 'Shopping Estação', 80, 80, 6.50,'https://tribunapr.uol.com.br/wp-content/uploads/2021/11/19200600/estacao-shopping.jpg', '10:00 às 22:00');
INSERT INTO LocalEst VALUES (2, 'Aeroporto Afonso Pena', 300, 300, 6.50,'https://jpimg.com.br/uploads/2018/01/curitiba_aerea_aeroportoafonsopena1304_2694-e1482930843441-1024x768.jpg', '24h');
INSERT INTO LocalEst VALUES (3, 'PUC - Paraná', 200, 200, 6.50,'https://s2.glbimg.com/T8nm1jUHrs0E-P1-5fngyoIsyi4=/0x0:1000x665/984x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_59edd422c0c84a879bd37670ae4f538a/internal_photos/bs/2020/O/M/3VfEQOSHAOl7wsJ4b6gg/pucpr-4-.jpg', '7:00 às 23:30');

INSERT INTO Veiculo VALUES (0,'Peugeot', '206','BVQ7861',0);
INSERT INTO Veiculo VALUES (1,'Kia', 'Sorento','JVT6953',0);
INSERT INTO Veiculo VALUES (2,'Nissan', 'Pathfinder','JTK9749',1);
INSERT INTO Veiculo VALUES (3,'Honda', 'Civic','AQA8517',2);
INSERT INTO Veiculo VALUES (4,'Toyota', 'Corolla','LVT0928',3);
INSERT INTO Veiculo VALUES (5,'Toyota', 'Hilux','HQC1626',3);
