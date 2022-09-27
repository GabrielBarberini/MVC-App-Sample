-- Cria o banco de dados
CREATE DATABASE [db4];
GO

-- Define qual banco de dados será utilizado
USE [db4];
GO

-- Cria a tabela Users 
CREATE TABLE CopaUsers(
	[Id] INT NOT NULL IDENTITY PRIMARY KEY, 
    [Nome] VARCHAR(255) NOT NULL,
	[Email] VARCHAR(255) NOT NULL UNIQUE,
	[Password] TEXT NOT NULL
);
GO

-- Insere um registro na tabela
INSERT INTO CopaUsers ([Nome], [Email], [Password])
VALUES ('admin', 'admin@email.com', 'admin123');
GO

-- Deleta um registro que coincida com o id do usuário informado
DELETE FROM CopaUsers WHERE id = 1;
