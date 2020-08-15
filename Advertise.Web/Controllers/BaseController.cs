using System;
using System.IO;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Advertise.Service.Managers.Localization;

namespace Advertise.Web.Controllers
{

    public partial class BaseController : Controller
    {
        #region Public Methods

     
        [NonAction]
        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        #endregion Public Methods

        #region Protected Methods

      
        [ChildActionOnly]
        protected ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction(MVC.Home.ActionNames.LandingPage);
        }

        [NonAction]
        protected string RenderViewToString<T>(string viewPath, T model)
        {
            ViewData.Model = model;
            using (var writer = new StringWriter())
            {
                var view = new WebFormView(ControllerContext, viewPath);
                var vdd = new ViewDataDictionary<T>(model);
                var viewCxt = new ViewContext(ControllerContext, view, vdd, new TempDataDictionary(), writer);
                viewCxt.View.Render(viewCxt, writer);
                return writer.ToString();
            }
        }


      
        public string L(string resource, string culture = null)
        {
            return ResourceExtensions.GetLocalize(resource, culture);
        }

       
        [NonAction]
        protected void SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);

            // Save culture in a cookie
            var cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture; // update cookie value
            else
            {
                cookie = new HttpCookie("_culture")
                {
                    Value = culture,
                    Expires = DateTime.Now.AddYears(1)
                };
            }
            Response.Cookies.Add(cookie);

            // Modify current thread's cultures
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        }

      
        public string Lang(string resource, string culture = null)
        {
            return ResourceExtensions.GetLocalize(resource, culture);
        }

        #endregion Protected Methods
    }
}