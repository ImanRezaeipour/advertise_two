using Advertise.Core.Models.AdsPayment;
using Advertise.Service.Factories.AdsPayment;
using Advertise.Service.Services.Ads;
using Advertise.Service.Services.Permissions;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{
    public partial class AdsPaymentController : Controller
    {

        #region Private Fields

        private readonly IAdsPaymentFactory _adsPaymentFactory;
        private readonly IAdsPaymentService _adsPaymentService;

        #endregion Private Fields

        #region Public Constructors

        public AdsPaymentController(IAdsPaymentFactory adsPaymentFactory, IAdsPaymentService adsPaymentService)
        {
            _adsPaymentFactory = adsPaymentFactory;
            _adsPaymentService = adsPaymentService;
        }

        #endregion Public Constructors

        #region Public Methods


        public virtual async Task<ActionResult> Callback(AdsPaymentCallbackViewModel viewModel)
        {
            if (ModelState.IsValid == false)
                return View(MVC.Error.Views.BadRequest);

            var result = await _adsPaymentService.CallbackWithZarinpalByViewModelAsync(viewModel);
            if (result.Succeeded)
            {
                return RedirectToAction(MVC.AdsPayment.Complete());
            }

            this.MessageError("خطا");
            return RedirectToAction(MVC.Home.LandingPage());
        }


        public virtual async Task<ActionResult> Complete()
        {
            return View(MVC.AdsPayment.Views.Complete);
        }


        [MvcAuthorize(PermissionConst.CanAdsPaymentList)]
        public virtual async Task<ActionResult> List(AdsPaymentSearchRequest request)
        {
            var viewModel = await _adsPaymentFactory.PrepareListViewModel(request);
            return View(MVC.AdsPayment.Views.List, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanAdsPaymentMyList)]
        public virtual async Task<ActionResult> MyList(AdsPaymentSearchRequest request)
        {
            var viewModel = await _adsPaymentFactory.PrepareListViewModel(request, true);
            return View(MVC.AdsPayment.Views.List, viewModel);
        }

        #endregion Public Methods

    }
}