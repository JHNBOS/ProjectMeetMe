using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class DeleteMembers : System.Web.UI.Page
    {
        //DBContext
        public meetmeEntities data = new meetmeEntities();
        public string group = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            group = Session["GroupDelete"].ToString();
            Memberlist();
        }

        private void Memberlist()
        {
            try
            {
                List<Members> GroupMembers = data.Members.Where(m => m.Group == group).ToList();

                foreach (var member in GroupMembers)
                {
                    //AspNetUser
                    string email = member.User;
                    AspNetUsers user = data.AspNetUsers.Where(u => u.UserName == email).FirstOrDefault();

                    //User info
                    string firstname = user.Firstname;
                    string lastname = user.Lastname;

                    //Delete button
                    Button del = new Button();
                    del.ID = email;
                    del.Text = "X";
                    del.CssClass = "MDeleteButton";
                    del.Width = 24;
                    del.Height = 24;
                    del.Click += Del_Click;
                    del.OnClientClick = "Confirm()";

                    //Table
                    TableRow row = new TableRow();
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();
                    TableCell cell3 = new TableCell();

                    cell1.Controls.Add(new LiteralControl(email));
                    cell2.Controls.Add(new LiteralControl(firstname + " " + lastname));
                    cell3.Controls.Add(del);

                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);
                    row.Cells.Add(cell3);

                    MemberTable.Rows.Add(row);
                }

            } catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
        }

        private void Del_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string[] tmp = btn.ID.Split('_');
            string username = btn.ID;

            string confirmValue = Request.Form["confirm_value"];

            if (confirmValue == "Yes")
            {
                try
                {
                    Members MemberToDelete = data.Members.Where(m => m.User == username).FirstOrDefault();

                    data.Members.Remove(MemberToDelete);
                    data.SaveChanges();

                    Response.Redirect("~/GroupCalendars.aspx");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                }
            }
            else
            {
                Response.Redirect("~/GroupCalendars.aspx");
            }
        }


    }
}