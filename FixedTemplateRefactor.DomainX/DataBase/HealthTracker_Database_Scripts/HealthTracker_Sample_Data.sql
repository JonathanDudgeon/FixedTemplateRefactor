/*
	Insert sample data into HealthTracker database
*/
USE HealthTracker
GO

PRINT N'Deleting any existing data...'
GO
-- Delete all existing records
DELETE FROM [dbo].[Activities]
DELETE FROM [dbo].[Hydrations]
DELETE FROM [dbo].[Meals]
DELETE FROM [dbo].[People]
DELETE FROM [dbo].[ActivityTypes]
DELETE FROM [dbo].[MealTypes]

PRINT N'Inserting sample data...'
GO
-- Insert Activity Types
SET IDENTITY_INSERT [dbo].[ActivityTypes] ON
INSERT INTO [dbo].[ActivityTypes] ([ActivityTypeId], [Description]) VALUES (1, N'Treadmill')
INSERT INTO [dbo].[ActivityTypes] ([ActivityTypeId], [Description]) VALUES (2, N'Jogging')
INSERT INTO [dbo].[ActivityTypes] ([ActivityTypeId], [Description]) VALUES (3, N'Weight Training')
INSERT INTO [dbo].[ActivityTypes] ([ActivityTypeId], [Description]) VALUES (4, N'Biking')
INSERT INTO [dbo].[ActivityTypes] ([ActivityTypeId], [Description]) VALUES (5, N'Aerobics')
INSERT INTO [dbo].[ActivityTypes] ([ActivityTypeId], [Description]) VALUES (6, N'Other')
SET IDENTITY_INSERT [dbo].[ActivityTypes] OFF

-- Insert Meal Types
SET IDENTITY_INSERT [dbo].[MealTypes] ON
INSERT INTO [dbo].[MealTypes] ([MealTypeId], [Description]) VALUES (1, N'Breakfast')
INSERT INTO [dbo].[MealTypes] ([MealTypeId], [Description]) VALUES (2, N'Mid-Morning')
INSERT INTO [dbo].[MealTypes] ([MealTypeId], [Description]) VALUES (3, N'Lunch')
INSERT INTO [dbo].[MealTypes] ([MealTypeId], [Description]) VALUES (4, N'Mid-Afternoon')
INSERT INTO [dbo].[MealTypes] ([MealTypeId], [Description]) VALUES (5, N'Dinner')
INSERT INTO [dbo].[MealTypes] ([MealTypeId], [Description]) VALUES (6, N'Snack')
INSERT INTO [dbo].[MealTypes] ([MealTypeId], [Description]) VALUES (7, N'Brunch')
INSERT INTO [dbo].[MealTypes] ([MealTypeId], [Description]) VALUES (8, N'Other')
SET IDENTITY_INSERT [dbo].[MealTypes] OFF

-- Insert People
SET IDENTITY_INSERT [dbo].[People] ON
INSERT INTO [dbo].[People] ([PersonId], [Name]) VALUES (1, N'John Doe')
INSERT INTO [dbo].[People] ([PersonId], [Name]) VALUES (2, N'Maria Garcia')
INSERT INTO [dbo].[People] ([PersonId], [Name]) VALUES (3, N'Rahul Gupta')
INSERT INTO [dbo].[People] ([PersonId], [Name]) VALUES (4, N'Shreya Chopra')
SET IDENTITY_INSERT [dbo].[People] OFF

-- Insert Activities
SET IDENTITY_INSERT [dbo].[Activities] ON
INSERT INTO [dbo].[Activities] ([ActivityId], [Date], [ActivityTypeId], [Notes], [PersonId]) VALUES ( 1, DATEADD(d,-0,GETDATE()), 1, N'30 Minutes, 500 Calories', 1)
INSERT INTO [dbo].[Activities] ([ActivityId], [Date], [ActivityTypeId], [Notes], [PersonId]) VALUES ( 2, DATEADD(d,-1,GETDATE()), 1, N'30 Minutes, 500 Calories', 1)
INSERT INTO [dbo].[Activities] ([ActivityId], [Date], [ActivityTypeId], [Notes], [PersonId]) VALUES ( 3, DATEADD(d,-2,GETDATE()), 1, N'40 Minutes, 600 Calories', 1)
INSERT INTO [dbo].[Activities] ([ActivityId], [Date], [ActivityTypeId], [Notes], [PersonId]) VALUES ( 4, DATEADD(d,-3,GETDATE()), 1, N'40 Minutes, 600 Calories', 1)
INSERT INTO [dbo].[Activities] ([ActivityId], [Date], [ActivityTypeId], [Notes], [PersonId]) VALUES ( 5, DATEADD(d,-4,GETDATE()), 1, N'30 Minutes, 500 Calories', 1)
INSERT INTO [dbo].[Activities] ([ActivityId], [Date], [ActivityTypeId], [Notes], [PersonId]) VALUES ( 6, DATEADD(d,-5,GETDATE()), 1, N'35 Minutes, 450 Calories', 1)
INSERT INTO [dbo].[Activities] ([ActivityId], [Date], [ActivityTypeId], [Notes], [PersonId]) VALUES ( 7, DATEADD(d,-6,GETDATE()), 1, N'35 Minutes, 450 Calories', 1)
INSERT INTO [dbo].[Activities] ([ActivityId], [Date], [ActivityTypeId], [Notes], [PersonId]) VALUES ( 8, DATEADD(d,-0,GETDATE()), 1, N'30 Minutes, 500 Calories', 2)
INSERT INTO [dbo].[Activities] ([ActivityId], [Date], [ActivityTypeId], [Notes], [PersonId]) VALUES ( 9, DATEADD(d,-1,GETDATE()), 2, N'5 Miles Cross-Country', 2)
INSERT INTO [dbo].[Activities] ([ActivityId], [Date], [ActivityTypeId], [Notes], [PersonId]) VALUES (10, DATEADD(d,-1,GETDATE()), 3, N'45 Minutes, 20 Sets', 3)
INSERT INTO [dbo].[Activities] ([ActivityId], [Date], [ActivityTypeId], [Notes], [PersonId]) VALUES (11, DATEADD(d,-1,GETDATE()), 1, N'12K Road Race', 4)
SET IDENTITY_INSERT [dbo].[Activities] OFF

-- Insert Hydrations
SET IDENTITY_INSERT [dbo].[Hydrations] ON
INSERT INTO [dbo].[Hydrations] ([HydrationId], [Date], [Count], [PersonId]) VALUES (1, DATEADD(d,-0,GETDATE()), 8, 1)
INSERT INTO [dbo].[Hydrations] ([HydrationId], [Date], [Count], [PersonId]) VALUES (2, DATEADD(d,-1,GETDATE()), 8, 1)
INSERT INTO [dbo].[Hydrations] ([HydrationId], [Date], [Count], [PersonId]) VALUES (3, DATEADD(d,-2,GETDATE()), 7, 1)
INSERT INTO [dbo].[Hydrations] ([HydrationId], [Date], [Count], [PersonId]) VALUES (4, DATEADD(d,-3,GETDATE()), 8, 1)
INSERT INTO [dbo].[Hydrations] ([HydrationId], [Date], [Count], [PersonId]) VALUES (5, DATEADD(d,-4,GETDATE()), 6, 1)
INSERT INTO [dbo].[Hydrations] ([HydrationId], [Date], [Count], [PersonId]) VALUES (6, DATEADD(d,-5,GETDATE()), 7, 1)
INSERT INTO [dbo].[Hydrations] ([HydrationId], [Date], [Count], [PersonId]) VALUES (7, DATEADD(d,-6,GETDATE()), 8, 1)
INSERT INTO [dbo].[Hydrations] ([HydrationId], [Date], [Count], [PersonId]) VALUES (8, DATEADD(d,-0,GETDATE()), 5, 2)
SET IDENTITY_INSERT [dbo].[Hydrations] OFF

-- Insert Meals
SET IDENTITY_INSERT [dbo].[Meals] ON
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES ( 1, DATEADD(d,-0,GETDATE()), 1, N'2 Slices Toast, 1 Orange', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES ( 2, DATEADD(d,-1,GETDATE()), 1, N'2 Slices Toast, 1 Orange', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES ( 3, DATEADD(d,-2,GETDATE()), 1, N'1 Bowl Cereal, 1 Banana', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES ( 4, DATEADD(d,-3,GETDATE()), 1, N'2 Slices Toast, 1 Orange', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES ( 5, DATEADD(d,-4,GETDATE()), 1, N'1 Protein Bar', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES ( 6, DATEADD(d,-5,GETDATE()), 1, N'2 Slices Toast, 1 Orange', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES ( 7, DATEADD(d,-6,GETDATE()), 1, N'1 Bowl Cereal, 1 Banana', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES ( 8, DATEADD(d,-0,GETDATE()), 3, N'2 Slices Toast, 1 Orange', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES ( 9, DATEADD(d,-1,GETDATE()), 3, N'1 Protein Shake, 1 Apple', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES (10, DATEADD(d,-2,GETDATE()), 3, N'1 Protein Shake, 1 Banana', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES (11, DATEADD(d,-3,GETDATE()), 3, N'1 Turkey Sandwich, Potato Chips, Apple Pie', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES (12, DATEADD(d,-4,GETDATE()), 3, N'1 Protein Shake, 1 Banana', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES (13, DATEADD(d,-5,GETDATE()), 3, N'1 Protein Shake, 1 Apple', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES (14, DATEADD(d,-6,GETDATE()), 3, N'1 Tuna fish Sandwich, 1 Orange', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES (15, DATEADD(d,-0,GETDATE()), 5, N'Steak, French Fries, Corn', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES (16, DATEADD(d,-1,GETDATE()), 5, N'Fish Fry, Coleslaw, Ice Cream', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES (17, DATEADD(d,-2,GETDATE()), 5, N'Pork Chops, Baked Potato, Green Beans', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES (18, DATEADD(d,-3,GETDATE()), 5, N'Turkey Sandwich, Potato Chips, Apple Pie', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES (19, DATEADD(d,-4,GETDATE()), 5, N'Chicken BBQ, Coleslaw, Chocolate Pie', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES (20, DATEADD(d,-5,GETDATE()), 5, N'Hamburger, French Fries, Green Beans', 1)
INSERT INTO [dbo].[Meals] ([MealId], [Date], [MealTypeId], [Description], [PersonId]) VALUES (21, DATEADD(d,-6,GETDATE()), 5, N'Meatloaf, Garden Salad, Ice Cream', 1)
SET IDENTITY_INSERT [dbo].[Meals] OFF

PRINT N'Sample data inserted...'
GO