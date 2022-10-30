SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [varchar](200) NOT NULL,
	[NroDNI] [varchar](8) NOT NULL,
	[CorreoElectronico] [varchar](200) NOT NULL,
	[NroCelular] [varchar](9) NOT NULL,
	[DireccionActiva] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO