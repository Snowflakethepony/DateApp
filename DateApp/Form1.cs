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
        public Form1()
        {
            InitializeComponent();

            personBox.DataSource = people;
            personBox.DisplayMember = "FullInfo";
        }

        private void buttonQuery_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            people = db.GetPeople("");

            personBox.DataSource = people;
            personBox.DisplayMember = "FullInfo";
            personBox.Refresh();
        }
    }
}
