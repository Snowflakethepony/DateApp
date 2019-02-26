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
        public bool updateCliced;
        public Person updatePerson;
        public byte[] btImage;
        private DataAccess db = new DataAccess();

        public UpdateForm()
        {
            InitializeComponent();
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

            updateCliced = true;
            Close();
        }

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
        }
    }
}
