use [LabDev]



IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.SP_GenerarFactura'))
BEGIN
    DROP PROCEDURE dbo.SP_GenerarFactura
END
GO

IF EXISTS (SELECT * FROM sys.types WHERE user_type_id= TYPE_ID('dbo.TdetallesFactura'))
BEGIN
    DROP TYPE dbo.TdetallesFactura
END
go

create type  dbo.TdetallesFactura as  TABLE (
    id INT ,
    idFactura INT,
    idProducto INT NOT NULL,
    cantidad INT NOT NULL,
    precioUnitario DECIMAL(18, 2) NOT NULL,
    subtotalProducto DECIMAL(18, 2) NOT NULL,
    notas VARCHAR(200) NULL
    )
	
	go

CREATE PROCEDURE SP_GenerarFactura
    (
    @idCliente INT,
    @numeroFactura INT,
    @fechaEmisionFactura DATETIME,
    @subTotalFactura DECIMAL(18, 2),
    @totalImpuesto DECIMAL(18, 2),
    @totalFactura DECIMAL(18, 2),
    @detallesFactura TdetallesFactura READONLY
)
AS
BEGIN TRANSACTION;

BEGIN TRY


    -- Insertar la factura
    INSERT INTO TblFacturas
    (
    FechaEmisionFactura,
    IdCliente,
    NumeroFactura,
    NumeroTotalArticulos,
    SubTotalFactura,
    TotalImpuesto,
    TotalFactura
    )
VALUES
    (
        @fechaEmisionFactura,
        @idCliente,
        @numeroFactura,
        (SELECT COUNT(*)
        FROM @detallesFactura),
        @subTotalFactura,
        @totalImpuesto,
        @totalFactura
    );

    -- Obtener el ID de la factura
    DECLARE @idFactura INT;

    SELECT @idFactura = SCOPE_IDENTITY();

    -- Insertar los detalles de la factura
    INSERT INTO TblDetallesFactura
    (
    idFactura,
    idProducto,
    CantidadDelProducto,
    PrecioUnitarioProducto,
    SubtotalProducto,
    Notas
    )
SELECT
    @idFactura,
    idProducto,
    cantidad,
    precioUnitario,
    cantidad * precioUnitario,
    ''
FROM
    @detallesFactura;

    COMMIT TRANSACTION;

END TRY
BEGIN CATCH

    ROLLBACK TRANSACTION;

    THROW;

END CATCH;

