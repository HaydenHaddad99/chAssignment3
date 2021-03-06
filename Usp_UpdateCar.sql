USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[Usp_UpdateCar]    Script Date: 6/4/2015 2:55:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_UpdateCar]
@Id int = NULL,
@Name VARCHAR(50),
@Model VARCHAR(50),
@Year int,
@Color VARCHAR(50)

AS
BEGIN
	SET NOCOUNT ON;
Update Car 

set Name  = CASE WHEN ISNULL(@Name,'') = ''  THEN Name ELSE @Name END 
   ,Model = CASE WHEN ISNULL(@Model,'') = '' THEN Model ELSE @Model  END 
   ,[Year]= CASE WHEN ISNULL(@Year,'') = ''  THEN [Year] ELSE @Year END 
   ,Color = CASE WHEN ISNULL(@Color,'') = '' THEN Color ELSE @Color END 
   WHERE Id = @Id 
END
