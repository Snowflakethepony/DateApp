using DateApp.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DateApp.Helpers
{
    /// <summary>
    /// Class used as handle for the dynamic GUI changes.
    /// </summary>
    public class GUIHelper
    {
        /// <summary>
        /// List people inside LiseView box.
        /// </summary>
        /// <param name="list"> ListView Control. </param>
        /// <param name="person"> List of type PersonSeeking. </param>
        /// <param name="columns"> Array containing column names and width format like this: "NameOfColumn:WidthInPixels". </param>
        public void ListPeopleView(ListView list, List<PersonSeeking> person, string[] columns)
        {
            // Clear list view.
            list.Clear();
            string[] t;


            list.Columns.Add("ID", 40);
            foreach (string v in columns)
            {
                t = v.Split(':');
                list.Columns.Add(t[0], Convert.ToInt16(t[1]));
            }

            list.Columns.Add("Picture", 50);

            // Goes though each of the person found and put them in the list as items.
            foreach (PersonSeeking p in person)
            {
                // Instasiate a new ListViewItem.
                ListViewItem item = new ListViewItem
                {
                    Text = Convert.ToString(p.PersonID)
                };
                // Add PersonID First always.
                item.SubItems.Add(p.Firstname + " " + p.Lastname);
                item.SubItems.Add(p.City);
                item.SubItems.Add(p.Mail);
                item.SubItems.Add(p.Seeking);
                try
                {
                    if (p.Picture != null)
                    {
                        item.SubItems.Add("Present");
                    }
                    else
                    {
                        item.SubItems.Add("No Picture");
                    }
                }
                catch
                {
                }


                

                // Add the item to the ListView.
                list.Items.Add(item);
            }
        }

        public void ListFindUserView(ListView list, List<PersonSeeking> person)
        {
            // Clear list view.
            list.Clear();
            // Create the needed columns.
            list.Columns.Add("Name", 100);
            list.Columns.Add("ID", 50);
            list.Columns.Add("Mail", 100);

            // Goes though each of the person found and put them in the list as items.
            foreach (PersonSeeking p in person)
            {
                // Instasiate a new ListViewItem.
                ListViewItem item = new ListViewItem
                {
                    // Populate the item.
                    Text = p.Firstname + " " + p.Lastname
                };
                //item.SubItems.Add(Convert.ToString(p.PersonID));
                item.SubItems.Add(p.Mail);

                // Add the item to the ListView.
                list.Items.Add(item);
            }
        }
    }
}