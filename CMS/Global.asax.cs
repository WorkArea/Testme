using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.IO.Compression;
using Handler;

namespace CMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                   "LogOn", // Route name
                   "Administration", // URL with parameters
                   new { controller = "Administration", action = "Index", id = UrlParameter.Optional } // Parameter defaults
               );

            routes.Add(
            "View Page",
            new Route("{FirstLevel}/{SecondLevel}", new BaseHandler())
            {
                Constraints = new RouteValueDictionary { { "FirstLevel", @"^([A-Za-z]|[0-9]|_|-|)+$" }, { "SecondLevel", @"^([A-Za-z]|[0-9]|_|-|.|)+$" } }
            }
        );

            routes.Add(
           "View SubCategory",
           new Route("{FirstLevel}/{SecondLevel}/{ThirdLevel}", new BaseHandler())
           {
               Constraints = new RouteValueDictionary { { "FirstLevel", @"^([A-Za-z]|[0-9]|_|-|)+$" }, { "SecondLevel", @"^([A-Za-z]|[0-9]|_|-|)+$" }, { "ThirdLevel", @"^([A-Za-z]|[0-9]|_|-|.|)+$" } }
           }
       );

            routes.Add(
              "View Topic1",
              new Route("{FirstLevel}/{SecondLevel}/{ThirdLevel}/{FourthLevel}", new BaseHandler())
              {
                  Constraints = new RouteValueDictionary { { "FirstLevel", @"^([A-Za-z]|[0-9]|_|-|)+$" }, { "SecondLevel", @"^([A-Za-z]|[0-9]|_|-|)+$" }, { "ThirdLevel", @"^([A-Za-z]|[0-9]|_|-|)+$" }, { "FourthLevel", @"^([A-Za-z]|[0-9]|_|-|.|)+$" } }
              }
              );

            routes.Add(
              "View Page1",
              new Route("{FirstLevel}/{SecondLevel}/{ThirdLevel}/{FourthLevel}/{FifthLevel}", new BaseHandler())
              {
                  Constraints = new RouteValueDictionary { { "FirstLevel", @"^([A-Za-z]|[0-9]|_|-|)+$" }, { "SecondLevel", @"^([A-Za-z]|[0-9]|_|-|)+$" }, { "ThirdLevel", @"^([A-Za-z]|[0-9]|_|-|)+$" }, { "FourthLevel", @"^([A-Za-z]|[0-9]|_|-|.|)+$" }, { "FifthLevel", @"^([A-Za-z]|[0-9]|_|-|.|)+$" } }
              }
              );

            routes.Add(
              "View SixPage",
              new Route("{FirstLevel}/{SecondLevel}/{ThirdLevel}/{FourthLevel}/{FifthLevel}/{SixthLevel}", new BaseHandler())
              {
                  Constraints = new RouteValueDictionary { { "FirstLevel", @"^([A-Za-z]|[0-9]|_|-|)+$" }, { "SecondLevel", @"^([A-Za-z]|[0-9]|_|-|)+$" }, { "ThirdLevel", @"^([A-Za-z]|[0-9]|_|-|)+$" }, { "FourthLevel", @"^([A-Za-z]|[0-9]|_|-|.|)+$" }, { "FifthLevel", @"^([A-Za-z]|[0-9]|_|-|.|)+$" }, { "SixthLevel", @"^([A-Za-z]|[0-9]|_|-|.|)+$" } }
              }
              );

        }
        /// <summary>
        /// 
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {

            string contentType = HttpContext.Current.Response.ContentType;

            if (contentType == "text/html" || contentType == "text/css")
            {
                HttpContext.Current.Response.Cache.VaryByHeaders["Accept-Encoding"] = true;
            }
            else
            {
                HttpResponse Response = HttpContext.Current.Response;
                if (IsCompressionAllowed())
                {
                    string AcceptEncoding = HttpContext.Current.Request.Headers["Accept-Encoding"];

                    if (AcceptEncoding.Contains("deflate"))
                    {
                        Response.Filter = new DeflateStream(Response.Filter, CompressionMode.Compress);
                        Response.AppendHeader("Content-Encoding", "deflate");
                    }
                    else
                    {
                        Response.Filter = new GZipStream(Response.Filter, CompressionMode.Compress);
                        Response.AppendHeader("Content-Encoding", "gzip");
                    }
                }
                Response.AppendHeader("Vary", "Content-Encoding");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsCompressionAllowed()
        {
            string AcceptEncoding = HttpContext.Current.Request.Headers["Accept-Encoding"];
            if (!string.IsNullOrEmpty(AcceptEncoding))
            {
                if (AcceptEncoding.Contains("gzip") || AcceptEncoding.Contains("deflate"))
                    return true; ////If browser supports encoding
            }
            return false;
        }

    }
}