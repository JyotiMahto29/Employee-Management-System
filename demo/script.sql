USE [master]
GO
/****** Object:  Database [EmpMgt]    Script Date: 28-12-2022 16:09:36 ******/
CREATE DATABASE [EmpMgt]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EmpMgt', FILENAME = N'C:\Users\jyoti.mahto\EmpMgt.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EmpMgt_log', FILENAME = N'C:\Users\jyoti.mahto\EmpMgt_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EmpMgt] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EmpMgt].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EmpMgt] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EmpMgt] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EmpMgt] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EmpMgt] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EmpMgt] SET ARITHABORT OFF 
GO
ALTER DATABASE [EmpMgt] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EmpMgt] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EmpMgt] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EmpMgt] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EmpMgt] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EmpMgt] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EmpMgt] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EmpMgt] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EmpMgt] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EmpMgt] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EmpMgt] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EmpMgt] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EmpMgt] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EmpMgt] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EmpMgt] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EmpMgt] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EmpMgt] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EmpMgt] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EmpMgt] SET  MULTI_USER 
GO
ALTER DATABASE [EmpMgt] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EmpMgt] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EmpMgt] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EmpMgt] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EmpMgt] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EmpMgt] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EmpMgt] SET QUERY_STORE = OFF
GO
USE [EmpMgt]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 28-12-2022 16:09:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[Salary] [int] NOT NULL,
	[Contact] [nvarchar](50) NOT NULL,
	[Address] [nvarchar](50) NULL,
	[EmailId] [nvarchar](50) NOT NULL,
	[deptId] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDepartment]    Script Date: 28-12-2022 16:09:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDepartment](
	[deptId] [int] IDENTITY(1,1) NOT NULL,
	[deptName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblDepartment] PRIMARY KEY CLUSTERED 
(
	[deptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUser]    Script Date: 28-12-2022 16:09:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUser](
	[userId] [int] IDENTITY(1,1) NOT NULL,
	[userName] [nvarchar](50) NOT NULL,
	[userEmail] [nvarchar](50) NOT NULL,
	[userPassword] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED 
(
	[userId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[proc_RegisterUser]    Script Date: 28-12-2022 16:09:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[proc_RegisterUser]
@userName nvarchar(50),
@userEmail nvarchar(50),
@userPassword nvarchar(MAX)
As
Begin
	if exists(select * from tblUser where userEmail=@userEmail)
	begin
		return 0
	end
	else
		begin
			Insert into [tblUser](userName,userEmail,userPassword) Values(@userName,@userEmail,@userPassword)
		end	
End
GO
/****** Object:  StoredProcedure [dbo].[sp_deleteDepartment]    Script Date: 28-12-2022 16:09:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_deleteDepartment]
@deptId int
As
Begin
     if exists(select employeeId from Employee where deptId=@deptId)
        begin
		   return 0
		end
	else
	   begin
	      delete from tblDepartment where deptid=@deptId
	   end
end

GO
/****** Object:  StoredProcedure [dbo].[sp_insertDepartment]    Script Date: 28-12-2022 16:09:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/

  Create procedure [dbo].[sp_insertDepartment]
@deptName nvarchar(50)
As
begin

 

        if exists(select deptID from tblDepartment where deptName=@deptName)
        begin
            return 0
        end
        else
        begin
                INSERT INTO [dbo].[tblDepartment](deptName)
                    VALUES(@deptName)
        end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_insertEmployee]    Script Date: 28-12-2022 16:09:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/

  Create procedure [dbo].[sp_insertEmployee]
  @EmployeeName nvarchar(50),
  @Position nvarchar(50),
  @Salary int,
  @Contact nvarchar(50),
  @Address nvarchar(50),
  @EmailId nvarchar(50),
  @deptId int

As
begin
 INSERT INTO [dbo].[Employee](EmployeeName,Position,Salary,Contact,Address,EmailId,deptId)
                    VALUES(@EmployeeName,@Position,@Salary,@Contact,@Address,@EmailId,@deptId)
 

       
end
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateDepartment]    Script Date: 28-12-2022 16:09:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_UpdateDepartment]  
(  
   @deptId int,  
   @deptName varchar (50)
)  
as  
begin  
    if exists(select deptid from tblDepartment where deptName=@deptName )
	begin
	  return 0
	end
	else
	 begin
	     Update tblDepartment   
             set deptName=@deptName 
                 where deptId=@deptId  
	 end
  
End  
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateEmployee]    Script Date: 28-12-2022 16:09:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_UpdateEmployee]  
(  
   @EmployeeId int,  
   @EmployeeName nvarchar (50),
   @Position nvarchar (50),
   @Salary int,
   @Contact nvarchar (50),
   @Address nvarchar (50),
   @EmailId nvarchar (50),
   @deptId int
)  
as  
begin  
   Update Employee   
   set EmployeeName= @EmployeeName,
   Position=@Position,
   Salary=@Salary,
   Contact=@Contact,
   Address=@Address,
   EmailId=@EmailId,
   deptId=@deptId

   where EmployeeId=@EmployeeId 
End
GO
USE [master]
GO
ALTER DATABASE [EmpMgt] SET  READ_WRITE 
GO
