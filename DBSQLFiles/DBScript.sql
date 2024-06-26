USE [TodoDB]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 6/15/2024 11:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderNumber] [nvarchar](50) NOT NULL,
	[OrderType] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[Remark] [nvarchar](100) NULL,
	[IsValid] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ChangedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderNumber] ASC,
	[OrderType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Todos]    Script Date: 6/15/2024 11:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Todos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[IsComplete] [bit] NULL,
	[UserId] [int] NULL,
	[Priority] [int] NULL,
	[IsDeleted] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Todos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/15/2024 11:35:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NULL,
	[IsValid] [bit] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[UpdatedOn] [datetime] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Todos] ON 

INSERT [dbo].[Todos] ([Id], [Name], [IsComplete], [UserId], [Priority], [IsDeleted], [CreatedOn], [UpdatedOn]) VALUES (3, N'寫報告', 1, 1, 1, 0, CAST(N'2022-03-01T00:00:00.000' AS DateTime), CAST(N'2022-03-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Todos] ([Id], [Name], [IsComplete], [UserId], [Priority], [IsDeleted], [CreatedOn], [UpdatedOn]) VALUES (4, N'看電視', 0, 1, 2, 0, CAST(N'2022-03-01T00:00:00.000' AS DateTime), CAST(N'2022-03-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Todos] ([Id], [Name], [IsComplete], [UserId], [Priority], [IsDeleted], [CreatedOn], [UpdatedOn]) VALUES (5, N'玩遊戲', 0, 3, 1, 0, CAST(N'2022-03-02T00:00:00.000' AS DateTime), CAST(N'2022-03-02T00:00:00.000' AS DateTime))
INSERT [dbo].[Todos] ([Id], [Name], [IsComplete], [UserId], [Priority], [IsDeleted], [CreatedOn], [UpdatedOn]) VALUES (7, N'寫文章', 0, 3, 2, 0, CAST(N'2022-03-03T00:00:00.000' AS DateTime), CAST(N'2022-03-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Todos] ([Id], [Name], [IsComplete], [UserId], [Priority], [IsDeleted], [CreatedOn], [UpdatedOn]) VALUES (8, N'寫程式', 0, 3, 1, 0, CAST(N'2022-03-03T00:00:00.000' AS DateTime), CAST(N'2022-03-03T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Todos] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [UserName], [IsValid], [CreatedOn], [UpdatedOn]) VALUES (1, N'王小名', 1, CAST(N'2022-03-03T00:00:00.000' AS DateTime), CAST(N'2022-03-03T00:00:00.000' AS DateTime))
INSERT [dbo].[Users] ([Id], [UserName], [IsValid], [CreatedOn], [UpdatedOn]) VALUES (3, N'小美', 1, CAST(N'2022-03-03T00:00:00.000' AS DateTime), CAST(N'2022-03-03T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Order Number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'OrderNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Order Type' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'OrderType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Create Order Date' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'CreatedDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Order Remark' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IsValid' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'IsValid'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System Record Create Date ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'CreatedOn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'System Record Change Date' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Order', @level2type=N'COLUMN',@level2name=N'ChangedOn'
GO
