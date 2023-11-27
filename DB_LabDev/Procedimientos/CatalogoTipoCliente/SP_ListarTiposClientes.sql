USE [LabDev]
GO


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.SP_ListarTiposClientes'))
BEGIN

  DROP PROCEDURE dbo.SP_ListarTiposClientes

END
GO

CREATE PROCEDURE [dbo].[SP_ListarTiposClientes]
AS
BEGIN

SELECT
  [Id],
  [TipoCliente]
FROM [dbo].[CatTipoCliente]

END
GO
