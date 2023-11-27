USE [LabDev]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.SP_EliminarCliente'))
BEGIN

DROP PROCEDURE dbo.SP_EliminarCliente

END
GO
CREATE PROCEDURE [dbo].[SP_EliminarCliente]
	@Id INT
AS
BEGIN
BEGIN TRY
	BEGIN TRAN



		DELETE FROM [dbo].[TblClientes] WHERE Id = @Id

		COMMIT TRAN
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(MAX) = ERROR_MESSAGE()

	IF @ErrorMessage LIKE '%REFERENCE constraint%'
	BEGIN
		ROLLBACK TRAN
		RAISERROR('No se puede eliminar el cliente porque existen registros dependientes.', 16, 1)
	END
	ELSE
	BEGIN
		ROLLBACK TRAN
		RAISERROR(@ErrorMessage, 16, 1)
	END
END CATCH
END
