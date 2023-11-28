USE [LabDev]
GO


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.SP_BuscarFacturaPorCliente'))
BEGIN

  DROP PROCEDURE dbo.SP_BuscarFacturaPorCliente

END
GO


CREATE PROCEDURE SP_BuscarFacturaPorCliente
(
    @idCliente INT
)
AS
BEGIN
    SELECT
        f.Id,
        f.FechaEmisionFactura,
        f.IdCliente,
        f.NumeroFactura,
        f.NumeroTotalArticulos,
        f.SubTotalFactura,
        f.TotalImpuesto,
        f.TotalFactura
    FROM TblFacturas f
    WHERE f.IdCliente = @idCliente
    ORDER BY f.FechaEmisionFactura DESC;
END
