SET IDENTITY_INSERT [dbo].[Movie] ON
INSERT INTO [dbo].[Movie] ([Id], [title], [releaseDate], [genre], [price]) VALUES (1, N'300', N'2001-03-22', N'Action', 5.12)
INSERT INTO [dbo].[Movie] ([Id], [title], [releaseDate], [genre], [price]) VALUES (3, N'Z', N'2020-10-20', N'Kids', 3.99)
INSERT INTO [dbo].[Movie] ([Id], [title], [releaseDate], [genre], [price]) VALUES (4, N'MadMax', N'2020-10-20', N'Action', 3.11)
INSERT INTO [dbo].[Movie] ([Id], [title], [releaseDate], [genre], [price]) VALUES (5, N'Ma', N'1230-10-20', N'Children', 9.23)
SET IDENTITY_INSERT [dbo].[Movie] OFF

Alter Table Movie
ADD images varbinary (4056)