using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

namespace Handler
{    
    public class BaseHandler : IRouteHandler
    {
        dynamic Handler;
        UrlPattern pattern = new UrlPattern();

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            pattern.FirstLevel = requestContext.RouteData.Values["FirstLevel"] as string; ;
            pattern.SecondLevel = requestContext.RouteData.Values["SecondLevel"] as string;
            pattern.ThirdLevel = requestContext.RouteData.Values["ThirdLevel"] as string; ;
            pattern.FourthLevel = requestContext.RouteData.Values["FourthLevel"] as string;
            pattern.FifthLevel = requestContext.RouteData.Values["FifthLevel"] as string;

            if (String.Equals("administration", pattern.FirstLevel, StringComparison.CurrentCultureIgnoreCase))
                Handler = new AdminHandler();
            else
                Handler = new SiteHandler();

            return Handler.GetHttpHandler(requestContext, pattern);
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class UrlPattern
    {
        /// <summary>
        /// 
        /// </summary>
        public string FirstLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SecondLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ThirdLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FourthLevel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FifthLevel { get; set; }
    }
}
