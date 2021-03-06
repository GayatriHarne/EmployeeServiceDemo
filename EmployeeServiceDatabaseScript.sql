USE [GH]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 15/03/2021 10:50:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[Salary] [int] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 15/03/2021 10:50:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Gender], [Salary]) VALUES (0, N'Anupam', N'HRN', N'Male', 75000)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Gender], [Salary]) VALUES (2, N'Sanvi', N'HRN', N'FeMale', 75000)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Gender], [Salary]) VALUES (3, N'Mary', N'Lambeth', N'Female', 68000)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Gender], [Salary]) VALUES (4, N'Genlia1', N'Dart11', N'Female', 71000)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Gender], [Salary]) VALUES (5, N'test1', N'Lastname', N'Male', 61000)
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [Gender], [Salary]) VALUES (6, N'test2', N'Togbey', N'Female', 65000)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Username], [Password]) VALUES (1, N'male', N'male')
INSERT [dbo].[Users] ([Id], [Username], [Password]) VALUES (2, N'female', N'female')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
