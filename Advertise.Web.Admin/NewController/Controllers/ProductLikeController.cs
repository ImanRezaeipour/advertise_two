using Advertise.Core.Constants;
using Advertise.Core.Models.ProductLike;
using Advertise.Service.Factories.Products;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Products;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class ProductLikeController : BaseController
    {
        #region Private Fields

        private readonly IProductLikeService _productLikeService;
        private readonly IProductLikeFactory _productLikeFactory;

        #endregion Private Fields

        #region Public Constructors

        public ProductLikeController(IProductLikeService productLikeService, IProductLikeFactory productLikeFactory)
        {
            _productLikeService = productLikeService;
            _productLikeFactory = productLikeFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        public virtual async Task<JsonResult> CountAjax(Guid? productId)
        {
            if (productId == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var count = await _productLikeService.CountByProductIdAsync(productId.Value);
            return Json(AjaxResult.Succeeded(count), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanProductLikeMyLikeList)]
        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "لیست لایک‌ها ", Key = "Profile_ProductLike_LikeListMe")]
        public virtual async Task<ActionResult> MyLikeList(ProductLikeSearchRequest request)
        {
            var viewModel = await _productLikeFactory.PrepareListViewModelAsync(request, true);
            return viewModel != null ? View(MVC.ProductLike.Views.ListMe, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


        [MvcAuthorize(PermissionConst.CanProductLikeMyLikerList)]
        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "لیست لایک‌ شده ها ", Key = "Profile_ProductLike_LikerListMe")]
        public virtual async Task<ActionResult> MyLikerList(ProductLikeSearchRequest request)
        {
            var viewModel = await _productLikeFactory.PrepareListViewModelAsync(request);
            return View(MVC.ProductLike.Views.LikerListMe, viewModel);
        }

        [MvcAuthorize(PermissionConst.CanProductLikeMyToggleAjax)]
        public virtual async Task<JsonResult> MyToggleAjax(Guid? productId)
        {
            if (productId == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _productLikeService.ToggleCurrentUserByProductIdAsync(productId.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}