USE [LabDev]
GO

DROP TABLE IF EXISTS [dbo].[TblDetallesFactura]
GO

/****** Object:  Table [dbo].[TblDetallesFactura]   Created By: Mario Luevano ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblDetallesFactura](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idFactura] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[CantidadDelProducto] [int] NOT NULL,
	[PrecioUnitarioProducto] [decimal](18, 2) NOT NULL,
	[SubtotalProducto] [decimal](18, 2) NOT NULL,
	[Notas] [varchar](200) NOT NULL,
 CONSTRAINT [PK_TblDetallesFactura] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblDetallesFactura]  WITH CHECK ADD  CONSTRAINT [FK_TblDetallesFactura_CatProductos] FOREIGN KEY([idProducto])
REFERENCES [dbo].[CatProductos] ([id])
GO

ALTER TABLE [dbo].[TblDetallesFactura] CHECK CONSTRAINT [FK_TblDetallesFactura_CatProductos]
GO

ALTER TABLE [dbo].[TblDetallesFactura]  WITH CHECK ADD  CONSTRAINT [FK_TblDetallesFactura_TblFacturas] FOREIGN KEY([idFactura])
REFERENCES [dbo].[TblFacturas] ([id])
GO

ALTER TABLE [dbo].[TblDetallesFactura] CHECK CONSTRAINT [FK_TblDetallesFactura_TblFacturas]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'llave foranea hacia el catalogo de productos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TblDetallesFactura', @level2type=N'CONSTRAINT',@level2name=N'FK_TblDetallesFactura_CatProductos'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'llave foranea de  facturas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TblDetallesFactura', @level2type=N'CONSTRAINT',@level2name=N'FK_TblDetallesFactura_TblFacturas'
GO


