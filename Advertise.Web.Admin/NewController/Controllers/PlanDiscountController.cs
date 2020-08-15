using Advertise.Core.Constants;
using Advertise.Core.Models.PlanDiscount;
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

    public partial class PlanDiscountController : Controller
    {
        #region Private Fields

        private readonly IPlanDiscountFactory _planDiscountFactory;
        private readonly IPlanDiscountService _planDiscountService;

        #endregion Private Fields

        #region Public Constructors

        public PlanDiscountController(IPlanDiscountService planDiscountService, IPlanDiscountFactory planDiscountFactory)
        {
            _planDiscountService = planDiscountService;
            _planDiscountFactory = planDiscountFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [HttpPost]
        [MvcAuthorize(PermissionConst.CanPlanDiscountCreate)]
        public virtual async Task<ActionResult> Create(PlanDiscountCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _planDiscountService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.PlanDiscount.Create());
        }

       
        public virtual async Task<JsonResult> GetPercentAjax(string code)
        {
            if (code == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var planDiscountPercent = await _planDiscountService.GetPercentByCodeAsync(code);
            return Json(AjaxResult.Succeeded(planDiscountPercent), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanPlanDiscountCreate)]
        [ImportModelData(typeof(PlanDiscountCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            return View(MVC.PlanDiscount.Views.Create);
        }


        [MvcAuthorize(PermissionConst.CanPlanDiscountDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _planDiscountService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [MvcAuthorize(PermissionConst.CanPlanDiscountEdit)]
        public virtual async Task<ActionResult> Edit(PlanDiscountEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);
           
            await _planDiscountService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.PlanDiscount.List());
        }


        [MvcAuthorize(PermissionConst.CanPlanDiscountEdit)]
        [ImportModelData(typeof(PlanDiscountEditViewModel))]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _planDiscountFactory.PrepareEditViewModelAsync(id);
            return View(MVC.PlanDiscount.Views.Edit, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanPlanDiscountList)]
        public virtual async Task<ActionResult> List(PlanDiscountSearchRequest request)
        {
            var viewModel = await _planDiscountFactory.PrepareListViewModelAsync(request);
            return View(MVC.PlanDiscount.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}