USE [Test_Task]
GO
/****** Object:  StoredProcedure [dbo].[Get_TH_new]    Script Date: 13.07.2024 21:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Get_TH_new]
AS
BEGIN
	SELECT 
		timesheets.id,
		timesheets.employee,
		timesheets.reason,
		timesheets.start_date,
		timesheets.duration,
		timesheets.discounted,
		timesheets.description,
		employees.first_name + employees.last_name AS fullnmae
	FROM timesheets
	JOIN employees ON employees.id = timesheets.employee
END
GO
