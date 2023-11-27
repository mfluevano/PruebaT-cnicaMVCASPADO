using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTécnicaMVCASPADO.Models;

public class TblFacturas
{

    [DisplayName("ID de Factura")]
    public int Id { get; set; }

    [DisplayName("Fecha de Emisión")]
    public string? FechaEmisionFactura { get; set; }

    [DisplayName("ID de Cliente")]
    public int IdCliente { get; set; }

    [DisplayName("Número de Factura")]
    public int NumeroFactura { get; set; }

    [DisplayName("Número Total de Artículos")]
    public int NumeroTotalArticulos { get; set; }

    [DisplayName("Subtotal de Factura")]
    public decimal SubTotalFactura { get; set; }

    [DisplayName("Total de Impuestos")]
    [DataType(DataType.Currency)]
    public decimal TotalImpuesto { get; set; }

    [DisplayName("Total de Factura")]
    public decimal TotalFactura { get; set; }
    public List<tblDetallesFactura> DetalleFactura { get; set; } = new  List<tblDetallesFactura>();

}

