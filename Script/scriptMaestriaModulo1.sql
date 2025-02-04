USE [Maestria1Modulo]
GO
/****** Object:  Table [dbo].[Año]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Año](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AsignacionCamion]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsignacionCamion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCamion] [int] NULL,
	[IdCliente] [int] NULL,
 CONSTRAINT [PK_AsignacionCamion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Banco]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Banco](
	[Id_Banco] [int] NOT NULL,
	[Descripcion] [varchar](250) NULL,
	[Abreviacion] [nvarchar](200) NULL,
 CONSTRAINT [PK_Banco] PRIMARY KEY CLUSTERED 
(
	[Id_Banco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bitacora]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bitacora](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](250) NOT NULL,
	[Accion] [varchar](1000) NOT NULL,
	[Fecha] [datetime] NOT NULL CONSTRAINT [DF_Bitacora_Fecha]  DEFAULT (getdate()),
	[IdUsuario] [int] NOT NULL,
 CONSTRAINT [PK_Bitacora] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Camiones]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Camiones](
	[Id_Camion] [int] IDENTITY(1,1) NOT NULL,
	[Placa] [varchar](150) NULL,
	[Emplaque] [varchar](250) NULL,
	[Capacidad] [varchar](250) NULL,
	[OBS] [varchar](1000) NULL,
	[Est] [int] NULL CONSTRAINT [DF_Camiones_Est]  DEFAULT ((0)),
	[Estado] [int] NULL CONSTRAINT [DF_Camiones_Estado]  DEFAULT ((2)),
	[Ubicacion] [varchar](100) NULL,
	[Fecha_Registro] [datetime] NULL CONSTRAINT [DF_Camiones_Fecha_Registro]  DEFAULT (getdate()),
	[FechaEstado] [datetime] NULL,
	[Id_Marca] [int] NULL,
	[Id_Color] [int] NULL,
	[IdPropietario] [varchar](250) NULL,
	[IdChofer] [varchar](250) NULL,
	[IdTitBanco] [varchar](250) NULL,
	[Id_Soat] [int] NULL,
	[Id_InspeccionTecnica] [int] NULL,
	[Id_Rastreo] [int] NULL,
	[Seguros] [int] NULL CONSTRAINT [DF_Camiones_Seguros]  DEFAULT ((0)),
 CONSTRAINT [PK_Camiones] PRIMARY KEY CLUSTERED 
(
	[Id_Camion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Color]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Color](
	[Id_Color] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](350) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Cuenta]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuenta](
	[Id_Cuenta] [int] IDENTITY(1,1) NOT NULL,
	[NroCuenta] [bigint] NULL,
	[Id_Banco] [int] NULL,
	[Id_TipoCuenta] [int] NULL CONSTRAINT [DF_Cuenta_Id_TipoCuenta]  DEFAULT ((1)),
 CONSTRAINT [PK_Cuenta] PRIMARY KEY CLUSTERED 
(
	[Id_Cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Detalle_Camion]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Detalle_Camion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaCambio] [datetime] NOT NULL CONSTRAINT [DF_Detalle_Camion_FechaCambio]  DEFAULT (getdate()),
	[IdEstado] [int] NOT NULL,
	[Placa] [varchar](250) NOT NULL,
	[IdChofer] [int] NOT NULL,
 CONSTRAINT [PK_Detalle_Camion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Detalle_Planta]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Planta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Planta] [nvarchar](300) NULL,
	[IdPlanta] [int] NULL,
 CONSTRAINT [PK_Detalle_Planta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Detalle_Recepcion]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Detalle_Recepcion](
	[Id_Detalle] [int] NOT NULL,
	[Monto_Anticipo] [float] NULL,
	[FechaCarga] [date] NULL,
	[FechaDescarga] [date] NULL,
	[Vigencia] [date] NULL,
	[FechaRegistro] [date] NULL CONSTRAINT [DF_Detalle_Recepcion_FechaRegistro]  DEFAULT (getdate()),
	[Placa_Camion] [varchar](250) NULL,
	[Id_Recepcion] [int] NULL,
	[Estado] [int] NULL,
	[Id_Chofer] [varchar](250) NULL,
	[Compartimiento1] [float] NULL,
	[Compartimiento2] [float] NULL,
	[Compartimiento3] [float] NULL,
	[Compartimiento4] [float] NULL,
	[Compartimiento5] [float] NULL,
	[Compartimiento6] [float] NULL,
	[Compartimiento7] [float] NULL,
	[Precintos] [int] NULL,
	[Producto] [int] NULL,
	[Id_Ruta] [int] NULL,
	[VolumenRecepcion] [float] NULL,
	[Cre] [varchar](200) NULL,
	[Obs] [varchar](1000) NULL,
	[CreditoDebito] [varchar](500) NULL,
	[Confirmado] [int] NULL CONSTRAINT [DF_Detalle_Recepcion_Asegurado]  DEFAULT ((1)),
	[Insertado] [int] NULL CONSTRAINT [DF_Detalle_Recepcion_Insertado]  DEFAULT ((0)),
	[FechaAnticipo] [date] NULL,
	[Enviado] [int] NULL CONSTRAINT [DF_Detalle_Recepcion_Enviado]  DEFAULT ((0)),
	[IdFactura] [int] NULL,
	[NroFactura] [nvarchar](500) NULL,
	[NombreTitular] [varchar](250) NULL,
	[DetallePlantaOrigen] [int] NULL,
	[DetallePlantaDestino] [int] NULL,
	[Id_Titular] [nvarchar](250) NULL,
	[SF1] [int] NULL DEFAULT ((0)),
	[FechaConfirmacion] [datetime] NULL,
	[NoCrt] [nvarchar](300) NULL,
	[VolumenCrt] [float] NULL,
	[PesoCrt] [float] NULL,
	[NoMic] [nvarchar](300) NULL,
	[VolumenMic] [float] NULL,
	[PesoMic] [float] NULL,
	[Id_Pmm] [int] NULL,
	[EstConfViaInternacional] [int] NULL DEFAULT ((0)),
 CONSTRAINT [PK_Detalle_Recepcion] PRIMARY KEY CLUSTERED 
(
	[Id_Detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Detalle_Ruta]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Ruta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdRuta] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[MermaMaxima] [float] NULL,
	[MultaPorProducto] [float] NULL,
 CONSTRAINT [PK_Detalle_Ruta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Detalle_TipoEntidad]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_TipoEntidad](
	[Id_Detalle] [int] IDENTITY(1,1) NOT NULL,
	[Cod_Ente] [int] NULL,
	[Id_TipoEntidad] [int] NULL,
	[Estado] [int] NULL CONSTRAINT [DF_Detalle_TipoEntidad_Estado]  DEFAULT ((1)),
	[Fecha_Registro] [datetime] NULL CONSTRAINT [DF_Detalle_TipoEntidad_Fecha_Registro]  DEFAULT (getdate())
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Entes]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entes](
	[Cod_Ente] [int] IDENTITY(1,1) NOT NULL,
	[Id_Tipo] [int] NULL,
 CONSTRAINT [PK__Entes__F4E9089B9FDD254E] PRIMARY KEY CLUSTERED 
(
	[Cod_Ente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Estado]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estado](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Desccripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Marca](
	[Id_Marca] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](250) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mes]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Persona](
	[Id_Persona] [int] IDENTITY(1,1) NOT NULL,
	[CI] [varchar](250) NULL,
	[Nombre] [varchar](100) NULL,
	[Apellidos] [varchar](100) NULL,
	[Direccion] [varchar](100) NULL,
	[Telefono] [varchar](50) NULL,
	[TelfReferencia] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Emision] [varchar](250) NULL,
	[Estado] [int] NULL CONSTRAINT [DF_Persona_Estado]  DEFAULT ((1)),
	[Fecha_Registro] [datetime] NULL CONSTRAINT [DF_Persona_Fecha_Registro]  DEFAULT (getdate()),
	[Cod_Ente] [int] NULL,
	[Id_ImagenCi] [int] NULL,
	[Id_ImagenLicencia] [int] NULL,
	[Id_ImagenFelcn] [int] NULL,
	[Id_ImagenRejap] [int] NULL,
	[Id_CuentaContable] [int] NULL,
	[ClienteAceite] [int] NULL,
	[idFp] [int] NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[Id_Persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Planta]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_Planta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Producto]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Producto](
	[Id_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](250) NULL,
	[Abrev] [varchar](50) NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rastreo]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Rastreo](
	[Id_Rastreo] [int] NULL,
	[Descripcion] [varchar](250) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Recepcion]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Recepcion](
	[Id_Recepcion] [int] NOT NULL,
	[Id_RecepcionManual] [varchar](1000) NULL,
	[Estado] [int] NOT NULL,
	[F_Reg] [datetime] NULL CONSTRAINT [DF_Recepcion_F_Reg]  DEFAULT (getdate()),
	[OBS] [varchar](2000) NULL,
	[Cod_Ente] [int] NULL,
	[Id_Conciliacion] [int] NULL,
	[VolumenTotalDespacho] [float] NULL,
	[TramoDesde] [int] NULL,
	[TramoHasta] [int] NULL,
	[FechaCarga] [date] NULL,
	[FechaDescarga] [date] NULL,
	[Cod_Prod] [int] NULL,
	[EstadoConciFLet] [int] NULL,
	[Id_Ruta] [int] NULL,
 CONSTRAINT [PK_Recepcion] PRIMARY KEY CLUSTERED 
(
	[Id_Recepcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[Id_rol] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ruta]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ruta](
	[Id_Ruta] [int] IDENTITY(1,1) NOT NULL,
	[Ruta] [nvarchar](250) NULL,
	[Origen] [int] NULL,
	[Destino] [int] NULL,
	[MontoAnticipo] [float] NULL,
	[PrecioFlet] [float] NULL,
	[PrecioTotal] [float] NULL,
	[CamionGuia] [int] NULL CONSTRAINT [DF_Ruta_CamionGuia]  DEFAULT ((0)),
	[Id_Cliente] [int] NOT NULL,
	[IdRegion] [int] NULL,
	[RutaCorta] [int] NULL CONSTRAINT [DF_Ruta_RutaCorta]  DEFAULT ((0)),
	[Estado] [int] NULL CONSTRAINT [DF_Ruta_Estado]  DEFAULT ((1)),
	[IdFrontera] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sucursal](
	[Id_Sucursal] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Sucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Tipo_Ente]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tipo_Ente](
	[Id_Tipo] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](250) NULL,
 CONSTRAINT [PK__Tipo_Ent__064163925A2AFB76] PRIMARY KEY CLUSTERED 
(
	[Id_Tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoPersona]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoPersona](
	[Id_TipoPers] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](250) NULL,
 CONSTRAINT [PK__TipoPers__50DB2919E203957F] PRIMARY KEY CLUSTERED 
(
	[Id_TipoPers] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TitularBanco]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TitularBanco](
	[Id_Persona] [int] NOT NULL,
	[Id_Cuenta] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Persona] ASC,
	[Id_Cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Id_Persona] [int] NOT NULL,
	[Usuario] [varchar](100) NOT NULL,
	[Contraseña] [varchar](100) NOT NULL,
	[Id_Sucursal] [int] NOT NULL,
	[Id_Rol] [int] NOT NULL,
	[Estado] [int] NOT NULL CONSTRAINT [DF__Usuario__Estado__3C69FB99]  DEFAULT ((1)),
	[Fecha_Registro] [datetime] NULL CONSTRAINT [DF__Usuario__Fecha_R__37A5467C]  DEFAULT (getdate()),
	[IdGenero] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ListaMarca]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ListaMarca]
AS
SELECT        dbo.Camiones.Id_Marca, dbo.Marca.Descripcion
FROM            dbo.Camiones INNER JOIN
                         dbo.Marca ON dbo.Camiones.Id_Marca = dbo.Marca.Id_Marca

GO
/****** Object:  View [dbo].[Vi_BuscarPersona]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[Vi_BuscarPersona]
AS
SELECT        Id_Persona, CI, Nombre + ' ' + Apellidos AS Personas, Direccion, Telefono
FROM            dbo.Persona


GO
/****** Object:  View [dbo].[Vi_Camion]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[Vi_Camion]
AS
SELECT        Id_Camion, Placa, Emplaque, Capacidad
FROM            dbo.Camiones


GO
/****** Object:  View [dbo].[Vi_Cliente]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[Vi_Cliente]
AS
SELECT        P.Id_Persona, P.CI, P.Cod_Ente, P.Nombre + ' ' + P.Apellidos AS CLIENTE, P.Direccion, P.Telefono, P.Telefono AS Expr1, P.Email, TP.Id_TipoPers, TP.Descripcion AS Tipo_Entidad
FROM            dbo.Detalle_TipoEntidad AS TEnt LEFT OUTER JOIN
                         dbo.Entes AS E ON TEnt.Cod_Ente = E.Cod_Ente LEFT OUTER JOIN
                         dbo.Persona AS P ON TEnt.Cod_Ente = P.Cod_Ente LEFT OUTER JOIN
                         dbo.TipoPersona AS TP ON TEnt.Id_TipoEntidad = TP.Id_TipoPers
WHERE        (TP.Id_TipoPers = 5)

GO
/****** Object:  View [dbo].[Vi_ClienteEnte]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[Vi_ClienteEnte]
AS
SELECT        P.CI, P.Id_Persona, P.Cod_Ente, P.Nombre + ' ' + P.Apellidos AS CLIENTE, P.Direccion, P.Telefono, P.Telefono AS Expr1, P.Email, TP.Id_TipoPers, TP.Descripcion AS Tipo_Entidad
FROM            dbo.Detalle_TipoEntidad AS TEnt LEFT OUTER JOIN
                         dbo.Entes AS E ON TEnt.Cod_Ente = E.Cod_Ente LEFT OUTER JOIN
                         dbo.Persona AS P ON TEnt.Cod_Ente = P.Cod_Ente LEFT OUTER JOIN
                         dbo.TipoPersona AS TP ON TEnt.Id_TipoEntidad = TP.Id_TipoPers
WHERE        (TP.Id_TipoPers = 5)

GO
/****** Object:  View [dbo].[Vi_DetalleTipoEntidad]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[Vi_DetalleTipoEntidad]
AS
SELECT        P.Cod_Ente, P.Id_Persona, P.CI, P.Nombre, P.Apellidos, TP.Id_TipoPers, TP.Descripcion AS Tipo_Entidad
FROM            dbo.Detalle_TipoEntidad AS DT INNER JOIN
                         dbo.Persona AS P ON DT.Cod_Ente = P.Cod_Ente INNER JOIN
                         dbo.TipoPersona AS TP ON DT.Id_TipoEntidad = TP.Id_TipoPers

GO
/****** Object:  View [dbo].[Vi_ListaCamiones]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Vi_ListaCamiones]
AS
SELECT        Id_Camion, Placa, Emplaque, Capacidad, OBS, Ubicacion, ISNULL(Estado, 1) AS Estado, ISNULL(Fecha_Registro, GETDATE()) AS Fecha_Registro, Id_Marca, Id_Color, IdPropietario, IdChofer, IdTitBanco, 
                         ISNULL(Id_Soat, 0) AS Id_Soat, ISNULL(Id_InspeccionTecnica, 0) AS Id_InspeccionTecnica, Id_Rastreo
FROM            dbo.Camiones

GO
/****** Object:  View [dbo].[Vi_ListaCuenta]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[Vi_ListaCuenta]
AS
SELECT        Id_Cuenta, NroCuenta, Id_Banco, Id_TipoCuenta
FROM            dbo.Cuenta

GO
/****** Object:  View [dbo].[vi_listaPersonas]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vi_listaPersonas]
AS
SELECT        Id_Persona, CI, Nombre, Apellidos, Direccion, Telefono, TelfReferencia, ISNULL(Email, '') AS Email, ISNULL(Emision, '') AS Emision, ISNULL(Cod_Ente, 0) AS Cod_Ente, ISNULL(Id_ImagenCi, 0) AS Id_ImagenCi, 
                         ISNULL(Id_ImagenLicencia, 0) AS Id_ImagenLicencia, ISNULL(Id_ImagenFelcn, 0) AS Id_ImagenFelcn, ISNULL(Id_ImagenRejap, 0) AS Id_ImagenRejap, ISNULL(Id_CuentaContable, 0) AS Id_CuentaContable, 
                         ISNULL(Estado, 1) AS Estado, ISNULL(Fecha_Registro, GETDATE()) AS Fecha_Registro, 0 AS IdTipoPersona, Nombre +' '+Apellidos as Nombres
FROM            dbo.Persona AS P
WHERE        (Estado = 1)

GO
/****** Object:  View [dbo].[vi_ListaPersonasCL]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vi_ListaPersonasCL]
AS
SELECT        Id_Persona, CI, Nombre + ' ' + Apellidos AS Cliente, Direccion, Telefono, TelfReferencia, ISNULL(Email, '') AS Email, ISNULL(Cod_Ente, 0) AS Cod_Ente, ISNULL(Id_ImagenCi, 0) AS Id_ImagenCi, ISNULL(Id_ImagenLicencia, 0) 
                         AS Id_ImagenLicencia, ISNULL(Id_ImagenFelcn, 0) AS Id_ImagenFelcn, ISNULL(Id_ImagenRejap, 0) AS Id_ImagenRejap, ISNULL(Id_CuentaContable, 0) AS Id_CuentaContable, ISNULL(Estado, 1) AS Estado, 
                         ISNULL(Fecha_Registro, GETDATE()) AS Fecha_Registro, 0 AS IdTipoPersona
FROM            dbo.Persona AS P

GO
/****** Object:  View [dbo].[Vi_ListaUsuarios]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[Vi_ListaUsuarios]
AS
SELECT        U.Id_Usuario, U.Id_Persona, U.Usuario, U.Contraseña, P.Nombre, P.Apellidos, P.Direccion, P.Telefono, P.TelfReferencia, P.Email, R.Id_rol, R.Descripcion AS Rol, S.Descripcion AS Sucursal, U.Estado
FROM            dbo.Usuario AS U INNER JOIN
                         dbo.Persona AS P ON U.Id_Persona = P.Id_Persona INNER JOIN
                         dbo.Roles AS R ON U.Id_Rol = R.Id_rol INNER JOIN
                         dbo.Entes AS E ON P.Cod_Ente = E.Cod_Ente INNER JOIN
                         dbo.Sucursal AS S ON U.Id_Sucursal = S.Id_Sucursal
WHERE        (U.Estado = 1)


GO
/****** Object:  View [dbo].[Vi_Ruta]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[Vi_Ruta]
AS
SELECT        R.Id_Ruta, R.Ruta, R.MontoAnticipo, R.PrecioTotal, R.Id_Cliente, Pe.Id_Persona, Pe.CI, Pe.Nombre, Pe.Apellidos, Pl.Descripcion AS Origen, Pla.Descripcion AS Destino, R.PrecioFlet, R.Origen AS Ori, 
                         R.Destino AS Des, R.CamionGuia,R.IdFrontera
FROM            dbo.Ruta AS R INNER JOIN
                         dbo.Persona AS Pe ON R.Id_Cliente = Pe.Id_Persona INNER JOIN
                         dbo.Planta AS Pl ON R.Origen = Pl.Id INNER JOIN
                         dbo.Planta AS Pla ON R.Destino = Pla.Id

GO
/****** Object:  View [dbo].[Vi_Usuario]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[Vi_Usuario] as
select Persona.Id_Persona,Persona.Nombre+' '+Persona.Apellidos as NombreUsuario
from Persona,Detalle_TipoEntidad,TipoPersona
where Persona.Cod_Ente=Detalle_TipoEntidad.Cod_Ente and Detalle_TipoEntidad.Id_TipoEntidad=TipoPersona.Id_TipoPers and TipoPersona.Id_TipoPers=4
GO
/****** Object:  View [dbo].[View_AsignacionCamiones]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_AsignacionCamiones]
AS
SELECT        dbo.Camiones.Id_Camion, dbo.Camiones.Placa, dbo.Camiones.IdPropietario, dbo.Camiones.IdChofer, dbo.Camiones.IdTitBanco, dbo.AsignacionCamion.Id, dbo.AsignacionCamion.IdCamion, 
                         dbo.AsignacionCamion.IdCliente, dbo.Persona.Id_Persona, dbo.Persona.CI, dbo.Persona.Nombre + ' ' + dbo.Persona.Apellidos AS Cliente, dbo.Persona.Cod_Ente, dbo.Camiones.Estado
FROM            dbo.Camiones INNER JOIN
                         dbo.AsignacionCamion ON dbo.Camiones.Id_Camion = dbo.AsignacionCamion.IdCamion INNER JOIN
                         dbo.Persona ON dbo.AsignacionCamion.IdCliente = dbo.Persona.Id_Persona

GO
/****** Object:  View [dbo].[View_AsignacionRuta]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_AsignacionRuta]
AS
SELECT        Pe.Nombre + ' ' + Pe.Apellidos AS CLIENTE, Re.Id_Recepcion, Re.F_Reg
FROM            dbo.Persona AS Pe INNER JOIN
                         dbo.Recepcion AS Re ON Pe.Cod_Ente = Re.Cod_Ente

GO
/****** Object:  View [dbo].[View_Camiones]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_Camiones]
AS
SELECT        C.Id_Camion, C.Placa, C.Emplaque, C.Capacidad, C.Ubicacion, C.OBS, C.Estado, E.Desccripcion, C.Fecha_Registro, C.Id_Marca, M.Descripcion, C.Id_Color, Co.Descripcion AS Color, C.IdPropietario, 
                         Pe.Nombre + ' ' + Pe.Apellidos AS Propietario, C.IdChofer, P.Nombre + ' ' + P.Apellidos AS Chofer, C.IdTitBanco, Pet.Nombre + ' ' + Pet.Apellidos AS titular, C.Id_Soat, C.Id_InspeccionTecnica, C.Id_Rastreo, 
                         C.Est
FROM            dbo.Camiones AS C INNER JOIN
                         dbo.Color AS Co ON C.Id_Color = Co.Id_Color INNER JOIN
                         dbo.Marca AS M ON C.Id_Marca = M.Id_Marca LEFT OUTER JOIN
                         dbo.Persona AS P ON C.IdChofer = P.CI LEFT OUTER JOIN
                         dbo.Persona AS Pe ON C.IdPropietario = Pe.CI LEFT OUTER JOIN
                         dbo.Persona AS Pet ON C.IdTitBanco = Pet.CI INNER JOIN
                         dbo.Estado AS E ON C.Estado = E.Id

GO
/****** Object:  View [dbo].[View_Chofer]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_Chofer]
AS
SELECT dbo.Persona.CI, dbo.Persona.Nombre + ' ' + dbo.Persona.Apellidos AS CLIENTE, dbo.Persona.Estado
FROM     dbo.Persona INNER JOIN
                  dbo.Detalle_TipoEntidad ON dbo.Persona.Cod_Ente = dbo.Detalle_TipoEntidad.Cod_Ente INNER JOIN
                  dbo.TipoPersona ON dbo.Detalle_TipoEntidad.Id_TipoEntidad = dbo.TipoPersona.Id_TipoPers
WHERE  (dbo.TipoPersona.Id_TipoPers = 2)

GO
/****** Object:  View [dbo].[View_Color]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_Color]
AS
SELECT        Id_Color, Descripcion
FROM            dbo.Color

GO
/****** Object:  View [dbo].[View_Marca]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[View_Marca]
AS
SELECT        Id_Marca, Descripcion
FROM            dbo.Marca

GO
/****** Object:  View [dbo].[View_Propietario]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_Propietario]
AS
SELECT dbo.Persona.CI, dbo.Persona.Nombre + ' ' + dbo.Persona.Apellidos AS CLIENTE, dbo.Persona.Estado
FROM     dbo.Persona INNER JOIN
                  dbo.Detalle_TipoEntidad ON dbo.Persona.Cod_Ente = dbo.Detalle_TipoEntidad.Cod_Ente INNER JOIN
                  dbo.TipoPersona ON dbo.Detalle_TipoEntidad.Id_TipoEntidad = dbo.TipoPersona.Id_TipoPers
WHERE  (dbo.TipoPersona.Id_TipoPers = 1)

GO
/****** Object:  View [dbo].[View_Titular]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_Titular]
AS
SELECT dbo.Persona.CI, dbo.Persona.Nombre + ' ' + dbo.Persona.Apellidos AS CLIENTE, dbo.Persona.Estado
FROM     dbo.Persona INNER JOIN
                  dbo.Detalle_TipoEntidad ON dbo.Persona.Cod_Ente = dbo.Detalle_TipoEntidad.Cod_Ente INNER JOIN
                  dbo.TipoPersona ON dbo.Detalle_TipoEntidad.Id_TipoEntidad = dbo.TipoPersona.Id_TipoPers
WHERE  (dbo.TipoPersona.Id_TipoPers = 3)

GO
/****** Object:  View [dbo].[ViewTitularCuenta]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ViewTitularCuenta]
AS
SELECT        P.Id_Persona, P.CI, TB.Id_Persona AS ID, TB.Id_Cuenta, C.NroCuenta, C.Id_Banco
FROM            dbo.TitularBanco AS TB INNER JOIN
                         dbo.Persona AS P ON TB.Id_Persona = P.Id_Persona INNER JOIN
                         dbo.Cuenta AS C ON TB.Id_Cuenta = C.Id_Cuenta

GO
ALTER TABLE [dbo].[Entes]  WITH CHECK ADD  CONSTRAINT [FK__Entes__Id_Tipo__15502E78] FOREIGN KEY([Id_Tipo])
REFERENCES [dbo].[Tipo_Ente] ([Id_Tipo])
GO
ALTER TABLE [dbo].[Entes] CHECK CONSTRAINT [FK__Entes__Id_Tipo__15502E78]
GO
/****** Object:  StoredProcedure [dbo].[BuscarCamion]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BuscarCamion]
	-- Add the parameters for the stored procedure here
	@Placa varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from vi_Camion where Placa=@Placa
END


GO
/****** Object:  StoredProcedure [dbo].[BuscarChofer]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BuscarChofer]
	-- Add the parameters for the stored procedure here
@Cliente varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * From View_Chofer where CLIENTE=@Cliente and Estado=1
END


GO
/****** Object:  StoredProcedure [dbo].[BuscarMarca]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BuscarMarca]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * From ListaMarca 
END


GO
/****** Object:  StoredProcedure [dbo].[BuscarPersona]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BuscarPersona]
	-- Add the parameters for the stored procedure here
	@Cliente varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from vi_BuscarPersona where Personas=@Cliente
END


GO
/****** Object:  StoredProcedure [dbo].[BuscarPlanta]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BuscarPlanta]
	-- Add the parameters for the stored procedure here
	@Planta int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * From Detalle_Planta where IdPlanta=@Planta
END


GO
/****** Object:  StoredProcedure [dbo].[BuscarPorPlaca]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BuscarPorPlaca]
	-- Add the parameters for the stored procedure here
	@Placa varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Estado from Camiones where Placa=@Placa
END


GO
/****** Object:  StoredProcedure [dbo].[BuscarProductos]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BuscarProductos]
	-- Add the parameters for the stored procedure here
	@Producto int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * From Producto,Ruta,Detalle_Ruta Where Ruta.Id_Ruta=@Producto and Detalle_Ruta.IdProducto=Producto.Id_Producto 
	and Detalle_Ruta.IdRuta=Ruta.Id_Ruta
END

GO
/****** Object:  StoredProcedure [dbo].[BuscarPropietario]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BuscarPropietario]
	-- Add the parameters for the stored procedure here
	@Prop varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * From View_Propietario where CLIENTE=@Prop and Estado=1
END


GO
/****** Object:  StoredProcedure [dbo].[BuscarRepetidosEnProgramacion]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BuscarRepetidosEnProgramacion]
	-- Add the parameters for the stored procedure here
	@Placa nvarchar(300),
	@FechaCarga date,
	@IdRuta int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Detalle_Recepcion where Placa_Camion=@Placa and FechaCarga=@FechaCarga and Id_Ruta=@IdRuta
END

GO
/****** Object:  StoredProcedure [dbo].[BuscarRuta]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BuscarRuta]
	-- Add the parameters for the stored procedure here
	@IdRuta int
	As
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * From Vi_Ruta where Id_Ruta=@IdRuta
END


GO
/****** Object:  StoredProcedure [dbo].[BuscarTitular]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[BuscarTitular]
	-- Add the parameters for the stored procedure here
@Cliente varchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * From View_Titular where CLIENTE=@Cliente and Estado=1
END


GO
/****** Object:  StoredProcedure [dbo].[CantidadCamiones]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CantidadCamiones]
	-- Add the parameters for the stored procedure here
	@IdEstado int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Count(*) as Cantidad From View_Camiones Where Estado=@IdEstado
END

GO
/****** Object:  StoredProcedure [dbo].[EstadoChofer]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EstadoChofer]
	-- Add the parameters for the stored procedure here
	@CI varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Estado From Persona where CI =@CI
END

GO
/****** Object:  StoredProcedure [dbo].[IdTitular]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[IdTitular]
	-- Add the parameters for the stored procedure here
	@IdTitular Varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id_Persona from Persona where CI=@IdTitular
END

GO
/****** Object:  StoredProcedure [dbo].[MaximaRecepcion]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MaximaRecepcion]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
select MAX(Id_Recepcion) as Maximo
from Recepcion 
END

GO
/****** Object:  StoredProcedure [dbo].[MaximoDetalle]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[MaximoDetalle]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

select MAX(Id_Detalle) as Maxim
from Detalle_Recepcion 

END

GO
/****** Object:  StoredProcedure [dbo].[ProcAsig]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProcAsig]
	-- Add the parameters for the stored procedure here
-- Add the parameters for the stored procedure here
	@IdCliente int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * From View_AsignacionCamiones where IdCliente=@IdCliente and View_AsignacionCamiones.Estado<>1
END
GO
/****** Object:  StoredProcedure [dbo].[ProcAsigCamion]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProcAsigCamion] 
	-- Add the parameters for the stored procedure here
@IdCamion int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Id_Persona,Cliente From View_AsignacionCamiones where IdCamion=@IdCamion
END
GO
/****** Object:  StoredProcedure [dbo].[ProcBuscarCliente]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProcBuscarCliente]
	-- Add the parameters for the stored procedure here
	@IdPersona int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
Select Id_Ruta, Ruta, MontoAnticipo From Ruta,Persona where Ruta.Id_Cliente=Persona.Id_Persona and Ruta.Id_Cliente=@IdPersona and ruta.Estado=1
order By Ruta.Origen 
END



GO
/****** Object:  StoredProcedure [dbo].[ProcBuscarEstado]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProcBuscarEstado]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Estado
END

GO
/****** Object:  StoredProcedure [dbo].[ProcConsultaCamiones]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProcConsultaCamiones]
	-- Add the parameters for the stored procedure here
	@Id_Camion int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Vi_ListaCamiones where Id_Camion=@Id_Camion
END

GO
/****** Object:  StoredProcedure [dbo].[ProcConsultaCuenta]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProcConsultaCuenta]
	-- Add the parameters for the stored procedure here
	@NroCuenta Bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Vi_ListaCuenta where NroCuenta=@NroCuenta
END

GO
/****** Object:  StoredProcedure [dbo].[ProcConsultaPersonas]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProcConsultaPersonas]
	@Id_Persona int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

 SET NOCOUNT ON;
select * from vi_listaPersonas where Id_Persona=@Id_Persona
END

GO
/****** Object:  StoredProcedure [dbo].[ProcConsultaTipoEntidad]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProcConsultaTipoEntidad]

	-- Add the parameters for the stored procedure here
	@Id_Persona int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Vi_DetalleTipoEntidad where Id_Persona=@Id_Persona 
END

GO
/****** Object:  StoredProcedure [dbo].[ProcEncCliente]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProcEncCliente]
	-- Add the parameters for the stored procedure here
	 @IdPersona int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
Select Id_Ruta, Ruta From Ruta,Persona where 
Ruta.Id_Cliente=Persona.Id_Persona and Ruta.Id_Cliente=@IdPersona Order By Id_Ruta
END

GO
/****** Object:  StoredProcedure [dbo].[ProcFechaAsignacionRuta]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
CREATE PROCEDURE [dbo].[ProcFechaAsignacionRuta]
	-- Add the parameters for the stored procedure here
	@IdMes int,
	@IdAño nvarchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from View_AsignacionRuta where MONTH(F_Reg)=@IdMes and YEAR(F_Reg)=@IdAño 
	order by ClIENTE,Id_Recepcion
END

GO
/****** Object:  StoredProcedure [dbo].[ProcTitCuen]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ProcTitCuen]
	-- Add the parameters for the stored procedure here
	@Ci varchar(250)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from ViewTitularCuenta where CI=@Ci
END

GO
/****** Object:  StoredProcedure [dbo].[ProcUsuarios]    Script Date: 29/11/2024 12:17:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProcUsuarios]
	--@param1 int = 0,
	--@param2 int
	@Usuario VARCHAR(100),
	@Contraseña varchar(100)

AS
	SELECT * --@param1, @param2
	FROM vi_ListaUsuarios
	WHERE Usuario = @Usuario and Contraseña = @Contraseña
RETURN 0

GO
