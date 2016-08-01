using DHTMLX.Scheduler;
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
        SchedulerContextDataContext data;

        protected void Page_Load(object sender, EventArgs e)
        {
            //1. Database context
            //2. Current user
            //3. Group
            //4. AspNetUser
            data = new SchedulerContextDataContext();
            string user = User.Identity.Name;
            string group = Session["Group"].ToString();
            AspNetUser CurrentUser = data.AspNetUsers.Where(ev => ev.UserName == user).FirstOrDefault();


            //Set title above calendar to show group
            GroupTitle.InnerText = group;

            //Groupmembers
            groupmembers.Controls.Clear();
            deletebuttondiv.Controls.Clear();
            CreateButtons();

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

        private void CreateButtons()
        {
            //1. Database context
            //2. Group
            data = new SchedulerContextDataContext();
            string group = Session["Group"].ToString();


            //Show members of this group.
            List<Member> memberlist = data.Members.Where(ev => ev.Group == group).ToList();

            for (int i = 0; i < memberlist.Count; i++)
            {
                Button m = new Button();
                Button d = new Button();
                m.ID = memberlist[i].User + i;
                d.ID = memberlist[i].User;

                m.Text = memberlist[i].User;
                d.Text = "X";

                m.CssClass = "GroupmemberButton";
                d.CssClass = "DeleteButton";

                m.Height = 35;
                d.Height = 35;

                m.Width = 200;
                d.Width = 35;

                d.Click += D_Click;
                
                groupmembers.Controls.Add(m);
                groupmembers.Controls.Add(new LiteralControl("<br />"));

                deletebuttondiv.Controls.Add(d);
                deletebuttondiv.Controls.Add(new LiteralControl("<br />"));

            }
        }

        private void D_Click(object sender, EventArgs e)
        {
            //1. New Button
            //2. Database context
            //3. Group
           
            Button btn = (Button)sender;
            data = new SchedulerContextDataContext();
            string group = Session["Group"].ToString();

            //List of members
            List<Member> memberstodelete = data.Members.Where(ev => ev.User == btn.ID).ToList();

            data.Members.DeleteAllOnSubmit(memberstodelete);
            data.SubmitChanges();

            groupmembers.Controls.Clear();
            deletebuttondiv.Controls.Clear();

            CreateButtons();
            Response.Redirect("~/Calendar.aspx");
        }
    }

}