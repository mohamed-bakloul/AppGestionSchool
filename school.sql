USE [master]
GO
/****** Object:  Database [gestionschool]    Script Date: 6/16/2024 2:20:14 PM ******/
CREATE DATABASE [gestionschool]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'gestionschool', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\gestionschool.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'gestionschool_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\gestionschool_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [gestionschool] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [gestionschool].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [gestionschool] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [gestionschool] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [gestionschool] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [gestionschool] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [gestionschool] SET ARITHABORT OFF 
GO
ALTER DATABASE [gestionschool] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [gestionschool] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [gestionschool] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [gestionschool] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [gestionschool] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [gestionschool] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [gestionschool] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [gestionschool] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [gestionschool] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [gestionschool] SET  DISABLE_BROKER 
GO
ALTER DATABASE [gestionschool] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [gestionschool] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [gestionschool] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [gestionschool] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [gestionschool] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [gestionschool] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [gestionschool] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [gestionschool] SET RECOVERY FULL 
GO
ALTER DATABASE [gestionschool] SET  MULTI_USER 
GO
ALTER DATABASE [gestionschool] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [gestionschool] SET DB_CHAINING OFF 
GO
ALTER DATABASE [gestionschool] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [gestionschool] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [gestionschool] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [gestionschool] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'gestionschool', N'ON'
GO
ALTER DATABASE [gestionschool] SET QUERY_STORE = OFF
GO
USE [gestionschool]
GO
/****** Object:  Table [dbo].[classes]    Script Date: 6/16/2024 2:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[classes](
	[reference] [int] NOT NULL,
	[niveau] [varchar](255) NULL,
	[description] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[reference] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[depense]    Script Date: 6/16/2024 2:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[depense](
	[cne] [varchar](255) NULL,
	[octobre] [decimal](10, 2) NULL,
	[septembre] [decimal](10, 2) NULL,
	[novembrer] [decimal](10, 2) NULL,
	[decembrer] [decimal](10, 2) NULL,
	[janvier] [decimal](10, 2) NULL,
	[fevrier] [decimal](10, 2) NULL,
	[mars] [decimal](10, 2) NULL,
	[avril] [decimal](10, 2) NULL,
	[mai] [decimal](10, 2) NULL,
	[juin] [decimal](10, 2) NULL,
	[juillet] [decimal](10, 2) NULL,
	[date_depense] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[eleves]    Script Date: 6/16/2024 2:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[eleves](
	[cne] [varchar](255) NOT NULL,
	[nom] [varchar](255) NULL,
	[prenom] [varchar](255) NULL,
	[sexe] [varchar](255) NULL,
	[Date_naissance] [date] NULL,
	[Lieu_naissance] [varchar](255) NULL,
	[Nationnalite] [varchar](255) NULL,
	[classe] [int] NULL,
	[photo] [image] NULL,
PRIMARY KEY CLUSTERED 
(
	[cne] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[emploi]    Script Date: 6/16/2024 2:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[emploi](
	[classename] [varchar](255) NOT NULL,
	[lundi_8H15_9h50] [varchar](255) NULL,
	[proflundi_8H15_9h50] [varchar](255) NULL,
	[lundi_10H05_11h35] [varchar](255) NULL,
	[proflundi_10H05_11h35] [varchar](255) NULL,
	[lundi_14H15_15h50] [varchar](255) NULL,
	[proflundi_14H15_15h50] [varchar](255) NULL,
	[lundi_16H05_17h35] [varchar](255) NULL,
	[proflundi_16H05_17h35] [varchar](255) NULL,
	[mardi_8H15_9h50] [varchar](255) NULL,
	[profmardi_8H15_9h50] [varchar](255) NULL,
	[mardi_10H05_11h35] [varchar](255) NULL,
	[profmardi_10H05_11h35] [varchar](255) NULL,
	[mardi_14H15_15h50] [varchar](255) NULL,
	[profmardi_14H15_15h50] [varchar](255) NULL,
	[mardi_16H05_17h35] [varchar](255) NULL,
	[profmardi_16H05_17h35] [varchar](255) NULL,
	[mercredi_8H15_9h50] [varchar](255) NULL,
	[profmercredi_8H15_9h50] [varchar](255) NULL,
	[mercredi_10H05_11h35] [varchar](255) NULL,
	[profmercredi_10H05_11h35] [varchar](255) NULL,
	[mercredi_14H15_15h50] [varchar](255) NULL,
	[profmercredi_14H15_15h50] [varchar](255) NULL,
	[mercredi_16H05_17h35] [varchar](255) NULL,
	[profmercredi_16H05_17h35] [varchar](255) NULL,
	[jeudi_8H15_9h50] [varchar](255) NULL,
	[profjeudi_8H15_9h50] [varchar](255) NULL,
	[jeudi_10H05_11h35] [varchar](255) NULL,
	[profjeudi_10H05_11h35] [varchar](255) NULL,
	[jeudi_14H15_15h50] [varchar](255) NULL,
	[profjeudi_14H15_15h50] [varchar](255) NULL,
	[jeudi_16H05_17h35] [varchar](255) NULL,
	[profjeudi_16H05_17h35] [varchar](255) NULL,
	[vendredi_8H15_9h50] [varchar](255) NULL,
	[profvendredi_8H15_9h50] [varchar](255) NULL,
	[vendredi_10H05_11h35] [varchar](255) NULL,
	[profvendredi_10H05_11h35] [varchar](255) NULL,
	[vendredi_14H15_15h50] [varchar](255) NULL,
	[profvendredi_14H15_15h50] [varchar](255) NULL,
	[vendredi_16H05_17h35] [varchar](255) NULL,
	[profvendredi_16H05_17h35] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[classename] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[login]    Script Date: 6/16/2024 2:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[login](
	[username] [varchar](255) NOT NULL,
	[password] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[matiere]    Script Date: 6/16/2024 2:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[matiere](
	[id] [int] NOT NULL,
	[description] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[note]    Script Date: 6/16/2024 2:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[note](
	[cne] [varchar](255) NULL,
	[id] [int] NULL,
	[notes] [float] NULL,
	[datenote] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[perso]    Script Date: 6/16/2024 2:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[perso](
	[cin] [varchar](255) NOT NULL,
	[nom] [varchar](255) NULL,
	[prenom] [varchar](255) NULL,
	[profession] [varchar](255) NULL,
	[tel] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[cin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[prof]    Script Date: 6/16/2024 2:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[prof](
	[cin] [varchar](255) NOT NULL,
	[nom] [varchar](255) NULL,
	[prenom] [varchar](255) NULL,
	[sexe] [varchar](255) NULL,
	[Date_naissance] [date] NULL,
	[email] [varchar](255) NULL,
	[tel] [varchar](255) NULL,
	[diplome] [varchar](255) NULL,
	[Lieu_naissance] [varchar](255) NULL,
	[Nationnalite] [varchar](255) NULL,
	[photo] [image] NULL,
	[poste] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[cin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[profclasse]    Script Date: 6/16/2024 2:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[profclasse](
	[cin] [varchar](255) NULL,
	[reference] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[depense]  WITH CHECK ADD FOREIGN KEY([cne])
REFERENCES [dbo].[eleves] ([cne])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[eleves]  WITH CHECK ADD FOREIGN KEY([classe])
REFERENCES [dbo].[classes] ([reference])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[note]  WITH CHECK ADD  CONSTRAINT [FK__note__cne__6EF57B66] FOREIGN KEY([cne])
REFERENCES [dbo].[eleves] ([cne])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[note] CHECK CONSTRAINT [FK__note__cne__6EF57B66]
GO
ALTER TABLE [dbo].[note]  WITH CHECK ADD FOREIGN KEY([id])
REFERENCES [dbo].[matiere] ([id])
GO
ALTER TABLE [dbo].[profclasse]  WITH CHECK ADD FOREIGN KEY([reference])
REFERENCES [dbo].[classes] ([reference])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[profclasse]  WITH CHECK ADD FOREIGN KEY([cin])
REFERENCES [dbo].[prof] ([cin])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[eleves]  WITH CHECK ADD CHECK  (([sexe]='Féminin' OR [sexe]='Masculin'))
GO
ALTER TABLE [dbo].[note]  WITH CHECK ADD CHECK  (([notes]>=(0) AND [notes]<=(20)))
GO
ALTER TABLE [dbo].[prof]  WITH CHECK ADD CHECK  (([sexe]='Féminin' OR [sexe]='Masculin'))
GO
USE [master]
GO
ALTER DATABASE [gestionschool] SET  READ_WRITE 
GO
