using DateApp.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DateApp.Helpers
{
    public class GUIHelper
    {
        public void ListPeopleView(ListView list, List<PersonSeeking> person)
        {
            // Clear list view
            list.Clear();
            // Create the needed columns
            list.Columns.Add("Name", 150);
            list.Columns.Add("City", 100);
            list.Columns.Add("State", 100);
            list.Columns.Add("Seeks", 50);

            // Goes though each of the person found and put them in the list as items
            foreach (PersonSeeking p in person)
            {
                // Instasiate a new ListViewItem
                ListViewItem item = new ListViewItem
                {

                    // Populate the item
                    Text = p.Firstname + " " + p.Lastname
                };
                item.SubItems.Add(p.City);
                item.SubItems.Add(p.State);
                item.SubItems.Add(p.Seeking);

                // Add the item to the ListView
                list.Items.Add(item);
            }
        }
    }
}