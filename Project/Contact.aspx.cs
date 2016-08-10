using Project;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class Contacts1 : System.Web.UI.Page
    {
        meetmeEntities data = new meetmeEntities();
        string currentuser = HttpContext.Current.User.Identity.Name;

        protected void Page_Load(object sender, EventArgs e)
        {
            SearchButton.Click += SearchButton_Click1;
            AddContactsButton.Click += AddContactsButton_Click;

            FillListedContactsGrid();

            if (!IsPostBack)
            {
                //FillListedContactsGrid();
            }
        }

        private void AddContactsButton_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("First Name"), new DataColumn("Last Name"), new DataColumn("Email") });
            foreach (GridViewRow row in ContactGridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("chkRow") as CheckBox);
                    if (chkRow.Checked)
                    {
                        string first = row.Cells[1].Text;
                        string last = row.Cells[2].Text;
                        string email = row.Cells[3].Text;
                        ListedContacts c = new ListedContacts();
                        c.Username = email;
                        c.Owner = User.Identity.Name;

                        data.ListedContacts.Add(c);
                        data.SaveChanges();
                    }
                }
            }

            ListedContactsGridView.DataBind();
        }

        private void SearchButton_Click1(object sender, EventArgs e)
        {
            this.FillGrid(SearchBox.Text);
        }

        private void FillGrid(string name)
        {
            var griddata = data.AspNetUsers.Where(ev => ev.UserName.Contains(name)).Select(ev => new { ev.Firstname, ev.Lastname, ev.Email }).ToList();

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("First Name"), new DataColumn("Last Name"), new DataColumn("Email")});

            for (int i = 0; i < griddata.Count; i++)
            {
                string first = griddata[i].Firstname;
                string last = griddata[i].Lastname;
                string email = griddata[i].Email;

                dt.Rows.Add(first, last, email);
            }

            ContactGridView.DataSource = dt;
            ContactGridView.DataBind();
        }

        private void FillListedContactsGrid()
        {
            List<ListedContacts> lcontacts = data.ListedContacts.Where(ev => ev.Owner == User.Identity.Name).ToList();
            List<AspNetUsers> griddata = null;

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("First Name"), new DataColumn("Last Name"), new DataColumn("Email") });

            try
            {
                for (int i = 0; i < lcontacts.Count; i++)
                {
                    string uname = lcontacts[i].Username;
                    griddata = data.AspNetUsers.Where(ep => ep.UserName == uname).ToList();
                }

                for (int i = 0; i < griddata.Count; i++)
                {
                    string first = griddata[i].Firstname;
                    string last = griddata[i].Lastname;
                    string email = griddata[i].Email;

                    dt.Rows.Add(first, last, email);
                }

                ListedContactsGridView.DataSource = dt;
                ListedContactsGridView.DataBind();
            } catch(Exception ex)
            {
                //Message m = new Message();
                //m.Show("No Contacts!");
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }

        }

    }
}