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

            //Linkbutton
            LinkButton addmemberlink = new LinkButton();
            addmemberlink.CssClass = "ÄddMemberlink";
            addmemberlink.ForeColor = System.Drawing.ColorTranslator.FromHtml("#18bc9c");
            addmemberlink.Font.Size = FontUnit.Medium;
            addmemberlink.Font.Bold = true;
            addmemberlink.Text = "Add Member";
            addmemberlink.ID = group;
            addmemberlink.Click += AddMemberLink_Click;

            groupmembers.Controls.Add(addmemberlink);

            //Create Buttons
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
            Scheduler.Extensions.Add(SchedulerExtensions.Extension.QuickInfo);
            Scheduler.Templates.event_header = "{start_date:date(%H:%i)} - {end_date:date(%H:%i)}";
            Scheduler.Templates.event_text = "<b>{creator}:</b> {text}";
            Scheduler.BeforeInit.Add(string.Format("initResponsive({0})", Scheduler.Name));


        }

        private void AddMemberLink_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            Session["AddContact"] = btn.ID;
            HttpContext.Current.Response.Redirect("~/AddContacts.aspx");
        }

        private void CreateButtons()
        {
            //1. Group
            string group = Session["Group"].ToString();

            //Show members of this group.
            //Get list of all users.
            List<Members> memberlist = null;
            List<AspNetUsers> userlist = null;
            AspNetUsers asp = null;

            try
            {
                memberlist = data.Members.Where(ev => ev.Group == group).ToList();
                userlist = data.AspNetUsers.ToList();



                for (int i = 0; i < memberlist.Count; i++)
                {
                    if (userlist[i].UserName == memberlist[i].User)
                    {
                        asp = userlist[i];
                    }
                    else
                    {
                        asp = data.AspNetUsers.Where(ev => ev.UserName == User.Identity.Name).FirstOrDefault();
                    }
                }

            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("No members in this group!");
            }

            //Color of user
            string color = asp.Colour;

            //Delete button
            Button d = new Button();
            d.ID = asp.UserName;
            d.Text = "X";
            d.CssClass = "MDeleteButton";
            d.Height = 24;
            d.Width = 24;
            d.Click += D_Click;

            //1. Table Row
            //2 + 3. Table Cells
            TableRow row = new TableRow();
            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();

            //Width and height of cells
            cell2.Width = 120;

            cell1.Height = 30;
            cell2.Height = 30;
            cell3.Height = 30;

            //Add glyphicon with color to table
            cell1.Controls.Add(new LiteralControl("<i class='glyphicon glyphicon-calendar' style='color:" + color + ";'></i>"));

            //Add name to table
            cell2.Controls.Add(new LiteralControl("<span style='font-size: 17px;float: right;'>" + asp.Firstname + " " + asp.Lastname + "</span>"));
                
            //Add button to table
            cell3.Controls.Add(d);

            //Add cells to row
            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);

            //Add row to table
            MemberTable.Rows.Add(row);

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

                CreateButtons();
                Response.Redirect("~/Calendar.aspx");
            }
            catch (Exception ex)
            {
                Message m = new Message();
                m.Show("Cannot delete member!");
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
        }

    }

}