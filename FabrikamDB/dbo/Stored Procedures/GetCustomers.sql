CREATE PROCEDURE [dbo].[GetCustomers]
AS
	SELECT * FROM [$(TableName)]
	ORDER BY [$(OrderBy)]