USE [master]
GO
/****** Object:  Database [Inventario1]    Script Date: 13/8/2018 14:35:33 ******/
CREATE DATABASE [Inventario1]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Inventario1', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLSTANDARD\MSSQL\DATA\Inventario1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Inventario1_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLSTANDARD\MSSQL\DATA\Inventario1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Inventario1] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Inventario1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Inventario1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Inventario1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Inventario1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Inventario1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Inventario1] SET ARITHABORT OFF 
GO
ALTER DATABASE [Inventario1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Inventario1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Inventario1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Inventario1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Inventario1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Inventario1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Inventario1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Inventario1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Inventario1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Inventario1] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Inventario1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Inventario1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Inventario1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Inventario1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Inventario1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Inventario1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Inventario1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Inventario1] SET RECOVERY FULL 
GO
ALTER DATABASE [Inventario1] SET  MULTI_USER 
GO
ALTER DATABASE [Inventario1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Inventario1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Inventario1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Inventario1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Inventario1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Inventario1] SET QUERY_STORE = OFF
GO
USE [Inventario1]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [Inventario1]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 13/8/2018 14:35:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[categoria] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 13/8/2018 14:35:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NULL,
	[id_proveedores] [int] NULL,
	[id_usuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_compras]    Script Date: 13/8/2018 14:35:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_compras](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[precio] [float] NULL,
	[id_productos] [int] NULL,
	[id_compras] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_factura]    Script Date: 13/8/2018 14:35:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_factura](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[codigo_factura] [int] NULL,
	[descripcion] [varchar](100) NULL,
	[id_productos] [int] NULL,
	[id_factura] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Factura]    Script Date: 13/8/2018 14:35:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Factura](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fecha] [date] NULL,
	[cantidad] [int] NULL,
	[precio] [float] NULL,
	[descuento] [float] NULL,
	[iva] [float] NULL,
	[total] [float] NULL,
	[id_usuario] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 13/8/2018 14:35:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 13/8/2018 14:35:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[descripcion] [varchar](100) NULL,
	[precio] [float] NULL,
	[id_marca] [int] NULL,
	[id_categoria] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 13/8/2018 14:35:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[direccion] [varchar](100) NULL,
	[telefono] [varchar](100) NULL,
	[empresa] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol]    Script Date: 13/8/2018 14:35:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[rol] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuario]    Script Date: 13/8/2018 14:35:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[pass] [varchar](50) NULL,
	[id_rol] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categoria] ON 

INSERT [dbo].[Categoria] ([id], [categoria]) VALUES (1, N'Alimentos')
INSERT [dbo].[Categoria] ([id], [categoria]) VALUES (2, N'Bebidas')
INSERT [dbo].[Categoria] ([id], [categoria]) VALUES (3, N'Limpieza')
INSERT [dbo].[Categoria] ([id], [categoria]) VALUES (4, N'Electrodomesticos')
INSERT [dbo].[Categoria] ([id], [categoria]) VALUES (5, N'Herramientas')
INSERT [dbo].[Categoria] ([id], [categoria]) VALUES (6, N'Vestuario')
SET IDENTITY_INSERT [dbo].[Categoria] OFF
SET IDENTITY_INSERT [dbo].[Detalle_compras] ON 

INSERT [dbo].[Detalle_compras] ([id], [precio], [id_productos], [id_compras]) VALUES (1, 0.5, 3, NULL)
SET IDENTITY_INSERT [dbo].[Detalle_compras] OFF
SET IDENTITY_INSERT [dbo].[Factura] ON 

INSERT [dbo].[Factura] ([id], [fecha], [cantidad], [precio], [descuento], [iva], [total], [id_usuario]) VALUES (1, CAST(N'2018-08-09' AS Date), 5, 10, 1, 0, 9, NULL)
INSERT [dbo].[Factura] ([id], [fecha], [cantidad], [precio], [descuento], [iva], [total], [id_usuario]) VALUES (2, CAST(N'2018-08-09' AS Date), 5, 10, 0.5, 0.23, 9.27, NULL)
INSERT [dbo].[Factura] ([id], [fecha], [cantidad], [precio], [descuento], [iva], [total], [id_usuario]) VALUES (3, CAST(N'2018-08-09' AS Date), 5, 0.5, 0.5, 0.23, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Factura] OFF
SET IDENTITY_INSERT [dbo].[Marca] ON 

INSERT [dbo].[Marca] ([id], [nombre]) VALUES (1, N'cocacola')
INSERT [dbo].[Marca] ([id], [nombre]) VALUES (2, N'pepsi')
SET IDENTITY_INSERT [dbo].[Marca] OFF
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([id], [nombre], [descripcion], [precio], [id_marca], [id_categoria]) VALUES (3, N'del valle', N'jugo', 0.5, 1, 2)
SET IDENTITY_INSERT [dbo].[Productos] OFF
SET IDENTITY_INSERT [dbo].[Proveedores] ON 

INSERT [dbo].[Proveedores] ([id], [nombre], [direccion], [telefono], [empresa]) VALUES (1, N'asd', N'sddgfg', N'7853-46574', N'cdst')
SET IDENTITY_INSERT [dbo].[Proveedores] OFF
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD FOREIGN KEY([id_proveedores])
REFERENCES [dbo].[Proveedores] ([id])
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[Detalle_compras]  WITH CHECK ADD FOREIGN KEY([id_compras])
REFERENCES [dbo].[Compras] ([id])
GO
ALTER TABLE [dbo].[Detalle_compras]  WITH CHECK ADD FOREIGN KEY([id_productos])
REFERENCES [dbo].[Productos] ([id])
GO
ALTER TABLE [dbo].[Detalle_factura]  WITH CHECK ADD FOREIGN KEY([id_factura])
REFERENCES [dbo].[Factura] ([id])
GO
ALTER TABLE [dbo].[Detalle_factura]  WITH CHECK ADD FOREIGN KEY([id_productos])
REFERENCES [dbo].[Productos] ([id])
GO
ALTER TABLE [dbo].[Factura]  WITH CHECK ADD FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuario] ([id])
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD FOREIGN KEY([id_categoria])
REFERENCES [dbo].[Categoria] ([id])
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD FOREIGN KEY([id_marca])
REFERENCES [dbo].[Marca] ([id])
GO
ALTER TABLE [dbo].[usuario]  WITH CHECK ADD FOREIGN KEY([id_rol])
REFERENCES [dbo].[rol] ([id])
GO
USE [master]
GO
ALTER DATABASE [Inventario1] SET  READ_WRITE 
GO
