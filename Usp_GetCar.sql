USE [Test]
GO
/****** Object:  StoredProcedure [dbo].[Usp_GetCar]    Script Date: 6/4/2015 2:53:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Usp_GetCar] 
@Id int
AS
BEGIN

	SET NOCOUNT ON;

SELECT Id, Name,Model,[Year],Color
FROM Car 
WHERE Id = @Id 

END
