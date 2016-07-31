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
            //Database context
            var data = new SchedulerContextDataContext();

            //Current user
            string user = User.Identity.Name;

            //AspNetUser
            AspNetUser CurrentUser = data.AspNetUsers.Where(ev => ev.UserName == user).FirstOrDefault();

            //Scheduler
            this.Scheduler = new DHXScheduler();
            //Scheduler.Localization.Set(SchedulerLocalization.Localizations.Dutch);
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

            Scheduler.Config.displayed_event_color = CurrentUser.Colour;
            Scheduler.Templates.event_header = "{start_date:date(%H:%i)} - {end_date:date(%H:%i)} \n by {creator}";
   
        }
    }

}