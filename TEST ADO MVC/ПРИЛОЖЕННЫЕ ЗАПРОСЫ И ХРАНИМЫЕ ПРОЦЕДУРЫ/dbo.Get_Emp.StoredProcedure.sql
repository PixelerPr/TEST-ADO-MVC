USE [Test_Task]
GO
/****** Object:  StoredProcedure [dbo].[Get_Emp]    Script Date: 13.07.2024 21:14:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Get_Emp]
AS
BEGIN
	SELECT * FROM employees WITH (NOLOCK)
END
GO
