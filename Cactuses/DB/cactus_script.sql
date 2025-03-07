USE [master]
GO
/****** Object:  Database [MDK_RPM_Cactus]    Script Date: 12/22/2024 3:11:49 AM ******/
CREATE DATABASE [MDK_RPM_Cactus]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MDK_RPM_Cactus', FILENAME = N'C:\Users\Kolpa\MDK_RPM_Cactus.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
 LOG ON 
( NAME = N'MDK_RPM_Cactus_log', FILENAME = N'C:\Users\Kolpa\MDK_RPM_Cactus_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MDK_RPM_Cactus] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MDK_RPM_Cactus].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MDK_RPM_Cactus] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET ARITHABORT OFF 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET  MULTI_USER 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MDK_RPM_Cactus] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MDK_RPM_Cactus] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MDK_RPM_Cactus] SET QUERY_STORE = OFF
GO
USE [MDK_RPM_Cactus]
GO
/****** Object:  Table [dbo].[Cactuses]    Script Date: 12/22/2024 3:11:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cactuses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Sort] [nvarchar](50) NULL,
	[Origin] [nvarchar](50) NULL,
	[Age] [nvarchar](50) NULL,
	[Cost] [decimal](9, 2) NULL,
	[Instruction] [nvarchar](max) NULL,
 CONSTRAINT [PK_Cactuses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cactuses-Exhibitions]    Script Date: 12/22/2024 3:11:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cactuses-Exhibitions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CactusID] [int] NOT NULL,
	[ExhibitionID] [int] NOT NULL,
 CONSTRAINT [PK_Cactuses-Exhibitions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exhibitions]    Script Date: 12/22/2024 3:11:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exhibitions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NULL,
	[Address] [nvarchar](150) NULL,
	[Awards] [nvarchar](200) NULL,
	[Commentaries] [nvarchar](max) NULL,
 CONSTRAINT [PK_Exhibitions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logins]    Script Date: 12/22/2024 3:11:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logins](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_Logins] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/22/2024 3:11:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Access] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cactuses] ON 

INSERT [dbo].[Cactuses] ([ID], [Sort], [Origin], [Age], [Cost], [Instruction]) VALUES (1, N'Echinocactus grusonii', N'Центральная мексика', N'21', CAST(17890.00 AS Decimal(9, 2)), N'Свет: Полное солнце
Полив: Летом умеренный полив, зимой сухой период
Температура: Не ниже 12°C зимой
Почва: Хороший дренаж, песчаная почва
Вода теплая')
INSERT [dbo].[Cactuses] ([ID], [Sort], [Origin], [Age], [Cost], [Instruction]) VALUES (2, N'Mammilaria', N'Мексика, Юго-запад США', N'13', CAST(3799.00 AS Decimal(9, 2)), N'Свет: Яркий солнечный свет
Полив: Регулярный полив летом, зимой — минимальный
Температура: Переносит до +4°C зимой
Почва: Легкая, хорошо дренируемая смесь')
SET IDENTITY_INSERT [dbo].[Cactuses] OFF
GO
SET IDENTITY_INSERT [dbo].[Cactuses-Exhibitions] ON 

INSERT [dbo].[Cactuses-Exhibitions] ([ID], [CactusID], [ExhibitionID]) VALUES (1, 1, 3)
INSERT [dbo].[Cactuses-Exhibitions] ([ID], [CactusID], [ExhibitionID]) VALUES (2, 2, 3)
SET IDENTITY_INSERT [dbo].[Cactuses-Exhibitions] OFF
GO
SET IDENTITY_INSERT [dbo].[Exhibitions] ON 

INSERT [dbo].[Exhibitions] ([ID], [Date], [Address], [Awards], [Commentaries]) VALUES (1, CAST(N'2024-09-06' AS Date), N'Ул. Бари Галеева 3а', N'Лучший кактус выставки, Лучший в категории, Редкий вид', NULL)
INSERT [dbo].[Exhibitions] ([ID], [Date], [Address], [Awards], [Commentaries]) VALUES (3, CAST(N'2024-05-20' AS Date), N'Ул. Николая Ершова 32', N'За коллекцию, Лучший гибрид', NULL)
SET IDENTITY_INSERT [dbo].[Exhibitions] OFF
GO
SET IDENTITY_INSERT [dbo].[Logins] ON 

INSERT [dbo].[Logins] ([ID], [Login], [Password], [UserID]) VALUES (1, N'Eduard', N'admin', 1)
INSERT [dbo].[Logins] ([ID], [Login], [Password], [UserID]) VALUES (2, N'Riyaz', N'lox', 2)
SET IDENTITY_INSERT [dbo].[Logins] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Name], [Access]) VALUES (1, N'Eduard', N'admin')
INSERT [dbo].[Users] ([ID], [Name], [Access]) VALUES (2, N'Riyaz', N'visitor')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
/****** Object:  Index [IX_Exhibitions]    Script Date: 12/22/2024 3:11:49 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Exhibitions] ON [dbo].[Exhibitions]
(
	[Date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cactuses-Exhibitions]  WITH CHECK ADD  CONSTRAINT [FK_Cactuses-Exhibitions_Cactuses] FOREIGN KEY([CactusID])
REFERENCES [dbo].[Cactuses] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cactuses-Exhibitions] CHECK CONSTRAINT [FK_Cactuses-Exhibitions_Cactuses]
GO
ALTER TABLE [dbo].[Cactuses-Exhibitions]  WITH CHECK ADD  CONSTRAINT [FK_Cactuses-Exhibitions_Exhibitions] FOREIGN KEY([ExhibitionID])
REFERENCES [dbo].[Exhibitions] ([ID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cactuses-Exhibitions] CHECK CONSTRAINT [FK_Cactuses-Exhibitions_Exhibitions]
GO
ALTER TABLE [dbo].[Logins]  WITH CHECK ADD  CONSTRAINT [FK_Logins_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Logins] CHECK CONSTRAINT [FK_Logins_Users]
GO
USE [master]
GO
ALTER DATABASE [MDK_RPM_Cactus] SET  READ_WRITE 
GO
