using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class AddMembers : System.Web.UI.Page
    {
        public SchedulerContextDataContext data { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            memberButton.Click += MemberButton_Click;

            if (!IsPostBack)
            {
                LoadGroupsDDL();
                LoadUsersDDL();
            }
            
        }

        private void LoadGroupsDDL()
        {
            data = new SchedulerContextDataContext();
            List<Group> groups = data.Groups.ToList();

            //Add empty listitem
            GroupsDropDown.Items.Add(new ListItem(""));

            //Add listitems with groupnames
            foreach (var group in groups)
            {
                string groupname = group.Name;
                GroupsDropDown.Items.Add(new ListItem(groupname));
            }

        }

        private void LoadUsersDDL()
        {
            data = new SchedulerContextDataContext();
            List<AspNetUser> users = data.AspNetUsers.ToList();

            //Add empty listitem
            UsersDropDown.Items.Add(new ListItem(""));

            //Add listitems with usernames
            foreach (var user in users)
            {
                string username = user.UserName;
                UsersDropDown.Items.Add(new ListItem(username));
            }

        }

        private void MemberButton_Click(object sender, EventArgs e)
        {
            string groupname = GroupsDropDown.SelectedValue;
            string username = UsersDropDown.SelectedValue;

            Member m = new Member();
            m.Group = groupname;
            m.User = username;

            data = new SchedulerContextDataContext();
            data.Members.InsertOnSubmit(m);
            data.SubmitChanges();

            Response.Redirect("~/Groups.aspx");
        }

    }
}