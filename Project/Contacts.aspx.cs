using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class Contacts : System.Web.UI.Page
    {
        SchedulerContextDataContext data = new SchedulerContextDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            AddContactButton.Click += AddContactButton_Click;

            if (!IsPostBack)
            {
                ListMembers();
                LoadGroupsDDL();
            }
        }

        private void AddContactButton_Click(object sender, EventArgs e)
        {
            string groupname = GroupDropDownList.SelectedValue;
            List<string> selected_users = new List<string>();

            foreach (ListItem item in ContaxtCheckBoxList.Items)
            {
                if (item.Selected)
                    selected_users.Add(item.Value);
            }

            foreach (var user in selected_users)
            {
                Member m = new Member();
                m.Group = groupname;
                m.User = user;

                try
                {
                    data.Members.InsertOnSubmit(m);
                    data.SubmitChanges();

                } catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.StackTrace); }
            }
            
            Response.Redirect("~/Group.aspx");
        }

        private void ListMembers()
        {
            //Show members of this group.
            //1. Get all members
            //2. Current user
            //3. Remove current user from list
            List<AspNetUser> memberlist = data.AspNetUsers.ToList();
            AspNetUser current = data.AspNetUsers.Where(ev => ev.UserName == User.Identity.Name).FirstOrDefault();

            try
            {
                memberlist.Remove(current);
            } catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.StackTrace); }

            foreach (var member in memberlist)
            {
                string name = member.UserName;
                string first = member.FirstName;
                string last = member.LastName;

                ListItem item = new ListItem();
                item.Text = first + " " + last + " - " + name;
                item.Value = name;

                ContaxtCheckBoxList.Items.Add(item);
            }            
        }

        private void LoadGroupsDDL()
        {
            string user = User.Identity.Name;
            List<Group> groups = data.Groups.Where(ev => ev.Creator == user).ToList();

            //Add empty listitem
            GroupDropDownList.Items.Add(new ListItem(""));

            //Add listitems with groupnames
            foreach (var group in groups)
            {
                string groupname = group.Name;
                GroupDropDownList.Items.Add(new ListItem(groupname));
            }

        }
    }
}