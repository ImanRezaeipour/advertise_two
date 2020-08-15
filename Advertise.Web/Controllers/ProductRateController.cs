using Advertise.Core.Constants;
using Advertise.Core.Models.ProductRate;
using Advertise.Service.Services.Products;
using Advertise.Service.Validators.Product;
using Advertise.Web.Framework.Results;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class ProductRateController : BaseController
    {
        #region Private Fields

        private readonly IProductRateService _productRateService;

        #endregion Private Fields

        #region Public Constructors


        public ProductRateController(IProductRateService productRateService)
        {
            _productRateService = productRateService;
        }

        #endregion Public Constructors

        #region Public Methods


        [HttpPost]
        public virtual async Task<JsonResult> CreateAjax(ProductRateCreateViewModel viewModel)
        {
            if (viewModel == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _productRateService.CreateByViewModelAsync(viewModel);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}