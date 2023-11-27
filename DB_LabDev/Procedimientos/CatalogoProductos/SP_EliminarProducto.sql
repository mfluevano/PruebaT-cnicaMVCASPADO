USE [LabDev]
GO


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.SP_EliminarProducto'))
BEGIN

  DROP PROCEDURE dbo.SP_EliminarProducto

END
GO

CREATE PROCEDURE [dbo].[SP_EliminarProducto]
@Id int
AS
BEGIN

DELETE FROM [dbo].[CatProductos]
WHERE [Id] = @Id

END
GO
