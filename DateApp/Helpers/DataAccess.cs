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

        public string InsertPeople(string[] values)
        {
            List<object> prof = new List<object>();
            List<object> area = new List<object>();
            List<object> status = new List<object>();

            using (IDbConnection con = new System.Data.SqlClient.SqlConnection(SqlHelper.ConVal("DateApp")))
            {
                object oprof = con.Query($"SELECT profession.profID FROM profession WHERE prof = '{ values[5] }' ").FirstOrDefault();
                object oarea = con.Query($"SELECT area.areaID FROM area WHERE postnumber = '{ values[6] }' ").FirstOrDefault();
                object ostatus = con.Query($"SELECT status.statusID FROM status WHERE status = '{ values[7] }' ").FirstOrDefault();

                prof = ((IDictionary<string, object>)oprof).Values.ToList();
                area = ((IDictionary<string, object>)oarea).Values.ToList();
                status = ((IDictionary<string, object>)ostatus).Values.ToList();
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
                    command.Parameters.AddWithValue("@profession", prof[0].ToString());
                    command.Parameters.AddWithValue("@area", area[0].ToString());
                    command.Parameters.AddWithValue("@status", status[0].ToString());
                    command.Parameters.AddWithValue("@seeking    ", values[8]);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            return "";
        }
    }
}