USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[Usp_DeleteCar]    Script Date: 6/4/2015 2:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_DeleteCar]
@Id int
AS
BEGIN

	SET NOCOUNT ON;
DELETE FROM Car
WHERE Id = @Id

END
