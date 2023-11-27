using PruebaTécnicaMVCASPADO.Models;
public class TblClientes
{
    public int Id { get; set; }
    public required string RazonSocial { get; set; }
    public int IdTipoCliente { get; set; }
    public String? TipoCliente { get; set; }
    public DateTime FechaCreacion { get; set; }
    public required string RFC { get; set; }

}
