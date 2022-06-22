using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Examen_Escuela.Classes
{
    public class SQL
    {

        public static DataTable returnedDt = null;

        public DataTable spGetData(string[] parameters) {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString))
            {
                con.Open();
                DataTable dt = new DataTable();
                using (SqlCommand cmd = new SqlCommand("Examen_Escuela", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < parameters.Length; i++) {

                        var parameterSplit = parameters[i].Split(':');


                        cmd.Parameters.AddWithValue(parameterSplit[0], parameterSplit[1]);
                        
                    }

                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);

                    return dt;
                }
            }
        }

        public void spSendData(string[] parameters)
        {
            try {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("Examen_Escuela", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        for (int i = 0; i < parameters.Length; i++)
                        {

                            var parameterSplit = parameters[i].Split(':');

                            cmd.Parameters.AddWithValue(parameterSplit[0], parameterSplit[1]);

                        }
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e) { 
                
            }
        }

    }
}