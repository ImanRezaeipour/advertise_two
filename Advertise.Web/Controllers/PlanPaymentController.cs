using Advertise.Core.Models.PlanPayment;
using Advertise.Service.Factories.Plans;
using Advertise.Service.Services.Plans;
using Advertise.Web.Framework.Extensions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{
 
    public partial class PlanPaymentController : BaseController
    {
        #region Private Fields

        private readonly IPlanPaymentFactory _planPaymentFactory;
        private readonly IPlanPaymentService _planPaymentService;

        #endregion Private Fields

        #region Public Constructors

      
        public PlanPaymentController(IPlanPaymentService planPaymentService, IPlanPaymentFactory planPaymentFactory)
        {
            _planPaymentService = planPaymentService;
            _planPaymentFactory = planPaymentFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        public virtual async Task<ActionResult> Callback(PlanPaymentCallbackViewModel viewModel)
        {
            if (ModelState.IsValid == false)
                return View(MVC.Error.Views.BadRequest);

            await _planPaymentService.CallbackByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.PlanPayment.Complete());
        }


        public virtual async Task<ActionResult> Complete()
        {
            return View(MVC.PlanPayment.Views.Complete);
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(PlanPyamentCreateViewModel viewModel)
        {
            if (ModelState.IsValid == false)
                return View(MVC.Page.Views.Costs);

            var result = await _planPaymentService.CreateByViewModelAsync(viewModel);
            if (result.Succeeded)
                return Redirect(result.ReturnUrl);

            this.MessageError("خطا");
            return RedirectToAction(MVC.Home.LandingPage());
        }


        public virtual async Task<ActionResult> Create()
        {
            var viewModel = await _planPaymentFactory.PrepareCreateViewModel();
            return View(MVC.PlanPayment.Views.Create, viewModel);
        }


        public virtual async Task<ActionResult> List(PlanPaymentSearchRequest request)
        {
            var viewModel = await _planPaymentFactory.PrepareListViewModel(request);
            return View(MVC.PlanPayment.Views.List, viewModel);
        }

 
        public virtual async Task<ActionResult> MyList(PlanPaymentSearchRequest request)
        {
            if (request == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _planPaymentFactory.PrepareListViewModel(request, true);
            return View(MVC.PlanPayment.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}