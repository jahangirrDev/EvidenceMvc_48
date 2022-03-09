using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EvidenceMvc_48.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoute(RouteCollection route)
        {
            route.IgnoreRoute("{resource}.axd/{*pathInfo}");

            route.MapRoute(name: "Default", url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });

        }
    }
}