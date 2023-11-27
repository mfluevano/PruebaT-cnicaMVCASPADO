using System.ComponentModel;
using PruebaTécnicaMVCASPADO.Models;
using PruebaTécnicaMVCASPADO.Services.Interfaces;
using System.Data;
using System.Data.SqlClient;
using PruebaTécnicaMVCASPADO.Data;

namespace PruebaTécnicaMVCASPADO.Services.Implementaciones;

public class catProductosImplementacion : ICatalogosService<CatProducto>
{
    private readonly string _conexionStr;

    public catProductosImplementacion(IConfiguration configuracion)
    {
        _conexionStr = configuracion.GetConnectionString("conexion")!;
    }

    async Task<List<CatProducto>> ICatalogosService<CatProducto>.Listar()
    {
        List<CatProducto> _lista = new List<CatProducto>();
        using (SqlConnection con = new(_conexionStr))
        {
            con.Open();
            SqlCommand command = new SqlCommand(SpNames._ListarProductos, con);
            command.CommandType = CommandType.StoredProcedure;
            using (var dr = await command.ExecuteReaderAsync())
            {
                while (await dr.ReadAsync())
                {
                    _lista.Add(
                        new CatProducto
                        {
                            Id = (int)dr[0],
                            NombreProducto = dr[1].ToString()!,
                            ImagenProducto = dr[2].ToString()!,
                            PrecioUnitario = Convert.ToDecimal(dr[3]),
                            Ext = dr[4].ToString()!
                        }
                    );
                }
            }
        }
        return _lista;
    }

  
    public async Task<bool> Guardar(CatProducto modelo)
    {
        using (SqlConnection con = new(_conexionStr))
        {
            con.Open();
            SqlCommand command = new SqlCommand(SpNames._CrearProducto, con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@NombreProducto", modelo.NombreProducto);
            command.Parameters.AddWithValue("@ImagenProducto", modelo.ImagenProducto);
            command.Parameters.AddWithValue("@PrecioUnitario", modelo.PrecioUnitario);
            command.Parameters.AddWithValue("@Ext", modelo.Ext);

            int rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
    }

    public async Task<bool> Editar(CatProducto modelo)
    {
        using (SqlConnection con = new(_conexionStr))
        {
            con.Open();
            SqlCommand command = new SqlCommand(SpNames._EditarProducto, con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", modelo.Id);
            command.Parameters.AddWithValue("@NombreProducto", modelo.NombreProducto);
            command.Parameters.AddWithValue("@ImagenProducto", modelo.ImagenProducto);
            command.Parameters.AddWithValue("@PrecioUnitario", modelo.PrecioUnitario);
            command.Parameters.AddWithValue("@Ext", modelo.Ext);

            int rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        }
    }

    public async Task<bool> Eliminar(int id)
    {
        using (SqlConnection con = new(_conexionStr))
        {
            con.Open();
            SqlCommand command = new SqlCommand(SpNames._EliminarProducto, con);
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
