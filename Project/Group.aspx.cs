using System;
using System.Collections.Generic;
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
        static SchedulerContextDataContext data = new SchedulerContextDataContext();
        static List<Group> grouplist = data.Groups.ToList();
        static int count = grouplist.Count;
        Button[] buttons = new Button[count];

        protected void Page_Load(object sender, EventArgs e)
        {
            //Create and add ul to div
            groupdiv.Controls.Add(new LiteralControl("<ul style='list-style-type:none;'>"));

            //Create and add buttons to ul and add ul to div
            for (int i=0; i < grouplist.Count; i++)
            {
                
                Button b = new Button();
                b.ID = grouplist[i].Name + i;
                b.Text = grouplist[i].Name;
                b.CssClass = "GroupButton";
                b.Height = 35;
                b.Width = 200;
                b.Click += B_Click;

                buttons[i] = b;
                
                groupdiv.Controls.Add(new LiteralControl("<li>"));
                groupdiv.Controls.Add(b);
                groupdiv.Controls.Add(new LiteralControl("</li>"));
                

            }
            //Close ul
            groupdiv.Controls.Add(new LiteralControl("</ul>"));

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
    }
}