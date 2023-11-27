USE [LabDev]
GO


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.SP_ListarCliente'))
BEGIN

  DROP PROCEDURE dbo.SP_ListarCliente

END
GO

CREATE PROCEDURE [dbo].[SP_ListarCliente]
AS
BEGIN

SELECT 
	[CLI].[id],
	[RazonSocial],
	[IdTipoCliente],
	[TCLI].[TipoCliente],
	[FechaCreacion],
	[RFC]
FROM
	[dbo].[TblClientes] AS CLI
INNER JOIN
	[dbo].CatTipoCliente AS TCLI
ON CLI.IdTipoCliente = TCLI.Id
END
GO
