CREATE TABLE [dbo].[Dependent]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Cost] DECIMAL NOT NULL, 
    [EmployeeId] NVARCHAR(50) NOT NULL, 
    [CreatedDate] DATE NOT NULL, 
    [CreatedBy] NVARCHAR(50) NULL, 
    [ModifiedDate] DATE NULL, 
    [ModifiedBy] NVARCHAR(50) NULL

)