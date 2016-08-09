using DHTMLX.Scheduler;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class Calendar : System.Web.UI.Page
    {
        //1. Scheduler
        //2. Database context
        //3. Current group
        //4. Current user
        public DHXScheduler Scheduler { get; set; }
        public meetmeEntities data = new meetmeEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            //1. Database context
            //2. Current user
            //3. Group
            //4. AspNetUser
            data = new meetmeEntities();
            string user = User.Identity.Name;
            string group = Session["Group"].ToString();
            AspNetUsers CurrentUser = data.AspNetUsers.Where(ev => ev.UserName == user).FirstOrDefault();

            //Set title above calendar to show group
            GroupTitle.InnerText = group;

            //Groupmembers
            groupmembers.Controls.Clear();
            deletebuttondiv.Controls.Clear();
            CreateButtons();

            //Add member button
            Button AddMemButton = new Button();
            AddMemButton.Click += AddMemButton_Click;
            AddMemButton.ID = group;
            AddMemButton.Text = "Add Member";
            AddMemButton.CssClass = "btn btn-default AddM";

            addmembersdiv.Controls.Add(AddMemButton);

            //Scheduler settings
            this.Scheduler = new DHXScheduler();
            Scheduler.InitialDate = DateTime.Now;// the initial data of Scheduler
            Scheduler.Config.first_hour = 0;//the minimum value of the hour scale
            Scheduler.Config.last_hour = 24;//the maximum value of the hour scale
            Scheduler.Config.time_step = 5;//the scale interval for the time selector in the lightbox
            Scheduler.Config.limit_time_select = true;// sets the max and min values for the time selector in the lightbox to the values of the last_hour and first_hour options
            Scheduler.Config.update_render = true;
            Scheduler.LoadData = true;
            Scheduler.DataAction = this.ResolveUrl("~/Data.ashx");// the handler which defines loading data to Scheduler
            Scheduler.SaveAction = this.ResolveUrl("~/Save.ashx");// the handler which defines create/update/delete logic
            Scheduler.EnableDataprocessor = true;
            Scheduler.Data.DataProcessor.UpdateFieldsAfterSave = true;
            Scheduler.Templates.event_header = "{start_date:date(%H:%i)} - {end_date:date(%H:%i)}";
            Scheduler.Templates.event_text = "<b>{creator}:</b> <br /> {text}";


        }

        private void AddMemButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Session["AddContact"] = btn.ID;
            HttpContext.Current.Response.Redirect("~/AddContacts.aspx");
        }

        private void CreateButtons()
        {
            //1. Group
            string group = Session["Group"].ToString();

            //Show members of this group.
            List<Members> memberlist = data.Members.Where(ev => ev.Group == group).ToList();
            List<AspNetUsers> userlist = data.AspNetUsers.ToList();

            groupmembers.Controls.Add(new LiteralControl("<ul style='list-style-type:none;'>"));

            for (int i = 0; i < memberlist.Count; i++)
            {
                AspNetUsers asp = null;

                if (userlist[i].UserName == memberlist[i].User)
                {
                    asp = userlist[i];
                }

                string color = asp.Colour;

                groupmembers.Controls.Add(new LiteralControl("<li style='margin-bottom: 5px;'>"));
                groupmembers.Controls.Add(new LiteralControl("<i class='glyphicon glyphicon-calendar' style='color:" + color + ";'></i><span style='font-size: 17px;'>" + " " + asp.Firstname + " " + asp.Lastname + "</span>"));
                groupmembers.Controls.Add(new LiteralControl("<li>"));

                //Button m = new Button();
                Button d = new Button();
                //m.ID = asp.UserName + i;
                d.ID = asp.UserName;

                //m.Text = asp.Firstname + " " + asp.Lastname;
                d.Text = "X";

                //string color = asp.Colour;
                //m.BorderColor = System.Drawing.ColorTranslator.FromHtml(color);
                //m.BorderStyle = BorderStyle.Solid;
                //m.BorderWidth = 4;

                //m.CssClass = "GroupmemberButton";
                d.CssClass = "MDeleteButton";

                //m.Height = 35;
                d.Height = 24;

                //m.Width = 200;
                d.Width = 24;

                d.Click += D_Click;

                //groupmembers.Controls.Add(m);
                deletebuttondiv.Controls.Add(d);
            }

            groupmembers.Controls.Add(new LiteralControl("</ul>"));

        }

        private void D_Click(object sender, EventArgs e)
        {
            //1. New Button
            //2. Database context
            //3. Group

            Button btn = (Button)sender;
            data = new meetmeEntities();
            string group = Session["Group"].ToString();

            try
            {
                //List of members
                List<Members> memberstodelete = data.Members.Where(ev => ev.User == btn.ID).ToList();

                data.Members.RemoveRange(memberstodelete);
                data.SaveChanges();

                groupmembers.Controls.Clear();
                deletebuttondiv.Controls.Clear();

                CreateButtons();
                Response.Redirect("~/Calendar.aspx");
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine(ex.StackTrace); }
        }

    }

}