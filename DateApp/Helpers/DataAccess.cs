using Dapper;
using DateApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DateApp.Helpers
{
    public class DataAccess
    {
        public List<PersonSeeking> GetPeople(string name, string query)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(SqlHelper.ConVal(name)))
            {
                return connection.Query<PersonSeeking>(query).ToList();
            }
        }

        public string InsertPeople(string[] values)
        {
            string area;

            using (IDbConnection con = new System.Data.SqlClient.SqlConnection(SqlHelper.ConVal("DateApp")))
            {
                area = con.Query($"SELECT area.areaID FROM area WHERE postnumber = { values[7] }").ToString();
            }

            using (SqlConnection connection = new SqlConnection(SqlHelper.ConVal("DateApp")))
            {
                String query = "INSERT INTO dbo.person (firstName,lastName,mail,gender,birthday,profession,area,status,seeking) VALUES (@firstName,@lastName,@mail,@gender,@birthday,@profession,@area,@status,@seeking)";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@firstName", values[0]);
                    command.Parameters.AddWithValue("@lastName", values[1]);
                    command.Parameters.AddWithValue("@mail", values[2]);
                    command.Parameters.AddWithValue("@gender", values[3]);
                    command.Parameters.AddWithValue("@birthday", values[4]);
                    command.Parameters.AddWithValue("@profession", values[5]);
                    command.Parameters.AddWithValue("@profession", area);
                    command.Parameters.AddWithValue("@status", values[7]);
                    command.Parameters.AddWithValue("@status", values[8]);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
            }

            return "";
        }
    }
}
