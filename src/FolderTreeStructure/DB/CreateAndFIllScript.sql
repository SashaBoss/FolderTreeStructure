USE [FolderTree]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Folder](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[folder_name] [nvarchar](255) NOT NULL,
	[parent_id] [int] NOT NULL,
	CONSTRAINT chars_spaces_only CHECK (folder_name NOT LIKE '%[^A-Z]{ }%'),
 CONSTRAINT [PK_Folder] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Folder] ON 

INSERT [dbo].[Folder] ([id], [folder_name], [parent_id]) VALUES (1, N'Creating digital images', 0)
INSERT [dbo].[Folder] ([id], [folder_name], [parent_id]) VALUES (3, N'Evidence', 1)
INSERT [dbo].[Folder] ([id], [folder_name], [parent_id]) VALUES (4, N'Graphic Products', 1)
INSERT [dbo].[Folder] ([id], [folder_name], [parent_id]) VALUES (7, N'Process', 4)
INSERT [dbo].[Folder] ([id], [folder_name], [parent_id]) VALUES (2, N'Resources', 1)
INSERT [dbo].[Folder] ([id], [folder_name], [parent_id]) VALUES (5, N'Primary Sources', 2)
INSERT [dbo].[Folder] ([id], [folder_name], [parent_id]) VALUES (6, N'Secondary Sources', 2)
INSERT [dbo].[Folder] ([id], [folder_name], [parent_id]) VALUES (8, N'Final Product', 4)
SET IDENTITY_INSERT [dbo].[Folder] OFF
SET ANSI_PADDING ON

GO

ALTER TABLE [dbo].[Folder] ADD  CONSTRAINT [level_unique] UNIQUE NONCLUSTERED 
(
	[parent_id] ASC,
	[folder_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
