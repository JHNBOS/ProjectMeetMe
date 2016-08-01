using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class CreateGroup : System.Web.UI.Page
    {
        //1. Get name of current user
        //2. Database context
        string user = HttpContext.Current.User.Identity.Name;
        SchedulerContextDataContext data = new SchedulerContextDataContext();

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
            Group g = new Group();
            g.Name = GroupNameBox.Text;
            g.Creator = user;

            Member m = new Member();
            m.Group = g.Name;
            m.User = user;

            data.Groups.InsertOnSubmit(g);
            data.Members.InsertOnSubmit(m);
            data.SubmitChanges();

            Response.Redirect("~/Group.aspx");
        }
    }
}