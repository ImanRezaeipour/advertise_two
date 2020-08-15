using Advertise.Core.Models.CompanyHour;
using Advertise.Service.Factories.Companies;
using Advertise.Service.Services.Companies;
using Advertise.Web.Framework.Extensions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{
    public partial class CompanyHourController : Controller
    {
        #region Private Fields

        private readonly ICompanyHourFactory _companyHourFactory;
        private readonly ICompanyHourService _companyHourService;

        #endregion Private Fields

        #region Public Constructors

        public CompanyHourController(ICompanyHourFactory companyHourFactory, ICompanyHourService companyHourService)
        {
            _companyHourFactory = companyHourFactory;
            _companyHourService = companyHourService;
        }

        #endregion Public Constructors

        #region Public Methods

        public virtual async Task<ActionResult> Edit()
        {
            var viewModel = await _companyHourFactory.PrepareEditViewModelAsync();
            return View(MVC.CompanyHour.Views.Edit, viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public virtual async Task<ActionResult> Edit(CompanyHourEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _companyHourService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Profile.Dashboard());
        }

        #endregion Public Methods
    }
}