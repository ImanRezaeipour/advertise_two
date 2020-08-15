using Advertise.Core.Constants;
using Advertise.Service.Factories.Products;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Products;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class ProductSpecificationController : BaseController
    {
        #region Private Fields

        private readonly IProductSpecificationFactory _productSpecificationFactory;
        private readonly IProductSpecificationService _productSpecificationService;

        #endregion Private Fields

        #region Public Constructors


        public ProductSpecificationController(IProductSpecificationService productSpecificationService, IProductSpecificationFactory productSpecificationFactory)
        {
            _productSpecificationService = productSpecificationService;
            _productSpecificationFactory = productSpecificationFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        public virtual async Task<JsonResult> CreateAjax(Guid? categoryId)
        {
            if (categoryId == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var viewModel = await _productSpecificationFactory.PrepareCreateViewModelAsync(categoryId.Value);
            return Json(AjaxResult.Succeeded(RenderRazorViewToString(MVC.ProductSpecification.Views._Create, viewModel)), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanProductSpecificationDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _productSpecificationService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanProductSpecificationEditAjax)]
        public virtual async Task<JsonResult> EditAjax(Guid? productId)
        {
            if (productId == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var viewModel = await _productSpecificationFactory.PrepareEditViewModelAsync(productId.Value);
            return Json(AjaxResult.Succeeded(RenderRazorViewToString(MVC.ProductSpecification.Views._Edit, viewModel)), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}