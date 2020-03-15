CREATE TABLE [dbo].[homeworks]
(
	ID	INT IDENTITY (1,1)	NOT NULL,
	Department VARCHAR (200) NOT NULL,
	SubjectNum Int NOT NULL,
	HomeworkTitle VARCHAR (200) NOT NULL,
	DueDate DATE NOT NULL,
	DueTime TIME (0) NOT NULL,
	Notes VARCHAR (300) NULL,
	Importance INT NOT NULL
);

INSERT INTO [dbo].[homeworks] (Department, SubjectNum, HomeworkTitle, DueDate, DueTime, Notes, Importance) VALUES
	('Divination', '243', 'The Effects of Soil on Tea', '2019-04-07', '14:00:00', 'essay, 5000 words', 4),
	('Charms', '280', 'Summoning spells drawings','2019-04-30','10:00:00','proper hand formation for summoning spells', 2),
	('Advanced Arithmancy', '502' , 'Ch 5-2) #1-20, 24, 56', '2019-05-27', '12:00:00', 'show all work and label any necessary diagrams', 1),
	('Potions', '394', 'Guidebook to Forbidden Forest', '2019-05-31', '15:00:00','Final project for the year', 1),
	('Defense Against the Dark Arts', '521', 'Unbreakable curse', '2019-05-31', '11:00:00', 'presentation', 3)

	GO