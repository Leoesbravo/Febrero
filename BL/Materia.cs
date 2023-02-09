using System;
using System.Collections.Generic;
using System.Data;
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

                        if (rowsAffected > 0)
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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    var query = "SELECT IdMateria, Nombre, Creditos, Costo FROM Materia";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        //Crear tabla virtual
                        DataTable tableMateria = new DataTable();

                        //Permite leer la información de la consulta
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        //llenar la tabla virtual
                        adapter.Fill(tableMateria);
                        
                        if(tableMateria.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableMateria.Rows)
                            {
                                ML.Materia materia = new ML.Materia();

                                materia.IdMateria = int.Parse(row[0].ToString());
                                materia.Nombre = row[1].ToString();
                                materia.Creditos = byte.Parse(row[2].ToString());
                                materia.Costo = decimal.Parse(row[3].ToString());

                                result.Objects.Add(materia);
                            }

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct= false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetById()
        {

        }
    }
}
