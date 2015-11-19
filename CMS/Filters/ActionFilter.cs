using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Filters
{
    /// <summary>
    /// This class is used to set view's master page dynamically
    /// </summary>
    public class MasterPage : ActionFilterAttribute, IActionFilter
    {
        /// <summary>
        /// get and set the Master page path from controller's action filter
        /// </summary>
        private string _MasterPage
        {
            get;
            set;
        }
        /// <summary>
        /// set the current master page that will be used for view
        /// </summary>
        /// <param name="MasterPage"></param>
        public MasterPage(string MasterPage)
        {
            this._MasterPage = MasterPage;
        }
        /// <summary>
        /// set master page path for the view in "filtercontext" object
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var action = filterContext.Result as ViewResult;

            if (action != null && String.IsNullOrEmpty(action.MasterName) && this._MasterPage != string.Empty)
                action.MasterName = "~/Views/Shared/" + _MasterPage + "";
            else
                action.MasterName = string.Empty;

            base.OnActionExecuted(filterContext);
        }
    }
}