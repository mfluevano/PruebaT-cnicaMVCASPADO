using System.ComponentModel;
using PruebaTécnicaMVCASPADO.Models;
using PruebaTécnicaMVCASPADO.Services.Interfaces;
using System.Data;
using System.Data.SqlClient;
using PruebaTécnicaMVCASPADO.Data;
namespace PruebaTécnicaMVCASPADO.Services.Implementaciones;

public class catClientesImplementacion : ICatalogosService<TblClientes>
{
    private readonly string _connectionStr;

    public catClientesImplementacion(IConfiguration configuracion)
    {
        _connectionStr = configuracion.GetConnectionString("conexion")!;;
         
    }

    public async Task<List<TblClientes>> Listar()
    {
        List<TblClientes> _lista = new List<TblClientes>();
        using (SqlConnection con = new(_connectionStr))
        {
            con.Open(); 
            SqlCommand command = new SqlCommand(SpNames._ListarCliente, con);
            command.CommandType = CommandType.StoredProcedure;
            using (var dr = await command.ExecuteReaderAsync())
            {
                while (await dr.ReadAsync())
                {
                    _lista.Add(new TblClientes
                    {
                        Id = (int)dr[0],
                        RazonSocial = dr[1].ToString()!,
                        IdTipoCliente = (int)dr[2],
                        TipoCliente = dr[3].ToString()!,
                        FechaCreacion = (DateTime)dr[4],
                        RFC = dr[5].ToString()!
                    });
                }
            }
        }
        return _lista;
    }

    public async Task<bool> Guardar(TblClientes modelo)
    {
        using (SqlConnection con = new(_connectionStr))
        {
            con.Open();
            SqlCommand command = new SqlCommand(SpNames._CrearCliente, con);
            command.CommandType = CommandType.StoredProcedure;

            // Agregar los parámetros del modelo
            command.Parameters.AddWithValue("@RazonSocial", modelo.RazonSocial);
            command.Parameters.AddWithValue("@IdTipoCliente", modelo.IdTipoCliente);
            command.Parameters.AddWithValue("@RFC", modelo.RFC);

            // Ejecutar el comando y obtener el número de filas afectadas
            int rowsAffected = await command.ExecuteNonQueryAsync();

            // Devolver el resultado
            return rowsAffected > 0;
        }
    }

    public async Task<bool> Editar(TblClientes modelo)
    {
        using (SqlConnection con = new(_connectionStr))
        {
            con.Open();
            SqlCommand command = new SqlCommand(SpNames._EditarCliente, con);
            command.CommandType = CommandType.StoredProcedure;

            // Agregar los parámetros del modelo
            command.Parameters.AddWithValue("@Id", modelo.Id);
            command.Parameters.AddWithValue("@RazonSocial", modelo.RazonSocial);
            command.Parameters.AddWithValue("@IdTipoCliente", modelo.IdTipoCliente);
            command.Parameters.AddWithValue("@RFC", modelo.RFC);

            // Ejecutar el comando y obtener el número de filas afectadas
            int rowsAffected = await command.ExecuteNonQueryAsync();

            // Devolver el resultado
            return rowsAffected > 0;
        }
    }

    public async Task<bool> Eliminar(int id)
    {
        using (SqlConnection con = new(_connectionStr))
        {
            con.Open();
            SqlCommand command = new SqlCommand(SpNames._EliminarCliente, con);
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

