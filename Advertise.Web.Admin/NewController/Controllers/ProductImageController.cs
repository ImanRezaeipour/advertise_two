using Advertise.Core.Constants;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Products;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class ProductImageController : BaseController
    {
        #region Private Fields

        private readonly IProductImageService _productImageService;

        #endregion Private Fields

        #region Public Constructors


        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        #endregion Public Constructors

        #region Public Methods

        [MvcAuthorize(PermissionConst.CanProductImageDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _productImageService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanProductImageGetListAjax)]
        public virtual async Task<JsonResult> GetListAjax(Guid? productId)
        {
            if (productId == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var productImages = _productImageService.GetByProductIdAsFileModelAsync(productId.Value);
            return Json(AjaxResult.Succeeded(productImages), JsonRequestBehavior.AllowGet);
        }
    }

    #endregion Public Methods
}