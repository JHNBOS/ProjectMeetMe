using DHTMLX.Scheduler.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project
{
    /// <summary>
    /// Summary description for Data
    /// </summary>
    public class Data : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            var data = new SchedulerContextDataContext();
            string group = context.Session["Group"].ToString();

            //Load events to scheduler where groupname equals groupname of those events
            context.Response.ContentType = "text/json";
            context.Response.Write(
                new SchedulerAjaxData(data.Events.Where(ev => ev.group == group))
                );
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}