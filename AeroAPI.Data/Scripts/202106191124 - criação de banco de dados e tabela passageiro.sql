
CREATE DATABASE AeroAPI
GO

USE AeroAPI
GO

CREATE TABLE Passageiro
(
	Id INT IDENTITY PRIMARY KEY,
	Nome NVARCHAR(50) NOT NULL,
	Idade INT NOT NULL,
	Celular NVARCHAR(20)
)
GO
