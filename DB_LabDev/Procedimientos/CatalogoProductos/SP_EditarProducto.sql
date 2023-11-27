	USE [LabDev]
GO



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.SP_EditarProducto'))
BEGIN

  DROP PROCEDURE dbo.SP_EditarProducto	

END
go
CREATE PROCEDURE [dbo].[SP_EditarProducto]
@Id int,
@NombreProducto varchar(50),
@ImagenProducto varchar(MAX),
@PrecioUnitario decimal(18, 2),
@ext varchar(5)
AS
BEGIN

UPDATE [dbo].[CatProductos]
SET
  [NombreProducto] = @NombreProducto,
  [ImagenProducto] = @ImagenProducto,
  [PrecioUnitario] = @PrecioUnitario,
  [ext] = @ext
WHERE [Id] = @Id

END
GO
