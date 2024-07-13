USE [Test_Task]
GO
/****** Object:  StoredProcedure [dbo].[Get_TH_by_Id]    Script Date: 13.07.2024 21:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--GetById
CREATE PROC [dbo].[Get_TH_by_Id]
(
	@Id INT
)
AS
BEGIN
	SELECT * FROM timesheets WITH (NOLOCK)
	WHERE id = @Id
END
GO
