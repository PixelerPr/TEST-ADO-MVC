USE [Test_Task]
GO
/****** Object:  StoredProcedure [dbo].[Update_TH]    Script Date: 13.07.2024 21:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Update_TH]
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
DECLARE @RowCount INT = 0
	BEGIN TRY
		SET @RowCount = (SELECT COUNT(1) FROM timesheets WITH (NOLOCK) WHERE id = @id)

		IF(@RowCount > 0)
			BEGIN
				BEGIN TRAN
					UPDATE timesheets
						SET
							id = @id,
							employee = @employee,
							reason = @reason,
							start_date = @start_date,
							duration = @duration,
							discounted = @discounted,
							description = @description
						WHERE id = @id
				COMMIT TRAN
			END
	END TRY
BEGIN CATCH
	ROLLBACK TRAN
END CATCH
END
GO
