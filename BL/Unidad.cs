using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Unidad
    {
        public static bool Add(ML.UnidadEntrega unidad)
        {
            bool result = false;
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "AddUnidad";

                    SqlCommand cmd = new SqlCommand(query, context);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] parms = new SqlParameter[5];

                    parms[0] = new SqlParameter("@placa", SqlDbType.VarChar);
                    parms[0].Value = unidad.NumeroPlaca;

                    parms[1] = new SqlParameter("@modelo", SqlDbType.VarChar);
                    parms[1].Value = unidad.Modelo;

                    parms[2] = new SqlParameter("@marca",SqlDbType.VarChar);
                    parms[2].Value = unidad.Marca;

                    parms[3] = new SqlParameter("@Fabricacion", SqlDbType.VarChar);
                    parms[3].Value = unidad.Fabricacion;

                    parms[4] = new SqlParameter("@idEstatus", SqlDbType.Int);
                    parms[4].Value = unidad.Estatus.IdEstatusUnidad;

                    cmd.Parameters.AddRange(parms);
                    cmd.Connection.Open();

                    int filasAffectadas = cmd.ExecuteNonQuery();

                    if(filasAffectadas > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool Delete(int idUnidad)
        {
            bool result = false;
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "DeleteUnidad";

                    SqlCommand cmd = new SqlCommand(query,context);

                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    SqlParameter[] parameter = new SqlParameter[1];

                    parameter[0] = new SqlParameter("@idUnidad", SqlDbType.Int);
                    parameter[0].Value = idUnidad;

                    cmd.Parameters.AddRange(parameter);
                    cmd.Connection.Open();

                    int filasAffectadas = cmd.ExecuteNonQuery();

                    if (filasAffectadas > 0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool Update(ML.UnidadEntrega unidad)
        {
            bool result = false;
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "UpdateUnidad";

                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = context;
                    cmd.CommandText = query;

                    SqlParameter[] collection = new SqlParameter[6];

                    collection[0] = new SqlParameter("@idunidad",SqlDbType.Int);
                    collection[0].Value = unidad.IdUnidad;

                    collection[1] = new SqlParameter("@placa", SqlDbType.VarChar);
                    collection[1].Value = unidad.NumeroPlaca;
                    collection[2] = new SqlParameter("@modelo", SqlDbType.VarChar);
                    collection[2].Value = unidad.Modelo;
                    collection[3] = new SqlParameter("@marca", SqlDbType.VarChar);
                    collection[3].Value = unidad.Marca;
                    collection[4] = new SqlParameter("@Fabricacion", SqlDbType.VarChar);
                    collection[4].Value = unidad.Fabricacion;
                    collection[5] = new SqlParameter("@idEstatus", SqlDbType.Int);
                    collection[5].Value = unidad.Estatus.IdEstatusUnidad;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if(filasAfectadas > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch 
            {
                result = false;
            }
            return result;
        }

        public static List<object> GetAll()
        {
            var result = new List<object>();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "GetAllUnidad";
                    
                    SqlCommand cmd = new SqlCommand(query, context);
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    
                    DataTable TableUnidad = new DataTable();
                    
                    adapter.Fill(TableUnidad);

                    if (TableUnidad.Rows.Count > 0)
                    {
                        foreach (DataRow row in TableUnidad.Rows)
                        {
                            ML.UnidadEntrega entrega = new ML.UnidadEntrega();
                            entrega.IdUnidad = int.Parse(row[0].ToString());
                            entrega.NumeroPlaca = row[1].ToString();
                            entrega.Modelo = row[2].ToString();
                            entrega.Marca = row[3].ToString();
                            entrega.Fabricacion = row[4].ToString();
                            entrega.Estatus = new ML.EstatusUnidad();
                            entrega.Estatus.IdEstatusUnidad = int.Parse(row[5].ToString());
                            entrega.Estatus.Estatus = row[6].ToString();

                            result.Add(entrega);
                        }
                    }
                }
            }
            catch
            {
                result = null;
            }
            return result;
        }

        public static ML.UnidadEntrega GetById(int idUnidad)
        {
            ML.UnidadEntrega unidad = new ML.UnidadEntrega();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "GetByIdUnidad";

                    SqlCommand cmd = new SqlCommand(query, context);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] param = new SqlParameter[1];

                    param[0] = new SqlParameter("@idUnidad",SqlDbType.Int);
                    param[0].Value = idUnidad;

                    cmd.Parameters.AddRange(param);
                    cmd.Connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                    DataTable tableUnidades = new DataTable();

                    adapter.Fill(tableUnidades);

                    if (tableUnidades.Rows.Count > 0 )
                    {
                        DataRow row = tableUnidades.Rows[0];

                        unidad.NumeroPlaca = row[0].ToString();
                        unidad.Modelo = row[1].ToString();
                        unidad.Marca = row[2].ToString();
                        unidad.Fabricacion = row[3].ToString();
                        unidad.Estatus.IdEstatusUnidad =int.Parse (row[4].ToString());
                        unidad.Estatus.Estatus = row[5].ToString();
                    }
                }
            }
            catch
            {

            }
            return unidad;
        }

        public static List<object> GetAllUnidadesAsignadas()
        {
            var result = new List<object>();

            try
            {
                using (DL.JGarciaTrakingAndTraceEntities context = new DL.JGarciaTrakingAndTraceEntities())
                {
                    var query = context.GetAllUnidadAsignada().ToList();

                    if(query != null)
                    {
                        foreach (var item in query)
                        {
                            ML.UnidadEntrega unidad = new ML.UnidadEntrega();
                            unidad.IdUnidad = item.IdUnidad;
                            unidad.NumeroPlaca = item.NumeroPlaca;

                            result.Add(unidad);
                        }
                    }
                }
            }
            catch
            {
                result = null;
            }
            return result;

        }
    }
}
