/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
MERGE INTO Team AS Target
USING (VALUES
		(1,'Pirates','Hockey',84055),
		(2,'Cavaliers','Basketball',84024),
		(3,'Redskins','Football',84317),
		(4,'Diamondbacks','Baseball',84108),
		(5,'Warriors','Basketball',89128),
		(6,'Seahawks','Football',84326),
(7,'Oilers','Hockey',84041)
)
AS Source (TeamId, TeamName, Sport, ZipCode)
ON Target.TeamID = Source.TeamID
WHEN NOT MATCHED BY TARGET THEN
INSERT (TeamName, Sport, ZipCode)
VALUES (TeamName, Sport, ZipCode);