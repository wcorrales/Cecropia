/*
   jueves 16 de febrero de 201709:12:00 a.m.
   User: 
   Server: CORRALES-MENA\ROBERTO
   Database: CecropiaDB_test
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.BloodType SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Country SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Patient
	(
	Id int NOT NULL IDENTITY (1, 1),
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	DateOfBirth datetime NOT NULL,
	Nationality int NULL,
	Diseases nvarchar(250) NULL,
	PhoneNumber nvarchar(50) NULL,
	BloodType int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Patient ADD CONSTRAINT
	PK_Patient PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Patient ADD CONSTRAINT
	FK_Patient_Country FOREIGN KEY
	(
	Nationality
	) REFERENCES dbo.Country
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Patient ADD CONSTRAINT
	FK_Patient_BloodType FOREIGN KEY
	(
	BloodType
	) REFERENCES dbo.BloodType
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Patient SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
