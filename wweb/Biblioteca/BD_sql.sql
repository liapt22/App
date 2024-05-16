USE MASTER
GO
IF EXISTS(SELECT * FROM sys.databases WHERE NAME='Biblioteca')
BEGIN
ALTER DATABASE Biblioteca SET SINGLE_USER
WITH ROLLBACK IMMEDIATE
DROP DATABASE Biblioteca
END
GO
CREATE DATABASE Biblioteca
GO
USE Biblioteca
GO


CREATE TABLE [dbo].[Type_user](
[ID_Type_user] [int] PRIMARY KEY,
[Name] 		   [nvarchar](50) NOT NULL
)
GO
INSERT INTO Type_user VALUES
(1,'Unconfirmed'),
(2,'Confirmed')
GO

CREATE TABLE [dbo].[Users](
[ID_User]		[int] PRIMARY KEY IDENTITY,
[ID_Type_user] [int] FOREIGN KEY REFERENCES Type_user(ID_Type_user),
[Username]	[nvarchar](50) NOT NULL,
[Hash_Password]	[nvarchar](256) NOT NULL,
[Salt] [nvarchar](50) NOT NULL,
[Email]		[nvarchar](50) NOT NULL,
[Code] [varchar](6) NOT NULL
)
GO 

CREATE TABLE [dbo].[Sessions](
ID_Session [int] PRIMARY KEY IDENTITY,
ID_User [int] FOREIGN KEY REFERENCES Users(ID_User),
SessionToken [nvarchar](100) NOT NULL,
ExpiryDateTime [datetime] NOT NULL
);
GO
