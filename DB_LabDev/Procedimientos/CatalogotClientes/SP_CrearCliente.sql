USE [LabDev]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.SP_CrearCliente'))
BEGIN

  DROP PROCEDURE dbo.SP_CrearCliente

END
GO
CREATE PROCEDURE [dbo].[SP_CrearCliente]
	@RazonSocial VARCHAR(255),
	@IdTipoCliente INT,
	@RFC VARCHAR(50)
AS
BEGIN
BEGIN TRY
	BEGIN TRAN
		INSERT INTO [dbo].[TblClientes] (RazonSocial, IdTipoCliente, RFC, FechaCreacion)
		VALUES (@RazonSocial, @IdTipoCliente,@RFC, CONVERT(DATE,GETDATE()))

		SELECT SCOPE_IDENTITY() AS IdCliente

	COMMIT TRAN
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE()

	IF @ErrorMessage LIKE '%REFERENCE constraint%'
	BEGIN
		ROLLBACK TRAN
		RAISERROR('El tipo de cliente eSPecificado no existe.', 16, 1)
	END 
	ELSE
	BEGIN
		ROLLBACK TRAN
		RAISERROR(@ErrorMessage, 16, 1)
	END
END CATCH
END



select CONVERT(DATE, GETDATE())