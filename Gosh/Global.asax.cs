using Gosh.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Gosh
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AddFirstTimeValues();
            
        }

        private static void AddFirstTimeValues()
        {
            using (MyDB db = new MyDB())
            {
                
            }
        }
    }
}
