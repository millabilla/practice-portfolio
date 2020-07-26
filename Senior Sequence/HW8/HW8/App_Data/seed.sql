CREATE TABLE [dbo].[AllData]
(
	[Location] NVARCHAR(50),
	[MeetDate] DATETIME,
	[Team] NVARCHAR(50),
	[Coach] NVARCHAR(50),
	[Event] NVARCHAR(20),
	[Gender] NVARCHAR(20),
	[Athlete] NVARCHAR(50),
	[RaceTime] REAL
);
 
BULK INSERT [dbo].[AllData]
	FROM 'C:\Users\mille\Desktop\School\CS 460\racetimes.csv'
	WITH
	(
		FIELDTERMINATOR = ',',
		ROWTERMINATOR = '\n',
		FIRSTROW = 2
	);

INSERT INTO [dbo].[Coaches] ([Name])
	SELECT DISTINCT Coach from [dbo].[AllData];

INSERT INTO [dbo].[Teams]
	(Name,CoachID)
	SELECT DISTINCT ad.Team,cs.ID
		FROM dbo.AllData as ad, dbo.Coaches as cs
		WHERE ad.Coach = cs.Name;

INSERT INTO [dbo].[Athletes](Name, Gender, TeamID)
	SELECT DISTINCT ad.Athlete, ad.Gender, ts.ID
		FROM dbo.AllData as ad, dbo.Teams as ts
		Where (ad.Team = ts.Name);
		
INSERT INTO [dbo].[Locations](Name, Date)
	SELECT DISTINCT Location, MeetDate from [dbo].[AllData];


Insert Into [dbo].[Events](LocationID, Distance, AthleteID, RaceTimes)
	SELECT DISTINCT ls.ID, ad.Event, ats.ID, ad.RaceTime
		FROM dbo.AllData as ad
		JOIN dbo.Locations as ls ON ad.Location = ls.Name
		JOIN dbo.Athletes as ats ON ad.Athlete = ats.Name
	

-- We don't need this staging table anymore so clear it away
DROP TABLE [dbo].[AllData];
