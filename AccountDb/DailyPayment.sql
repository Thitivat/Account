CREATE TABLE [dbo].[DailyPayment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(255) NOT NULL, 
    [Type] VARCHAR(255) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Amount] INT NOT NULL, 
    [Date] DATE NOT NULL
)
