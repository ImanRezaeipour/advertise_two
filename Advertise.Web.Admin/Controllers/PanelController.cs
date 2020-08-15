using Advertise.Service.Factories.Home;
using Advertise.Service.Factories.Users;
using Advertise.Service.Services.Permissions;
using Advertise.Web.Framework.Filters;
using MvcSiteMapProvider;
using Nito.AsyncEx;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{
    public partial class PanelController : Controller
    {
        #region Private Fields

        private readonly IHomeFactory _homeFactory;
        private readonly IUserFactory _userFactory;

        #endregion Private Fields

        #region Public Constructors

       
        public PanelController(IHomeFactory homeFactory, IUserFactory userFactory)
        {
            _homeFactory = homeFactory;
            _userFactory = userFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanHomeBoardPage)]
        [MvcSiteMapNode(ParentKey = "Public_Home_Index", Title = "پنل کاربری", Key = "Panel_Home_Index")]
        public virtual async Task<ActionResult> Board()
        {
            var viewModel = await _homeFactory.PrepareDashBoardViewModelAsync();
            return View(MVC.Panel.Views.Board, viewModel);
        }


        [ChildActionOnly]
        public virtual ActionResult Header()
        {
            var viewModel = AsyncContext.Run(_userFactory.PrepareHeaderViewModelAsync);
            return PartialView(MVC.Shared.Views.SiteLayout.Panel._PanelHeader, viewModel);
        }

        #endregion Public Methods
    }
}