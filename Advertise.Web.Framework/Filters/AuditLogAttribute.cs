using System;
using System.Web.Mvc;

namespace Advertise.Web.Framework.Filters
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class AuditLogAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}