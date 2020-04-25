using EnvisionAGreenLife.PasswordProtect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EnvisionAGreenLife
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalFilters.Filters.Add(new BasicAuthenticationAttribute("admin", "fit5120"));

        }
        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started


            //Ensure SessionID in order to prevent the folloing exception
            //when the Application Pool Recycles
            //[HttpException]: Session state has created a session id, but cannot
            //    save it because the response was already flushed by 
            string sessionId = Session.SessionID;
        }
    }
}
