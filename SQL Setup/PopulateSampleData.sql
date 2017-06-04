USE [AddressManagerDb]
GO


IF EXISTS (SELECT 1 FROM [dbo].[Contact])
BEGIN
	DELETE FROM [dbo].[Contact]
END
GO
IF EXISTS (SELECT 1 FROM [dbo].[ContactAddress])
BEGIN
	DELETE FROM [dbo].[ContactAddress]
END
IF EXISTS (SELECT 1 FROM [dbo].[Address])
BEGIN
	DELETE FROM [dbo].[Address]
END
GO
DECLARE @DATESTAMP DATETIME2(0) = GETDATE();

SET IDENTITY_INSERT [dbo].[Contact] ON

INSERT INTO [dbo].[Contact]
			([Id]
			,[FirstName]
			,[LastName]
			,[StartDate]
			, [EndDate])
		VALUES
			(1, 'Theresa','May', @DATESTAMP, NULL),
			(2, 'Jeremy','Corbyn', @DATESTAMP, NULL),
			(3, 'Tim','Farron', @DATESTAMP, NULL),
			(4, 'Caroline','Lucas', @DATESTAMP, NULL),
			(5, 'Leanne','Wood', @DATESTAMP, NULL),
			(6, 'Nicola','Sturgeon', @DATESTAMP, NULL),
			(7, 'Paul','Nuttall', @DATESTAMP, NULL)

SET IDENTITY_INSERT [dbo].[Contact] OFF

SET IDENTITY_INSERT [dbo].[Address] ON

INSERT INTO [dbo].[Address]
        ([id]
		,[Number]
        ,[Street]
        ,[Town]
		,[City]
		,[PostCode])
    VALUES
        (1, 10, 'Downing Street', 'Westminster', 'London', 'SW1A 2AA'),
		(2, 105, 'Victoria Street', 'Westminster', 'London', 'SW1E 6QT'),
		(3, 8, 'Great George Street', 'Westminster', 'London', 'SW1P 3AE'),
		(4, 100, 'Clements Road', NULL, 'London', 'SE16 4DG'),
		(5, 1, 'Anson Court', 'Atlantic Wharf', 'Cardiff', 'CF10 4AL'),
		(6, 69, 'Dixon Road', NULL, 'Glasgow', 'G42 8AT'),
		(7, 1, 'King Charles Business Park', 'Newton Abbot', 'Devon', 'TQ12 6UT')


SET IDENTITY_INSERT [dbo].[Address] OFF

SET IDENTITY_INSERT [dbo].[ContactAddress] ON

INSERT INTO [dbo].[ContactAddress]
           ([Id]
           ,[ContactId]
           ,[AddressId]
           ,[StartDate]
		   ,[EndDate])
     VALUES
           (1, 1, 1, @DATESTAMP, NULL),
		   (2, 2, 2, @DATESTAMP, NULL),
		   (3, 3, 3, @DATESTAMP, NULL),
		   (4, 4, 4, @DATESTAMP, NULL),
		   (5, 5, 5, @DATESTAMP, NULL),
		   (6, 6, 6, @DATESTAMP, NULL),
		   (7, 7, 7, @DATESTAMP, NULL)

SET IDENTITY_INSERT [dbo].[ContactAddress] OFF
GO

SELECT * FROM [dbo].[Contact]
SELECT * FROM [dbo].[ContactAddress]
SELECT * FROM [dbo].[Address]
