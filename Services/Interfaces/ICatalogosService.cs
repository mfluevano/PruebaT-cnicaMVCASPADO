namespace PruebaTécnicaMVCASPADO.Services.Interfaces;

public interface ICatalogosService<T> where T : class
{
    Task<List<T>> Listar();
   
    Task<bool> Guardar(T modelo);              
    Task<bool> Editar(T modelo);              
    Task<bool> Eliminar(int id);  

}
