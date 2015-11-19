using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Filters;
using System.Web.Mvc;
using CMS.Models;

namespace CMS.Controllers.Administration
{
    /// <summary>
    /// set master page dynamically for the view
    /// </summary>
    [MasterPage("Administrator/_Layout.cshtml")]
    public class MenuController : BaseController
    {
        /// <summary>
        /// return's the user to menu list page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult MenuMaster()
        {
            return View("~/Views/Administration/Menu/Menu.cshtml");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult CreateMenu()
        {
            return View("~/Views/Administration/Menu/CreateMenu.cshtml");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateMenu(Menu menu)
        {
            if (ModelState.IsValid)
            {

            }
            return View(menu);
        }
    }
}
        