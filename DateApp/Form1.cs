using DateApp.Helpers;
using DateApp.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DateApp
{
    public partial class Form1 : Form
    {
        private List<Person> people = new List<Person>();
        private List<PersonSeeking> peopleSeeking = new List<PersonSeeking>();

        private DataAccess db = new DataAccess();
        private GUIHelper gh = new GUIHelper();

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            string[] values =
                {
                firstnameBox.Text,
                lastnameBox.Text,
                mailBox.Text,
                genderBox.Text,
                birthdayBox.Text,
                profBox.Text,
                postNumberBox.Text,
                statusBox.Text,
                seekingBox.Text
            };

            // Make sure there is no null values
            foreach (string v in values)
            {
                if (v == "" || v == null)
                {
                    // Display message and return
                    MessageBox.Show("Hey there! You can not create a user with an empty field(s)", "HEY YOU!");
                    return;
                }
            }

            // Call to insert person
            db.InsertPeople(values);
        }

        private void buttonQueryMales_Click(object sender, EventArgs e)
        {
            // Query database
            peopleSeeking = db.GetPeople("DateApp",
                "SELECT firstName, lastName, seeking, area.city, area.state FROM person " +
                "INNER JOIN area ON person.area = area.areaID " +
                "WHERE gender = 'M'");

            // Call GUIHelper function to populate listview
            gh.ListPeopleView(listViewPerson, peopleSeeking);
        }

        private void buttonQueryFemales_Click(object sender, EventArgs e)
        {
            // Query database
            peopleSeeking = db.GetPeople("DateApp",
                "SELECT firstName, lastName, seeking, area.city, area.state FROM person " +
                "INNER JOIN area ON person.area = area.areaID " +
                "WHERE gender = 'F'");

            // Call GUIHelper function to populate listview
            gh.ListPeopleView(listViewPerson, peopleSeeking);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            object[] prof = db.GetValues("DateApp", "SELECT prof FROM profession");
            object[] status = db.GetValues("DateApp", "SELECT status FROM status");

            int px = 0;
            int ps = 0;

            // Old test code. THE LAST LINE WORKS TO GET INFO AND IS CURRENTLY IN USE!
            //object test = obj[0];
            //string test1 = ((Dapper.SqlMapper.DapperRow)obj[0]).values[0];
            //var test11 = s[0][1];
            //var s = obj.AsQueryable();
            //var st = ((object[])((System.Collections.Generic.IDictionary<string, object>)obj[0]).Values)[0];

            foreach (object p in prof)
            {
                profBox.Items.Add(((object[])((IDictionary<string, object>)prof[px]).Values)[0].ToString());
                px++;
            }
            foreach (object s in status)
            {
                statusBox.Items.Add(((object[])((IDictionary<string, object>)status[ps]).Values)[0].ToString());
                ps++;
            }
        }
    }
}