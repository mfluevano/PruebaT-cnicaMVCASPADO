USE [LabDev]
GO


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.SP_BuscarFacturaPorNumeroFactura'))
BEGIN

  DROP PROCEDURE dbo.SP_BuscarFacturaPorNumeroFactura

END
GO

CREATE PROCEDURE SP_BuscarFacturaPorNumeroFactura
(
    @numeroFactura INT
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
    WHERE f.NumeroFactura = @numeroFactura
    ORDER BY f.FechaEmisionFactura DESC;
END
