using Advertise.Service.Factories.Companies;
using Advertise.Service.Factories.Home;
using Advertise.Service.Factories.Users;
using MvcSiteMapProvider;
using Nito.AsyncEx;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class ProfileController : BaseController
    {
        #region Private Fields

        private readonly ICompanyFactory _companyFactory;
        private readonly IHomeFactory _homeFactory;
        private readonly IUserFactory _userFactory;

        #endregion Private Fields

        #region Public Constructors

        public ProfileController(IHomeFactory homeFactory, IUserFactory userFactory, ICompanyFactory companyFactory)
        {
            _homeFactory = homeFactory;
            _userFactory = userFactory;
            _companyFactory = companyFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcSiteMapNode(ParentKey = "Public_Home_Index", Title = "پروفایل", Key = "Profile_Home_Index")]
        public virtual async Task<ActionResult> Dashboard()
        {
            var viewModel = await _homeFactory.PrepareProfileViewModelAsync();
            return View(MVC.Profile.Views.Dashboard, viewModel);
        }


        [ChildActionOnly]
        public virtual ActionResult Header()
        {
            var viewModel = AsyncContext.Run(_userFactory.PrepareHeaderViewModelAsync);
            return PartialView(MVC.Shared.Views._ProfileHeader, viewModel);
        }


        [ChildActionOnly]
        public virtual ActionResult Menu()
        {
            var viewModel = AsyncContext.Run(_companyFactory.PrepareProfileMenuViewModelAsync);
            return PartialView(MVC.Shared.Views._ProfileMenu, viewModel);
        }

        #endregion Public Methods
    }
}