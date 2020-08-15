using Advertise.Core.Models.UserBudget;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Users;
using Advertise.Web.Framework.Filters;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class UserBudgetController : Controller
    {
        #region Private Fields

        private readonly IUserBudgetService _userBudgetService;

        #endregion Private Fields

        #region Public Constructors

        public UserBudgetController(IUserBudgetService userBudgetService)
        {
            _userBudgetService = userBudgetService;
        }

        #endregion Public Constructors

        #region Public Methods

        [MvcAuthorize(PermissionConst.CanUserBudgetDetail)]
        public virtual async Task<ActionResult> Detail()
        {
            var viewModel = new UserBudgetDetailViewModel();
            return View(MVC.UserBudget.Views.Detail, viewModel);
        }

        #endregion Public Methods
    }
}