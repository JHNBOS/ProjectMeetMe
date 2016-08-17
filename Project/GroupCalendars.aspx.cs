﻿using DHTMLX.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class GroupCalendars : System.Web.UI.Page
    {
        //1. Scheduler object
        //2. Database context
        public DHXScheduler Scheduler { get; set; }
        public meetmeEntities data = new meetmeEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            //1. Username
            //2. ASP NET User object
            string user = User.Identity.Name;
            AspNetUsers CurrentUser = data.AspNetUsers.Where(ev => ev.UserName == user).FirstOrDefault();

            //Methods to run
            CreateGroupButtons();

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
            Scheduler.Extensions.Add(SchedulerExtensions.Extension.QuickInfo);
            Scheduler.Templates.event_header = "{start_date:date(%H:%i)} - {end_date:date(%H:%i)}";
            Scheduler.Templates.event_text = "<b>{creator}:</b> {text}";
            Scheduler.BeforeInit.Add(string.Format("initResponsive({0})", Scheduler.Name));

        }

        private void CreateGroupButtons()
        {
            List<Groups> grouplist = null;

            try
            {
                List<Members> members = data.Members.Where(p => p.User == User.Identity.Name).ToList();

                for (int i = 0; i < members.Count; i++)
                {
                    string group = members[i].Group;
                    grouplist = data.Groups.Where(ev => ev.Name == group || ev.Creator == User.Identity.Name).ToList();
                }

                int count = grouplist.Count;

                //Create and add buttons to div
                for (int i = 0; i < count; i++)
                {
                    Button b = new Button();
                    b.ID = grouplist[i].Name + i;
                    b.Text = grouplist[i].Name;
                    b.CssClass = "GroupButton";
                    b.Click += B_Click;

                    TableRow row = new TableRow();
                    TableCell cell = new TableCell();
                    

                    cell.Controls.Add(b);
                    row.Cells.Add(cell);
                    GroupListTable.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
        }

        private void B_Click(object sender, EventArgs e)
        {
            //1. New Button
            //2. Set Session Variable to send to Data.ashx
            //3. Set title above calendar to show group
            //4. Add Render of Scheduler to div
            Button btn = (Button)sender;
            Session["Group"] = btn.Text;
            GroupTitle.InnerText = btn.Text;
            scheduler_here.InnerHtml = this.Scheduler.Render();
        }

    }
}