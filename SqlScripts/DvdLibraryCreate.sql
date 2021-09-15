USE master
GO

IF EXISTS(SELECT * FROM sys.databases WHERE name='DvdLibrary')
	DROP DATABASE DvdLibrary
GO

CREATE DATABASE DvdLibrary
GO

USE DvdLibrary
GO

--Tables
IF EXISTS(SELECT * FROM sys.tables WHERE name='Dvd')
	DROP TABLE Dvd
GO

CREATE TABLE Dvd(
	DvdId INT IDENTITY(1,1) PRIMARY KEY,
	Title NVARCHAR(30) NOT NULL,
	ReleaseYear VARCHAR(4) NULL,
	Director NVARCHAR(30) NULL,
	Rating NVARCHAR(5) NULL,
	Notes NVARCHAR(150) NULL
)

GO