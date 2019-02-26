using DateApp.Helpers;
using DateApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DateApp
{
    public partial class DateAppForm : Form
    {
        // Instansiate local variables.
        private List<Person> people = new List<Person>();
        private List<PersonSeeking> peopleSeeking = new List<PersonSeeking>();

        // Instansiate Helper classes.
        private DataAccess db = new DataAccess();
        private GUIHelper gh = new GUIHelper();
        private UpdateForm f2 = new UpdateForm();

        // Open the app.
        public DateAppForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Happens doing loadtime.
        /// Responsible for getting correct names for combo boxes.
        /// </summary>
        private void DateAppFormLoad(object sender, EventArgs e)
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

            var test = (((object[])((IDictionary<string, object>)prof[px]).Values));
            var test1 = (object)(prof[px]);
            var test2 = test[0];

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

        #region UserInteractions

        /// <summary>
        /// Click handler for Inser button.
        /// Extracts inputet data and call insert to DB.
        /// </summary>
        /// <param name="sender"> Button. </param>
        /// <param name="e"> Event. </param>
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            
            string[] controlNames = { profBox.Text, statusBox.Text };

            try
            {
                openFileDialog1.Filter = "JPG files|*.jpg";
                openFileDialog1.Title = "Select a jpg image File";
                List<object> pobjs = db.Translator2(controlNames);

                // Show the Dialog.
                // If the user clicked OK in the dialog and
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileInfo finfo = new FileInfo(openFileDialog1.FileName);
                    byte[] btImage = new byte[finfo.Length];
                    FileStream fStream = finfo.OpenRead();
                    fStream.Read(btImage, 0, btImage.Length);
                    fStream.Close();

                    Person person = new Person(
                        firstnameBox.Text,
                        lastnameBox.Text,
                        birthdayBox.Text,
                        Convert.ToChar(genderBox.Text),
                        mailBox.Text,
                        Convert.ToInt16(postNumberBox.Text),
                        Convert.ToInt16(pobjs[0].ToString()),
                        Convert.ToInt16(pobjs[1].ToString()),
                        seekingBox.Text,
                        btImage

                    );

                    /*
                    person.Firstname = firstnameBox.Text
                    person.Lastname = lastnameBox.Text;
                    person.Mail = mailBox.Text;
                    person.Gender = Convert.ToChar(genderBox.Text);
                    person.Birthday = birthdayBox.Text;
                    person.Profession = pobjs[0].ToString();
                    person.Area = Convert.ToInt16(postNumberBox.Text);
                    person.Status = Convert.ToInt16(pobjs[1].ToString());
                    person.Seeking = seekingBox.Text;
                    person.Picture = btImage;
                    */

                    // Call to insert person
                    //db.InsertPeople(values, file);
                    db.InsertPerson(person);

                    // Show picture chosen
                    profilePicture.Image = Image.FromFile(openFileDialog1.FileName);

                    // Show result
                    //MessageBox.Show(result, "New User");
                }
                else
                {
                    return;
                }
            }
            catch
            {
            }
            /* OLD
            string result;
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
            };*/

            /*// Make sure there is no null values
            foreach (string v in values)
            {
                if (v == "" || v == null)
                {
                    // Display message and return
                    MessageBox.Show("Hey there! You can not create a user with an empty field(s)", "HEY YOU!");
                    return;
                }
            }*/
        }

        /// <summary>
        /// Click handler for Query Males button.
        /// Query and display in ListView.
        /// </summary>
        /// <param name="sender"> Button. </param>
        /// <param name="e"> Event. </param>
        private void buttonQueryMales_Click(object sender, EventArgs e)
        {
            // OLD NOT USED!
            /* Query database
            peopleSeeking = db.GetPeople("DateApp",
                "SELECT firstName, lastName, seeking, area.city, area.state FROM person " +
                "INNER JOIN area ON person.area = area.areaID " +
                "WHERE gender = 'M'");*/

            // Columns - EMpty for picture
            string[] columns = { "Name:150", "City:100", "Mail:100", "Seeks:50"};

            // Query database using stored procedure method.
            peopleSeeking = db.GetPersonSeeking("DateApp", "Gender", "M");

            // Call GUIHelper function to populate listview
            gh.ListPeopleView(listViewPerson, peopleSeeking, columns);
        }

        /// <summary>
        /// Click handler for Query Females button.
        /// Query and display in ListView.
        /// </summary>
        /// <param name="sender"> Button. </param>
        /// <param name="e"> Event. </param>
        private void buttonQueryFemales_Click(object sender, EventArgs e)
        {
            // OLD NOT USED!
            /* Query database
            peopleSeeking = db.GetPeople("DateApp",
                "SELECT firstName, lastName, seeking, area.city, area.state FROM person " +
                "INNER JOIN area ON person.area = area.areaID " +
                "WHERE gender = 'F'");*/

            // Columns - Empty for picture
            string[] columns = { "Name:150", "City:100", "Mail:100", "Seeks:50"};

            // Query database using stored procedure method.
            peopleSeeking = db.GetPersonSeeking("DateApp", "Gender", "F");

            // Call GUIHelper function to populate listview
            gh.ListPeopleView(listViewPerson, peopleSeeking, columns);
        }

        /// <summary>
        /// Click handler for image button.
        /// Displays a chosen JPG file in pictureBox.
        /// </summary>
        /// <param name="sender"> Button. </param>
        /// <param name="e"> Event. </param>
        private void buttonImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPG files|*.jpg";
            openFileDialog1.Title = "Select a jpg image File";

            // Show the Dialog.
            // If the user clicked OK in the dialog and
            // a .CUR file was selected, open it.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                profilePicture.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        /// <summary>
        /// Handle to update a person in the DB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            foreach (Control c in f2.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox))
                {
                    c.Text = "";
                }
            }

            if (peopleSeeking.Count == 1)
            {
                f2.ShowDialog();
                if (f2.updateCliced)
                {
                    string[] controlNames = { f2.profBox.Text, f2.statusBox.Text };
                    List<object> pobjs = db.Translator2(controlNames);

                    Person person = new Person(
                        peopleSeeking[0].PersonID,
                        f2.firstnameBox.Text,
                        f2.lastnameBox.Text,
                        f2.birthdayBox.Text,
                        Convert.ToChar(f2.genderBox.Text),
                        f2.mailBox.Text,
                        Convert.ToInt16(f2.postNumberBox.Text),
                        Convert.ToInt16(pobjs[0].ToString()),
                        Convert.ToInt16(pobjs[1].ToString()),
                        f2.seekingBox.Text,
                        f2.btImage
                        );

                    db.UpdatePerson(person);
                }
            }
            else
            {
                // HANDLE DA LEVER KRONK!
            }
        }

        /// <summary>
        /// Click handler for Query button. 
        /// Has multiple query string into the databse based on the input given.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuery_Click(object sender, EventArgs e)
        {
            string box = nameIDBox.Text;
            // Columns - Empty for picture
            string[] columns = { "Name:150", "City:100", "Mail:100", "Seeks:50", ":0" };

            int testInput;
            
            try
            {
                try
                {
                    testInput = Convert.ToInt32(box);
                }
                catch
                {
                    testInput = -1;
                }

                if (box != "" && box != null)
                {
                    // If contain "-" then birthday is provided.
                    if (box.Contains("-"))
                    {
                        // Query by birthday
                        peopleSeeking = db.GetPersonSeeking2("DateApp", $"SELECT * FROM person WHERE birthday like '{box}%'");
                    }
                    // If the test int is higher then -1 (correct id) then an id is provided.
                    else if (testInput >= 0)
                    {
                        // Query ID - And call display image.
                        peopleSeeking = db.GetPersonSeeking("DateApp", "ID", box);

                        // Instaziate a new person to extract profile picture.
                        PersonSeeking person = peopleSeeking[0];

                        // Only call show picture code if there is an image.
                        if (person.Picture != null)
                        {
                            // Call the function to show the profile picture.
                            showProfilePicture(person.Picture);
                        }
                    }
                    // Name most be provided.
                    else
                    {
                        box = box.Trim();
                        peopleSeeking = db.GetPersonSeeking("DateApp", "Name", $"'{box}%'");
                    }

                    gh.ListPeopleView(listViewPerson, peopleSeeking, columns);
                }
                else
                {
                    // Show message
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }

        /// <summary>
        /// Click handler for Delete User button.
        /// Will go through all selected items inside the listview and call methods to delete the users from the SQL database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteUser_Click(object sender, EventArgs e)
        {
           /* Goes through all items in the listview and checks if one is checked. Then calls the DeletePerson.
            foreach (ListViewItem item in listViewPerson.Items)
            {
                if (item.Selected == true)
                {
                    //db.DeletePerson(Convert.ToInt16(item.Text));
                    Console.WriteLine(Convert.ToInt16(item.Text));
                }
            }
            */

            // Gets all the selected items Only
            var items = listViewPerson.SelectedItems;

            // Goes through the collection of items and calls DeletePerson for each one.
            foreach (ListViewItem i in items)
            {
                bool result = db.DeletePerson(Convert.ToInt16(i.Text));
                i.Remove();
                Console.WriteLine(result);
            }
        }

        #endregion UserInteractions

        #region Internal

        /// <summary>
        /// Show a byteArray image on the GUI control.
        /// </summary>
        /// <param name="picture"> Bytearray of the image. </param>
        private void showProfilePicture(byte[] picture)
        {
            try
            {
                Image i = byteArrayToImage(picture);

                profilePicture.Image = i;
            }
            catch
            {
                // Handle it KRONK
            }
        }

        /// <summary>
        /// Convert a bytearray to an Image type.
        /// </summary>
        /// <param name="byteArray"> Bytearray to convert. </param>
        /// <returns> The converted image. </returns>
        private Image byteArrayToImage(byte[] byteArray)
        {
            Image image = null;
            try
            {
                using (var ms = new MemoryStream(byteArray))
                {
                    image = Image.FromStream(ms);
                }
            }
            catch
            {
            }

            return image;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemShowPicture(object sender, ListViewItemMouseHoverEventArgs e)
        {
            foreach (PersonSeeking person in peopleSeeking)
            {
                if (e.Item.SubItems[0].Text == Convert.ToString(person.PersonID))
                {
                    showProfilePicture(person.Picture);
                }
            }
            
        }

        private void listViewPerson_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            // Enable delete button
            buttonDeleteUser.Enabled = true;

            if (e.IsSelected == false)
            {
                buttonDeleteUser.Enabled = false;
            }
        }

        #endregion Internal

    }
}