SET IDENTITY_INSERT [dbo].[Locations] ON 

INSERT [dbo].[Locations] ([Id], [Guid], [Name], [Description], [Street], [City], [CreatedOn], [UpdatedOn], [ParentLocationId], [UserId]) VALUES (1, N'23ed6fc2-5c78-4d40-a87e-8e145ff23569', N'Green room', N'Green room in the corner of the flat', NULL, NULL, CAST(N'2020-07-23T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Locations] OFF
