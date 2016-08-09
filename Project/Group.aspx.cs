using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class Group1 : System.Web.UI.Page
    {
        //1. Database context
        //2. List of items in table 'Groups'
        //3. Number of items in the List
        //4. Array of buttons to hold the groupnames
        meetmeEntities data;

        protected void Page_Load(object sender, EventArgs e)
        {
            groupbuttondiv.Controls.Clear();
            deletebuttondiv.Controls.Clear();

            CreateButtons();

            CreateGroupLink.Click += CreateGroupLink_Click;
        }

        private void CreateGroupLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CreateGroup.aspx");
        }

        private void D_Click(object sender, EventArgs e)
        {
            //1. New Button
            //2. Test to check which group has been clicked
            //3. Set Session Variable to send to Data.ashx
            //4. Redirect to Calendar.aspx
            data = new meetmeEntities();

            Button btn = (Button)sender;

            System.Diagnostics.Debug.WriteLine("Button text: " + btn.Text);

            List<Members> memberstodelete = data.Members.Where(ev => ev.Group == btn.ID).ToList();

            try
            {
                data.Members.RemoveRange(memberstodelete);
                data.SaveChanges();

                data.Groups.Remove(data.Groups.Where(ev => ev.Name == btn.ID).FirstOrDefault());
                data.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
            

            groupbuttondiv.Controls.Clear();
            deletebuttondiv.Controls.Clear();

            CreateButtons();
            Response.Redirect("~/Group.aspx");
        }

        private void B_Click(object sender, EventArgs e)
        {
            //1. New Button
            //2. Test to check which group has been clicked
            //3. Set Session Variable to send to Data.ashx
            //4. Redirect to Calendar.aspx
            Button btn = (Button)sender;
            System.Diagnostics.Debug.WriteLine("Button clicked: " + btn.Text);
            Session["Group"] = btn.Text;
            HttpContext.Current.Response.Redirect("~/Calendar.aspx");
        }

        private void CreateButtons()
        {
            data = new meetmeEntities();
            List<Groups> grouplist = null;

            try {
                List<Members> members = data.Members.Where(p => p.User == User.Identity.Name).ToList();

                for (int i = 0; i < members.Count; i++)
                {
                    string group = members[i].Group;
                    grouplist = data.Groups.Where(ev => ev.Name == group || ev.Creator == User.Identity.Name).ToList();
                }

                int count = grouplist.Count;

                //Create and add buttons to ul and add ul to div
                for (int i = 0; i < count; i++)
                {
                    Button b = new Button();
                    Button d = new Button();
                    b.ID = grouplist[i].Name + i;
                    d.ID = grouplist[i].Name;

                    b.Text = grouplist[i].Name;
                    d.Text = "X";

                    b.CssClass = "GroupButton";
                    d.CssClass = "DeleteButton";

                    b.Height = 35;
                    d.Height = 35;

                    b.Width = 320;
                    d.Width = 35;

                    b.Click += B_Click;
                    d.Click += D_Click;

                    TableRow row = new TableRow();
                    TableCell cell1 = new TableCell();
                    TableCell cell2 = new TableCell();

                    cell1.Controls.Add(b);
                    cell2.Controls.Add(d);

                    row.Cells.Add(cell1);
                    row.Cells.Add(cell2);

                    ButtonTable.Rows.Add(row);
                }

            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.StackTrace); }

        }


    }
}