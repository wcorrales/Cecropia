USE [CecropiaTest_DB]
GO

-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE sp_CreatePatient @FirstName nvarchar(50), @LastName nvarchar(50), @DateOfBirth datetime, @Nationality int,
								@Diseases nvarchar(250), @PhoneNumber nvarchar(50), @BloodType int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
	INSERT INTO [dbo].[Patient]
           ([FirstName]
           ,[LastName]
           ,[DateOfBirth]
           ,[Nationality]
           ,[Diseases]
           ,[PhoneNumber]
           ,[BloodType])
     VALUES
           (@FirstName
           ,@LastName
           ,@DateOfBirth
           ,@Nationality
           ,@Diseases
           ,@PhoneNumber
           ,@BloodType)

END
GO
