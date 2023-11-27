USE [LabDev]
GO


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.SP_EditarTipoCliente'))
BEGIN


  DROP PROCEDURE dbo.SP_EditarTipoCliente		

END 
go
CREATE PROCEDURE [dbo].[SP_EditarTipoCliente]
@Id int,
@TipoCliente varchar(50)
AS
BEGIN

UPDATE [dbo].[CatTipoCliente]
SET
  [TipoCliente] = @TipoCliente
WHERE [Id] = @Id

END
GO
