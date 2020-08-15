using Advertise.Core.Constants;
using Advertise.Core.Models.Plan;
using Advertise.Service.Factories.Plans;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Plans;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class PlanController : BaseController
    {
        #region Private Fields

        private readonly IPlanFactory _planFactory;
        private readonly IPlanService _planService;

        #endregion Private Fields

        #region Public Constructors

    
        public PlanController(IPlanService planService, IPlanFactory planFactory)
        {
            _planService = planService;
            _planFactory = planFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanPlanList)]
        public virtual async Task<ActionResult> List(PlanSearchRequest request)
        {
            var viewModel = await _planFactory.PrepareListViewModelAsync(request);
            return View(MVC.Plan.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}