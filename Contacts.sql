--Selecionando a database--
USE db_4
GO

--Criamos a tabela tentando utilizar uma foreign key
CREATE TABLE Contacts(
	[Id]			INT NOT NULL IDENTITY PRIMARY KEY,
    [User_Id]       INT NOT NULL UNIQUE,
	[Info]			VARCHAR(255) NOT NULL
);
GO
