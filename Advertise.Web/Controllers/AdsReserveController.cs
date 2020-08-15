using Advertise.Service.Services.Ads;
using Advertise.Web.Framework.Results;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{
    public partial class AdsReserveController : Controller
    {

        #region Private Fields

        private readonly IAdsReserveService _adsReserveService;

        #endregion Private Fields

        #region Public Constructors

        public AdsReserveController(IAdsReserveService adsReserveService)
        {
            _adsReserveService = adsReserveService;
        }

        #endregion Public Constructors

        #region Public Methods

        public virtual async Task<JsonResult> DateofReleaseAjax(Guid optionId)
        {
            var result = await _adsReserveService.GetReserveDayByOptionIdAsync(optionId);
            return Json(AjaxResult.Succeeded(result), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods

    }
}