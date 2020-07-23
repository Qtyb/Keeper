SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [Description], [CreatedOn], [UpdatedOn], [ParentCategoryId]) VALUES (1, N'Root', N'Root category', CAST(N'2020-07-23T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, NULL)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [CreatedOn], [UpdatedOn], [ParentCategoryId]) VALUES (2, N'Electronics', N'Category for electronics ex. phones, computers, network devices', CAST(N'2020-07-23T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, 1)
INSERT [dbo].[Categories] ([Id], [Name], [Description], [CreatedOn], [UpdatedOn], [ParentCategoryId]) VALUES (3, N'Maintance', N'Category for things used for electronics maintance', CAST(N'2020-07-23T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, 2)
SET IDENTITY_INSERT [dbo].[Categories] OFF
