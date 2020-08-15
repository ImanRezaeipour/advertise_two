using Advertise.Core.Constants;
using Advertise.Core.Models.Ads;
using Advertise.Service.Factories.Adses;
using Advertise.Service.Services.Ads;
using Advertise.Service.Services.Permissions;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{
    public partial class AdsController : BaseController
    {
        #region Private Fields

        private readonly IAdsFactory _adsFactory;
        private readonly IAdsService _adsService;

        #endregion Private Fields

        #region Public Constructors

        public AdsController(IAdsService adsService, IAdsFactory adsFactory)
        {
            _adsService = adsService;
            _adsFactory = adsFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanAdsApproved)]
        public virtual async Task<JsonResult> ApproveAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _adsService.ApproveByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        [MvcAuthorize(PermissionConst.CanAdsCreate)]
        public virtual async Task<ActionResult> Create()
        {
            var viewModel = await _adsFactory.PrepareCreateViewModel();
            return View(MVC.Ads.Views.Create, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanAdsCreate)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public virtual async Task<ActionResult> Create(AdsCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            var result = await _adsService.CreateByViewModelAsync(viewModel);
            if (result.Succeeded)
                return Redirect(result.ReturnUrl);

            return RedirectToAction(MVC.Ads.Create());
        }


        [MvcAuthorize(PermissionConst.CanAdsCreateByAdmin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public virtual async Task<ActionResult> CreateByAdmin(AdsCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _adsService.CreateByViewModelAsync(viewModel, true);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Ads.Create());
        }

        ///
        [MvcAuthorize(PermissionConst.CanAdsEdit)]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _adsFactory.PrepareEditViewModelAsync(id.Value);
            return View(MVC.Ads.Views.Edit, viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [MvcAuthorize(PermissionConst.CanAdsEditApprove)]
        public virtual async Task<ActionResult> EditApprove(AdsEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _adsService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.AdsPayment.List());
        }

        public virtual async Task<JsonResult> GetFileAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest));

            var files = await _adsService.GetFileAsFineUploaderModelByIdAsync(id.Value);
            return Json(files, JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanAdsRejected)]
        public virtual async Task<JsonResult> RejectAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _adsService.RejectByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods

    }
}