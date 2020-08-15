using Advertise.Core.Constants;
using Advertise.Core.Models.PlanDiscount;
using Advertise.Service.Factories.Plans;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Plans;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class PlanDiscountController : Controller
    {
        #region Private Fields

        private readonly IPlanDiscountFactory _planDiscountFactory;
        private readonly IPlanDiscountService _planDiscountService;

        #endregion Private Fields

        #region Public Constructors

        public PlanDiscountController(IPlanDiscountService planDiscountService, IPlanDiscountFactory planDiscountFactory)
        {
            _planDiscountService = planDiscountService;
            _planDiscountFactory = planDiscountFactory;
        }

        #endregion Public Constructors

        #region Public Methods


     
       
        public virtual async Task<JsonResult> GetPercentAjax(string code)
        {
            if (code == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var planDiscountPercent = await _planDiscountService.GetPercentByCodeAsync(code);
            return Json(AjaxResult.Succeeded(planDiscountPercent), JsonRequestBehavior.AllowGet);
        }



        




        #endregion Public Methods
    }
}