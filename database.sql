USE [master]
GO
/****** Object:  Database [test]    Script Date: 11/17/2022 9:18:42 AM ******/
CREATE DATABASE [test]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'test', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\test.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'test_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\test_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [test] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [test].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [test] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [test] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [test] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [test] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [test] SET ARITHABORT OFF 
GO
ALTER DATABASE [test] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [test] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [test] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [test] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [test] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [test] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [test] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [test] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [test] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [test] SET  DISABLE_BROKER 
GO
ALTER DATABASE [test] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [test] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [test] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [test] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [test] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [test] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [test] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [test] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [test] SET  MULTI_USER 
GO
ALTER DATABASE [test] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [test] SET DB_CHAINING OFF 
GO
ALTER DATABASE [test] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [test] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [test] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [test] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [test] SET QUERY_STORE = OFF
GO
USE [test]
GO
/****** Object:  User [teste]    Script Date: 11/17/2022 9:18:43 AM ******/
CREATE USER [teste] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [teste]
GO
/****** Object:  Table [dbo].[tblAdmin]    Script Date: 11/17/2022 9:18:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblAdmin](
	[admin_id] [int] NOT NULL,
	[name] [nchar](10) NULL,
	[surname] [nchar](10) NULL,
	[password] [nchar](10) NULL,
 CONSTRAINT [PK_tblAdmin] PRIMARY KEY CLUSTERED 
(
	[admin_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDate]    Script Date: 11/17/2022 9:18:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDate](
	[id_step] [int] NOT NULL,
	[date] [datetime] NOT NULL,
 CONSTRAINT [PK_tblDate] PRIMARY KEY CLUSTERED 
(
	[id_step] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblGas]    Script Date: 11/17/2022 9:18:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblGas](
	[Gas_ID] [nchar](10) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Emission_level] [nchar](10) NULL,
	[Time_taken] [time](7) NULL,
 CONSTRAINT [PK_tblGas] PRIMARY KEY CLUSTERED 
(
	[Gas_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHeartRate]    Script Date: 11/17/2022 9:18:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHeartRate](
	[HeartRateID] [nchar](10) NOT NULL,
	[HeartRate] [nchar](10) NULL,
	[UserId] [nchar](10) NULL,
	[Time_Taken] [time](7) NULL,
 CONSTRAINT [PK_tblHeartRate] PRIMARY KEY CLUSTERED 
(
	[HeartRateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblSteps]    Script Date: 11/17/2022 9:18:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblSteps](
	[id_step] [int] NOT NULL,
	[emp_id] [int] NULL,
	[avr_heartrate] [int] NULL,
	[clock_in] [datetime] NULL,
	[clock_out] [datetime] NULL,
	[total_steps] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 11/17/2022 9:18:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[emp_id] [int] NOT NULL,
	[name] [nchar](10) NULL,
	[surname] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_Dados]    Script Date: 11/17/2022 9:18:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sp_Dados]
AS
BEGIN
	TRUNCATE TABLE tbl_employee
	TRUNCATE TABLE tbl_steps
	TRUNCATE TABLE tbl_heartrates


	-- tbl_employee
	INSERT INTO tbl_employee ([employeeuser],[employeepassword],[employeetype]) VALUES ('alex', '123','A')
	INSERT INTO tbl_employee ([employeeuser],[employeepassword],[employeetype]) VALUES ('caty', '456','U')
	INSERT INTO tbl_employee ([employeeuser],[employeepassword],[employeetype]) VALUES ('nelia', '789','U')
	INSERT INTO tbl_employee ([employeeuser],[employeepassword],[employeetype]) VALUES ('andre', '000','A')

	--tbl_steps
	INSERT INTO tbl_steps ([employeeid],[total_steps],[clock_in],[clock_out]) VALUES (1,100,'2022-11-01 08:30','2022-11-01 17:30')

	--tbl_heartrates
	INSERT INTO tbl_heartrates ([stepid],[heartrate],[time]) VALUES (1,85,'2022-11-01 08:50')
	INSERT INTO tbl_heartrates ([stepid],[heartrate],[time]) VALUES (1,74,'2022-11-01 13:34')
	INSERT INTO tbl_heartrates ([stepid],[heartrate],[time]) VALUES (1,52,'2022-11-01 15:12')
	INSERT INTO tbl_heartrates ([stepid],[heartrate],[time]) VALUES (1,65,'2022-11-01 17:20')

	--tbl_steps
	INSERT INTO tbl_steps ([employeeid],[total_steps],[clock_in],[clock_out]) VALUES (2,200,'2022-11-01 10:00','2022-11-01 15:00')

	--tbl_heartrates
	INSERT INTO tbl_heartrates ([stepid],[heartrate],[time]) VALUES (2,85,'2022-11-01 12:00')
	INSERT INTO tbl_heartrates ([stepid],[heartrate],[time]) VALUES (2,84,'2022-11-01 13:34')

	--tbl_steps
	INSERT INTO tbl_steps ([employeeid],[total_steps],[clock_in],[clock_out]) VALUES (1,300,'2022-11-02 08:45','2022-11-02 18:23')

	--tbl_heartrates
	INSERT INTO tbl_heartrates ([stepid],[heartrate],[time]) VALUES (3,100,'2022-11-02 08:55')
	INSERT INTO tbl_heartrates ([stepid],[heartrate],[time]) VALUES (3,95,'2022-11-02 14:12')
	INSERT INTO tbl_heartrates ([stepid],[heartrate],[time]) VALUES (3,87,'2022-11-02 18:10')



	SELECT * FROM tbl_employee
	SELECT * FROM tbl_steps
	SELECT * fROM tbl_heartrates

	SELECT A.stepid, A.employeeid, A.total_steps, A.clock_in, A.clock_out, B.heartrate, B.time
	FROM tbl_steps A
	INNER JOIN tbl_heartrates B ON A.stepid = B.stepid

	SELECT A.stepid, A.employeeid, A.total_steps, A.clock_in, A.clock_out, B.heartrate, B.time
	FROM tbl_steps A
	INNER JOIN tbl_heartrates B ON A.stepid = B.stepid
	WHERE employeeid = 1
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DadosCaty]    Script Date: 11/17/2022 9:18:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[sp_DadosCaty]
AS
BEGIN
	TRUNCATE TABLE tblAdmin
	TRUNCATE TABLE tblUser
	TRUNCATE TABLE tblDate
	TRUNCATE TABLE tblSteps

	-- tbl_employee
	INSERT INTO tblAdmin ([admin_id],[name],[surname],[password]) VALUES (1,'alex', 'afonso','123')
	INSERT INTO tblAdmin ([admin_id],[name],[surname],[password]) VALUES (2,'caty', 'afonso','456')

	-- tblUser
	INSERT INTO tblUser ([emp_id],[name],[surname]) VALUES (1,'dolores', 'raposinho')
	INSERT INTO tblUser ([emp_id],[name],[surname]) VALUES (2,'jose', 'nico')

	-- tblDate
	INSERT INTO tblDate ([id_step],[date]) VALUES (1,'2022-11-01')
	INSERT INTO tblDate ([id_step],[date]) VALUES (2,'2022-11-02')

	-- tblSteps
	INSERT INTO tblSteps ([id_step],[emp_id],[avr_heartrate],[clock_in],[clock_out],[total_steps]) VALUES (1,1,85,'2022-11-01 08:30','2022-11-01 17:30',100)
	INSERT INTO tblSteps ([id_step],[emp_id],[avr_heartrate],[clock_in],[clock_out],[total_steps]) VALUES (1,2,67,'2022-11-01 10:30','2022-11-01 14:30',250)
	INSERT INTO tblSteps ([id_step],[emp_id],[avr_heartrate],[clock_in],[clock_out],[total_steps]) VALUES (2,1,49,'2022-11-02 11:30','2022-11-02 19:56',52)
	INSERT INTO tblSteps ([id_step],[emp_id],[avr_heartrate],[clock_in],[clock_out],[total_steps]) VALUES (2,2,56,'2022-11-02 10:24','2022-11-02 17:02',158)

	SELECT * FROM tblAdmin
	SELECT * FROM tblUser
	SELECT * FROM tblDate
	SELECT * FROM tblSteps
END
GO
USE [master]
GO
ALTER DATABASE [test] SET  READ_WRITE 
GO
