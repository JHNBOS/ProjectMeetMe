using DHTMLX.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project
{
    /// <summary>
    /// Summary description for Save
    /// </summary>
    public class Save : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";// the data is passed in XML format

            //1. ?
            //2. Database context
            //3. Name of current user
            //4. User logged in?
            //5. Name of selected group
            //6. Curren ASPNetUser
            //7. Color of eventbox based on colour user has chosen.
            var action = new DataAction(context.Request.Form);
            var data = new SchedulerContextDataContext();
            var user = context.User.Identity.Name;
            Boolean allowed = context.User.Identity.IsAuthenticated;
            string group = context.Session["Group"].ToString();
            AspNetUser CurrentUser = data.AspNetUsers.Where(ev => ev.UserName == user).FirstOrDefault();
            string colour = CurrentUser.Colour;

            try
            {
                //1. New Event
                //2. Full name of user
                //3. Assign name of current user to this event
                //4. Assign name of selected group to this event
                //5. Assign color to this event
                var changedEvent = (Event)DHXEventsHelper.Bind(typeof(Event), context.Request.Form);//see details below
                string fullname = CurrentUser.FirstName + " " + CurrentUser.LastName;
                changedEvent.creator = fullname;
                changedEvent.group = group;
                changedEvent.color = colour;

                switch (action.Type)
                {
                    case DataActionTypes.Insert: // your Insert logic
                        if (allowed && changedEvent.creator == fullname)
                        {
                            data.Events.InsertOnSubmit(changedEvent);
                        }
                        else
                        {
                            action.Type = DataActionTypes.Error;
                        }
                        break;
                    case DataActionTypes.Delete: // your Delete logic
                        changedEvent = data.Events.SingleOrDefault(ev => ev.id == action.SourceId);
                        if (allowed && changedEvent.creator == fullname)
                        {
                            data.Events.DeleteOnSubmit(changedEvent);
                        }
                            
                        break;
                    default:// "update" // your Update logic
                        var updated = data.Events.SingleOrDefault(ev => ev.id == action.SourceId);
                        if (allowed && updated.creator == fullname)
                        {
                            DHXEventsHelper.Update(updated, changedEvent, new List<string>() { "id" });// see details below
                        }
                        break;
                }
                data.SubmitChanges();
                action.TargetId = changedEvent.id;
            }
            catch (Exception a)
            {
                action.Type = DataActionTypes.Error;
            }

            var result = new AjaxSaveResponse(action);
            result.UpdateField("color", colour);
            context.Response.Write(result);
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