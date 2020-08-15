using System.Web.Mvc;
using Advertise.Service.Managers.Caching;

namespace Advertise.Web.Framework.Filters
{
    public class NoBrowserCacheAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.DisableBrowserCache();
            base.OnResultExecuting(filterContext);
        }
    }
}
