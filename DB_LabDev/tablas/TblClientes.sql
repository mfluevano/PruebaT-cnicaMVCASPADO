USE [LabDev]
GO

DROP TABLE IF EXISTS [dbo].[TblClientes]
GO

/****** Object:  Table [dbo].[TblClientes]    Script Date: 01/11/2023 05:06:36 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblClientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RazonSocial] [varchar](200) NOT NULL,
	[IdTipoCliente] [int] NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[RFC] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TblClientes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblClientes]  WITH CHECK ADD  CONSTRAINT [FK_TblClientes_CatTipoClietne] FOREIGN KEY([IdTipoCliente])
REFERENCES [dbo].[CatTipoCliente] ([Id])
GO

ALTER TABLE [dbo].[TblClientes] CHECK CONSTRAINT [FK_TblClientes_CatTipoClietne]
GO


