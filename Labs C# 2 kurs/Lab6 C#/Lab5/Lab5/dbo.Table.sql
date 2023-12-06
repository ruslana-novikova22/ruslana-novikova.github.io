CREATE TABLE [dbo].[Library]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Author] NVARCHAR(50) NOT NULL, 
    [PublicationYear] INT NOT NULL, 
    [AuthorAdress] NVARCHAR(50) NOT NULL, 
    [PublisherAddress] NVARCHAR(50) NOT NULL, 
    [Price] DECIMAL(18, 2) NOT NULL, 
    [BookstoreFirm] NVARCHAR(50) NOT NULL

)
