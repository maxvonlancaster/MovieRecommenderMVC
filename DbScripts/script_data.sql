USE [master]
GO
/****** Object:  Database [MovieRecommender]    Script Date: 6/6/2019 12:57:07 PM ******/
CREATE DATABASE [MovieRecommender]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MovieRecommender', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\MovieRecommender.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MovieRecommender_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\MovieRecommender_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [MovieRecommender] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MovieRecommender].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MovieRecommender] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MovieRecommender] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MovieRecommender] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MovieRecommender] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MovieRecommender] SET ARITHABORT OFF 
GO
ALTER DATABASE [MovieRecommender] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MovieRecommender] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MovieRecommender] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MovieRecommender] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MovieRecommender] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MovieRecommender] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MovieRecommender] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MovieRecommender] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MovieRecommender] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MovieRecommender] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MovieRecommender] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MovieRecommender] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MovieRecommender] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MovieRecommender] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MovieRecommender] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MovieRecommender] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [MovieRecommender] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MovieRecommender] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MovieRecommender] SET  MULTI_USER 
GO
ALTER DATABASE [MovieRecommender] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MovieRecommender] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MovieRecommender] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MovieRecommender] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MovieRecommender] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MovieRecommender] SET QUERY_STORE = OFF
GO
USE [MovieRecommender]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/6/2019 12:57:07 PM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ActorMovies]    Script Date: 6/6/2019 12:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActorMovies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ActorId] [int] NULL,
	[MovieId] [int] NULL,
 CONSTRAINT [PK_ActorMovies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Actors]    Script Date: 6/6/2019 12:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ActorName] [nvarchar](max) NULL,
	[ActorSecondName] [nvarchar](max) NULL,
	[BirthDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Actors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Directors]    Script Date: 6/6/2019 12:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Directors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DirectorName] [nvarchar](max) NULL,
	[DirectorSecondName] [nvarchar](max) NULL,
	[BirthDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Directors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 6/6/2019 12:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GenreName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdentityUserClaims]    Script Date: 6/6/2019 12:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdentityUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](max) NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_IdentityUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 6/6/2019 12:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[MovieId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[GanreId] [int] NULL,
	[DirectorId] [int] NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserMovies]    Script Date: 6/6/2019 12:57:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserMovies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[MovieId] [int] NULL,
	[Rating] [int] NOT NULL,
 CONSTRAINT [PK_UserMovies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/6/2019 12:57:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[NormalizedUserName] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[NormalizedEmail] [nvarchar](max) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[UserFirstName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190504194341_User4', N'2.1.4-rtm-31024')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190504201305_claims', N'2.1.4-rtm-31024')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190508055207_auto-generated', N'2.1.4-rtm-31024')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190508134320_genre table', N'2.1.8-servicing-32085')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190509115230_usermovie table', N'2.1.8-servicing-32085')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190509120443_usermovie rating', N'2.1.8-servicing-32085')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190605114111_actors-dirs', N'2.1.8-servicing-32085')
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([Id], [GenreName]) VALUES (1, N'action')
INSERT [dbo].[Genres] ([Id], [GenreName]) VALUES (2, N'comedy')
INSERT [dbo].[Genres] ([Id], [GenreName]) VALUES (3, N'sci-fi')
INSERT [dbo].[Genres] ([Id], [GenreName]) VALUES (4, N'drama')
SET IDENTITY_INSERT [dbo].[Genres] OFF
SET IDENTITY_INSERT [dbo].[Movies] ON 

INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (1, N'Star Wars', 3, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (2, N'Casablanca', 4, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (3, N'Battle Royale', 1, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (4, N'Aquaman', 3, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (5, N'The room', 2, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (6, N'The room', 2, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (7, N'Gazgolder', 1, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (9, N'Back to the future', 3, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (10, N'Green elephfant', 4, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (17, N'Star Wars 3', 3, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (18, N'Star Wars 4', 3, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (19, N'Star Wars 5', 3, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (20, N'Star Wars 6', 3, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (21, N'Star Wars 7', 3, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (23, N'Black Rose', NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (28, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (30, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (32, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (34, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (35, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (36, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (37, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (38, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (40, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (41, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (42, N'Green Mile', 4, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (43, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (44, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (45, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (47, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (48, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (49, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (50, N'c', NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (51, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (53, N'Ivan Vsilyevich changes occupation', 3, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (55, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (57, N'Independence day', NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (58, N'Avengers', 1, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (61, N'Avengers 2', NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (62, N'Avengers3', 3, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (63, N'Avengers4', NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (64, N'Avengers5', NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (65, N'Movie 43', 2, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (66, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (67, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (69, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (70, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (71, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (72, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (73, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (74, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (75, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (76, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (77, NULL, NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (81, N'Jay and silent Bob strike back', NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (82, N'Gazgolder', 3, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (84, N'Die Hard', 1, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (86, N'Die Hard 2', 1, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (87, N'fgfdsg', NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (88, N'Who killed captain Alex', NULL, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (89, N'Die Hard 3', 1, NULL)
INSERT [dbo].[Movies] ([MovieId], [Name], [GanreId], [DirectorId]) VALUES (90, N'Die Hard 4', 2, NULL)
SET IDENTITY_INSERT [dbo].[Movies] OFF
SET IDENTITY_INSERT [dbo].[UserMovies] ON 

INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (1, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 4, 4)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (2, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 4, 1)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (3, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 7, 2)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (4, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 17, 4)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (5, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 10, 9)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (6, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 10, 0)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (7, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 1, 7)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (8, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 2, 3)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (9, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 3, 5)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (10, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 89, 6)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (11, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 89, 3)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (12, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 88, 1)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (13, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 87, 4)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (14, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 86, 4)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (15, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 84, 9)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (16, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 82, 8)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (17, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 81, 8)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (18, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 23, 4)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (19, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 6, 5)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (20, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 53, 3)
INSERT [dbo].[UserMovies] ([Id], [UserId], [MovieId], [Rating]) VALUES (21, N'95d6fd26-7dd0-40b4-b18a-adba1254039e', 4, 2)
SET IDENTITY_INSERT [dbo].[UserMovies] OFF
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserId], [UserFirstName], [Password]) VALUES (N'0a6c1a11-f14f-4798-849c-3801060248b6', N'windchange25@gmail.com', N'WINDCHANGE25@GMAIL.COM', N'windchange25@gmail.com', N'WINDCHANGE25@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEHkwU/3etUX72/1LtxOHPlXkpIii3drCxKEAW1sdeon7xBb3uNsc3sHQ9gkQ4LGVVg==', N'EQT7WFOULQE7GDFKEW2DSEYZWVEEITEQ', N'8db76932-4bd7-477e-994e-bf583c4758d2', NULL, 0, 0, NULL, 1, 0, 0, NULL, NULL)
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserId], [UserFirstName], [Password]) VALUES (N'95d6fd26-7dd0-40b4-b18a-adba1254039e', N'windchange225@gmail.com', N'WINDCHANGE225@GMAIL.COM', N'windchange225@gmail.com', N'WINDCHANGE225@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEC2vz6rmVSCOhFnpVD8Nr0DNd/AlEXAViJ/AR0HrvQWWbXt4/IuLEmydVLxP+W0Wig==', N'QHYBIAJJEN4E6LETBRK6YJKKCQLSSCVT', N'bea8c497-381a-4c4d-944c-16accf3279c3', NULL, 0, 0, NULL, 1, 0, 0, NULL, NULL)
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserId], [UserFirstName], [Password]) VALUES (N'9b3ded61-db2a-4ae0-9a9c-d61aa926f3eb', N'windchange7@gmail.com', N'WINDCHANGE7@GMAIL.COM', N'windchange7@gmail.com', N'WINDCHANGE7@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAELkeDXY3RjOFFy3OXeI4Iam93AVMRw35AwqXj5LDL9h8UhdV+tRv9NOMVDz4YXempA==', N'NTPMTJAUPOQNDSRAF77AMWVD7T6LLVRD', N'71e65954-0615-46e7-8a91-e7509eeb47f9', NULL, 0, 0, NULL, 1, 0, 0, NULL, NULL)
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserId], [UserFirstName], [Password]) VALUES (N'dc7fab96-ae64-41c4-a395-ccc6dc939fd5', N'windchange255@gmail.com', N'WINDCHANGE255@GMAIL.COM', N'windchange255@gmail.com', N'WINDCHANGE255@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEEdIRpCQ2AjDudXPgG8pQzglvc14LWhUkqne4N+7i2WcpCGCp3h50bEnyQ6K1H5oMA==', N'LVUHNAM2YBCBF4PDU2XVP44C73VJTTQB', N'e31a33aa-ac52-4746-966b-cf40c3e089ae', NULL, 0, 0, NULL, 1, 0, 0, NULL, NULL)
/****** Object:  Index [IX_ActorMovies_ActorId]    Script Date: 6/6/2019 12:57:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_ActorMovies_ActorId] ON [dbo].[ActorMovies]
(
	[ActorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ActorMovies_MovieId]    Script Date: 6/6/2019 12:57:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_ActorMovies_MovieId] ON [dbo].[ActorMovies]
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movies_DirectorId]    Script Date: 6/6/2019 12:57:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_Movies_DirectorId] ON [dbo].[Movies]
(
	[DirectorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movies_GanreId]    Script Date: 6/6/2019 12:57:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_Movies_GanreId] ON [dbo].[Movies]
(
	[GanreId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserMovies_MovieId]    Script Date: 6/6/2019 12:57:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserMovies_MovieId] ON [dbo].[UserMovies]
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserMovies_UserId]    Script Date: 6/6/2019 12:57:08 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserMovies_UserId] ON [dbo].[UserMovies]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserMovies] ADD  DEFAULT ((0)) FOR [Rating]
GO
ALTER TABLE [dbo].[ActorMovies]  WITH CHECK ADD  CONSTRAINT [FK_ActorMovies_Actors_ActorId] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actors] ([Id])
GO
ALTER TABLE [dbo].[ActorMovies] CHECK CONSTRAINT [FK_ActorMovies_Actors_ActorId]
GO
ALTER TABLE [dbo].[ActorMovies]  WITH CHECK ADD  CONSTRAINT [FK_ActorMovies_Movies_MovieId] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([MovieId])
GO
ALTER TABLE [dbo].[ActorMovies] CHECK CONSTRAINT [FK_ActorMovies_Movies_MovieId]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Directors_DirectorId] FOREIGN KEY([DirectorId])
REFERENCES [dbo].[Directors] ([Id])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Directors_DirectorId]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Genres_GanreId] FOREIGN KEY([GanreId])
REFERENCES [dbo].[Genres] ([Id])
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Genres_GanreId]
GO
ALTER TABLE [dbo].[UserMovies]  WITH CHECK ADD  CONSTRAINT [FK_UserMovies_Movies_MovieId] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([MovieId])
GO
ALTER TABLE [dbo].[UserMovies] CHECK CONSTRAINT [FK_UserMovies_Movies_MovieId]
GO
ALTER TABLE [dbo].[UserMovies]  WITH CHECK ADD  CONSTRAINT [FK_UserMovies_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserMovies] CHECK CONSTRAINT [FK_UserMovies_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [MovieRecommender] SET  READ_WRITE 
GO
