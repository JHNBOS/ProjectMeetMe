using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class Site_Mobile : System.Web.UI.MasterPage
    {
        public static meetmeEntities data = new meetmeEntities();
        public AspNetUsers CurrentUser = data.AspNetUsers.Where(ev => ev.UserName == HttpContext.Current.User.Identity.Name).SingleOrDefault();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.IsAuthenticated == false)
            {
                Grouplink.Visible = false;
                Contactlink.Visible = false;
            }
            else
            {
                Grouplink.Visible = true;
                Contactlink.Visible = true;
            }
        }
    }
}