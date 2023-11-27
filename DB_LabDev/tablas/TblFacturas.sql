USE [LabDev]
GO
DROP TABLE IF EXISTS [dbo].[TblFacturas]					
GO

/****** Object:  Table [dbo].[TblFacturas]    Script Date: 01/11/2023 06:52:01 p. m. ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblFacturas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FechaEmisionFactura] [datetime] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[NumeroFactura] [int] NOT NULL,
	[NumeroTotalArticulos] [int] NOT NULL,
	[SubTotalFactura] [decimal](18, 2) NOT NULL,
	[TotalImpuesto] [decimal](18, 2) NOT NULL,
	[TotalFactura] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_TblFacturas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblFacturas]  WITH CHECK ADD  CONSTRAINT [FK_TblFacturas_TblClientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[TblClientes] ([id])
GO

ALTER TABLE [dbo].[TblFacturas] CHECK CONSTRAINT [FK_TblFacturas_TblClientes]
GO


