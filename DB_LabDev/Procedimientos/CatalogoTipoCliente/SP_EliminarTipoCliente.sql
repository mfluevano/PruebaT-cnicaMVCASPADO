USE [LabDev]
GO


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.SP_EliminarTipoCliente'))
BEGIN

  DROP PROCEDURE dbo.SP_EliminarTipoCliente

END
GO

CREATE PROCEDURE [dbo].[SP_EliminarTipoCliente]
@Id int
AS
BEGIN

DELETE FROM [dbo].[CatTipoCliente]
WHERE [Id] = @Id

END
GO
