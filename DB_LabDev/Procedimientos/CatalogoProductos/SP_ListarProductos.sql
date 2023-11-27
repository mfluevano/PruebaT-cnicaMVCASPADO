USE [LabDev]
GO



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.SP_ListarProductos'))
BEGIN

  DROP PROCEDURE dbo.SP_ListarProductos

END
GO

CREATE PROCEDURE [dbo].[SP_ListarProductos]
AS
BEGIN

SELECT
  [Id],
  [NombreProducto],
  [ImagenProducto],
  [PrecioUnitario],
  [ext]
FROM [dbo].[CatProductos]

END
GO
