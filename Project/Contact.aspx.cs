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
        bool wasClicked = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            SearchButton.Click += SearchButton_Click1;
            AddContactsButton.Click += AddContactsButton_Click;

            FillListedContactsGrid();

            if (!IsPostBack)
            {
                SearchTitle.Text = "";
                AddContactsButton.Visible = false;
                line.Visible = false;
                line1.Visible = false;
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

            Response.Redirect("~/Contact.aspx");
        }

        //Method to run when search button is clicked
        private void SearchButton_Click1(object sender, EventArgs e)
        {
            this.FillGrid(SearchBox.Text);

            if(Request.Browser.ScreenPixelsWidth <= 640 && Request.Browser.IsMobileDevice)
            {
                line.Visible = true;
                line1.Visible = true;
            }
            else
            {
                line.Visible = false;
                line1.Visible = false;
            }
            
            SearchTitle.Text = "Contacts that match your search query.";
            AddContactsButton.Visible = true;
        }

        //Fill GridView with search query
        private void FillGrid(string name)
        {
            var griddata = data.AspNetUsers.Where(ev => ev.UserName.Contains(name) && ev.UserName != User.Identity.Name).Select(ev => new { ev.Firstname, ev.Lastname, ev.Email }).ToList();

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

        //Fill GridView of listed contacts.
        private void FillListedContactsGrid()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("First Name"), new DataColumn("Last Name"), new DataColumn("Email") });

            try
            {
                List<ListedContacts> contactlist = data.ListedContacts.Where(ev => ev.Owner == User.Identity.Name).ToList();

                for (int i = 0; i < contactlist.Count; i++)
                {
                    string contactname = contactlist[i].Username;
                    AspNetUsers user = data.AspNetUsers.Where(ep => ep.UserName == contactname && ep.UserName != User.Identity.Name).SingleOrDefault();

                    string first = user.Firstname;
                    string last = user.Lastname;
                    string email = user.Email;

                    dt.Rows.Add(first, last, email);
                }

                ListedContactsGridView.DataSource = dt;
                ListedContactsGridView.DataBind();
            }
            catch (Exception ex)
            {
                //Message m = new Message();
                //m.Show("No Contacts!");
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            wasClicked = true;

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("First Name"), new DataColumn("Last Name"), new DataColumn("Email") });
            foreach (GridViewRow row in ListedContactsGridView.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    Button delete = (row.Cells[3].FindControl("DeleteButton") as Button);
                    if (wasClicked == true)
                    {
                        string first = row.Cells[0].Text;
                        string last = row.Cells[1].Text;
                        string email = row.Cells[2].Text;

                        ListedContacts c = data.ListedContacts.Where(ev => ev.Username == email).FirstOrDefault();

                        data.ListedContacts.Remove(c);
                        data.SaveChanges();
                    }
                }
            }

            Response.Redirect("~/Contact.aspx");

        }
    }
}