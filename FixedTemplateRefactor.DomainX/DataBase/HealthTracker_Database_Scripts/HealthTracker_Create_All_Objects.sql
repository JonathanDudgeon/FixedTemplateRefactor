/*
Deployment script for HealthTracker database
Creates all database objects
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;

GO
PRINT N'Creating [dbo].[Activities]...';


GO
CREATE TABLE [dbo].[Activities] (
    [ActivityId]     INT            IDENTITY (1, 1) NOT NULL,
    [Date]           DATETIME       NOT NULL,
    [ActivityTypeId] INT            NOT NULL,
    [Notes]          NVARCHAR (100) NULL,
    [PersonId]       INT            NOT NULL,
    CONSTRAINT [PK_dbo.Activities] PRIMARY KEY CLUSTERED ([ActivityId] ASC)
);


GO
PRINT N'Creating [dbo].[Activities].[IX_PersonId]...';


GO
CREATE NONCLUSTERED INDEX [IX_PersonId]
    ON [dbo].[Activities]([PersonId] ASC);


GO
PRINT N'Creating [dbo].[ActivityTypes]...';


GO
CREATE TABLE [dbo].[ActivityTypes] (
    [ActivityTypeId] INT          IDENTITY (1, 1) NOT NULL,
    [Description]    VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_ActivityTypes] PRIMARY KEY CLUSTERED ([ActivityTypeId] ASC)
);


GO
PRINT N'Creating [dbo].[Hydrations]...';


GO
CREATE TABLE [dbo].[Hydrations] (
    [HydrationId] INT      IDENTITY (1, 1) NOT NULL,
    [Date]        DATETIME NOT NULL,
    [Count]       INT      NOT NULL,
    [PersonId]    INT      NOT NULL,
    CONSTRAINT [PK_dbo.Hydrations] PRIMARY KEY CLUSTERED ([HydrationId] ASC)
);


GO
PRINT N'Creating [dbo].[Hydrations].[IX_PersonId]...';


GO
CREATE NONCLUSTERED INDEX [IX_PersonId]
    ON [dbo].[Hydrations]([PersonId] ASC);


GO
PRINT N'Creating [dbo].[Meals]...';


GO
CREATE TABLE [dbo].[Meals] (
    [MealId]      INT            IDENTITY (1, 1) NOT NULL,
    [Date]        DATETIME       NOT NULL,
    [MealTypeId]  INT            NOT NULL,
    [Description] NVARCHAR (100) NULL,
    [PersonId]    INT            NOT NULL,
    CONSTRAINT [PK_dbo.Meals] PRIMARY KEY CLUSTERED ([MealId] ASC)
);


GO
PRINT N'Creating [dbo].[Meals].[IX_PersonId]...';


GO
CREATE NONCLUSTERED INDEX [IX_PersonId]
    ON [dbo].[Meals]([PersonId] ASC);


GO
PRINT N'Creating [dbo].[MealTypes]...';


GO
CREATE TABLE [dbo].[MealTypes] (
    [MealTypeId]  INT          IDENTITY (1, 1) NOT NULL,
    [Description] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_MealTypes] PRIMARY KEY CLUSTERED ([MealTypeId] ASC)
);


GO
PRINT N'Creating [dbo].[People]...';


GO
CREATE TABLE [dbo].[People] (
    [PersonId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_dbo.People] PRIMARY KEY CLUSTERED ([PersonId] ASC)
);


GO
PRINT N'Creating FK_dbo.Activities_dbo.People_PersonId...';


GO
ALTER TABLE [dbo].[Activities] WITH NOCHECK
    ADD CONSTRAINT [FK_dbo.Activities_dbo.People_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[People] ([PersonId]) ON DELETE CASCADE;


GO
PRINT N'Creating FK_Activities_ActivityTypes...';


GO
ALTER TABLE [dbo].[Activities] WITH NOCHECK
    ADD CONSTRAINT [FK_Activities_ActivityTypes] FOREIGN KEY ([ActivityTypeId]) REFERENCES [dbo].[ActivityTypes] ([ActivityTypeId]);


GO
PRINT N'Creating FK_dbo.Hydrations_dbo.People_PersonId...';


GO
ALTER TABLE [dbo].[Hydrations] WITH NOCHECK
    ADD CONSTRAINT [FK_dbo.Hydrations_dbo.People_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[People] ([PersonId]) ON DELETE CASCADE;


GO
PRINT N'Creating FK_dbo.Meals_dbo.People_PersonId...';


GO
ALTER TABLE [dbo].[Meals] WITH NOCHECK
    ADD CONSTRAINT [FK_dbo.Meals_dbo.People_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[People] ([PersonId]) ON DELETE CASCADE;


GO
PRINT N'Creating FK_Meals_MealTypes...';


GO
ALTER TABLE [dbo].[Meals] WITH NOCHECK
    ADD CONSTRAINT [FK_Meals_MealTypes] FOREIGN KEY ([MealTypeId]) REFERENCES [dbo].[MealTypes] ([MealTypeId]);


GO
PRINT N'Creating [dbo].[CountActivities]...';


GO
CREATE FUNCTION [dbo].[CountActivities]
(
	@personId int
)
RETURNS INT
AS
BEGIN
	RETURN
	(
		SELECT COUNT(ActivityId) FROM dbo.Activities
		WHERE PersonId = @personId
	);
END
GO
PRINT N'Creating [dbo].[CountHydrations]...';


GO
CREATE FUNCTION [dbo].[CountHydrations]
(
	@personId int
)
RETURNS INT
AS
BEGIN
	RETURN
	(
		SELECT COUNT(HydrationId) FROM dbo.Hydrations
		WHERE PersonId = @personId
	);
END
GO
PRINT N'Creating [dbo].[CountMeals]...';


GO
CREATE FUNCTION [dbo].[CountMeals]
(
	@personId int
)
RETURNS INT
AS
BEGIN
	RETURN
	(
		SELECT COUNT(MealId) FROM dbo.Meals
		WHERE PersonId = @personId
	);
END
GO
PRINT N'Creating [dbo].[PersonSummaryViews]...';


GO
CREATE VIEW [dbo].[PersonSummaryViews]
	AS SELECT PersonId, Name, 
		dbo.CountActivities(PersonId)	AS	[ActivitiesCount], 
		dbo.CountMeals(PersonId)		AS	[MealsCount], 
		dbo.CountActivities(PersonId)	AS	[HydrationCount]
	FROM dbo.People
GO
PRINT N'Creating [dbo].[GetPersonSummary]...';


GO
CREATE PROCEDURE [dbo].[GetPersonSummary]
	@personId int = 0
AS
	SELECT PersonId, Name, 
		dbo.CountActivities(@personId)	AS	[ActivitiesCount], 
		dbo.CountMeals(@personId)		AS	[MealsCount], 
		dbo.CountActivities(@personId)	AS	[HydrationCount]
	FROM dbo.People
	WHERE PersonId = @personId
RETURN 0
GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [HealthTracker];


GO
ALTER TABLE [dbo].[Activities] WITH CHECK CHECK CONSTRAINT [FK_dbo.Activities_dbo.People_PersonId];

ALTER TABLE [dbo].[Activities] WITH CHECK CHECK CONSTRAINT [FK_Activities_ActivityTypes];

ALTER TABLE [dbo].[Hydrations] WITH CHECK CHECK CONSTRAINT [FK_dbo.Hydrations_dbo.People_PersonId];

ALTER TABLE [dbo].[Meals] WITH CHECK CHECK CONSTRAINT [FK_dbo.Meals_dbo.People_PersonId];

ALTER TABLE [dbo].[Meals] WITH CHECK CHECK CONSTRAINT [FK_Meals_MealTypes];


GO
PRINT N'Update complete.'
GO
