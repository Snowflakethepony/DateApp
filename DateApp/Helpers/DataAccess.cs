using Dapper;
using DateApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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

        public object[] GetValues(string name, string query)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(SqlHelper.ConVal(name)))
            {
                return connection.Query<object>(query).ToArray();
            }

            /*
            object[] obj = null;
            using (SqlConnection connection = new SqlConnection(SqlHelper.ConVal("DateApp")))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    obj = command.ExecuteReader().GetSqlValue();
                }
            }
            return obj;*/
        }

        public string InsertPeople(string[] values, string fileName)
        {
            // Create a list -> Lists can be indexed into. And i can not use a string easily*** I
            List<object> prof = new List<object>();
            List<object> area = new List<object>();
            List<object> status = new List<object>();

            using (IDbConnection con = new System.Data.SqlClient.SqlConnection(SqlHelper.ConVal("DateApp")))
            {
                // Query for the ID of the foreign keys needed.
                object oprof = con.Query($"SELECT profession.profID FROM profession WHERE prof = '{ values[5] }' ").FirstOrDefault();
                object oarea = con.Query($"SELECT area.areaID FROM area WHERE postnumber = '{ values[6] }' ").FirstOrDefault();
                object ostatus = con.Query($"SELECT status.statusID FROM status WHERE status = '{ values[7] }' ").FirstOrDefault();

                // Get the value from the objects and put them in a list
                prof = ((IDictionary<string, object>)oprof).Values.ToList();
                area = ((IDictionary<string, object>)oarea).Values.ToList();
                status = ((IDictionary<string, object>)ostatus).Values.ToList();
            }

            using (SqlConnection connection = new SqlConnection(SqlHelper.ConVal("DateApp")))
            {
                // SQL INSERT query 
                String query = "INSERT INTO dbo.person (firstName,lastName,mail,gender,birthday,profession,area,status,seeking,picture) VALUES (@firstName,@lastName,@mail,@gender,@birthday,@profession,@area,@status,@seeking,@picture)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    FileInfo finfo = new FileInfo(fileName);
                    byte[] btImage = new byte[finfo.Length];
                    FileStream fStream = finfo.OpenRead();
                    fStream.Read(btImage, 0, btImage.Length);
                    fStream.Close();

                    // Add all the parameter values needed
                    command.Parameters.AddWithValue("@firstName", values[0]);
                    command.Parameters.AddWithValue("@lastName", values[1]);
                    command.Parameters.AddWithValue("@mail", values[2]);
                    command.Parameters.AddWithValue("@gender", values[3]);
                    command.Parameters.AddWithValue("@birthday", values[4]);
                    command.Parameters.AddWithValue("@profession", prof[0].ToString());
                    command.Parameters.AddWithValue("@area", area[0].ToString());
                    command.Parameters.AddWithValue("@status", status[0].ToString());
                    command.Parameters.AddWithValue("@seeking    ", values[8]);

                    SqlParameter imageParameter = new SqlParameter("@picture", SqlDbType.Image);
                    imageParameter.Value = btImage;
                    command.Parameters.Add(imageParameter);

                    // Open connection
                    connection.Open();
                    // HANDLE THE LEVER KRONK!
                    int result = command.ExecuteNonQuery();

                    if (result == 0)
                    {
                        return "Somthing went wrong, no rows affected";
                    }
                }
            }

            return "Success!";
        }
    }
}