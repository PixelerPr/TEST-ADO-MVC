USE [Test_Task]
GO
/****** Object:  StoredProcedure [dbo].[Get_TH]    Script Date: 13.07.2024 21:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Read All Timesheets
CREATE PROC [dbo].[Get_TH]
AS
BEGIN
	SELECT * FROM timesheets WITH (NOLOCK)
END
GO
