SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [Name], [Path], [Format], [CreatedOn], [UpdatedOn]) VALUES (1, N'Fake', N'/fake/path', N'.fake', CAST(N'2020-07-23T00:00:00.0000000+00:00' AS DateTimeOffset), NULL)
SET IDENTITY_INSERT [dbo].[Images] OFF
