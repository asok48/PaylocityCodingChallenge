CREATE TABLE [dbo].[Employee]
(
	[EmployeeId] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50), 
    [Cost] DECIMAL NOT NULL,
    [CreatedDate] DATE NOT NULL, 
    [CreatedBy] NVARCHAR(50) NULL, 
    [ModifiedDate] DATE NULL, 
    [ModifiedBy] NVARCHAR(50) NULL
)