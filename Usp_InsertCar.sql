USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[Usp_InsertCar]    Script Date: 6/4/2015 2:21:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_InsertCar]
@Name VARCHAR(50),
@Model VARCHAR(50),
@Year int,
@Color VARCHAR(50)
AS
BEGIN

	SET NOCOUNT ON;

DECLARE @MaxId int 
	Insert into Car
	SELECT @Name,
	       @Model,
		   @Year,
		   @Color

SET @MaxId = (SELECT MAX(Id) From Car)
SELECT @MaxId AS Id 
END
