using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Project
{
    public partial class Contacts : System.Web.UI.Page
    {
        meetmeEntities data = new meetmeEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            AddContactButton.Click += AddContactButton_Click;

            if (!IsPostBack)
            {
                ListMembers();
            }
        }

        private void AddContactButton_Click(object sender, EventArgs e)
        {
            string groupname = Session["AddContact"].ToString();
            List<string> selected_users = new List<string>();

            foreach (ListItem item in ContaxtCheckBoxList.Items)
            {
                if (item.Selected)
                    selected_users.Add(item.Value);
            }

            foreach (var user in selected_users)
            {
                Members m = new Members();
                m.Group = groupname;
                m.User = user;

                try
                {
                    data.Members.Add(m);
                    data.SaveChanges();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Contact is already added to this group!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    System.Diagnostics.Debug.WriteLine(ex.StackTrace);

                }
            }

            Response.Redirect("~/Group.aspx");
        }

        private void ListMembers()
        {
            //Show members of this group.
            //1. Get all members
            //2. Current user
            //3. Remove current user from list
            string groupname = Session["AddContact"].ToString();

            List<Members> members = data.Members.Where(ev => ev.Group == groupname).ToList();
            List<AspNetUsers> memberlist = null;

            try
            {

                for (int i = 0; i < members.Count; i++)
                {
                    string username = members[i].User;
                    memberlist = data.AspNetUsers.Where(ep => ep.UserName != username).ToList();
                }

                AspNetUsers current = data.AspNetUsers.Where(ev => ev.UserName == HttpContext.Current.User.Identity.Name).FirstOrDefault();


                memberlist.Remove(current);

                foreach (var member in memberlist)
                {
                    string name = member.UserName;
                    string first = member.Firstname;
                    string last = member.Lastname;

                    ListItem item = new ListItem();
                    item.Text = first + " " + last + " - " + name;
                    item.Value = name;

                    ContaxtCheckBoxList.Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Member cannot be removed from group/Member is already removed!");
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }

        }
    }
}