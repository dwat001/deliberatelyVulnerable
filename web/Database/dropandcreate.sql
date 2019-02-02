USE master
IF EXISTS (SELECT * FROM sys.databases where name = N'DeliberatelyVulnerable')
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'DeliberatelyVulnerable'
	GO

	/* Query to Get Exclusive Access of SQL Server Database before Dropping the Database  */
	ALTER DATABASE DeliberatelyVulnerable SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	GO

	DROP DATABASE DeliberatelyVulnerable

GO

CREATE DATABASE DeliberatelyVulnerable