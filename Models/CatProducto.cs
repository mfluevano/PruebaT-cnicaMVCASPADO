using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTécnicaMVCASPADO.Models;

public class CatProducto
{
    public int Id { get; set; }

    [DisplayName("Nombre el producto")]
    public string? NombreProducto { get; set; }

    [DisplayName("Imagen del producto")]
    public string? ImagenProducto { get; set; }

    [DisplayName("Precio unitario")]
    public decimal PrecioUnitario { get; set; }

    [DisplayName("Extensión")]
    public string? Ext { get; set; }
}
