USE [ManagementHRM]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 28/05/2023 16:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](500) NULL,
	[roleId] [int] NULL,
	[staffId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 28/05/2023 16:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[basicSalary] [float] NULL,
	[allowance] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Department]    Script Date: 28/05/2023 16:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EnglishLevel]    Script Date: 28/05/2023 16:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnglishLevel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Insurance]    Script Date: 28/05/2023 16:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Insurance](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[startDate] [date] NULL,
	[endDate] [date] NULL,
	[money] [float] NULL,
	[staffId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ITLevel]    Script Date: 28/05/2023 16:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ITLevel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Level]    Script Date: 28/05/2023 16:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Level](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Position]    Script Date: 28/05/2023 16:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Punish]    Script Date: 28/05/2023 16:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Punish](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[staffId] [int] NULL,
	[mission] [nvarchar](500) NULL,
	[createDate] [date] NULL,
	[regulationPunishId] [int] NULL,
	[money] [float] NULL,
	[note] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RegulationPunish]    Script Date: 28/05/2023 16:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegulationPunish](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[money] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RegulationReward]    Script Date: 28/05/2023 16:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegulationReward](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[money] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reward]    Script Date: 28/05/2023 16:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reward](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[staffId] [int] NULL,
	[mission] [nvarchar](500) NULL,
	[createDate] [date] NULL,
	[regulationRewardId] [int] NULL,
	[money] [float] NULL,
	[note] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 28/05/2023 16:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Salary]    Script Date: 28/05/2023 16:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salary](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[staffId] [int] NULL,
	[basicSalary] [float] NULL,
	[allowance] [float] NULL,
	[numberOfWorkDay] [int] NULL,
	[moneyReward] [float] NULL,
	[moneyPunish] [float] NULL,
	[createDate] [date] NULL,
	[departmentId] [int] NULL,
	[moneyInsurance] [float] NULL,
	[month] [int] NULL,
	[year] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Staff]    Script Date: 28/05/2023 16:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Staff](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NULL,
	[image] [nvarchar](500) NULL,
	[dateOfBirth] [date] NULL,
	[dateOfWork] [date] NULL,
	[sex] [bit] NULL,
	[phone] [varchar](11) NULL,
	[address] [nvarchar](500) NULL,
	[identityCard] [varchar](20) NULL,
	[positionId] [int] NULL,
	[contractId] [int] NULL,
	[levelId] [int] NULL,
	[departmentId] [int] NULL,
	[status] [bit] NULL,
	[englishLevelId] [int] NULL,
	[itLevelId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Timekeeping]    Script Date: 28/05/2023 16:03:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Timekeeping](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[staffId] [int] NULL,
	[createDate] [date] NULL,
	[status] [bit] NULL,
	[departmentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([id], [username], [password], [roleId], [staffId]) VALUES (1, N'admin', N'827ccb0eea8a706c4c34a16891f84e7b', 1, 3)
INSERT [dbo].[Account] ([id], [username], [password], [roleId], [staffId]) VALUES (4, N'toan', N'827ccb0eea8a706c4c34a16891f84e7b', 2, 4)
SET IDENTITY_INSERT [dbo].[Account] OFF
SET IDENTITY_INSERT [dbo].[Contract] ON 

INSERT [dbo].[Contract] ([id], [name], [basicSalary], [allowance]) VALUES (1, N'Intern(Thực tập)', 100000, 25000)
INSERT [dbo].[Contract] ([id], [name], [basicSalary], [allowance]) VALUES (3, N'Fresher(Sinh Viên ít kinh nghiệm)', 200000, 50000)
INSERT [dbo].[Contract] ([id], [name], [basicSalary], [allowance]) VALUES (4, N'Junior(Sơ cấp)', 400000, 100000)
INSERT [dbo].[Contract] ([id], [name], [basicSalary], [allowance]) VALUES (5, N'Middle(Trung cấp) ', 600000, 200000)
SET IDENTITY_INSERT [dbo].[Contract] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([id], [name]) VALUES (1, N'Kế toán')
INSERT [dbo].[Department] ([id], [name]) VALUES (2, N'IT')
INSERT [dbo].[Department] ([id], [name]) VALUES (3, N'Nhân sự')
INSERT [dbo].[Department] ([id], [name]) VALUES (4, N'Giám đốc')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[EnglishLevel] ON 

INSERT [dbo].[EnglishLevel] ([id], [name]) VALUES (1, N'Toeic')
INSERT [dbo].[EnglishLevel] ([id], [name]) VALUES (2, N'ITLES')
INSERT [dbo].[EnglishLevel] ([id], [name]) VALUES (3, N'TOEF')
SET IDENTITY_INSERT [dbo].[EnglishLevel] OFF
SET IDENTITY_INSERT [dbo].[Insurance] ON 

INSERT [dbo].[Insurance] ([id], [name], [startDate], [endDate], [money], [staffId]) VALUES (2, N'Bảo hiểm y tế', CAST(N'2023-04-06' AS Date), CAST(N'2023-04-26' AS Date), 500000, 3)
SET IDENTITY_INSERT [dbo].[Insurance] OFF
SET IDENTITY_INSERT [dbo].[ITLevel] ON 

INSERT [dbo].[ITLevel] ([id], [name]) VALUES (1, N'MOS')
INSERT [dbo].[ITLevel] ([id], [name]) VALUES (2, N'C1')
INSERT [dbo].[ITLevel] ([id], [name]) VALUES (3, N'C2')
SET IDENTITY_INSERT [dbo].[ITLevel] OFF
SET IDENTITY_INSERT [dbo].[Level] ON 

INSERT [dbo].[Level] ([id], [name]) VALUES (1, N'Đại học')
INSERT [dbo].[Level] ([id], [name]) VALUES (2, N'Cao đẳng')
INSERT [dbo].[Level] ([id], [name]) VALUES (3, N'Trung cấp')
INSERT [dbo].[Level] ([id], [name]) VALUES (4, N'THPT')
SET IDENTITY_INSERT [dbo].[Level] OFF
SET IDENTITY_INSERT [dbo].[Position] ON 

INSERT [dbo].[Position] ([id], [name]) VALUES (1, N'Nhân viên')
INSERT [dbo].[Position] ([id], [name]) VALUES (2, N'Giám đốc')
INSERT [dbo].[Position] ([id], [name]) VALUES (3, N'Trưởng phòng')
INSERT [dbo].[Position] ([id], [name]) VALUES (4, N'Thư ký')
SET IDENTITY_INSERT [dbo].[Position] OFF
SET IDENTITY_INSERT [dbo].[Punish] ON 

INSERT [dbo].[Punish] ([id], [staffId], [mission], [createDate], [regulationPunishId], [money], [note]) VALUES (1, 3, N'đi trễ quá nha', CAST(N'2023-04-25' AS Date), 1, 50000, N'đã đóng')
INSERT [dbo].[Punish] ([id], [staffId], [mission], [createDate], [regulationPunishId], [money], [note]) VALUES (2, 3, N'về quá sớm', CAST(N'2023-04-25' AS Date), 2, 100000, N'S')
INSERT [dbo].[Punish] ([id], [staffId], [mission], [createDate], [regulationPunishId], [money], [note]) VALUES (3, 4, N'đi trễ', CAST(N'2023-04-25' AS Date), 1, 50000, N'')
INSERT [dbo].[Punish] ([id], [staffId], [mission], [createDate], [regulationPunishId], [money], [note]) VALUES (4, 4, N'về sớm', CAST(N'2023-04-25' AS Date), 2, 100000, N'')
INSERT [dbo].[Punish] ([id], [staffId], [mission], [createDate], [regulationPunishId], [money], [note]) VALUES (5, 8, N'đi trễ', CAST(N'2023-04-25' AS Date), 1, 50000, N'đã đóng')
SET IDENTITY_INSERT [dbo].[Punish] OFF
SET IDENTITY_INSERT [dbo].[RegulationPunish] ON 

INSERT [dbo].[RegulationPunish] ([id], [name], [money]) VALUES (1, N'Đi trễ', 50000)
INSERT [dbo].[RegulationPunish] ([id], [name], [money]) VALUES (2, N'Về sớm hơn quy định', 100000)
INSERT [dbo].[RegulationPunish] ([id], [name], [money]) VALUES (3, N'Đồng phục không đúng quy định', 150000)
SET IDENTITY_INSERT [dbo].[RegulationPunish] OFF
SET IDENTITY_INSERT [dbo].[RegulationReward] ON 

INSERT [dbo].[RegulationReward] ([id], [name], [money]) VALUES (1, N'Giải thưởng cấp phòng', 1000000)
INSERT [dbo].[RegulationReward] ([id], [name], [money]) VALUES (2, N'Năng suất cao', 500000)
SET IDENTITY_INSERT [dbo].[RegulationReward] OFF
SET IDENTITY_INSERT [dbo].[Reward] ON 

INSERT [dbo].[Reward] ([id], [staffId], [mission], [createDate], [regulationRewardId], [money], [note]) VALUES (1, 3, N'giải thưởng nghiên cứu cấp phòng', CAST(N'2023-04-25' AS Date), 1, 50000, N'oke')
INSERT [dbo].[Reward] ([id], [staffId], [mission], [createDate], [regulationRewardId], [money], [note]) VALUES (2, 4, N'hi;hi', CAST(N'2023-04-25' AS Date), 2, 500000, N'')
INSERT [dbo].[Reward] ([id], [staffId], [mission], [createDate], [regulationRewardId], [money], [note]) VALUES (3, 5, N'da', CAST(N'2023-04-25' AS Date), 1, 1000000, N'')
SET IDENTITY_INSERT [dbo].[Reward] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([id], [name]) VALUES (1, N'admin')
INSERT [dbo].[Role] ([id], [name]) VALUES (2, N'user')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[Salary] ON 

INSERT [dbo].[Salary] ([id], [staffId], [basicSalary], [allowance], [numberOfWorkDay], [moneyReward], [moneyPunish], [createDate], [departmentId], [moneyInsurance], [month], [year]) VALUES (173, 3, 600000, 200000, 3, 0, 0, CAST(N'2023-04-25' AS Date), 1, 500000, 3, 2023)
INSERT [dbo].[Salary] ([id], [staffId], [basicSalary], [allowance], [numberOfWorkDay], [moneyReward], [moneyPunish], [createDate], [departmentId], [moneyInsurance], [month], [year]) VALUES (174, 4, 200000, 50000, 3, 0, 0, CAST(N'2023-04-25' AS Date), 3, 0, 3, 2023)
INSERT [dbo].[Salary] ([id], [staffId], [basicSalary], [allowance], [numberOfWorkDay], [moneyReward], [moneyPunish], [createDate], [departmentId], [moneyInsurance], [month], [year]) VALUES (175, 5, 200000, 50000, 3, 0, 0, CAST(N'2023-04-25' AS Date), 2, 0, 3, 2023)
INSERT [dbo].[Salary] ([id], [staffId], [basicSalary], [allowance], [numberOfWorkDay], [moneyReward], [moneyPunish], [createDate], [departmentId], [moneyInsurance], [month], [year]) VALUES (176, 8, 600000, 200000, 3, 0, 0, CAST(N'2023-04-25' AS Date), 2, 0, 3, 2023)
INSERT [dbo].[Salary] ([id], [staffId], [basicSalary], [allowance], [numberOfWorkDay], [moneyReward], [moneyPunish], [createDate], [departmentId], [moneyInsurance], [month], [year]) VALUES (177, 3, 600000, 200000, 1, 0, 0, CAST(N'2023-04-25' AS Date), 1, 500000, 2, 2023)
INSERT [dbo].[Salary] ([id], [staffId], [basicSalary], [allowance], [numberOfWorkDay], [moneyReward], [moneyPunish], [createDate], [departmentId], [moneyInsurance], [month], [year]) VALUES (178, 4, 200000, 50000, 1, 0, 0, CAST(N'2023-04-25' AS Date), 3, 0, 2, 2023)
INSERT [dbo].[Salary] ([id], [staffId], [basicSalary], [allowance], [numberOfWorkDay], [moneyReward], [moneyPunish], [createDate], [departmentId], [moneyInsurance], [month], [year]) VALUES (179, 5, 200000, 50000, 1, 0, 0, CAST(N'2023-04-25' AS Date), 2, 0, 2, 2023)
INSERT [dbo].[Salary] ([id], [staffId], [basicSalary], [allowance], [numberOfWorkDay], [moneyReward], [moneyPunish], [createDate], [departmentId], [moneyInsurance], [month], [year]) VALUES (180, 8, 600000, 200000, 1, 0, 0, CAST(N'2023-04-25' AS Date), 2, 0, 2, 2023)
INSERT [dbo].[Salary] ([id], [staffId], [basicSalary], [allowance], [numberOfWorkDay], [moneyReward], [moneyPunish], [createDate], [departmentId], [moneyInsurance], [month], [year]) VALUES (185, 3, 600000, 200000, 6, 50000, 150000, CAST(N'2023-04-25' AS Date), 1, 500000, 4, 2023)
INSERT [dbo].[Salary] ([id], [staffId], [basicSalary], [allowance], [numberOfWorkDay], [moneyReward], [moneyPunish], [createDate], [departmentId], [moneyInsurance], [month], [year]) VALUES (186, 4, 200000, 50000, 5, 500000, 150000, CAST(N'2023-04-25' AS Date), 3, 0, 4, 2023)
INSERT [dbo].[Salary] ([id], [staffId], [basicSalary], [allowance], [numberOfWorkDay], [moneyReward], [moneyPunish], [createDate], [departmentId], [moneyInsurance], [month], [year]) VALUES (187, 5, 200000, 50000, 5, 1000000, 0, CAST(N'2023-04-25' AS Date), 2, 0, 4, 2023)
INSERT [dbo].[Salary] ([id], [staffId], [basicSalary], [allowance], [numberOfWorkDay], [moneyReward], [moneyPunish], [createDate], [departmentId], [moneyInsurance], [month], [year]) VALUES (188, 8, 600000, 200000, 3, 0, 50000, CAST(N'2023-04-25' AS Date), 2, 0, 4, 2023)
SET IDENTITY_INSERT [dbo].[Salary] OFF
SET IDENTITY_INSERT [dbo].[Staff] ON 

INSERT [dbo].[Staff] ([id], [name], [image], [dateOfBirth], [dateOfWork], [sex], [phone], [address], [identityCard], [positionId], [contractId], [levelId], [departmentId], [status], [englishLevelId], [itLevelId]) VALUES (3, N'Đào Huy Toàn', N'', CAST(N'2003-01-11' AS Date), CAST(N'2023-04-02' AS Date), 1, N'0376880903', N'Thái Bình', N'34242342', 1, 5, 1, 1, 1, 2, 1)
INSERT [dbo].[Staff] ([id], [name], [image], [dateOfBirth], [dateOfWork], [sex], [phone], [address], [identityCard], [positionId], [contractId], [levelId], [departmentId], [status], [englishLevelId], [itLevelId]) VALUES (4, N'Nguyễn Ngọc Hải', N'', CAST(N'2003-11-21' AS Date), CAST(N'2023-04-25' AS Date), 1, N'0376880903', N'Bắc Giang', N'312382972', 2, 3, 3, 3, 1, 1, 3)
INSERT [dbo].[Staff] ([id], [name], [image], [dateOfBirth], [dateOfWork], [sex], [phone], [address], [identityCard], [positionId], [contractId], [levelId], [departmentId], [status], [englishLevelId], [itLevelId]) VALUES (5, N'Nguyễn Thị Thu Phương', N'', CAST(N'2003-05-22' AS Date), CAST(N'2023-04-02' AS Date), 1, N'0988322241', N'Thái Bình', N'832343829', 2, 3, 2, 2, 1, NULL, NULL)
INSERT [dbo].[Staff] ([id], [name], [image], [dateOfBirth], [dateOfWork], [sex], [phone], [address], [identityCard], [positionId], [contractId], [levelId], [departmentId], [status], [englishLevelId], [itLevelId]) VALUES (8, N'Lưu Thị DUng', N'', CAST(N'2003-01-11' AS Date), CAST(N'2023-04-13' AS Date), 0, N'0988922790', N'Tiền Giang', N'34289292', 2, 5, 1, 2, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Staff] OFF
SET IDENTITY_INSERT [dbo].[Timekeeping] ON 

INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (10, 3, CAST(N'2023-04-25' AS Date), 1, 1)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (11, 4, CAST(N'2023-04-25' AS Date), 1, 3)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (12, 5, CAST(N'2023-04-25' AS Date), 1, 2)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (13, 3, CAST(N'2023-04-19' AS Date), 1, 1)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (14, 4, CAST(N'2023-04-19' AS Date), 1, 3)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (15, 5, CAST(N'2023-04-19' AS Date), 1, 2)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (16, 3, CAST(N'2023-04-13' AS Date), 1, 1)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (17, 4, CAST(N'2023-04-13' AS Date), 1, 3)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (18, 5, CAST(N'2023-04-13' AS Date), 1, 2)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (19, 3, CAST(N'2023-04-24' AS Date), 1, 1)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (20, 4, CAST(N'2023-04-24' AS Date), 0, 3)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (21, 5, CAST(N'2023-04-24' AS Date), 1, 2)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (22, 8, CAST(N'2023-04-25' AS Date), 1, 2)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (23, 8, CAST(N'2023-04-24' AS Date), 1, 2)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (24, 3, CAST(N'2023-04-04' AS Date), 1, 1)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (25, 4, CAST(N'2023-04-04' AS Date), 1, 3)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (26, 5, CAST(N'2023-04-04' AS Date), 0, 2)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (27, 3, CAST(N'2023-04-10' AS Date), 1, 1)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (28, 4, CAST(N'2023-04-10' AS Date), 1, 3)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (29, 5, CAST(N'2023-04-10' AS Date), 1, 2)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (30, 8, CAST(N'2023-04-10' AS Date), 1, 2)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (31, 3, CAST(N'2023-03-27' AS Date), 1, 1)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (32, 4, CAST(N'2023-03-27' AS Date), 1, 3)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (33, 5, CAST(N'2023-03-27' AS Date), 1, 2)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (34, 8, CAST(N'2023-03-27' AS Date), 1, 2)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (35, 3, CAST(N'2023-02-28' AS Date), 1, 1)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (36, 4, CAST(N'2023-02-28' AS Date), 1, 3)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (37, 5, CAST(N'2023-02-28' AS Date), 1, 2)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (38, 8, CAST(N'2023-02-28' AS Date), 1, 2)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (39, 3, CAST(N'2023-03-01' AS Date), 1, 1)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (40, 4, CAST(N'2023-03-01' AS Date), 1, 3)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (41, 5, CAST(N'2023-03-01' AS Date), 1, 2)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (42, 8, CAST(N'2023-03-01' AS Date), 1, 2)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (43, 3, CAST(N'2023-03-02' AS Date), 1, 1)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (44, 4, CAST(N'2023-03-02' AS Date), 1, 3)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (45, 5, CAST(N'2023-03-02' AS Date), 1, 2)
INSERT [dbo].[Timekeeping] ([id], [staffId], [createDate], [status], [departmentId]) VALUES (46, 8, CAST(N'2023-03-02' AS Date), 1, 2)
SET IDENTITY_INSERT [dbo].[Timekeeping] OFF
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [fk_A_R] FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [fk_A_R]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [fk_A_S] FOREIGN KEY([staffId])
REFERENCES [dbo].[Staff] ([id])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [fk_A_S]
GO
ALTER TABLE [dbo].[Insurance]  WITH CHECK ADD  CONSTRAINT [fk_I_Staff] FOREIGN KEY([staffId])
REFERENCES [dbo].[Staff] ([id])
GO
ALTER TABLE [dbo].[Insurance] CHECK CONSTRAINT [fk_I_Staff]
GO
ALTER TABLE [dbo].[Punish]  WITH CHECK ADD  CONSTRAINT [fk_P_RP] FOREIGN KEY([regulationPunishId])
REFERENCES [dbo].[RegulationPunish] ([id])
GO
ALTER TABLE [dbo].[Punish] CHECK CONSTRAINT [fk_P_RP]
GO
ALTER TABLE [dbo].[Punish]  WITH CHECK ADD  CONSTRAINT [fk_P_Staff] FOREIGN KEY([staffId])
REFERENCES [dbo].[Staff] ([id])
GO
ALTER TABLE [dbo].[Punish] CHECK CONSTRAINT [fk_P_Staff]
GO
ALTER TABLE [dbo].[Reward]  WITH CHECK ADD  CONSTRAINT [fk_R_RR] FOREIGN KEY([regulationRewardId])
REFERENCES [dbo].[RegulationReward] ([id])
GO
ALTER TABLE [dbo].[Reward] CHECK CONSTRAINT [fk_R_RR]
GO
ALTER TABLE [dbo].[Reward]  WITH CHECK ADD  CONSTRAINT [fk_R_Staff] FOREIGN KEY([staffId])
REFERENCES [dbo].[Staff] ([id])
GO
ALTER TABLE [dbo].[Reward] CHECK CONSTRAINT [fk_R_Staff]
GO
ALTER TABLE [dbo].[Salary]  WITH CHECK ADD  CONSTRAINT [fk_Salary_Department] FOREIGN KEY([departmentId])
REFERENCES [dbo].[Department] ([id])
GO
ALTER TABLE [dbo].[Salary] CHECK CONSTRAINT [fk_Salary_Department]
GO
ALTER TABLE [dbo].[Salary]  WITH CHECK ADD  CONSTRAINT [fk_Salary_Staff] FOREIGN KEY([staffId])
REFERENCES [dbo].[Staff] ([id])
GO
ALTER TABLE [dbo].[Salary] CHECK CONSTRAINT [fk_Salary_Staff]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [fk_S_Contract] FOREIGN KEY([contractId])
REFERENCES [dbo].[Contract] ([id])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [fk_S_Contract]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [fk_S_Department] FOREIGN KEY([departmentId])
REFERENCES [dbo].[Department] ([id])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [fk_S_Department]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [fk_S_English] FOREIGN KEY([englishLevelId])
REFERENCES [dbo].[EnglishLevel] ([id])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [fk_S_English]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [fk_S_IT] FOREIGN KEY([itLevelId])
REFERENCES [dbo].[ITLevel] ([id])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [fk_S_IT]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [fk_S_Level] FOREIGN KEY([levelId])
REFERENCES [dbo].[Level] ([id])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [fk_S_Level]
GO
ALTER TABLE [dbo].[Staff]  WITH CHECK ADD  CONSTRAINT [fk_S_Position] FOREIGN KEY([positionId])
REFERENCES [dbo].[Position] ([id])
GO
ALTER TABLE [dbo].[Staff] CHECK CONSTRAINT [fk_S_Position]
GO
ALTER TABLE [dbo].[Timekeeping]  WITH CHECK ADD  CONSTRAINT [fk_TK_Department] FOREIGN KEY([departmentId])
REFERENCES [dbo].[Department] ([id])
GO
ALTER TABLE [dbo].[Timekeeping] CHECK CONSTRAINT [fk_TK_Department]
GO
ALTER TABLE [dbo].[Timekeeping]  WITH CHECK ADD  CONSTRAINT [fk_TK_Staff] FOREIGN KEY([staffId])
REFERENCES [dbo].[Staff] ([id])
GO
ALTER TABLE [dbo].[Timekeeping] CHECK CONSTRAINT [fk_TK_Staff]
GO
