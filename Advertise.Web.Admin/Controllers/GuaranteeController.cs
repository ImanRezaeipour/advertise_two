using Advertise.Core.Models.Guarantee;
using Advertise.Service.Services.Guarantees;
using Advertise.Web.Framework.Extensions;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Advertise.Core.Constants;
using Advertise.Service.Factories.Guarantee;
using Advertise.Service.Services.Permissions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;

namespace Advertise.Web.Controllers
{
    public partial class GuaranteeController : Controller
    {
        #region Private Fields

        private readonly IGuaranteeFactory _guaranteeFactory;
        private readonly IGuaranteeService _guaranteeService;

        #endregion Private Fields

        #region Public Constructors

        public GuaranteeController(IGuaranteeService guaranteeService, IGuaranteeFactory guaranteeFactory)
        {
            _guaranteeService = guaranteeService;
            _guaranteeFactory = guaranteeFactory;
        }

        #endregion Public Constructors

        #region Public Methods

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanGuaranteeCreate)]
        public virtual async Task<ActionResult> Create(GuaranteeCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

           await _guaranteeService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Guarantee.Create());
        }

        [MvcAuthorize(PermissionConst.CanGuaranteeCreate)]
        public virtual async Task<ActionResult> Create()
        {
            return View(MVC.Guarantee.Views.Create);
        }


        [MvcAuthorize(PermissionConst.CanGuaranteeEdit)]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _guaranteeFactory.PrepareEditViewModelAsync(id.Value);
            return View(MVC.Guarantee.Views.Edit, viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanGuaranteeEdit)]
        public virtual async Task<ActionResult> Edit(GuaranteeEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _guaranteeService.EditByViewMoodelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Guarantee.Edit());
        }

        [MvcAuthorize(PermissionConst.CanGuaranteeDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest),JsonRequestBehavior.AllowGet);

            await _guaranteeService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        [MvcAuthorize(PermissionConst.CanGuaranteeList)]
        public virtual async Task<ActionResult> List(GuaranteeSearchRequest request)
        {
            var viewModel = await _guaranteeFactory.PrepareListViewModelAsync(request);
            return View(MVC.Guarantee.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}