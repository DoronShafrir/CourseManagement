using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CourseManagement
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["globalCounter"] = 0;
            Application["inSite"] = 0;
            Application["globalCounterLogedIn"] = 0;
            Application["inSiteLogedIn"] = 0;

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session.Timeout = 5;

            /*************initialize Uer and Admin *****************/
            Session["UserName"] = null;
            Session["Admin"] = 0;

            /****************Update Counter in-site************************/
            Application["globalCounter"] = (int)Application["globalCounter"] + 1;
            Application["inSite"] = (int)Application["inSite"] + 1;
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            try
            {
                Application["inSiteLogedIn"] = (int)Application["inSiteLogedIn"] - 1;
                Application["inSite"] = (int)Application["inSite"] - 1;
            }
            catch
            {
                Application["inSiteLogedIn"] = 0;
            }

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}