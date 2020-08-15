using Advertise.Core.Constants;
using Advertise.Core.Models.ProductReview;
using Advertise.Service.Factories.Products;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Products;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class ProductReviewController : BaseController
    {
        #region Private Fields

        private readonly IProductReviewService _productReviewService;
        private readonly IProductReviewFactory _productReviewFactory;

        #endregion Private Fields

        #region Public Constructors


        public ProductReviewController(IProductReviewService productReviewService, IProductReviewFactory productReviewFactory)
        {
            _productReviewService = productReviewService;
            _productReviewFactory = productReviewFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanProductReviewCreate)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public virtual async Task<ActionResult> Create(ProductReviewCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            
            await _productReviewService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.ProductReview.Create());
        }


        [MvcAuthorize(PermissionConst.CanProductReviewCreate)]
        [MvcSiteMapNode(ParentKey = "Panel_ProductReview_List", Title = "ایجاد", Key = "Panel_ProductReview_Create")]
        [ImportModelData(typeof(ProductReviewCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            var viewModel = await _productReviewFactory.PrepareCreateViewModelAsync();
            return View(MVC.ProductReview.Views.Create, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanProductReviewDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _productReviewService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanProductReviewEdit)]
        [MvcSiteMapNode(ParentKey = "Panel_ProductReview_List", Title = "ویرایش", Key = "Panel_ProductReview_Edit", PreservedRouteParameters = "id")]
        [ImportModelData(typeof(ProductReviewEditViewModel))]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _productReviewFactory.PrepareEditViewModelAsync(id.Value);
            return viewModel != null ? View(MVC.ProductReview.Views.Edit, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


        [MvcAuthorize(PermissionConst.CanProductReviewEdit)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public virtual async Task<ActionResult> Edit(ProductReviewEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _productReviewService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.ProductReview.Edit(viewModel.Id));
        }


        [MvcAuthorize(PermissionConst.CanProductReviewList)]
        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "نقد و بررسی ها ", Key = "Panel_ProductReview_List")]
        public virtual async Task<ActionResult> List(ProductReviewSearchRequest request)
        {
            var viewModel = await _productReviewFactory.PrepareListViewModelAsync(request);
            return viewModel != null ? View(MVC.ProductReview.Views.List, viewModel) : View(MVC.Error.Views.InternalServerError);
        }

        #endregion Public Methods
    }
}