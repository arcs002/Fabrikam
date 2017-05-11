CREATE PROCEDURE [dbo].[GetCustomers]
AS
	SELECT * FROM [$(TableName)]