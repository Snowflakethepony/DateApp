using Dapper;
using DateApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateApp.Helpers
{
    public class DataAccess
    {
        public List<Person> GetPeople(string name)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(SqlHelper.ConVal("DateApp")))
            {
                return connection.Query<Person>("SELECT * FROM person").ToList();
            }
        }
    }
}
