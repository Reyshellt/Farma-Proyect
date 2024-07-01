USE [master]
GO
/****** Object:  Database [InstitutoTecnologicoAmericas]    Script Date: 4/20/2024 9:56:32 PM ******/
CREATE DATABASE [InstitutoTecnologicoAmericas]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'InstitutoTecnologicoAmericas', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\InstitutoTecnologicoAmericas.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'InstitutoTecnologicoAmericas_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\InstitutoTecnologicoAmericas_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InstitutoTecnologicoAmericas].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET ARITHABORT OFF 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET  ENABLE_BROKER 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET  MULTI_USER 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET DB_CHAINING OFF 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET QUERY_STORE = OFF
GO
USE [InstitutoTecnologicoAmericas]
GO
/****** Object:  Table [dbo].[Aulas]    Script Date: 4/20/2024 9:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aulas](
	[AulaID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[EdificioID] [int] NOT NULL,
 CONSTRAINT [PK_Aulas] PRIMARY KEY CLUSTERED 
(
	[AulaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Edificios]    Script Date: 4/20/2024 9:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Edificios](
	[EdificioID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Edificios] PRIMARY KEY CLUSTERED 
(
	[EdificioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 4/20/2024 9:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[FechaNacimiento] [datetime] NULL,
	[TipoUsuario] [nvarchar](20) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Clave] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visitantes]    Script Date: 4/20/2024 9:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visitantes](
	[VisitanteID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Apellido] [nvarchar](50) NOT NULL,
	[Carrera] [nvarchar](100) NULL,
 CONSTRAINT [PK_Visitantes] PRIMARY KEY CLUSTERED 
(
	[VisitanteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visitas]    Script Date: 4/20/2024 9:56:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visitas](
	[VisitaID] [int] IDENTITY(1,1) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	[VisitanteID] [int] NULL,
	[EdificioID] [int] NOT NULL,
	[AulaID] [int] NOT NULL,
	[HoraEntrada] [datetime] NOT NULL,
	[HoraSalida] [datetime] NULL,
	[MotivoVisita] [nvarchar](150) NULL,
	[FotoVisitante] [varbinary](max) NULL,
 CONSTRAINT [PK_Visitas] PRIMARY KEY CLUSTERED 
(
	[VisitaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Aulas] ON 

INSERT [dbo].[Aulas] ([AulaID], [Nombre], [EdificioID]) VALUES (13, N'Aula1', 5)
INSERT [dbo].[Aulas] ([AulaID], [Nombre], [EdificioID]) VALUES (14, N'Aula2', 6)
INSERT [dbo].[Aulas] ([AulaID], [Nombre], [EdificioID]) VALUES (15, N'Aula3', 7)
INSERT [dbo].[Aulas] ([AulaID], [Nombre], [EdificioID]) VALUES (16, N'Aula4', 8)
INSERT [dbo].[Aulas] ([AulaID], [Nombre], [EdificioID]) VALUES (17, N'Aula5', 9)
INSERT [dbo].[Aulas] ([AulaID], [Nombre], [EdificioID]) VALUES (18, N'Aula6', 10)
INSERT [dbo].[Aulas] ([AulaID], [Nombre], [EdificioID]) VALUES (19, N'Aula7', 11)
INSERT [dbo].[Aulas] ([AulaID], [Nombre], [EdificioID]) VALUES (20, N'Aula8', 12)
INSERT [dbo].[Aulas] ([AulaID], [Nombre], [EdificioID]) VALUES (21, N'Aula9', 13)
INSERT [dbo].[Aulas] ([AulaID], [Nombre], [EdificioID]) VALUES (22, N'Aula10', 14)
INSERT [dbo].[Aulas] ([AulaID], [Nombre], [EdificioID]) VALUES (23, N'Biblioteca', 15)
INSERT [dbo].[Aulas] ([AulaID], [Nombre], [EdificioID]) VALUES (24, N'Auditorio', 15)
SET IDENTITY_INSERT [dbo].[Aulas] OFF
GO
SET IDENTITY_INSERT [dbo].[Edificios] ON 

INSERT [dbo].[Edificios] ([EdificioID], [Nombre]) VALUES (5, N'Edificio1')
INSERT [dbo].[Edificios] ([EdificioID], [Nombre]) VALUES (6, N'Edificio2')
INSERT [dbo].[Edificios] ([EdificioID], [Nombre]) VALUES (7, N'Edificio3')
INSERT [dbo].[Edificios] ([EdificioID], [Nombre]) VALUES (8, N'Edificio4')
INSERT [dbo].[Edificios] ([EdificioID], [Nombre]) VALUES (9, N'Edificio5')
INSERT [dbo].[Edificios] ([EdificioID], [Nombre]) VALUES (10, N'Edificio6')
INSERT [dbo].[Edificios] ([EdificioID], [Nombre]) VALUES (11, N'Edificio7')
INSERT [dbo].[Edificios] ([EdificioID], [Nombre]) VALUES (12, N'Edificio8')
INSERT [dbo].[Edificios] ([EdificioID], [Nombre]) VALUES (13, N'Edificio9')
INSERT [dbo].[Edificios] ([EdificioID], [Nombre]) VALUES (14, N'Edificio10')
INSERT [dbo].[Edificios] ([EdificioID], [Nombre]) VALUES (15, N'Edificio A')
INSERT [dbo].[Edificios] ([EdificioID], [Nombre]) VALUES (16, N'')
SET IDENTITY_INSERT [dbo].[Edificios] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([UsuarioID], [Nombre], [Apellido], [FechaNacimiento], [TipoUsuario], [Username], [Clave]) VALUES (1, N'Juan', N'Pérez', CAST(N'1990-05-15T00:00:00.000' AS DateTime), N'Administrador', N'jperez', N'jperez01')
INSERT [dbo].[Usuarios] ([UsuarioID], [Nombre], [Apellido], [FechaNacimiento], [TipoUsuario], [Username], [Clave]) VALUES (2, N'Manuel', N'Terrero', CAST(N'1999-01-01T00:00:00.000' AS DateTime), N'Administrador', N'manuel', N'manuel01')
INSERT [dbo].[Usuarios] ([UsuarioID], [Nombre], [Apellido], [FechaNacimiento], [TipoUsuario], [Username], [Clave]) VALUES (4, N'Marco', N'Polo', CAST(N'2024-04-17T01:05:14.087' AS DateTime), N'Administrador', N'mpolo', N'mpolo1')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
SET IDENTITY_INSERT [dbo].[Visitantes] ON 

INSERT [dbo].[Visitantes] ([VisitanteID], [Nombre], [Apellido], [Carrera]) VALUES (1, N'María', N'González', N'Ingeniería en Sistemas')
INSERT [dbo].[Visitantes] ([VisitanteID], [Nombre], [Apellido], [Carrera]) VALUES (6, N'Juan', N'Pedro', N'Ingeniería')
INSERT [dbo].[Visitantes] ([VisitanteID], [Nombre], [Apellido], [Carrera]) VALUES (7, N'María', N'López', N'Medicina')
INSERT [dbo].[Visitantes] ([VisitanteID], [Nombre], [Apellido], [Carrera]) VALUES (8, N'Carlos', N'Martínez', N'Derecho')
INSERT [dbo].[Visitantes] ([VisitanteID], [Nombre], [Apellido], [Carrera]) VALUES (9, N'Ana', N'Rodríguez', N'Psicología')
INSERT [dbo].[Visitantes] ([VisitanteID], [Nombre], [Apellido], [Carrera]) VALUES (10, N'Pedro', N'Fernández', N'Administración de Empresas')
INSERT [dbo].[Visitantes] ([VisitanteID], [Nombre], [Apellido], [Carrera]) VALUES (11, N'Laura', N'García', N'Biología')
INSERT [dbo].[Visitantes] ([VisitanteID], [Nombre], [Apellido], [Carrera]) VALUES (12, N'Sergio', N'Pérez', N'Arquitectura')
INSERT [dbo].[Visitantes] ([VisitanteID], [Nombre], [Apellido], [Carrera]) VALUES (13, N'Elena', N'Sánchez', N'Marketing')
INSERT [dbo].[Visitantes] ([VisitanteID], [Nombre], [Apellido], [Carrera]) VALUES (14, N'Javier', N'Ruiz', N'Educación')
INSERT [dbo].[Visitantes] ([VisitanteID], [Nombre], [Apellido], [Carrera]) VALUES (15, N'Carmen', N'Díaz', N'Contabilidad')
INSERT [dbo].[Visitantes] ([VisitanteID], [Nombre], [Apellido], [Carrera]) VALUES (17, N'', N'', N'')
INSERT [dbo].[Visitantes] ([VisitanteID], [Nombre], [Apellido], [Carrera]) VALUES (18, N'Jorge', N'Mateo', N'Mecatronica')
SET IDENTITY_INSERT [dbo].[Visitantes] OFF
GO
SET IDENTITY_INSERT [dbo].[Visitas] ON 

INSERT [dbo].[Visitas] ([VisitaID], [UsuarioID], [VisitanteID], [EdificioID], [AulaID], [HoraEntrada], [HoraSalida], [MotivoVisita], [FotoVisitante]) VALUES (2, 1, 1, 5, 13, CAST(N'2024-04-20T16:17:31.000' AS DateTime), CAST(N'2024-04-20T17:17:31.000' AS DateTime), N'Clases', NULL)
INSERT [dbo].[Visitas] ([VisitaID], [UsuarioID], [VisitanteID], [EdificioID], [AulaID], [HoraEntrada], [HoraSalida], [MotivoVisita], [FotoVisitante]) VALUES (3, 1, 6, 5, 13, CAST(N'2024-04-20T16:17:31.000' AS DateTime), CAST(N'2024-04-20T17:17:31.000' AS DateTime), N'Clases', NULL)
INSERT [dbo].[Visitas] ([VisitaID], [UsuarioID], [VisitanteID], [EdificioID], [AulaID], [HoraEntrada], [HoraSalida], [MotivoVisita], [FotoVisitante]) VALUES (4, 1, 9, 6, 14, CAST(N'2024-04-20T16:17:31.000' AS DateTime), CAST(N'2024-04-20T17:17:31.000' AS DateTime), N'Clases', NULL)
INSERT [dbo].[Visitas] ([VisitaID], [UsuarioID], [VisitanteID], [EdificioID], [AulaID], [HoraEntrada], [HoraSalida], [MotivoVisita], [FotoVisitante]) VALUES (5, 2, 10, 7, 15, CAST(N'2024-04-20T16:17:31.000' AS DateTime), CAST(N'2024-04-20T17:17:31.000' AS DateTime), N'Clases', NULL)
INSERT [dbo].[Visitas] ([VisitaID], [UsuarioID], [VisitanteID], [EdificioID], [AulaID], [HoraEntrada], [HoraSalida], [MotivoVisita], [FotoVisitante]) VALUES (6, 1, 11, 9, 17, CAST(N'2024-04-18T16:17:31.000' AS DateTime), CAST(N'2024-04-20T17:17:31.000' AS DateTime), N'Clases', NULL)
INSERT [dbo].[Visitas] ([VisitaID], [UsuarioID], [VisitanteID], [EdificioID], [AulaID], [HoraEntrada], [HoraSalida], [MotivoVisita], [FotoVisitante]) VALUES (7, 1, 11, 9, 17, CAST(N'2024-04-18T16:17:31.000' AS DateTime), CAST(N'2024-04-20T17:17:31.000' AS DateTime), N'Clases', NULL)
INSERT [dbo].[Visitas] ([VisitaID], [UsuarioID], [VisitanteID], [EdificioID], [AulaID], [HoraEntrada], [HoraSalida], [MotivoVisita], [FotoVisitante]) VALUES (8, 2, 18, 13, 21, CAST(N'2024-04-20T10:33:45.000' AS DateTime), CAST(N'2024-04-20T07:33:45.000' AS DateTime), N'Clases', NULL)
INSERT [dbo].[Visitas] ([VisitaID], [UsuarioID], [VisitanteID], [EdificioID], [AulaID], [HoraEntrada], [HoraSalida], [MotivoVisita], [FotoVisitante]) VALUES (9, 1, 1, 15, 24, CAST(N'2024-04-20T21:37:47.110' AS DateTime), CAST(N'2024-04-20T21:37:47.110' AS DateTime), N'', NULL)
SET IDENTITY_INSERT [dbo].[Visitas] OFF
GO
/****** Object:  Index [IX_FK_EdificiosAulas]    Script Date: 4/20/2024 9:56:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_EdificiosAulas] ON [dbo].[Aulas]
(
	[EdificioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_AulasVisitas]    Script Date: 4/20/2024 9:56:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_AulasVisitas] ON [dbo].[Visitas]
(
	[AulaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_EdificiosVisitas]    Script Date: 4/20/2024 9:56:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_EdificiosVisitas] ON [dbo].[Visitas]
(
	[EdificioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_UsuariosVisitas]    Script Date: 4/20/2024 9:56:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_UsuariosVisitas] ON [dbo].[Visitas]
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_VisitantesVisitas]    Script Date: 4/20/2024 9:56:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_FK_VisitantesVisitas] ON [dbo].[Visitas]
(
	[VisitanteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Aulas]  WITH CHECK ADD  CONSTRAINT [FK_EdificiosAulas] FOREIGN KEY([EdificioID])
REFERENCES [dbo].[Edificios] ([EdificioID])
GO
ALTER TABLE [dbo].[Aulas] CHECK CONSTRAINT [FK_EdificiosAulas]
GO
ALTER TABLE [dbo].[Visitas]  WITH CHECK ADD  CONSTRAINT [FK_AulasVisitas] FOREIGN KEY([AulaID])
REFERENCES [dbo].[Aulas] ([AulaID])
GO
ALTER TABLE [dbo].[Visitas] CHECK CONSTRAINT [FK_AulasVisitas]
GO
ALTER TABLE [dbo].[Visitas]  WITH CHECK ADD  CONSTRAINT [FK_EdificiosVisitas] FOREIGN KEY([EdificioID])
REFERENCES [dbo].[Edificios] ([EdificioID])
GO
ALTER TABLE [dbo].[Visitas] CHECK CONSTRAINT [FK_EdificiosVisitas]
GO
ALTER TABLE [dbo].[Visitas]  WITH CHECK ADD  CONSTRAINT [FK_UsuariosVisitas] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuarios] ([UsuarioID])
GO
ALTER TABLE [dbo].[Visitas] CHECK CONSTRAINT [FK_UsuariosVisitas]
GO
ALTER TABLE [dbo].[Visitas]  WITH CHECK ADD  CONSTRAINT [FK_VisitantesVisitas] FOREIGN KEY([VisitanteID])
REFERENCES [dbo].[Visitantes] ([VisitanteID])
GO
ALTER TABLE [dbo].[Visitas] CHECK CONSTRAINT [FK_VisitantesVisitas]
GO
/****** Object:  StoredProcedure [dbo].[ActualizarAula]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ActualizarAula]
    @IdAula INT,
    @Nombre NVARCHAR(100),
    @EdificioID INT
AS
BEGIN
    UPDATE dbo.Aulas
    SET Nombre = @Nombre,
        EdificioID = @EdificioID
    WHERE AulaID = @IdAula;
END;
GO
/****** Object:  StoredProcedure [dbo].[ActualizarNombreEdificio]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarNombreEdificio]
    @IdEdificio INT,
    @Nombre NVARCHAR(100)
AS
BEGIN
    UPDATE dbo.Edificios
    SET Nombre = @Nombre
    WHERE EdificioID = @IdEdificio;
END;
GO
/****** Object:  StoredProcedure [dbo].[ActualizarUsuario]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarUsuario]
    @idUsuario INT,
    @nombre NVARCHAR(50),
    @apellido NVARCHAR(50),
    @fechaNacimiento DATETIME,
    @nombreUsuario NVARCHAR(50),
    @clave NVARCHAR(150),
    @tipoUsuario NVARCHAR(20)
AS
BEGIN
    UPDATE dbo.Usuarios
    SET 
        Nombre = @nombre,
        Apellido = @apellido,
        FechaNacimiento = @fechaNacimiento,
        Username = @nombreUsuario,
        Clave = @clave,
        TipoUsuario = @tipoUsuario
    WHERE 
        UsuarioID = @idUsuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[ActualizarVisita]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarVisita]
    @VisitaID INT,
    @UsuarioID INT,
    @VisitanteID INT,
    @EdificioID INT,
    @AulaID INT,
    @HoraEntrada DATETIME,
    @HoraSalida DATETIME,
    @MotivoVisita NVARCHAR(150)
AS
BEGIN
    UPDATE dbo.Visitas
    SET UsuarioID = @UsuarioID,
        VisitanteID = @VisitanteID,
        EdificioID = @EdificioID,
        AulaID = @AulaID,
        HoraEntrada = @HoraEntrada,
        HoraSalida = @HoraSalida,
        MotivoVisita = @MotivoVisita
    WHERE VisitaID = @VisitaID;
END;
GO
/****** Object:  StoredProcedure [dbo].[ActualizarVisitante]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ActualizarVisitante]
    @IdVisitante INT,
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Carrera NVARCHAR(100)
AS
BEGIN
    UPDATE dbo.Visitantes
    SET Nombre = @Nombre,
        Apellido = @Apellido,
        Carrera = @Carrera
    WHERE VisitanteID = @IdVisitante;
END;
GO
/****** Object:  StoredProcedure [dbo].[BuscarAulaPorNombreParcial]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BuscarAulaPorNombreParcial]
    @Nombre NVARCHAR(100)
AS
BEGIN
    SELECT AulaID, Nombre, EdificioID 
    FROM dbo.Aulas 
    WHERE Nombre LIKE '%' + @Nombre + '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[BuscarEdificioPorNombreParcial]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BuscarEdificioPorNombreParcial]
    @Nombre NVARCHAR(100)
AS
BEGIN
    SELECT * FROM dbo.Edificios WHERE Nombre LIKE '%' + @Nombre + '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[BuscarUsuarioPorNombre]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BuscarUsuarioPorNombre]
    @nombreUsuario NVARCHAR(50)
AS
BEGIN
    SELECT * FROM dbo.Usuarios WHERE Nombre = @nombreUsuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[BuscarUsuarioPorNombreParcial]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BuscarUsuarioPorNombreParcial]
    @nombreUsuario NVARCHAR(50)
AS
BEGIN
    SELECT * FROM dbo.Usuarios WHERE Nombre LIKE '%' + @nombreUsuario + '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[ContarVisitasPorEdificioID]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ContarVisitasPorEdificioID]
    @EdificioID INT
AS
BEGIN
    SELECT COUNT(*) 
    FROM dbo.Visitas 
    WHERE EdificioID = @EdificioID;
END;
GO
/****** Object:  StoredProcedure [dbo].[ContarVisitasPorEdificioYFecha]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ContarVisitasPorEdificioYFecha]
    @EdificioID INT,
    @Fecha DATE
AS
BEGIN
    SELECT COUNT(*) 
    FROM dbo.Visitas 
    WHERE EdificioID = @EdificioID 
    AND CONVERT(date, HoraEntrada) = @Fecha;
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarAula]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarAula]
    @IdAula INT
AS
BEGIN
    DELETE FROM dbo.Aulas
    WHERE AulaID = @IdAula;
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarEdificio]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarEdificio]
    @IdEdificio INT
AS
BEGIN
    DELETE FROM dbo.Edificios
    WHERE EdificioID = @IdEdificio;
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarUsuario]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarUsuario]
    @idUsuario INT
AS
BEGIN
    DELETE FROM dbo.Usuarios WHERE UsuarioID = @idUsuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarVisita]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarVisita]
    @VisitaID INT
AS
BEGIN
    DELETE FROM dbo.Visitas
    WHERE VisitaID = @VisitaID;
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarVisitante]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarVisitante]
    @IdVisitante INT
AS
BEGIN
    DELETE FROM dbo.Visitantes
    WHERE VisitanteID = @IdVisitante;
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarAula]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarAula]
    @Nombre NVARCHAR(100),
    @EdificioID INT
AS
BEGIN
    INSERT INTO dbo.Aulas (Nombre, EdificioID)
    VALUES (@Nombre, @EdificioID);
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarEdificio]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarEdificio]
    @Nombre NVARCHAR(100)
AS
BEGIN
    INSERT INTO dbo.Edificios (Nombre)
    VALUES (@Nombre);
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarUsuario]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarUsuario]
    @nombre NVARCHAR(50),
    @apellido NVARCHAR(50),
    @fechaNacimiento DATETIME,
    @nombreUsuario NVARCHAR(50),
    @clave NVARCHAR(150),
    @tipoUsuario NVARCHAR(20)
AS
BEGIN
    INSERT INTO dbo.Usuarios (Nombre, Apellido, FechaNacimiento, Username, Clave, TipoUsuario)
    VALUES (@nombre, @apellido, @fechaNacimiento, @nombreUsuario, @clave, @tipoUsuario);
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarVisita]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarVisita]
    @UsuarioID INT,
    @VisitanteID INT,
    @EdificioID INT,
    @AulaID INT,
    @HoraEntrada DATETIME,
    @HoraSalida DATETIME,
    @MotivoVisita NVARCHAR(150)
AS
BEGIN
    INSERT INTO dbo.Visitas (UsuarioID, VisitanteID, EdificioID, AulaID, HoraEntrada, HoraSalida, MotivoVisita)
    VALUES (@UsuarioID, @VisitanteID, @EdificioID, @AulaID, @HoraEntrada, @HoraSalida, @MotivoVisita);
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarVisitante]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarVisitante]
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Carrera NVARCHAR(100)
AS
BEGIN
    INSERT INTO dbo.Visitantes (Nombre, Apellido, Carrera)
    VALUES (@Nombre, @Apellido, @Carrera);
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerInformacionVisitas]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerInformacionVisitas]
AS
BEGIN
    SELECT v.VisitaID AS 'VisitaID',
           vis.Nombre AS 'Nombre de Visitante',
           e.Nombre AS 'Nombre de Edificio',
           a.Nombre AS 'Nombre de Aula',
           v.HoraEntrada AS 'Hora de Entrada',
           v.HoraSalida AS 'Hora de Salida',
           v.MotivoVisita AS 'Motivo de Visita'
    FROM Visitas v
    INNER JOIN Usuarios u ON v.UsuarioID = u.UsuarioID
    INNER JOIN Visitantes vis ON v.VisitanteID = vis.VisitanteID
    INNER JOIN Edificios e ON v.EdificioID = e.EdificioID
    INNER JOIN Aulas a ON v.AulaID = a.AulaID;
END;
GO
/****** Object:  StoredProcedure [dbo].[SeleccionarAulaPorID]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionarAulaPorID]
    @IdAula INT
AS
BEGIN
    SELECT * FROM dbo.Aulas WHERE AulaID = @IdAula;
END;
GO
/****** Object:  StoredProcedure [dbo].[SeleccionarAulas]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionarAulas]
AS
BEGIN
    SELECT AulaID, Nombre, EdificioID
    FROM dbo.Aulas;
END;
GO
/****** Object:  StoredProcedure [dbo].[SeleccionarAulasPorEdificioID]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SeleccionarAulasPorEdificioID]
    @EdificioID INT
AS
BEGIN
    SELECT AulaID, Nombre 
    FROM dbo.Aulas 
    WHERE EdificioID = @EdificioID;
END;
GO
/****** Object:  StoredProcedure [dbo].[SeleccionarEdificios]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionarEdificios]
AS
BEGIN
    SELECT * FROM dbo.Edificios;
END;
GO
/****** Object:  StoredProcedure [dbo].[SeleccionarHoraEntradaVisitas]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionarHoraEntradaVisitas]
AS
BEGIN
    SELECT HoraEntrada FROM dbo.Visitas;
END
GO
/****** Object:  StoredProcedure [dbo].[SeleccionarNombreEdificioPorID]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionarNombreEdificioPorID]
    @IdEdificio INT
AS
BEGIN
    SELECT Nombre FROM dbo.Edificios WHERE EdificioID = @IdEdificio;
END;
GO
/****** Object:  StoredProcedure [dbo].[SeleccionarTodosVisitantes]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionarTodosVisitantes]
AS
BEGIN
    SELECT * FROM dbo.Visitantes;
END;
GO
/****** Object:  StoredProcedure [dbo].[SeleccionarUsuarios]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SeleccionarUsuarios]
AS
BEGIN
    SELECT * FROM dbo.Usuarios;
END;
GO
/****** Object:  StoredProcedure [dbo].[SeleccionarVisitantesPorNombre]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionarVisitantesPorNombre]
    @Nombre NVARCHAR(100)
AS
BEGIN
    SELECT * 
    FROM dbo.Visitantes 
    WHERE Nombre LIKE '%' + @Nombre + '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[SeleccionarVisitaPorID]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionarVisitaPorID]
    @VisitaID INT
AS
BEGIN
    SELECT * 
    FROM dbo.Visitas 
    WHERE VisitaID = @VisitaID;
END;
GO
/****** Object:  StoredProcedure [dbo].[SeleccionarVisitas]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionarVisitas]
AS
BEGIN
    SELECT * FROM dbo.Visitas;
END;
GO
/****** Object:  StoredProcedure [dbo].[SeleccionarVisitasPorVisitanteID]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SeleccionarVisitasPorVisitanteID]
    @VisitanteID INT
AS
BEGIN
    SELECT * 
    FROM dbo.Visitas 
    WHERE VisitanteID = @VisitanteID;
END;
GO
/****** Object:  StoredProcedure [dbo].[ValidarCredenciales]    Script Date: 4/20/2024 9:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ValidarCredenciales]
    @user NVARCHAR(50),
    @pass NVARCHAR(150)
AS
BEGIN
    SELECT * FROM dbo.Usuarios WHERE Username = @user AND Clave = @pass;
END;
GO
USE [master]
GO
ALTER DATABASE [InstitutoTecnologicoAmericas] SET  READ_WRITE 
GO
