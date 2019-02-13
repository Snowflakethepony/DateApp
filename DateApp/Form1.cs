using DateApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DateApp.Helpers;

namespace DateApp
{
    public partial class Form1 : Form
    {
        List<Person> people = new List<Person>();
        List<PersonSeeking> peopleSeeking = new List<PersonSeeking>();

        DataAccess db = new DataAccess();
        GUIHelper gh = new GUIHelper();

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

            foreach (string v in values)
            {
                if (v == "" || v == null)
                {
                    MessageBox.Show("Hey there! You can not create a user with an empty field(s)", "HEY YOU!");
                }
                else
                {
                    db.InsertPeople(values);
                }
            }
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
    }
}
