using Advertise.Core.Models.ReceiptOption;
using Advertise.Core.Types;
using Advertise.Service.Factories.Receipts;
using Advertise.Service.Services.Permissions;
using Advertise.Web.Framework.Filters;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class ReceiptOptionController : Controller
    {
        #region Private Fields

        private readonly IReceiptOptionFactory _receiptOptionFactory;

        #endregion Private Fields

        #region Public Constructors

        public ReceiptOptionController(IReceiptOptionFactory receiptOptionFactory)
        {
            _receiptOptionFactory = receiptOptionFactory;
        }

        #endregion Public Constructors

        #region Public Methods

        [MvcAuthorize(PermissionConst.CanReceiptOptionList)]
        public virtual async Task<ActionResult> List(ReceiptOptionSearchRequest request)
        {
            var viewModel = await _receiptOptionFactory.PrepareListViewModel(request);
            return View(MVC.ReceiptOption.Views.List, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanReceiptOptionMyBuyList)]
        public virtual async Task<ActionResult> MyBuyList(ReceiptOptionSearchRequest request)
        {
            request.ListType = ReceiptOptionListType.Buy;
            var viewModel = await _receiptOptionFactory.PrepareListViewModel(request, true);
            return View(MVC.ReceiptOption.Views.List, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanReceiptOptionMySaleList)]
        public virtual async Task<ActionResult> MySaleList(ReceiptOptionSearchRequest request)
        {
            request.ListType = ReceiptOptionListType.Sale;
            var viewModel = await _receiptOptionFactory.PrepareListViewModel(request, true);
            return View(MVC.ReceiptOption.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}