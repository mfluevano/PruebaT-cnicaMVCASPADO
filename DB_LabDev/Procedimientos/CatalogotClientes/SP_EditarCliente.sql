USE [LabDev]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.SP_EditarCliente'))
BEGIN

DROP PROCEDURE dbo.SP_EditarCliente

END
GO
CREATE PROCEDURE [dbo].[SP_EditarCliente]
	@Id INT,
	@RazonSocial VARCHAR(255),
	@IdTipoCliente INT,
	@RFC VARCHAR(50)
AS
BEGIN
BEGIN TRY
	BEGIN TRAN
		UPDATE [dbo].[TblClientes]
			SET RazonSocial = @RazonSocial,
			IdTipoCliente = @IdTipoCliente,
			RFC = @RFC
			WHERE Id = @Id

		COMMIT TRAN
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE()

	IF @ErrorMessage LIKE '%REFERENCE constraint%'
	BEGIN
		ROLLBACK TRAN
		RAISERROR('El tipo de cliente especificado no existe.', 16, 1)
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RAISERROR(@ErrorMessage, 16, 1)
	END
END CATCH
END
