/**************************************************************************
* 					Creating tables for database						  *
***************************************************************************/

CREATE TABLE [dbo].[Author] (
	[ID] INT IDENTITY (1,1) NOT NULL,
	[FirstName] NVARCHAR(100) NOT NULL,
	[LastName] NVARCHAR(100) NOT NULL,
		Constraint [Pk_dbo.Author] PRIMARY KEY ([ID] ASC)  

);

CREATE TABLE [dbo].[Genre] (
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Genre] NVARCHAR(25) NOT NULL,
		Constraint [Pk_dbo.Genre] PRIMARY KEY ([ID] ASC)
);

CREATE TABLE [dbo].[Book] ( 
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Title] NVARCHAR(max),
	[GenreID] INT NOT NULL,
	[AuthorID] INT NOT NULL,
		Constraint [Pk_dbo.Book] PRIMARY KEY ([ID] ASC),
		Constraint [Fk_dbo.Book_dbo.Genre_ID] FOREIGN KEY ([GenreID]) REFERENCES [dbo].[Genre] ([ID]),
		Constraint [Fk_dbo.Book_dbo.Author_ID] FOREIGN KEY ([AuthorID]) REFERENCES [dbo].[Book] ([ID])
);