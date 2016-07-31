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
        public DHXScheduler Scheduler { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //1. Database context
            //2. Current user
            //3. AspNetUser
            //4. Group
            //5. Scheduler
            var data = new SchedulerContextDataContext();
            string user = User.Identity.Name;
            AspNetUser CurrentUser = data.AspNetUsers.Where(ev => ev.UserName == user).FirstOrDefault();
            string group = HttpContext.Current.Session["Group"].ToString();

            GroupTitle.InnerText = group;

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
            Scheduler.Templates.event_header = "{start_date:date(%H:%i)} - {end_date:date(%H:%i)} \n by {creator}";

            /*********************************************************************/
            //Show members of this group.
            List<Member> memberlist = data.Members.Where(ev => ev.Group == group).ToList();

            membersdiv.Controls.Add(new LiteralControl("<ul style='list-style-type: none;'>"));

            foreach (var member in memberlist)
            {
                string name = member.User;
                membersdiv.Controls.Add(new LiteralControl("<li>"));
                membersdiv.Controls.Add(new LiteralControl(name));
                membersdiv.Controls.Add(new LiteralControl("</li>"));
            }

            membersdiv.Controls.Add(new LiteralControl("</ul>"));





        }
    }

}