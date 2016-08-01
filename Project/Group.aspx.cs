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
        SchedulerContextDataContext data;

        protected void Page_Load(object sender, EventArgs e)
        {
            groupbuttondiv.Controls.Clear();
            deletebuttondiv.Controls.Clear();

            CreateButtons();
        }

        private void D_Click(object sender, EventArgs e)
        {
            //1. New Button
            //2. Test to check which group has been clicked
            //3. Set Session Variable to send to Data.ashx
            //4. Redirect to Calendar.aspx
            data = new SchedulerContextDataContext();

            Button btn = (Button)sender;

            System.Diagnostics.Debug.WriteLine("Button text: " + btn.Text);

            List<Member> memberstodelete = data.Members.Where(ev => ev.Group == btn.ID).ToList();

            data.Members.DeleteAllOnSubmit(memberstodelete);
            data.SubmitChanges();

            data.Groups.DeleteOnSubmit(data.Groups.Where(ev => ev.Name == btn.ID).FirstOrDefault());
            data.SubmitChanges();

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
            data = new SchedulerContextDataContext();
            List<Group> grouplist = data.Groups.ToList();

            //Create and add buttons to ul and add ul to div
            for (int i = 0; i < grouplist.Count; i++)
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

                b.Width = 200;
                d.Width = 35;

                b.Click += B_Click;
                d.Click += D_Click;

                groupbuttondiv.Controls.Add(b);
                groupbuttondiv.Controls.Add(new LiteralControl("<br />"));

                deletebuttondiv.Controls.Add(d);
                deletebuttondiv.Controls.Add(new LiteralControl("<br />"));

            }

        }


    }
}