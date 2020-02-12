CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [TermName] NCHAR(10) NULL , 
    [TermStatus] NCHAR(10) NULL, 
    [TProjStart] DATETIME NULL, 
    [TProjEnd] DATETIME NULL, 
    [TActStart] DATETIME NULL, 
    [TActEnd] DATETIME NULL
)
