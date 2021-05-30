USE [CollegeManagement]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/31/2021 1:11:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactSupport]    Script Date: 5/31/2021 1:11:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactSupport](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](255) NOT NULL,
	[LastName] [nvarchar](255) NOT NULL,
	[Email] [nvarchar](500) NULL,
	[PhoneNumber] [nvarchar](11) NULL,
	[Infomation] [nvarchar](2000) NULL,
	[Question] [nvarchar](max) NULL,
	[Deleted] [tinyint] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_ContactSupport] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Content]    Script Date: 5/31/2021 1:11:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Content](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Type] [int] NULL,
	[Year] [int] NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Deleted] [tinyint] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Content] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 5/31/2021 1:11:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Code] [nvarchar](5) NOT NULL,
	[Info] [nvarchar](max) NULL,
	[Evaluate] [int] NULL,
	[Price] [int] NULL,
	[DepartmentID] [int] NULL,
	[StudentNumber] [int] NOT NULL,
	[StartDate] [datetime2](7) NULL,
	[EndDate] [datetime2](7) NULL,
	[ImageURL] [nvarchar](500) NULL,
	[Status] [int] NULL,
	[Deleted] [tinyint] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[EntryPoint] [real] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CourseSubject]    Script Date: 5/31/2021 1:11:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseSubject](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CourseID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
	[FacultyID] [int] NOT NULL,
 CONSTRAINT [PK_CourseSubject] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 5/31/2021 1:11:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Info] [nvarchar](2000) NOT NULL,
	[Deleted] [tinyint] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facility]    Script Date: 5/31/2021 1:11:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facility](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Qty] [int] NULL,
	[Info] [nvarchar](1000) NULL,
	[Deleted] [tinyint] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Facility] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacilityImg]    Script Date: 5/31/2021 1:11:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacilityImg](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImgUrl] [nvarchar](500) NOT NULL,
	[FacilityId] [int] NOT NULL,
 CONSTRAINT [PK_FacilityImg] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 5/31/2021 1:11:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Info] [nvarchar](1000) NULL,
	[Gender] [tinyint] NULL,
	[ImageUrl] [nvarchar](500) NULL,
	[DOB] [datetime2](7) NULL,
	[Address] [nvarchar](500) NULL,
	[Email] [nvarchar](500) NULL,
	[PhoneNumber] [nvarchar](11) NULL,
	[ExperienceYear] [int] NULL,
	[DepartmentID] [int] NULL,
	[UserID] [int] NULL,
	[Deleted] [tinyint] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[Testimonials] [nvarchar](500) NULL,
 CONSTRAINT [PK_Faculty] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacultySubject]    Script Date: 5/31/2021 1:11:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacultySubject](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FacultyID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
 CONSTRAINT [PK_FacultySubject] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marks]    Script Date: 5/31/2021 1:11:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marks](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NULL,
	[StudentID] [int] NULL,
	[Score] [int] NULL,
	[Status] [int] NULL,
	[Deleted] [tinyint] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Marks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 5/31/2021 1:11:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[ResponsiblePersonName] [nvarchar](255) NOT NULL,
	[ResponsiblePersonPhone] [nvarchar](11) NOT NULL,
	[Code] [nvarchar](20) NOT NULL,
	[Email] [nvarchar](500) NULL,
	[PhoneNumber] [nvarchar](11) NULL,
	[ResidentialAddress] [nvarchar](500) NULL,
	[PermanentAddress] [nvarchar](500) NULL,
	[ImageURL] [nvarchar](500) NULL,
	[Gender] [tinyint] NULL,
	[DOB] [datetime2](7) NULL,
	[Status] [int] NULL,
	[CourseID] [int] NOT NULL,
	[UserID] [int] NULL,
	[TestScore] [real] NULL,
	[Deleted] [tinyint] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 5/31/2021 1:11:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Info] [nvarchar](2000) NULL,
	[ImageUrl] [nvarchar](500) NULL,
	[Deleted] [tinyint] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/31/2021 1:11:52 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Email] [nvarchar](500) NULL,
	[PhoneNumber] [nvarchar](11) NULL,
	[ImageURL] [nvarchar](500) NULL,
	[Address] [nvarchar](max) NULL,
	[UserName] [nvarchar](64) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Role] [nvarchar](20) NOT NULL,
	[Deleted] [tinyint] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[UpdatedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210519161510_dbMigrate', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210523120053_updateDB', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210529110817_UpdateFacilityMigrations', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210529135344_AddFacilityImgMigrations', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210530071448_UpdateFaculty', N'5.0.5')
GO
SET IDENTITY_INSERT [dbo].[Content] ON 

INSERT [dbo].[Content] ([ID], [Title], [Type], [Year], [Description], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (1, N'Establishment of a college', 1, 1960, N'<p>Establishment of a college<br></p>', NULL, CAST(N'2021-05-31T00:48:17.7787669' AS DateTime2), CAST(N'2021-05-31T00:48:17.7789323' AS DateTime2))
INSERT [dbo].[Content] ([ID], [Title], [Type], [Year], [Description], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (2, N'1970', 1, 1970, N'<p>Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.</p><p>Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.</p>', NULL, CAST(N'2021-05-31T00:49:25.8872912' AS DateTime2), CAST(N'2021-05-31T00:49:25.8872938' AS DateTime2))
INSERT [dbo].[Content] ([ID], [Title], [Type], [Year], [Description], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (3, N'1980', 1, 1980, N'<p>Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.</p><p>Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.</p>', NULL, CAST(N'2021-05-31T00:49:41.1701554' AS DateTime2), CAST(N'2021-05-31T00:49:41.1701574' AS DateTime2))
INSERT [dbo].[Content] ([ID], [Title], [Type], [Year], [Description], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (4, N'1990', 1, 1990, N'<p>Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.</p><p>Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.</p>', NULL, CAST(N'2021-05-31T00:49:57.1514125' AS DateTime2), CAST(N'2021-05-31T00:49:57.1514164' AS DateTime2))
INSERT [dbo].[Content] ([ID], [Title], [Type], [Year], [Description], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (5, N'2000', 1, 2000, N'<p>Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.</p><p>Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.</p>', NULL, CAST(N'2021-05-31T00:50:12.3163327' AS DateTime2), CAST(N'2021-05-31T00:50:12.3163771' AS DateTime2))
INSERT [dbo].[Content] ([ID], [Title], [Type], [Year], [Description], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (6, N'2010', 1, 2010, N'<p>Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.</p><p>Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.</p>', NULL, CAST(N'2021-05-31T01:06:54.4253059' AS DateTime2), CAST(N'2021-05-31T01:06:54.4253161' AS DateTime2))
INSERT [dbo].[Content] ([ID], [Title], [Type], [Year], [Description], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (7, N'2020', 1, 2020, N'<p>Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.</p><p>Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.</p>', NULL, CAST(N'2021-05-31T01:07:10.2271192' AS DateTime2), CAST(N'2021-05-31T01:07:10.2271219' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Content] OFF
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([ID], [Name], [Code], [Info], [Evaluate], [Price], [DepartmentID], [StudentNumber], [StartDate], [EndDate], [ImageURL], [Status], [Deleted], [CreatedAt], [UpdatedAt], [EntryPoint]) VALUES (1, N'Software technology - 2010', N'st1', N'Software technology - 2010', NULL, 50000000, 1, 32, CAST(N'2010-05-30T00:00:00.0000000' AS DateTime2), CAST(N'2010-05-31T00:00:00.0000000' AS DateTime2), N'/img/Course/motorcycle.jpg', 1, NULL, CAST(N'2021-05-30T15:27:47.5767451' AS DateTime2), CAST(N'2021-05-30T15:27:47.5758005' AS DateTime2), 14)
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[CourseSubject] ON 

INSERT [dbo].[CourseSubject] ([ID], [CourseID], [SubjectID], [FacultyID]) VALUES (1, 1, 1, 79)
INSERT [dbo].[CourseSubject] ([ID], [CourseID], [SubjectID], [FacultyID]) VALUES (2, 1, 12, 80)
INSERT [dbo].[CourseSubject] ([ID], [CourseID], [SubjectID], [FacultyID]) VALUES (3, 1, 20, 109)
INSERT [dbo].[CourseSubject] ([ID], [CourseID], [SubjectID], [FacultyID]) VALUES (4, 1, 17, 78)
SET IDENTITY_INSERT [dbo].[CourseSubject] OFF
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([ID], [Name], [Info], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (1, N'Information Technology', N'Information Technology', NULL, CAST(N'2021-05-30T13:24:07.2773164' AS DateTime2), CAST(N'2021-05-30T13:24:07.2773796' AS DateTime2))
INSERT [dbo].[Department] ([ID], [Name], [Info], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (2, N'Mechanical', N'Mechanical', NULL, CAST(N'2021-05-30T13:24:58.3142737' AS DateTime2), CAST(N'2021-05-30T13:24:58.3143224' AS DateTime2))
INSERT [dbo].[Department] ([ID], [Name], [Info], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (3, N'Mechanics Motivation', N'Mechanics Motivation', NULL, CAST(N'2021-05-30T13:25:32.2029712' AS DateTime2), CAST(N'2021-05-30T13:25:32.2029786' AS DateTime2))
INSERT [dbo].[Department] ([ID], [Name], [Info], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (4, N'Biotechnology', N'Biotechnology', NULL, CAST(N'2021-05-30T13:25:51.5467196' AS DateTime2), CAST(N'2021-05-30T13:25:51.5467316' AS DateTime2))
INSERT [dbo].[Department] ([ID], [Name], [Info], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (5, N'Textile – Footwear and Fashion', N'Textile – Footwear and Fashion', NULL, CAST(N'2021-05-30T13:26:30.9114368' AS DateTime2), CAST(N'2021-05-30T13:26:30.9114391' AS DateTime2))
INSERT [dbo].[Department] ([ID], [Name], [Info], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (6, N'Economics and Management', N'Economics and Management', NULL, CAST(N'2021-05-30T13:27:18.7578273' AS DateTime2), CAST(N'2021-05-30T13:27:18.7578305' AS DateTime2))
INSERT [dbo].[Department] ([ID], [Name], [Info], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (7, N'Pedagogy', N'Pedagogy', NULL, CAST(N'2021-05-30T13:28:14.1336204' AS DateTime2), CAST(N'2021-05-30T13:28:14.1336232' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[Faculty] ON 

INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (1, N'Patricia Doe', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.

Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 0, N'/img/Faculty/teacher_2_small.jpg', CAST(N'1997-02-05T00:00:00.0000000' AS DateTime2), N'Hà Nội', N'info@domain.com', N'0123238423', 5, 7, NULL, NULL, CAST(N'2021-05-30T13:36:52.5378241' AS DateTime2), CAST(N'2021-05-30T13:42:31.1837328' AS DateTime2), N'They have got my project on time with the competition with a sed highly skilled, and experienced & professional team.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (2, N'Patricia Doe', N'When an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.', 1, N'/img/Faculty/teacher_1_small.jpg', CAST(N'1997-06-10T00:00:00.0000000' AS DateTime2), N'Hà Nội', N'test@gmail.com', N'0345907668', 4, 6, NULL, NULL, CAST(N'2021-05-30T13:47:32.7457142' AS DateTime2), CAST(N'2021-05-30T13:47:32.7459102' AS DateTime2), N'They have got my project on time with the competition with a sed highly skilled, and experienced & professional team.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (3, N'Silvia Doe', N'
Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.

Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, N'/img/Faculty/teacher_3_small.jpg', CAST(N'2001-05-08T00:00:00.0000000' AS DateTime2), N'Hà Nội', N'test@gmail.com', N'0123238423', 2, 5, NULL, NULL, CAST(N'2021-05-30T13:48:49.4837812' AS DateTime2), CAST(N'2021-05-30T13:48:49.4837854' AS DateTime2), N'They have got my project on time with the competition with a sed highly skilled, and experienced & professional team.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (4, N'Roberta Twain', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.

Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 0, N'/img/Faculty/teacher_4_small.jpg', CAST(N'1998-02-03T00:00:00.0000000' AS DateTime2), N'Hà Nội', N'tets21@gmail.com', N'0324123412', 3, 4, NULL, NULL, CAST(N'2021-05-30T13:51:21.7344753' AS DateTime2), CAST(N'2021-05-30T13:51:21.7344802' AS DateTime2), N'They have got my project on time with the competition with a sed highly skilled, and experienced & professional team.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (68, N'Faculty 1', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 0, N'/img/Faculty/5.jpg', CAST(N'1988-06-18T00:00:00.0000000' AS DateTime2), N'Hà Nội', N'test1233@gmail.com', N'0324123412', 8, 6, NULL, NULL, NULL, CAST(N'2021-05-30T14:56:43.6392163' AS DateTime2), N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (69, N'Faculty 2', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test12312@gmail.com', N'0324123412', 8, 7, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (70, N'Faculty 3', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test123123@gmail.com', N'0324123412', 8, 1, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (71, N'Faculty 3', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'5123532@gmail.com', N'0324123412', 8, 2, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (72, N'Faculty 4', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test1223@gmail.com', N'0324123412', 8, 3, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (73, N'Faculty 5', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test1233@gmail.com', N'0324123412', 8, 4, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (74, N'Faculty 6', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test12513@gmail.com', N'0324123412', 8, 5, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (75, N'Faculty 7', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test12312@gmail.com', N'0324123412', 8, 6, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (76, N'Faculty 8', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test121233@gmail.com', N'0324123412', 8, 7, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (77, N'Faculty 9', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test123423@gmail.com', N'0324123412', 8, 1, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (78, N'Faculty 10', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 0, N'/img/Faculty/6.jpg', CAST(N'1988-06-18T00:00:00.0000000' AS DateTime2), N'Hà Nội', N'test123412@gmail.com', N'0324123412', 8, 2, NULL, NULL, NULL, CAST(N'2021-05-30T14:56:35.4162940' AS DateTime2), N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (79, N'Faculty 11', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, N'/img/Faculty/7.jpg', CAST(N'1988-06-18T00:00:00.0000000' AS DateTime2), N'Hà Nội', N'test112423@gmail.com', N'0324123412', 8, 3, NULL, NULL, NULL, CAST(N'2021-05-30T14:56:56.3272590' AS DateTime2), N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (80, N'Faculty 12', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 0, N'/img/Faculty/avatar-03.jpg', CAST(N'1988-06-18T00:00:00.0000000' AS DateTime2), N'Hà Nội', N'test123123@gmail.com', N'0324123412', 8, 4, NULL, NULL, NULL, CAST(N'2021-05-30T14:57:20.4075490' AS DateTime2), N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (81, N'Faculty 13', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 0, N'/img/Faculty/avatar-02.jpg', CAST(N'1988-06-18T00:00:00.0000000' AS DateTime2), N'Hà Nội', N'test112323@gmail.com', N'0324123412', 8, 5, NULL, NULL, NULL, CAST(N'2021-05-30T14:57:35.0671481' AS DateTime2), N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (82, N'Faculty 14', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 0, N'/img/Faculty/author.jpg', CAST(N'1988-06-07T00:00:00.0000000' AS DateTime2), N'Hà Nội', N'tsertsetrasfd@gmail.com', N'0324123412', 8, 6, NULL, NULL, NULL, CAST(N'2021-05-30T14:57:56.9015649' AS DateTime2), N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (83, N'Faculty 15', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, N'/img/Faculty/error-403.png', CAST(N'1988-06-18T00:00:00.0000000' AS DateTime2), N'Hà Nội', N'test12316@gmail.com', N'0324123412', 8, 7, NULL, NULL, NULL, CAST(N'2021-05-30T14:58:30.6558521' AS DateTime2), N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (84, N'Faculty 16', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 0, N'/img/Faculty/error-500.png', CAST(N'1988-06-18T00:00:00.0000000' AS DateTime2), N'Hà Nội', N'test4235@gmail.com', N'0324123412', 8, 1, NULL, NULL, NULL, CAST(N'2021-05-30T14:58:53.1705163' AS DateTime2), N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (85, N'Faculty 17', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, N'/img/Faculty/8.jpg', CAST(N'1988-06-18T00:00:00.0000000' AS DateTime2), N'Hà Nội', N'test12123@gmail.com', N'0324123412', 8, 2, NULL, NULL, NULL, CAST(N'2021-05-30T14:59:17.9649607' AS DateTime2), N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (86, N'Faculty 18', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test132223@gmail.com', N'0324123412', 8, 3, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (87, N'Faculty 19', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test1212123@gmail.com', N'0324123412', 8, 4, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (88, N'Faculty 20', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test125435433@gmail.com', N'0324123412', 8, 5, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (89, N'Faculty 21', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test121231243@gmail.com', N'0324123412', 8, 6, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (90, N'Faculty 22', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà N?i', N'test12122143@gmail.com', N'0324123412', 8, 7, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (91, N'Faculty 23', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà N?i', N'test123124124@gmail.com', N'0324123412', 8, 3, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (92, N'Faculty 24', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà N?i', N'test12123123@gmail.com', N'0324123412', 8, 3, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (93, N'Faculty 25', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà N?i', N'test123123123@gmail.com', N'0324123412', 8, 3, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (94, N'Faculty 26', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà N?i', N'test12423@gmail.com', N'0324123412', 8, 2, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (95, N'Faculty 27', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà N?i', N'test15423@gmail.com', N'0324123412', 8, 1, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (96, N'Faculty 28', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà N?i', N'test125553@gmail.com', N'0324123412', 8, 3, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (97, N'Faculty 29', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà N?i', N'test123555@gmail.com', N'0324123412', 8, 4, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (98, N'Faculty 30', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà N?i', N'test1212123@gmail.com', N'0324123412', 8, 1, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (99, N'Faculty 31', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test12qwe3@gmail.com', N'0324123412', 8, 5, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (100, N'Faculty 32', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test12qdg3@gmail.com', N'0324123412', 8, 6, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (101, N'Faculty 33', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test123dsagdg@gmail.com', N'0324123412', 8, 6, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (102, N'Faculty 34', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test123sdgsag@gmail.com', N'0324123412', 8, 6, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (103, N'Faculty 35', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test1sdgsdg23@gmail.com', N'0324123412', 8, 1, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (104, N'Faculty 36', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test12fsdg3@gmail.com', N'0324123412', 8, 2, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (105, N'Faculty 37', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test12gsdgsd3@gmail.com', N'0324123412', 8, 5, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (106, N'Faculty 38', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test123sgsdg@gmail.com', N'0324123412', 8, 6, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (107, N'Faculty 39', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test123sgsdg@gmail.com', N'0324123412', 8, 7, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (108, N'Faculty 40', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, NULL, CAST(N'1988-06-18T10:34:09.0000000' AS DateTime2), N'Hà Nội', N'test123sgsdg@gmail.com', N'0324123412', 8, 7, NULL, NULL, NULL, NULL, N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
INSERT [dbo].[Faculty] ([ID], [Name], [Info], [Gender], [ImageUrl], [DOB], [Address], [Email], [PhoneNumber], [ExperienceYear], [DepartmentID], [UserID], [Deleted], [CreatedAt], [UpdatedAt], [Testimonials]) VALUES (109, N'Faculty  41', N'Lorem ipsum dolor sit amet, dicta oportere ad est, ea eos partem neglegentur theophrastus. Esse voluptatum duo ne, expetenda corrumpit no per, at mei nobis lucilius. No eos semper aperiri neglegentur, vis noluisse quaestio no. Vix an nostro inimicus, qui ut animal fabellas reprehendunt. In quando repudiare intellegebat sed, nam suas dicta melius ea.
Mei ut decore accusam consequat, alii dignissim no usu. Phaedrum intellegat sit ut, no pri mutat eirmod. In eum iriure perpetua adolescens, pri dicunt prodesset et. Vis dicta postulant ad.', 1, N'/img/Faculty/1.jpg', CAST(N'1988-06-18T00:00:00.0000000' AS DateTime2), N'Hà Nội', N'test123sgsdg@gmail.com', N'0324123412', 8, 4, NULL, NULL, NULL, CAST(N'2021-05-30T14:56:03.7025138' AS DateTime2), N'The master-builder of human happines no one rejects, dislikes avoids pleasure itself, because it is very pursue pleasure.')
SET IDENTITY_INSERT [dbo].[Faculty] OFF
GO
SET IDENTITY_INSERT [dbo].[FacultySubject] ON 

INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (1, 109, 21)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (2, 109, 20)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (3, 109, 19)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (4, 109, 18)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (5, 68, 19)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (6, 68, 18)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (7, 68, 17)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (8, 68, 16)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (9, 68, 15)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (10, 78, 20)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (11, 78, 19)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (12, 78, 17)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (13, 79, 1)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (14, 79, 2)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (15, 80, 20)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (16, 80, 19)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (17, 80, 13)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (18, 80, 12)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (19, 81, 9)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (20, 81, 8)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (21, 81, 7)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (22, 81, 6)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (23, 82, 9)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (24, 82, 6)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (25, 82, 5)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (26, 82, 4)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (27, 83, 18)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (28, 83, 17)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (29, 83, 9)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (30, 83, 5)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (31, 83, 2)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (32, 84, 11)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (33, 84, 10)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (34, 84, 9)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (35, 84, 8)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (36, 84, 7)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (37, 85, 21)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (38, 85, 20)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (39, 85, 11)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (40, 85, 10)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (41, 85, 6)
INSERT [dbo].[FacultySubject] ([ID], [FacultyID], [SubjectID]) VALUES (42, 85, 5)
SET IDENTITY_INSERT [dbo].[FacultySubject] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (1, N'std 1', N'parents of std 1', N'0123456789', N'STD1622369378960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (2, N'std 1', N'parents of std 1', N'0123456789', N'STD162378960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (3, N'std 2', N'parents of std 2', N'0123456789', N'STD162213', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (4, N'std 3', N'parents of std 3', N'0123456789', N'STD1621260', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (5, N'std 4', N'parents of std 4', N'0123456789', N'STD16235960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (6, N'std 5', N'parents of std 5', N'0123456789', N'STD162343760', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (7, N'std 6', N'parents of std 6', N'0123456789', N'STD162358960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (8, N'std 7', N'parents of std 7', N'0123456789', N'STD1624378960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (9, N'std 8', N'parents of std 8', N'0123456789', N'STD162278960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (10, N'std 9', N'parents of std 9', N'0123456789', N'STD1622378960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (11, N'std 10', N'parents of std 10', N'0123456789', N'STD149378960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (12, N'std 11', N'parents of std 11', N'0123456789', N'STD123493789', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (13, N'std 12', N'parents of std 12', N'0123456789', N'STD1622370', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (14, N'std 13', N'parents of std 13', N'0123456789', N'STD1623960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (15, N'std 14', N'parents of std 14', N'0123456789', N'STD162178960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (16, N'std 15', N'parents of std 15', N'0123456789', N'STD1645960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (17, N'std 16', N'parents of std 16', N'0123456789', N'STD162460', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (18, N'std 17', N'parents of std 17', N'0123456789', N'STD1622960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (19, N'std 18', N'parents of std 18', N'0123456789', N'STD1622960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (20, N'std 19', N'parents of std 19', N'0123456789', N'STD1622960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (21, N'std 20', N'parents of std 20', N'0123456789', N'STD162260', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (22, N'std 21', N'parents of std 21', N'0123456789', N'STD16223960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (23, N'std 22', N'parents of std 22', N'0123456789', N'STD162378960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (24, N'std 23', N'parents of std 23', N'0123456789', N'STD166748960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (25, N'std 24', N'parents of std 24', N'0123456789', N'STD162558960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (26, N'std 25', N'parents of std 25', N'0123456789', N'STD162378960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (27, N'std 26', N'parents of std 26', N'0123456789', N'STD162224960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (28, N'std 27', N'parents of std 27', N'0123456789', N'STD16234378960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (29, N'std 28', N'parents of std 28', N'0123456789', N'STD162232360', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (30, N'std 29', N'parents of std 29', N'0123456789', N'STD16223428960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (31, N'std 30', N'parents of std 30', N'0123456789', N'STD16223478960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (32, N'std 31', N'parents of std 31', N'0123456789', N'STD162578960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 1, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (33, N'std 32', N'parents of std 32', N'0123456789', N'STD162242960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (34, N'std 33', N'parents of std 33', N'0123456789', N'STD16223960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (35, N'std 34', N'parents of std 34', N'0123456789', N'STD162245560', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (36, N'std 35', N'parents of std 35', N'0123456789', N'STD1622360', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (37, N'std 36', N'parents of std 36', N'0123456789', N'STD16224320', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (38, N'std 37', N'parents of std 37', N'0123456789', N'STD1632378960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (39, N'std 38', N'parents of std 38', N'0123456789', N'STD16222478960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (40, N'std 39', N'parents of std 39', N'0123456789', N'STD16228960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (41, N'std 40', N'parents of std 40', N'0123456789', N'STD162378960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (42, N'std 41', N'parents of std 41', N'0123456789', N'STD1622960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (43, N'std 42', N'parents of std 42', N'0123456789', N'STD162242360', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (44, N'std 43', N'parents of std 43', N'0123456789', N'STD16224234960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (45, N'std 44', N'parents of std 44', N'0123456789', N'STD16228960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (46, N'std 45', N'parents of std 45', N'0123456789', N'STD1623378960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (47, N'std 46', N'parents of std 46', N'0123456789', N'STD1622960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (48, N'std 47', N'parents of std 47', N'0123456789', N'STD16238960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (49, N'std 48', N'parents of std 48', N'0123456789', N'STD32424960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (50, N'std 49', N'parents of std 49', N'0123456789', N'STD16224378960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (51, N'std 50', N'parents of std 50', N'0123456789', N'STD162240', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (52, N'std 51', N'parents of std 51', N'0123456789', N'STD162378960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (53, N'std 52', N'parents of std 52', N'0123456789', N'STD16224378960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (54, N'std 53', N'parents of std 53', N'0123456789', N'STD162212260', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (55, N'std 54', N'parents of std 54', N'0123456789', N'STD112478960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (56, N'std 55', N'parents of std 55', N'0123456789', N'STD1622240', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (57, N'std 56', N'parents of std 56', N'0123456789', N'STD161278960', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (58, N'std 57', N'parents of std 57', N'0123456789', N'STD16222460', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
INSERT [dbo].[Student] ([ID], [Name], [ResponsiblePersonName], [ResponsiblePersonPhone], [Code], [Email], [PhoneNumber], [ResidentialAddress], [PermanentAddress], [ImageURL], [Gender], [DOB], [Status], [CourseID], [UserID], [TestScore], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (59, N'std 58', N'parents of std 58', N'0123456789', N'STD16173243240', N'tets21@gmail.com', N'0123456789', N'test 123213', N'test 123213', N'/img/Student/0baeca116d52840cdd43.jpg', 0, CAST(N'2003-05-06T00:00:00.0000000' AS DateTime2), 3, 1, NULL, 14, NULL, CAST(N'2021-05-30T17:09:38.9836556' AS DateTime2), CAST(N'2021-05-30T17:09:38.9837121' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[Subject] ON 

INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (1, N'Manufacturing technology', N'Manufacturing technology', N'/img/Subject/49874.1289109.jpg', NULL, CAST(N'2021-05-30T14:31:42.0719360' AS DateTime2), CAST(N'2021-05-30T14:31:42.0728673' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (2, N'Materials and Structural Mechanics', N'Materials and Structural Mechanics', N'/img/Subject/Strength-of-Materials-and-Structures-An-Introduction-to-the-Mechanics-of-Solids-and-Structures-By-John-Case-A.-H.-Chilver.jpg', NULL, CAST(N'2021-05-30T14:32:18.0617259' AS DateTime2), CAST(N'2021-05-30T14:32:18.0617908' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (3, N'Precision Mechanics and Optics', N'Precision Mechanics and Optics', N'/img/Subject/JUK_Branchen_Optische-Technologie_Referenzen-1.jpg', NULL, CAST(N'2021-05-30T14:32:59.6093497' AS DateTime2), CAST(N'2021-05-30T14:32:59.6093550' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (4, N'Machine and Robotic Design Facility', N'Machine and Robotic Design Facility', N'/img/Subject/robots-call-center.jpg', NULL, CAST(N'2021-05-30T14:33:34.6587833' AS DateTime2), CAST(N'2021-05-30T14:33:34.6587868' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (5, N'Applied mechanics', N'Applied mechanics', N'/img/Subject/81Pe6Q-cugL.jpg', NULL, CAST(N'2021-05-30T14:34:06.3908879' AS DateTime2), CAST(N'2021-05-30T14:34:06.3908927' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (6, N'Mechanical Engineering – dynamics', N'Mechanical Engineering – dynamics', N'/img/Subject/41gG4rRt5hL._SX369_BO1,204,203,200_.jpg', NULL, CAST(N'2021-05-30T14:34:40.0760327' AS DateTime2), CAST(N'2021-05-30T14:34:40.0760371' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (7, N'Aviation technique', N'Aviation technique', N'/img/Subject/41gG4rRt5hL._SX369_BO1,204,203,200_.jpg', NULL, CAST(N'2021-05-30T14:35:02.1698901' AS DateTime2), CAST(N'2021-05-30T14:35:02.1698941' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (8, N'Biotechnology', N'Biotechnology', N'/img/Subject/nganh-cong-nghe-sinh-hoc-hoc-gi-ra-truong-lam-gi-2.jpg', NULL, CAST(N'2021-05-30T14:35:35.2012195' AS DateTime2), CAST(N'2021-05-30T14:35:35.2012256' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (9, N'Food Technology', N'Food Technology', N'/img/Subject/wll8-food.jpg', NULL, CAST(N'2021-05-30T14:36:07.4867959' AS DateTime2), CAST(N'2021-05-30T14:36:07.4868008' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (10, N'Quality management', N'Quality management', N'/img/Subject/7-nguyên-tắc-chất-lượng.webp', NULL, CAST(N'2021-05-30T14:36:37.2169748' AS DateTime2), CAST(N'2021-05-30T14:36:37.2169789' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (11, N'Microbiology - biochemistry - molecular biology', N'Microbiology - biochemistry - molecular biology', N'/img/Subject/51+2iO0wdzL._SX355_BO1,204,203,200_.jpg', NULL, CAST(N'2021-05-30T14:37:07.7396696' AS DateTime2), CAST(N'2021-05-30T14:37:07.7396755' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (12, N'Software technology', N'Software technology', N'/img/Subject/phan-mem-va-cong-nghe-phan-mem-la-gi-63737985009.7284.jpg', NULL, CAST(N'2021-05-30T14:37:35.6992081' AS DateTime2), CAST(N'2021-05-30T14:37:35.6992129' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (13, N'Information system', N'Information system', N'/img/Subject/ím.jpg', NULL, CAST(N'2021-05-30T14:38:06.7797381' AS DateTime2), CAST(N'2021-05-30T14:38:06.7797462' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (14, N'Computer science', N'Computer science', N'/img/Subject/maxresdefault.jpg', NULL, CAST(N'2021-05-30T14:38:30.9596879' AS DateTime2), CAST(N'2021-05-30T14:38:38.9855393' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (15, N'Computer Engineering', N'Computer Engineering', N'/img/Subject/5dbbfe105afb5684c71e72b4_what-is-computer-engineering.jpg', NULL, CAST(N'2021-05-30T14:39:17.2660779' AS DateTime2), CAST(N'2021-05-30T14:39:17.2661205' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (16, N'Communication and computer networks', N'Communication and computer networks', N'/img/Subject/download.jpg', NULL, CAST(N'2021-05-30T14:39:43.3747361' AS DateTime2), CAST(N'2021-05-30T14:39:43.3747400' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (17, N'computer center', N'computer center', N'/img/Subject/download.jpg', NULL, CAST(N'2021-05-30T14:40:12.7161192' AS DateTime2), CAST(N'2021-05-30T14:40:12.7161318' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (18, N'Textile Technology', N'Textile Technology', N'/img/Subject/unnamed.jpg', NULL, CAST(N'2021-05-30T14:40:45.0908753' AS DateTime2), CAST(N'2021-05-30T14:40:45.0908784' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (19, N'Textile Chemistry Materials and Technology', N'Textile Chemistry Materials and Technology', N'/img/Subject/nganh-cong-nghe-soi-det.jpg', NULL, CAST(N'2021-05-30T14:41:19.3248030' AS DateTime2), CAST(N'2021-05-30T14:41:19.3248069' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (20, N'Science and Technology Education', N'Science and Technology Education', N'/img/Subject/9781536137170-e1536755850345.jpg', NULL, CAST(N'2021-05-30T14:41:54.5413738' AS DateTime2), CAST(N'2021-05-30T14:41:54.5413768' AS DateTime2))
INSERT [dbo].[Subject] ([ID], [Name], [Info], [ImageUrl], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (21, N'Pedagogy of technical disciplines', N'Pedagogy of technical disciplines', N'/img/Subject/cover_issue_14_en_US.jpg', NULL, CAST(N'2021-05-30T14:42:32.6236970' AS DateTime2), CAST(N'2021-05-30T14:42:32.6237648' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Subject] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [FullName], [Email], [PhoneNumber], [ImageURL], [Address], [UserName], [Password], [Role], [Deleted], [CreatedAt], [UpdatedAt]) VALUES (1, N'Admin', N'admin@gmail.com', NULL, NULL, NULL, N'admin', N'21232f297a57a5a743894a0e4a801fc3', N'SuperAdmin', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Department_DepartmentID] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([ID])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Department_DepartmentID]
GO
ALTER TABLE [dbo].[CourseSubject]  WITH CHECK ADD  CONSTRAINT [FK_CourseSubject_Course_CourseID] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourseSubject] CHECK CONSTRAINT [FK_CourseSubject_Course_CourseID]
GO
ALTER TABLE [dbo].[CourseSubject]  WITH CHECK ADD  CONSTRAINT [FK_CourseSubject_Faculty_FacultyID] FOREIGN KEY([FacultyID])
REFERENCES [dbo].[Faculty] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourseSubject] CHECK CONSTRAINT [FK_CourseSubject_Faculty_FacultyID]
GO
ALTER TABLE [dbo].[CourseSubject]  WITH CHECK ADD  CONSTRAINT [FK_CourseSubject_Subject_SubjectID] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[CourseSubject] CHECK CONSTRAINT [FK_CourseSubject_Subject_SubjectID]
GO
ALTER TABLE [dbo].[FacilityImg]  WITH CHECK ADD  CONSTRAINT [FK_FacilityImg_Facility_FacilityId] FOREIGN KEY([FacilityId])
REFERENCES [dbo].[Facility] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FacilityImg] CHECK CONSTRAINT [FK_FacilityImg_Facility_FacilityId]
GO
ALTER TABLE [dbo].[Faculty]  WITH CHECK ADD  CONSTRAINT [FK_Faculty_Department_DepartmentID] FOREIGN KEY([DepartmentID])
REFERENCES [dbo].[Department] ([ID])
GO
ALTER TABLE [dbo].[Faculty] CHECK CONSTRAINT [FK_Faculty_Department_DepartmentID]
GO
ALTER TABLE [dbo].[Faculty]  WITH CHECK ADD  CONSTRAINT [FK_Faculty_User_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Faculty] CHECK CONSTRAINT [FK_Faculty_User_UserID]
GO
ALTER TABLE [dbo].[FacultySubject]  WITH CHECK ADD  CONSTRAINT [FK_FacultySubject_Faculty_FacultyID] FOREIGN KEY([FacultyID])
REFERENCES [dbo].[Faculty] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FacultySubject] CHECK CONSTRAINT [FK_FacultySubject_Faculty_FacultyID]
GO
ALTER TABLE [dbo].[FacultySubject]  WITH CHECK ADD  CONSTRAINT [FK_FacultySubject_Subject_SubjectID] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FacultySubject] CHECK CONSTRAINT [FK_FacultySubject_Subject_SubjectID]
GO
ALTER TABLE [dbo].[Marks]  WITH CHECK ADD  CONSTRAINT [FK_Marks_Student_StudentID] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([ID])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_Student_StudentID]
GO
ALTER TABLE [dbo].[Marks]  WITH CHECK ADD  CONSTRAINT [FK_Marks_Subject_SubjectID] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([ID])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_Subject_SubjectID]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Course_CourseID] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Course_CourseID]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_User_UserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_User_UserID]
GO
