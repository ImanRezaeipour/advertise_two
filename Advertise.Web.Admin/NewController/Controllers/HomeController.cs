using System;
using Advertise.Service.Factories.Categories;
using Advertise.Service.Factories.Companies;
using Advertise.Service.Factories.Home;
using Advertise.Service.Factories.Users;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using Nito.AsyncEx;
using System.Threading.Tasks;
using System.Web.Mvc;
using Advertise.Core.Models.CompanyVideo;

namespace Advertise.Web.Controllers
{

    public partial class HomeController : BaseController
    {
        #region Private Fields

        private readonly ICategoryFactory _categoryFactory;
        private readonly ICompanyFactory _companyFactory;
        private readonly IHomeFactory _homeFactory;
        private readonly IUserFactory _userFactory;

        #endregion Private Fields

        #region Public Constructors

     
        public HomeController(ICategoryFactory categoryFactory, ICompanyFactory companyFactory, IHomeFactory homeFactory, IUserFactory userFactory)
        {
            _categoryFactory = categoryFactory;
            _companyFactory = companyFactory;
            _homeFactory = homeFactory;
            _userFactory = userFactory;
        }

        #endregion Public Constructors

        #region Public Methods

      
        [NoBrowserCache]
        [SkipRemoveWhiteSpaces]
        public virtual CaptchaImageResult CaptchaImage(string rndDate)
        {
            return new CaptchaImageResult();
        }

    
        public virtual async Task<ActionResult> Index()
        {
            return RedirectToAction(MVC.Home.LandingPage());
        }


        [MvcSiteMapNode(ParentKey = "", Title = "خانه", Key = "Public_Home_Index")]
        public virtual async Task<ActionResult> LandingPage()
        {
            var viewModel = await _homeFactory.PrepareLandingPageViewModelAsync();
            return View(MVC.Home.Views.LandingPage, viewModel);
        }


        public virtual async Task<ActionResult> LogList()
        {
            return Redirect("/elmah.axd");
        }


        [ChildActionOnly]
        public virtual ActionResult MainMenu()
        {
            var viewModel = AsyncContext.Run(_categoryFactory.PrepareMainMenuViewModelAsync);
            return PartialView(MVC.Shared.Views.SiteLayout._MainMenu, viewModel);
        }


        [ChildActionOnly]
        public virtual ActionResult MobileMenu()
        {
            var viewModel = AsyncContext.Run(_categoryFactory.PrepareMainMenuViewModelAsync);
            return PartialView(MVC.Shared.Views.SiteLayout._SideMenuLeft, viewModel);
        }

     
        public virtual async Task<ActionResult> SetLang(string lang)
        {
            switch (lang)
            {
                case "fa":
                    SetCulture("fa-IR");
                    break;

                case "en":
                    SetCulture("en-US");
                    break;

                case "ar":
                    SetCulture("ar-SA");
                    break;

                default:
                    SetCulture("fa-IR");
                    break;
            }

            return RedirectToAction(MVC.Home.LandingPage());
        }


        [ChildActionOnly]
        public virtual ActionResult SideMenuHeader()
        {
            var viewModel = AsyncContext.Run(_userFactory.PrepareHeaderViewModelAsync);
            return PartialView(MVC.Shared.Views.SiteLayout._SideMenuHeader, viewModel);
        }


        [ChildActionOnly]
        public virtual ActionResult SideMenuRight()
        {
            var viewModel = AsyncContext.Run(_companyFactory.PrepareProfileMenuViewModelAsync);
            return PartialView(MVC.Shared.Views.SiteLayout._SideMenuRight, viewModel);
        }

        #endregion Public Methods
    }
}