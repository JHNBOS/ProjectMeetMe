using Project;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Project
{
    public partial class Contacts1 : System.Web.UI.Page
    {
        meetmeEntities data = new meetmeEntities();
        string currentuser = HttpContext.Current.User.Identity.Name;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ListContacts();
            }

            SearchButton.Click += SearchButton_Click;
        }

        
        private void SearchButton_Click(object sender, EventArgs e)
        {
            AspNetUsers user = data.AspNetUsers.Where(ep => ep.UserName == SearchBox.Text).SingleOrDefault();

            try
            {
                ListedContacts c = new ListedContacts();

                c.FirstName = user.Firstname;
                c.LastName = user.Lastname;
                c.Username = user.UserName;
                c.Owner = currentuser;

                data.ListedContacts.Add(c);
                data.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Email not available!");
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }

            ListContacts();
            SearchBox.Text = "";
        }

        private void ListContacts()
        {
            List<ListedContacts> contactlist = data.ListedContacts.Where(ev => ev.Owner == User.Identity.Name).ToList();

            for (int i = 0; i < contactlist.Count; i++)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                TableCell cell2 = new TableCell();
                TableCell cell3 = new TableCell();

                if(i % 2 == 0)
                {
                    row.BackColor = System.Drawing.Color.GhostWhite;
                }
                else
                {
                    row.BackColor = System.Drawing.Color.LightGray;
                }

                cell1.Text = contactlist[i].FirstName;
                cell2.Text = contactlist[i].LastName;
                cell3.Text = contactlist[i].Username;

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);

                ContactTable.Rows.Add(row);
            }
        }

    }
}