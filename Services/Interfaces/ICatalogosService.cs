using PruebaTécnicaMVCASPADO.Models;

namespace PruebaTécnicaMVCASPADO.Services.Interfaces;

public interface ICatalogosService<T> where T : class
{
    Task<List<T>> Listar();
   
    Task<bool> Guardar(T modelo);              
    Task<bool> Editar(T modelo);              
    Task<bool> Eliminar(int id);
   
}
public interface ICatalogosServiceFac<T> : ICatalogosService<T> where T:class
{
     Task<List<TblFacturas>> BuscarFacturaPorCliente(int idCliente);
    Task<TblFacturas> BuscarFacturaPorNumeroFactura(int numeroFactura);

}
