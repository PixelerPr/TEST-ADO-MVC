USE [Test_Task]
GO
/****** Object:  StoredProcedure [dbo].[Insert_TH]    Script Date: 13.07.2024 21:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Insert_TH]
(
	@id  INT,
	@employee  INT,
	@reason  INT,
	@start_date  DATETIME,
	@duration  INT,
	@discounted BIT,
	@description VARCHAR(MAX)
)
AS
BEGIN
BEGIN TRY
	BEGIN TRAN
		INSERT INTO timesheets(id, employee, reason, start_date, duration, discounted, description)
		VALUES(@id, @employee, @reason, @start_date, @duration, @discounted, @description)
	COMMIT TRAN
END TRY
BEGIN CATCH
	ROLLBACK TRAN
END CATCH

END
GO
