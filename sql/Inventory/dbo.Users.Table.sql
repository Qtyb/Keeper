SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Guid], [Name], [Email], [CreatedOn], [UpdatedOn]) VALUES (1, N'00000001-0000-0000-0000-000000000000', N'Hariusz', N'hariusz@keeper.pl', CAST(N'2020-07-23T00:00:00.0000000+00:00' AS DateTimeOffset), NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
