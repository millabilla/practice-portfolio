--Following example on class repo 
--Beginning with Coaches due to seed example
CREATE TABLE [dbo].[Coaches] (

	[ID] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR (100) NOT NULL,
	CONSTRAINT [PK_dbo.Coaches] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Teams](

	[ID] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	[CoachID] INT,
	CONSTRAINT [PK_dbo.Teams] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Teams_dbo.Coaches_ID] FOREIGN KEY ([CoachID]) REFERENCES [dbo].[Coaches] ([ID])
);

CREATE TABLE [dbo].[Athletes] (

	[ID] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR (100) NOT NULL,
	[Gender] NVARCHAR(6) NOT NULL,
		CHECK (Gender in ('boys', 'girls')),
	[TeamID] INT NOT NULL
	CONSTRAINT [PK_dbo.Athletes] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Athletes_dbo.Teams_ID] FOREIGN KEY ([TeamID]) REFERENCES [dbo].[Teams] ([ID])

);

ALTER TABLE [dbo].[Athletes]
ADD CONSTRAINT [PK_Athletes] PRIMARY KEY ( [ID] );

CREATE TABLE [dbo].[Locations] (
	[ID] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR (100) NOT NULL,
	[Date] DATE NOT NULL,
	CONSTRAINT [PK_dbo.Locations] PRIMARY KEY CLUSTERED ([ID] ASC)
);


--WORKED WITH JOE AND DENNIS
CREATE TABLE [dbo].[Events] (
	[ID] INT IDENTITY (1,1) NOT NULL,
	[LocationID] INT NOT NULL,
	[Distance] NVARCHAR(5) NOT NULL,
		CHECK (Distance in ('100','110', '200', '300', '400', '800', '1500', '3000')),
	[Hurdles] BIT, --1 for 'yes', 0 for 'no'
	[AthleteID] INT,
	[RaceTimes] REAL,
	CONSTRAINT [PK_dbo.Events] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_dbo.Events.Locations_ID] FOREIGN KEY ([LocationID]) REFERENCES [dbo].[Locations] ([ID]),
	CONSTRAINT [FK_dbo.Events.Athletes_ID] FOREIGN KEY ([AthleteID]) REFERENCES [dbo].[Athletes] ([ID])

);