using Advertise.Core.Models.Receipt;
using Advertise.Service.Factories.Receipts;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Receipts;
using Advertise.Service.Validators.Receipts;
using Advertise.Web.Framework.Filters;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Advertise.Web.Framework.Extensions;

namespace Advertise.Web.Controllers
{

    public partial class ReceiptController : Controller
    {
        #region Private Fields

        private readonly IReceiptFactory _receiptFactory;
        private readonly IReceiptService _receiptService;

        #endregion Private Fields

        #region Public Constructors


        public ReceiptController(IReceiptService receiptService,IReceiptFactory receiptFactory)
        {
            _receiptService = receiptService;
            _receiptFactory = receiptFactory;
        }

        #endregion Public Constructors

        #region Public Methods

        [ImportModelData(typeof(ReceiptViewModel))]
        public virtual async Task<ActionResult> CheckOut()
        {
            var viewModel = await _receiptFactory.PrepareCreateViewModelAsync();
            return View(MVC.Receipt.Views.CheckOut, viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> CheckOut(ReceiptViewModel viewModel)
        {
           
            await _receiptService.FinalUpdateByViewModel(viewModel);
            return RedirectToAction(MVC.Receipt.Preview());
        }

     
        [MvcAuthorize(PermissionConst.CanReceiptList)]
        public virtual async Task<ActionResult> List(ReceiptSearchRequest request)
        {
            var viewModel = await _receiptFactory.PrepareListViewModelAsync(request);
            return View(MVC.Receipt.Views.List, viewModel);
        }

 
        [MvcAuthorize(PermissionConst.CanReceiptMyList)]
        public virtual async Task<ActionResult> MyList(ReceiptSearchRequest request)
        {
            var viewModel = await _receiptFactory.PrepareListViewModelAsync(request, true);
            return View(MVC.Receipt.Views.List, viewModel);
        }


        public virtual async Task<ActionResult> Preview(Guid? id)
        {
            var viewModel = await _receiptFactory.PreparePreviewViewModelAsync(id);
            return View(MVC.Receipt.Views.Preview, viewModel);
        }

        #endregion Public Methods
    }
}