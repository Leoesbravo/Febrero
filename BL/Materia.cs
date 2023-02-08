using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia 
    {
        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result(); //instancia

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "INSERT INTO Materia (Nombre, Creditos, Costo) VALUES (@Nombre, @Creditos, @Costo)";

                    //ejecutar una sentencia, necesita una conexion 
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        //asignar la conexion al command
                        cmd.Connection = context;
                        //asignamos la sentencia
                        cmd.CommandText = query;

                        SqlParameter[] parameters = new SqlParameter[3];

                        parameters[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                        parameters[0].Value = materia.Nombre;

                        parameters[1] = new SqlParameter("@Creditos", System.Data.SqlDbType.TinyInt);
                        parameters[1].Value = materia.Creditos;

                        parameters[2] = new SqlParameter("@Costo", System.Data.SqlDbType.Decimal);
                        parameters[2].Value = materia.Costo;

                        //asignarle los parametros al command
                        cmd.Parameters.AddRange(parameters);
                        cmd.Connection.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if(rowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
                result.Correct = false;
            }
            return result;
        }
    }
}
