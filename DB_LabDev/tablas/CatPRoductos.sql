	USE [LabDev]
	GO

	DROP TABLE IF EXISTS [dbo].[CatProductos]
	GO

	/****** Object:  Table [dbo].[CatProductos]  Created by: Mario Luevano ******/
	SET ANSI_NULLS ON
	GO

	SET QUOTED_IDENTIFIER ON
	GO

	CREATE TABLE [dbo].[CatProductos](
			[id] [int] IDENTITY(1,1) NOT NULL,
			[NombreProducto] [varchar](50) NOT NULL,
			[ImagenProducto] [varchar](MAX) NOT NULL,
			[PrecioUnitario] [decimal](18, 2) NOT NULL,
			[ext] [varchar](5) NOT NULL,
	 CONSTRAINT [PK_CatProductos] PRIMARY KEY CLUSTERED 
	(
		[id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	GO


