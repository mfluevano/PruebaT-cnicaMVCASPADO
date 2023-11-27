

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTécnicaMVCASPADO.Models;
public class tblDetallesFactura
{
    [DisplayName("ID de Detalle de Factura")]
    public int Id { get; set; }

    [DisplayName("ID de Factura")]
    public int IdFactura { get; set; }

    [DisplayName("ID de Producto")]
    public int IdProducto { get; set; }

    [DisplayName("Cantidad de Producto")]
    public int CantidadDelProducto { get; set; }

    [DisplayName("Precio Unitario del Producto")]
    [DataType(DataType.Currency)]
    public decimal PrecioUnitarioProducto { get; set; }

    [DisplayName("Subtotal del Producto")]
    [DataType(DataType.Currency)]
    public decimal SubtotalProducto { get; set; }

    [DisplayName("Notas")]
    public string? Notas { get; set; }
}
