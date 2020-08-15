using Advertise.Core.Constants;
using Advertise.Core.Models.ProductFeature;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Products;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class ProductFeatureController : BaseController
    {
        #region Private Fields

        private readonly IProductFeatureService _productFeature;

        #endregion Private Fields

        #region Public Constructors


        public ProductFeatureController(IProductFeatureService productFeature)
        {
            _productFeature = productFeature;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanProductFeatureDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _productFeature.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanProductFeatureGetListAjax)]
        public virtual async Task<JsonResult> GetListAjax()
        {
            var request = new ProductFeatureSearchRequest();
            var productFeatures = await _productFeature.ListByRequestAsync(request);
            return Json(AjaxResult.Succeeded(productFeatures), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}