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
        /// <summary>
        /// Query database for data in person.
        /// </summary>
        /// <param name="name"> Connectionstring. </param>
        /// <param name="query"> FULL query text as string. </param>
        /// <returns></returns>
        public List<Person> GetPerson(string name, string query)
        {
            using (IDbConnection connection = new SqlConnection(SqlHelper.ConVal(name)))
            {
                 return connection.Query<Person>(query).ToList();
            }
        }

        /// <summary>
        /// Put information form person type into personseeking type.
        /// </summary>
        /// <returns> A list of PersonSeeking type. </returns>
        public List<PersonSeeking> GetPersonSeeking2(string name, string query)
        {
            List<object> translated = new List<object>();
            List<PersonSeeking> personS = new List<PersonSeeking>();
            List<Person> person = new List<Person>();

            person = GetPerson(name, query);

            foreach (Person p in person)
            {
                // Populate the list of the translated information.
                translated = Translator(p);

                // Create a new person and populate it.
                PersonSeeking ps = new PersonSeeking
                {
                    Firstname = p.Firstname,
                    Lastname = p.Lastname,
                    Mail = p.Mail,
                    Seeking = p.Seeking,
                    Picture = p.Picture,
                    City = translated[1].ToString()
                };

                // Add the new person to the list.
                personS.Add(ps);
            }


            return personS;
        }

        /// <summary>
        /// Extract telling data from SQL database about a person.
        /// </summary>
        /// <param name="p"> The person object. </param>
        /// <returns></returns>
        private List<object> Translator(Person p)
        {
            // Create the output list.
            List<object> outPut = new List<object>();

            using (IDbConnection con = new SqlConnection(SqlHelper.ConVal("DateApp")))
            {
                // Query for the information of the foreign keys needed.
                object oprof = con.Query($"SELECT profession.prof FROM profession WHERE profID = '{ p.Profession }' ").FirstOrDefault();
                object ocity = con.Query($"SELECT area.city FROM area WHERE postnumber = '{ p.Area }' ").FirstOrDefault();
                object ostatus = con.Query($"SELECT status.status FROM status WHERE statusID = '{ p.Status }' ").FirstOrDefault();

                // Get the value from the objects and put them in a list - OLD NOT USED! CANNOT BE INDEXED INTO.
                //outPut.Add(((IDictionary<string, object>)oprof).Values.ToList());
                //outPut.Add(((IDictionary<string, object>)ocity).Values.ToList());
                //outPut.Add(((IDictionary<string, object>)ostatus).Values.ToList());

                // NEW SOLVED THE INDEXING ISSUE
                //var test = ((object[])((System.Collections.Generic.IDictionary<string, object>)oprof).Values)[0];
                outPut.Add(((object[])((IDictionary<string, object>)oprof).Values)[0]);
                outPut.Add(((object[])((IDictionary<string, object>)ocity).Values)[0]);
                outPut.Add(((object[])((IDictionary<string, object>)ostatus).Values)[0]);
            }

            return outPut;
        }

        /// <summary>
        /// Query directly into personseeking via stored procedure.
        /// Does not take in a query as this is a static query!.
        /// </summary>
        /// <param name="name"> Connectionstring. </param>
        /// <returns></returns>
        public List<PersonSeeking> GetPersonSeeking(string name, string where = "")
        {
            using (IDbConnection connection = new SqlConnection(SqlHelper.ConVal(name)))
            {
                return connection.Query<PersonSeeking>($"EXEC personSeeking @Where={where}").ToList();
            }
        }

        /// <summary>
        /// "Normal" query on database that returns rows as objects.
        /// </summary>
        /// <param name="name"> Connectionstring. </param>
        /// <param name="query"> FULL query text as string. </param>
        /// <returns></returns>
        public object[] GetValues(string name, string query)
        {
            using (IDbConnection connection = new SqlConnection(SqlHelper.ConVal(name)))
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

        /// <summary>
        /// Same as old one besides this used another class. 
        /// Makes it slitgly lighter.
        /// </summary>
        /// <param name="values"></param>
        /// <param name="fileName"></param>
        public void InsertPeopleBIG(string[] values, string fileName)
        {
            // Create a list -> Lists can be indexed into. And i can not use a string easily*** I
            List<object> prof = new List<object>();
            List<object> area = new List<object>();
            List<object> status = new List<object>();

            FileInfo finfo = new FileInfo(fileName);
            byte[] btImage = new byte[finfo.Length];
            FileStream fStream = finfo.OpenRead();
            fStream.Read(btImage, 0, btImage.Length);
            fStream.Close();

            String query = "INSERT INTO dbo.person (firstName,lastName,mail,gender,birthday,profession,area,status,seeking,picture) VALUES (@firstName,@lastName,@mail,@gender,@birthday,@profession,@area,@status,@seeking,@picture)";

            using (IDbConnection con = new SqlConnection(SqlHelper.ConVal("DateApp")))
            {
                // Query for the ID of the foreign keys needed.
                object oprof = con.Query($"SELECT profession.profID FROM profession WHERE prof = '{ values[5] }' ").FirstOrDefault();
                object oarea = con.Query($"SELECT area.areaID FROM area WHERE postnumber = '{ values[6] }' ").FirstOrDefault();
                object ostatus = con.Query($"SELECT status.statusID FROM status WHERE status = '{ values[7] }' ").FirstOrDefault();

                // Get the value from the objects and put them in a list
                prof = ((IDictionary<string, object>)oprof).Values.ToList();
                area = ((IDictionary<string, object>)oarea).Values.ToList();
                status = ((IDictionary<string, object>)ostatus).Values.ToList();

                con.Execute(query, new
                {
                    firstName = values[0],
                    lastName = values[1],
                    mail = values[2],
                    gender = values[3],
                    birthday = values[4],
                    profession = prof,
                    area,
                    status,
                    seeking = values[8],
                    picture = btImage
                }
                );
            }
        }

        /// <summary>
        /// Uses directly a person. No need for translation data.
        /// </summary>
        /// <param name="person"></param>
        public void InsertPeple(Person person)
        {
            using (IDbConnection db = new SqlConnection(SqlHelper.ConVal("DateApp")))
            {
                string insertQuery = @"INSERT INTO [dbo].[person]([firstName], [lastName], [birthday], [gender], [mail], [area], [profession], [status], [seeking], [picture]) VALUES (@firstName, @lastName, @birthday, @gender, @mail, @area, @profession, @status, @seeking, @picture)";

                var result = db.Execute(insertQuery, person);
            };
        }

        /// <summary>
        /// Insert row into people table. "New User".
        /// </summary>
        /// <param name="values"> All information in an array. </param>
        /// <param name="fileName"> Image file name. </param>
        /// <returns></returns>
        public string InsertPeopleOld(string[] values, string fileName)
        {
            string outResult = "";

            // Create a list -> Lists can be indexed into. And i can not use a string easily*** I
            List<object> prof = new List<object>();
            List<object> area = new List<object>();
            List<object> status = new List<object>();

            using (IDbConnection con = new SqlConnection(SqlHelper.ConVal("DateApp")))
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

                    SqlParameter imageParameter = new SqlParameter("@picture", SqlDbType.Image)
                    {
                        Value = btImage
                    };
                    command.Parameters.Add(imageParameter);

                    // Open connection
                    connection.Open();
                    // HANDLE THE LEVER KRONK!
                    var result = command.ExecuteNonQuery();

                    if (Convert.ToInt32(result) == 0)
                    {
                        outResult = "Somthing went wrong, no rows affected";
                    }
                    else if (Convert.ToString(result) != ""){
                        outResult = "Success";
                    }
                }
            }

            return outResult;
        }
    }
}