SET IDENTITY_INSERT [dbo].[Currencies] ON 

INSERT [dbo].[Currencies] ([Id], [Name], [Code], [CreatedOn], [UpdatedOn]) VALUES (1, N'Priceless', N'$$$', CAST(N'2020-07-23T00:00:00.0000000+00:00' AS DateTimeOffset), NULL)
INSERT [dbo].[Currencies] ([Id], [Name], [Code], [CreatedOn], [UpdatedOn]) VALUES (2, N'Polish zloty', N'PLN', CAST(N'2020-07-23T00:00:00.0000000+00:00' AS DateTimeOffset), NULL)
INSERT [dbo].[Currencies] ([Id], [Name], [Code], [CreatedOn], [UpdatedOn]) VALUES (3, N'United States dollar', N'USD', CAST(N'2020-07-23T00:00:00.0000000+00:00' AS DateTimeOffset), NULL)
SET IDENTITY_INSERT [dbo].[Currencies] OFF
