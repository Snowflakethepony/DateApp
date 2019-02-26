using DateApp.Helpers;
using DateApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateApp
{
    public partial class UpdateForm : Form
    {
        public Person updatePerson;
        public byte[] btImage;
        public bool updateClicked = false;
        private DataAccess db = new DataAccess();

        public UpdateForm()
        {
            InitializeComponent();
        }

        public void ShowForm(DateAppForm form)
        {
            // Instanziate the local varible
            List<object> objs = new List<object>();

            // Populate the profbox items
            foreach (string i in form.profBox.Items)
            {
                Console.WriteLine(i);
                objs.Add(i);
            }
            profBox.Items.AddRange(objs.ToArray());

            // Clear the local varible and populate the statusbox items
            objs.Clear();
            foreach (string i in form.statusBox.Items)
            {
                objs.Add(i);
            }
            statusBox.Items.AddRange(objs.ToArray());

            this.ShowDialog();
        }

        public void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo finfo = new FileInfo(openFileDialog1.FileName);
                btImage = new byte[finfo.Length];
                FileStream fStream = finfo.OpenRead();
                fStream.Read(btImage, 0, btImage.Length);
                fStream.Close();
            }
            else
            {
                MessageBox.Show("Error loading Image", "Warning");
            }

            updateClicked = true;
            Close();
        }

        /*
        private void UpdateForm_Load(object sender, EventArgs e)
        {
            object[] prof = db.GetValues("DateApp", "SELECT prof FROM profession");
            object[] status = db.GetValues("DateApp", "SELECT status FROM status");

            int px = 0;
            int ps = 0;

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
            
        }*/
    }
}
