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

    public partial class ProductNotifyController : Controller
    {
        #region Private Fields

        private readonly IProductNotifyService _productNotifyService;

        #endregion Private Fields

        #region Public Constructors

        public ProductNotifyController(IProductNotifyService productNotifyService)
        {
            _productNotifyService = productNotifyService;
        }

        #endregion Public Constructors

        #region Public Methods

        [MvcAuthorize(PermissionConst.CanProductNotifyMyToggleAjax)]
        public virtual async Task<JsonResult> MyToggleAjax(Guid? productId)
        {
            if (productId == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _productNotifyService.ToggleByProductIdAsync(productId.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}