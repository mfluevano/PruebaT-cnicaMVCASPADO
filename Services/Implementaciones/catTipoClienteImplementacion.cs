using System.ComponentModel;
using PruebaTécnicaMVCASPADO.Models;
using PruebaTécnicaMVCASPADO.Services.Interfaces;
using System.Data;
using System.Data.SqlClient;
using PruebaTécnicaMVCASPADO.Data;

namespace PruebaTécnicaMVCASPADO.Services.Implementaciones;

public class catTipoClienteImplementacion : ICatalogosService<CatTipoCliente>
{
    private readonly string _conexionStr;

    public catTipoClienteImplementacion(IConfiguration configuracion)
    {
        _conexionStr = configuracion.GetConnectionString("conexion")!;
    }

    public async Task<List<CatTipoCliente>> Listar()
    {
        List<CatTipoCliente> _lista = new List<CatTipoCliente>();
        using (SqlConnection con = new(_conexionStr))
        {
            con.Open();
            SqlCommand command = new SqlCommand(SpNames._ListarTiposClientes, con);
            command.CommandType = CommandType.StoredProcedure;
            using (var dr = await command.ExecuteReaderAsync())
            {
                while (await dr.ReadAsync())
                {
                    _lista.Add(
                        new CatTipoCliente
                        {
                            Id = (int)dr["Id"],
                            TipoCliente = dr["TipoCliente"].ToString()!
                        }
                    );
                }
            }
        }
        return _lista;
    }

    
    public async Task<bool> Guardar(CatTipoCliente modelo)
    {
        using (SqlConnection con = new(_conexionStr))
        {
            con.Open();
            SqlCommand command = new SqlCommand(SpNames._CrearTipoCliente, con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@TipoCliente", modelo.TipoCliente);

            int rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
    }

    public async Task<bool> Editar(CatTipoCliente modelo)
    {
        using (SqlConnection con = new(_conexionStr))
        {
            con.Open();
            SqlCommand command = new SqlCommand(SpNames._EditarTipoCliente, con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", modelo.Id);
            command.Parameters.AddWithValue("@TipoCliente", modelo.TipoCliente);

            int rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
    }

    public async Task<bool> Eliminar(int id)
    {
        using (SqlConnection con = new(_conexionStr))
        {
            con.Open();
            SqlCommand command = new SqlCommand(SpNames._EliminarTipoCliente, con);
            command.CommandType = CommandType.StoredProcedure;

            // Agregar el parámetro @Id
            command.Parameters.AddWithValue("@Id", id);

            // Ejecutar el comando
            int rowsAffected = await command.ExecuteNonQueryAsync();

            // Devolver el resultado
            return rowsAffected > 0;
        }
    }
}
