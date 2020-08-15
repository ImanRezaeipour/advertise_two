using Advertise.Core.Models.ReceiptPayment;
using Advertise.Service.Factories.Receipts;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Receipts;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using MvcSiteMapProvider;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class ReceiptPaymentController : Controller
    {
        #region Private Fields

        private readonly IReceiptPaymentService _receiptPaymentService;
        private readonly IReceiptPaymentFactory _receiptPaymentFactory;

        #endregion Private Fields

        #region Public Constructors


        public ReceiptPaymentController(IReceiptPaymentService receiptPaymentService, IReceiptPaymentFactory receiptPaymentFactory)
        {
            _receiptPaymentService = receiptPaymentService;
            _receiptPaymentFactory = receiptPaymentFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        public virtual async Task<ActionResult> Callback(ReceiptPaymentCallbackViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            if (string.IsNullOrEmpty(viewModel.Status) || string.IsNullOrEmpty(viewModel.Authority))
                return View(MVC.Error.Views.BadRequest);

            await _receiptPaymentService.CallbackByViewModelAsync(viewModel);
            this.MessageSuccess("تراکنش مالی صورت پذیرفت");
            return RedirectToAction(MVC.ReceiptPayment.Complete(viewModel.Authority));
        }


        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "تکمیل خرید", Key = "Profile_ReceiptPayment_PayComplete", PreservedRouteParameters = "authority")]
        public virtual async Task<ActionResult> Complete(string authority)
        {
            if (authority == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _receiptPaymentFactory.PrepareCompleteViewModelAsync(authority);
            return View(MVC.ReceiptPayment.Views.Complete, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanReceiptPaymentPay)]
        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "خرید", Key = "Profile_ReceiptPayment_Pay")]
        public virtual async Task<ActionResult> Create()
        {
            var result = await _receiptPaymentService.CreateAsync();
            if (result != null)
                return Redirect(result);

            this.MessageError("خطایی رخ داده است");
            return RedirectToAction(MVC.Home.LandingPage());
        }

        
        [MvcAuthorize(PermissionConst.CanReceiptPaymentList)]
        public virtual async Task<ActionResult> List(ReceiptPaymentSearchRequest request)
        {
            var viewModel = await _receiptPaymentFactory.PrepareListViewModelAsync(request);
            return View(MVC.ReceiptPayment.Views.List, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanReceiptPaymentMyList)]
        public virtual async Task<ActionResult> MyList(ReceiptPaymentSearchRequest request)
        {
            if (request == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _receiptPaymentFactory.PrepareListViewModelAsync(request, true);
            return View(MVC.ReceiptPayment.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}