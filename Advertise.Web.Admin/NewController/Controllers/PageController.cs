using MvcSiteMapProvider;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class PageController : BaseController
    {
        #region Public Methods


        [MvcSiteMapNode(ParentKey = "Public_Home_Index", Title = "درباره ما", Key = "Public_Page_About")]
        public virtual ActionResult About()
        {
            return View(MVC.Page.Views.About);
        }


        [MvcSiteMapNode(ParentKey = "Public_Home_Index", Title = "خرید و فروش", Key = "Public_Page_BuyAndSell")]
        public virtual ActionResult BuyAndSell()
        {
            return View(MVC.Page.Views.BuyAndSell);
        }


        [MvcSiteMapNode(ParentKey = "Public_Home_Index", Title = "تماس با ما", Key = "Public_Page_ContactUs")]
        public virtual ActionResult ContactUs()
        {
            return View(MVC.Page.Views.ContactUs);
        }


        [MvcSiteMapNode(ParentKey = "Public_Home_Index", Title = "تعرفه‌ها", Key = "Public_Page_Costs")]
        public virtual ActionResult Costs()
        {
            return View(MVC.Page.Views.Costs);
        }


        [MvcSiteMapNode(ParentKey = "Public_Home_Index", Title = "پرسش و پاسخ‌های متداول", Key = "Public_Page_FAQs")]
        public virtual ActionResult FAQs()
        {
            return View(MVC.Page.Views.FAQs);
        }


        [MvcSiteMapNode(ParentKey = "Public_Home_Index", Title = "چگونه به ما بپیوندید", Key = "Public_Page_HowToJoinUs")]
        public virtual ActionResult HowToJoinUs()
        {
            return View(MVC.Page.Views.HowToJoinUs);
        }


        [MvcSiteMapNode(ParentKey = "Public_Home_Index", Title = "قوانین و مقررات", Key = "Public_Page_Policy")]
        public virtual ActionResult Policy()
        {
            return View(MVC.Page.Views.Policy);
        }


        [MvcSiteMapNode(ParentKey = "Public_Home_Index", Title = "نقشه سایت", Key = "Public_Page_SiteMap")]
        public virtual ActionResult SiteMap()
        {
            return View(MVC.Page.Views.SiteMap);
        }

        #endregion Public Methods
    }
}