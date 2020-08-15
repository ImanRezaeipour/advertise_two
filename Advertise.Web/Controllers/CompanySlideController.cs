using Advertise.Core.Constants;
using Advertise.Core.Models.CompanySlide;
using Advertise.Service.Factories.Companies;
using Advertise.Service.Services.Companies;
using Advertise.Web.Framework.Results;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Advertise.Core.Models.Product;
using Advertise.Web.Framework.Filters;

namespace Advertise.Web.Controllers
{
    public partial class CompanySlideController : BaseController
    {
        #region Private Fields

        private readonly ICompanySlideFactory _companySlideFactory;
        private readonly ICompanySlideService _companySlideService;

        #endregion Private Fields

        #region Public Constructors

        public CompanySlideController(ICompanySlideService companySlideService, ICompanySlideFactory companySlideFactory)
        {
            _companySlideService = companySlideService;
            _companySlideFactory = companySlideFactory;
        }

        #endregion Public Constructors

        #region Public Methods

        public virtual async Task<ActionResult> Create()
        {
            var viewModel = await _companySlideFactory.PrepareCreateViewModelAsync();
            return View(MVC.CompanySlide.Views.Create, viewModel);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Create(CompanySlideCreateViewModel viewModel)
        {
            await _companySlideService.CreateByViewModelAsync(viewModel);
            return RedirectToAction(MVC.CompanySlide.List());
        }

        [HttpPost]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _companySlideService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var viewModel = await _companySlideFactory.PrepareEditViewModelAsync(id.Value);
            return View(MVC.CompanySlide.Views.Edit, viewModel);
        }

        [HttpPost]
        public virtual async Task<ActionResult> Edit(CompanySlideEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            await _companySlideService.EditByViewModelAsync(viewModel);
            return RedirectToAction(MVC.CompanySlide.List());
        }

        public virtual async Task<JsonResult> GetFileAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var files = await _companySlideService.GetFileAsFineUploaderModelByIdAsync(id.Value);
            return Json(files, JsonRequestBehavior.AllowGet);
        }

        public virtual async Task<ActionResult> List(CompanySlideSearchRequest request)
        {
            var viewModel = await _companySlideFactory.PrepareListViewModelAsync(request);
            return View(MVC.CompanySlide.Views.List, viewModel);
        }

        [ImportModelData(typeof(CompanySlideBulkEditViewModel))]
        public virtual async Task<ActionResult> BulkEdit()
        {
            var viewModel = await _companySlideFactory.PrepareBulkEditViewModelAsync();
            return View(MVC.CompanySlide.Views.BulkEdit, viewModel);
        }

        [HttpPost]
        [ClearModelData(typeof(CompanySlideBulkEditViewModel))]
        public virtual async Task<ActionResult> BulkEdit(CompanySlideBulkEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            //await _companySlideService.EditBulkByViewModelAsync(viewModel);
            return RedirectToAction(MVC.CompanySlide.BulkEdit());
        }

        #endregion Public Methods
    }
}