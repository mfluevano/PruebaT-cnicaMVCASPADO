USE [LabDev]
GO


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.SP_CrearTipoCliente'))
BEGIN

  DROP PROCEDURE dbo.SP_CrearTipoCliente

END
GO

CREATE PROCEDURE [dbo].[SP_CrearTipoCliente]
@TipoCliente varchar(50)
AS
BEGIN

INSERT INTO [dbo].[CatTipoCliente]
(
  [TipoCliente]
)
VALUES
(
  @TipoCliente
)

END
GO
