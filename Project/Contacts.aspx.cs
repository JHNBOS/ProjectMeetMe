﻿using System;
using System.Collections.Generic;
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

                data.Members.InsertOnSubmit(m);
                data.SubmitChanges();
            }
            
            Response.Redirect("~/Group.aspx");
        }

        private void ListMembers()
        {
            //Show members of this group.
            List<AspNetUser> memberlist = data.AspNetUsers.ToList();

            foreach (var member in memberlist)
            {
                string name = member.UserName;
                ContaxtCheckBoxList.Items.Add(new ListItem(name));
            }            
        }

        private void LoadGroupsDDL()
        {
            List<Group> groups = data.Groups.ToList();

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