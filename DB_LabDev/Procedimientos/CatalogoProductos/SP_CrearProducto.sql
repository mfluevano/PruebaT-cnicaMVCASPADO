USE [LabDev]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.SP_CrearProducto'))
BEGIN

  DROP PROCEDURE  [dbo].[SP_CrearProducto]

END
GO
	
CREATE PROCEDURE [dbo].[SP_CrearProducto]
@NombreProducto varchar(50),
@ImagenProducto varchar(MAX),
@PrecioUnitario decimal(18, 2),
@ext varchar(5)
AS
BEGIN

INSERT INTO [dbo].[CatProductos]
(
  [NombreProducto],
  [ImagenProducto],
  [PrecioUnitario],
  [ext]
)
VALUES
(
  @NombreProducto,
  @ImagenProducto,
  @PrecioUnitario,
  @ext
)

END
GO
---