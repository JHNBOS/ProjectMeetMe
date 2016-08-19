using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Project
{
    public partial class CreateGroup : System.Web.UI.Page
    {
        //1. Get name of current user
        //2. Database context
        string user = HttpContext.Current.User.Identity.Name;
        meetmeEntities data = new meetmeEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Set eventhandler of button
            CreateGroupButton.Click += CreateGroupButton_Click;
        }

        private void CreateGroupButton_Click(object sender, EventArgs e)
        {
            //1. Create new group
            //2. Assign name to this group
            //3. Assign name of current user to this group
            //4-5. Add this group to database
            try
            {
                Groups g = new Groups();
                g.Name = GroupNameBox.Text;
                g.Creator = user;

                Members m = new Members();
                m.Group = g.Name;
                m.User = user;
            
                data.Groups.Add(g);
                data.Members.Add(m);
                data.SaveChanges();
            }
            catch (Exception ex)
            {
                Message message = new Message();
                message.Show("Unable to create group!" + "\n" + "Group with the same name already exists?");
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }

            Response.Redirect("~/GroupCalendars.aspx");
        }
    }
}