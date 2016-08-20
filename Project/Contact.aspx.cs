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

            FillListedContacts();

            if (!IsPostBack)
            {
                SearchTitle.Text = "";
                AddContactsButton.Visible = false;
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
                        try { 
                            string first = row.Cells[1].Text;
                            string last = row.Cells[2].Text;
                            string email = row.Cells[3].Text;
                            ListedContacts c = new ListedContacts();
                            c.Username = email;
                            c.Owner = User.Identity.Name;

                            data.ListedContacts.Add(c);
                            data.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            Message m = new Message();
                            m.Show("Unable to add contact to list!");
                            System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                        }
                    }
                }
            }

            Response.Redirect("~/Contact.aspx");

        }


        //Method to run when search button is clicked
        private void SearchButton_Click1(object sender, EventArgs e)
        {
            this.FillGrid(SearchBox.Text);

            SearchTitle.Text = "Contacts that match your search query.";
            AddContactsButton.Visible = true;
        }


        //Fill GridView with search query
        private void FillGrid(string name)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("First Name"), new DataColumn("Last Name"), new DataColumn("Email")});

            try
            {
                var griddata = data.AspNetUsers.Where(ev => ev.UserName.Contains(name) && ev.UserName != User.Identity.Name).Select(ev => new { ev.Firstname, ev.Lastname, ev.Email }).ToList();

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
            catch (Exception ex)
            {
                Message m = new Message();
                m.Show("Unable to show contacts!");
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
        }


        //Fill GridView of listed contacts.
        private void FillListedContacts()
        {
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

                    Button d = new Button();
                    d.Text = "X";
                    d.CssClass = "CDeleteButton";
                    d.ID = email;
                    d.Click += D_Click;
                    d.OnClientClick = "Confirm()";

                    TableRow row = new TableRow();
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    TableCell cell3 = new TableCell();
                    TableCell cell4 = new TableCell();

                    cell1.Controls.Add(new LiteralControl(first));
                    cell2.Controls.Add(new LiteralControl(last));
                    cell3.Controls.Add(new LiteralControl(email));
                    cell4.Controls.Add(d);

                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);
                    row.Cells.Add(cell4);
       
                    ListedContactsTable.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                //Message m = new Message();
                //m.Show("No Contacts!");
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }

        }

        private void D_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string email = btn.ID;

            string confirmValue = Request.Form["confirm_value"];

            if (confirmValue == "Yes")
            {
                try
                {
                    ListedContacts lcontact = data.ListedContacts.Where(ev => ev.Username == email).FirstOrDefault();
                    data.ListedContacts.Remove(lcontact);
                    data.SaveChanges();

                    Response.Redirect("~/Contact.aspx");
                }
                catch (Exception ex)
                {
                    Message m = new Message();
                    m.Show("Unable to delete contact!");
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                }
            }
            else
            {
                Response.Redirect("~/Contact.aspx");
            }

        }
    }
}