CREATE TABLE [dbo].[Team]
(
	[TeamID] INT IDENTITY (1, 1) NOT NULL, 
    [TeamName] NVARCHAR(50) NULL, 
    [Sport] NVARCHAR(50) NULL, 
    [ZipCode] INT NULL,
	PRIMARY KEY CLUSTERED ([TeamID] ASC)
)
