using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Handler

{
    public class AdminHandler : MvcRouteHandler 
    {
        string Controller = string.Empty;
        string Action = string.Empty;

        public new IHttpHandler GetHttpHandler(RequestContext requestContext, UrlPattern pattern)
        {
            if(String.Equals("dashboard",pattern.SecondLevel,StringComparison.CurrentCultureIgnoreCase))
            {
                Controller = "Administration";
                Action = "Dashboard";
            }
            else if (String.Equals("Menu", pattern.SecondLevel, StringComparison.CurrentCultureIgnoreCase))
            {
                Controller = "Menu";
                Action = "MenuMaster";
            }
            else if (String.Equals("CreateMenu", pattern.SecondLevel, StringComparison.CurrentCultureIgnoreCase))
            {
                Controller = "Menu";
                Action = "CreateMenu";
            }

            requestContext.RouteData.Values["controller"] = Controller;
            requestContext.RouteData.Values["action"] = Action;

            return base.GetHttpHandler(requestContext);

        }
    }
}
