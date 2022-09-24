USE db_4
GO

--Criamos a tabela tentando utilizar uma foreign key
CREATE TABLE Contacts(
	[Id]			INT NOT NULL IDENTITY PRIMARY KEY,
	CONSTRAINT		[CopaUser_Id] FOREIGN KEY (Id)
	REFERENCES		CopaUsers(Id),
	[Info]			VARCHAR(255) NOT NULL
);
GO


SELECT * FROM Contacts;

/*Observamos que seria necessário adicionar
uma coluna User_Id e fazeressa tarefa manualmente*/
ALTER TABLE Contacts
ADD User_Id INT NOT NULL;
GO