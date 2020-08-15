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

    public partial class ProductTagController : Controller
    {
        #region Private Fields

        private readonly IProductTagService _productTagService;

        #endregion Private Fields

        #region Public Constructors


        public ProductTagController(IProductTagService productTagService)
        {
            _productTagService = productTagService;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanTagList)]
        public virtual async Task<JsonResult> GetTagsAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var tags = await _productTagService.GetTagsByProductIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(tags), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}