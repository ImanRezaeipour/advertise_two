using Advertise.Core.Models.AdsOption;
using Advertise.Core.Types;
using Advertise.Service.Factories.Adses;
using Advertise.Service.Services.Ads;
using Advertise.Service.Services.Permissions;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Advertise.Core.Constants;

namespace Advertise.Web.Controllers
{
    public partial class AdsOptionController : Controller
    {

        #region Private Fields

        private readonly IAdsOptionFactory _adsOptionFactory;
        private readonly IAdsOptionService _adsOptionService;

        #endregion Private Fields

        #region Public Constructors

        public AdsOptionController(IAdsOptionService adsOptionService, IAdsOptionFactory adsOptionFactory)
        {
            _adsOptionService = adsOptionService;
            _adsOptionFactory = adsOptionFactory;
        }

        #endregion Public Constructors

        #region Public Methods

        [MvcAuthorize(PermissionConst.CanAdsOptionCreate)]
        public virtual async Task<ActionResult> Create()
        {
            var viewModel = await _adsOptionFactory.PrepareCreateViewModelAsync();
            return View(MVC.AdsOption.Views.Create, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanAdsOptionCreate)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public virtual async Task<ActionResult> Create(AdsOptionCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _adsOptionService.CreateByViewModelAsync(viewModel);

            this.MessageSuccess("عملیات موفق");
            return RedirectToAction(MVC.AdsOption.Create());
        }



        [MvcAuthorize(PermissionConst.CanAdsOptionEdit)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public virtual async Task<ActionResult> Edit(AdsOptionEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _adsOptionService.EditByViewModelAsync(viewModel);

            this.MessageSuccess("عملیات موفق");
            return RedirectToAction(MVC.AdsOption.List());
        }


        [MvcAuthorize(PermissionConst.CanAdsOptionEdit)]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _adsOptionFactory.PrepareEditViewModelAsync(id.Value);
            return View(MVC.AdsOption.Views.Edit, viewModel);
        }

      
        [MvcAuthorize(PermissionConst.CanAdsOptionGetOptionAjax)]
        public virtual async Task<JsonResult> GetOptionAjax(AdsType type, AdsPositionType? position)
        {
            var result = await _adsOptionService.GetAsSelectListAsync(type, position);
            return Json(AjaxResult.Succeeded(result), JsonRequestBehavior.AllowGet);
        }

        
        [MvcAuthorize(PermissionConst.CanAdsOptionGetPriceAjax)]
        public virtual async Task<JsonResult> GetPriceAjax(Guid? optionId, DurationType? durationType)
        {
            if (optionId == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest));

            if (durationType == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest));

            var finalPrice = await _adsOptionService.GetPriceByIdAsync(optionId.Value, durationType.Value);
            return Json(AjaxResult.Succeeded(finalPrice), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanAdsOptionList)]
        public virtual async Task<ActionResult> List(AdsOptionSearchRequest request)
        {
            var viewModel = await _adsOptionFactory.PrepareListViewModelAsync(request);
            return View(MVC.AdsOption.Views.List, viewModel);
        }

        #endregion Public Methods

    }
}