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


        [MvcAuthorize(PermissionConst.CanPlanCreate)]
        [ImportModelData(typeof(PlanCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            var viewModel = await _planFactory.PrepareCreateViewModelAsync();
            return View(MVC.Plan.Views.Create, viewModel);
        }


        [HttpPost]
        [MvcAuthorize(PermissionConst.CanPlanCreate)]
        public virtual async Task<ActionResult> Create(PlanCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);
           
            await _planService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Plan.Create());
        }


        [MvcAuthorize(PermissionConst.CanPlanDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _planService.DeleteByIdAsync(id);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanPlanEdit)]
        [ImportModelData(typeof(PlanEditViewModel))]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _planFactory.PrepareEditViewModelAsync(id.Value);
            return View(MVC.Plan.Views.Edit, viewModel);
        }


        [HttpPost]
        [MvcAuthorize(PermissionConst.CanPlanEdit)]
        public virtual async Task<ActionResult> Edit(PlanEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _planService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Plan.Edit(viewModel.Id));
        }


        [MvcAuthorize(PermissionConst.CanPlanList)]
        public virtual async Task<ActionResult> List(PlanSearchRequest request)
        {
            var viewModel = await _planFactory.PrepareListViewModelAsync(request);
            return View(MVC.Plan.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}