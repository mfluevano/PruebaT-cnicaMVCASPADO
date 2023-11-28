// Nota: Se implementó la clase `tblFacturacionImplementacion`

using System.ComponentModel;
using PruebaTécnicaMVCASPADO.Models;
using PruebaTécnicaMVCASPADO.Services.Interfaces;
using System.Data;
using System.Data.SqlClient;
using PruebaTécnicaMVCASPADO.Data;

namespace PruebaTécnicaMVCASPADO.Services.Implementaciones
{
    public class tblFacturacionImplementacion : ICatalogosService<TblFacturas>
    {
        private readonly string _conexionStr;

        public tblFacturacionImplementacion(IConfiguration configuracion)
        {
            _conexionStr = configuracion.GetConnectionString("conexion")!;
        }

        public async Task<bool> Editar(TblFacturas modelo)
        {
            // No implementado
            throw new NotImplementedException();
        }

        public async Task<bool> Eliminar(int id)
        {
            // No implementado
            throw new NotImplementedException();
        }

        public async Task<bool> Guardar(TblFacturas modelo)
        {
            using (SqlConnection con = new(_conexionStr))
            {
                con.Open();
                SqlCommand command = new SqlCommand(SpNames._CrearFactura, con);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@idCliente", modelo.IdCliente);
                command.Parameters.AddWithValue("@numeroFactura", modelo.NumeroFactura);
                command.Parameters.AddWithValue("@fechaEmisionFactura",Convert.ToDateTime(modelo.FechaEmisionFactura));
                command.Parameters.AddWithValue("@subTotalFactura", modelo.TotalFactura);
                command.Parameters.AddWithValue("@totalImpuesto", modelo.TotalFactura);
                command.Parameters.AddWithValue("@totalFactura", modelo.TotalFactura);
                DataTable detalle = ConvertToDataTable(modelo.DetalleFactura);
                command.Parameters.AddWithValue("@detallesFactura", detalle);
                int rowsAffected = await command.ExecuteNonQueryAsync();
                return rowsAffected > 0;
            }
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(
                    prop.Name,
                    Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType
                );
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public async Task<List<TblFacturas>> Listar()
        {
            List<TblFacturas> _lista = new List<TblFacturas>();

            using (SqlConnection con = new(_conexionStr))
            {
                con.Open();
                SqlCommand command = new SqlCommand(SpNames._ListarFacturas, con);
                command.CommandType = CommandType.StoredProcedure;

                using (var dr = await command.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        _lista.Add(
                            new TblFacturas
                            {
                                Id = (int)dr[0],
                                FechaEmisionFactura = dr[1].ToString()!,
                                IdCliente = (int)dr[2],
                                NumeroFactura = (int)dr[3],
                                NumeroTotalArticulos = (int)dr[4],
                                SubTotalFactura = (decimal)dr[5],
                                TotalImpuesto = (decimal)dr[6],
                                TotalFactura = (decimal)dr[7]
                            }
                        );
                    }
                }
            }

            return _lista;
        }
    }
}
