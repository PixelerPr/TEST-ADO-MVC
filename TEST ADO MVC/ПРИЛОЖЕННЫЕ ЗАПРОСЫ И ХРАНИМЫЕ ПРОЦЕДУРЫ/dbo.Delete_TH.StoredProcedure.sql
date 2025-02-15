USE [Test_Task]
GO
/****** Object:  StoredProcedure [dbo].[Delete_TH]    Script Date: 13.07.2024 21:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Delete_TH]
(
	@id INT
)
AS
BEGIN
DECLARE @RowCount INT = 0
	BEGIN TRY
		SET @RowCount = (SELECT COUNT(1) FROM timesheets WITH (NOLOCK) WHERE id = @id)

		IF(@RowCount > 0)
			BEGIN
				BEGIN TRAN
					DELETE FROM timesheets
						WHERE id = @id
				COMMIT TRAN
			END
	END TRY
BEGIN CATCH
	ROLLBACK TRAN
END CATCH
END
GO
