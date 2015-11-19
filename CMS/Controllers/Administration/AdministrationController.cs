using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMS.Filters;

namespace CMS.Controllers
{
    public class AdministrationController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View("LogOn");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [MasterPage("Administrator/_Layout.cshtml")]
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}
