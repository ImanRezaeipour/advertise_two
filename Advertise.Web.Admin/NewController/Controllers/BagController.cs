using Advertise.Core.Constants;
using Advertise.Core.Models.Bag;
using Advertise.Service.Factories.Receipts;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Receipts;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class BagController : BaseController
    {

        #region Private Fields

        private readonly IBagFactory _bagFactory;
        private readonly IBagService _bagService;

        #endregion Private Fields

        #region Public Constructors

      
        public BagController(IBagService bagService, IBagFactory bagFactory)
        {
            _bagService = bagService;
            _bagFactory = bagFactory;
        }

        #endregion Public Constructors

        #region Public Methods

     
        [HttpPost]
        [MvcAuthorize(PermissionConst.CanBagChangeProductCountAjax)]
        public virtual async Task<JsonResult> ChangeProductCountAjax(Guid? productId, int? productCount)
        {
            if (productId == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            if (productCount == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _bagService.SetProductCountByIdAsync(productId.Value, productCount.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

      
        [MvcAuthorize(PermissionConst.CanBagCountAjax)]
        public virtual async Task<JsonResult> CountAjax()
        {
            var count = await _bagService.CountByCurrentUserAsync();
            return Json(AjaxResult.Succeeded(count), JsonRequestBehavior.AllowGet);
        }

      
        [MvcAuthorize(PermissionConst.CanBagCreateAjax)]
        public virtual async Task<JsonResult> CreateAjax(Guid? productId)
        {
            if (productId == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _bagService.CreateByIdAsync(productId.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

    
        [HttpPost]
        [MvcAuthorize(PermissionConst.CanBagDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? productId)
        {
            if (productId == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _bagService.DeleteByProductIdAsync(productId.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        public virtual async Task<ActionResult> Edit()
        {
            var viewModel = await _bagFactory.PrepareMyInfoViewModelAsync();
            return viewModel == null ? View(MVC.Panel.Views.Board) : View(MVC.Bag.Views.Edit, viewModel);
        }

    
        [MvcAuthorize(PermissionConst.CanBagIsExistAjax)]
        public virtual async Task<JsonResult> IsExistAjax(Guid? productId)
        {
            if (productId == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var isExist = await _bagService.IsExistByProductIdAsync(productId.Value);
            return Json(AjaxResult.Succeeded(isExist), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanBagList)]
        public virtual async Task<ActionResult> List(BagSearchRequest request)
        {
            var viewModel = await _bagFactory.PrepareListViewModelAsync(request);
            return viewModel == null ? View(MVC.Error.Views.InternalServerError) : View(MVC.Bag.Views.List, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanBagList)]
        public virtual async Task<JsonResult> ListMoreAjax(BagSearchRequest request)
        {
            var viewModel = await _bagFactory.PrepareListViewModelAsync(request);
            return Json(viewModel != null ? AjaxResult.Succeeded(RenderRazorViewToString(MVC.Bag.Views._ListMore, viewModel)) : AjaxResult.Failed(AjaxErrorStatus.InternalServerError), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanBagMyList)]
        public virtual async Task<ActionResult> MyList(BagSearchRequest request)
        {
            var viewModel = await _bagFactory.PrepareListViewModelAsync(request, true);
            return viewModel == null ? View(MVC.Error.Views.InternalServerError) : View(MVC.Bag.Views.List, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanBagMyList)]
        public virtual async Task<JsonResult> MyListMoreAjax(BagSearchRequest request)
        {
            var viewModel = await _bagFactory.PrepareListViewModelAsync(request, true);
            return Json(viewModel != null ? AjaxResult.Succeeded(RenderRazorViewToString(MVC.Bag.Views._ListMore, viewModel)) : AjaxResult.Failed(AjaxErrorStatus.InternalServerError), JsonRequestBehavior.AllowGet);
        }

    
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [HttpPost]

        public virtual async Task<ActionResult> Preview(BagUpdateMyInfoViewModel viewModel)
        {
            return View(MVC.Bag.Views.Preview);
        }

        [HttpPost]
        [MvcAuthorize(PermissionConst.CanBagToggleAjax)]
        public virtual async Task<JsonResult> ToggleAjax(Guid? productId)
        {
            if (productId == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _bagService.ToggleByCurrentUserAsync(productId.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods

    }
}