using Advertise.Core.Constants;
using Advertise.Core.Models.CompanyBalance;
using Advertise.Service.Factories.Companies;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.Permissions;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{
    /// <inheritdoc />

    public partial class CompanyBalanceController : BaseController
    {
        #region Private Fields

        private readonly ICompanyBalanceFactory _companyBalanceFactory;
        private readonly ICompanyBalanceService _companyBalanceService;

        #endregion Private Fields

        #region Public Constructors

     
        public CompanyBalanceController(ICompanyBalanceService companyBalanceService, ICompanyBalanceFactory companyBalanceFactory)
        {
            _companyBalanceService = companyBalanceService;
            _companyBalanceFactory = companyBalanceFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanCompanyBalanceCreate)]
        [ImportModelData(typeof(CompanyBalanceCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            var viewModel = await _companyBalanceFactory.PrepareCreateViewModelAsync();
            return View(MVC.CompanyBalance.Views.Create, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanCompanyBalanceCreate)]
        [HttpPost]
        public virtual async Task<ActionResult> Create(CompanyBalanceCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

          
            await _companyBalanceService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");

            return RedirectToAction(MVC.CompanyBalance.List());
        }


        [MvcAuthorize(PermissionConst.CanCompanyBalanceDeleteAjax)]
        public virtual async Task<ActionResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest));

            await _companyBalanceService.DeleteByIdAsync(id.Value);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanyBalance.List());
        }


        [MvcAuthorize(PermissionConst.CanCompanyBalanceEdit)]
        [ImportModelData(typeof(CompanyBalanceEditViewModel))]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _companyBalanceFactory.PrepareEditViewModelAsync(id.Value);
            return View(MVC.CompanyBalance.Views.Edit, viewModel);
        }


        [HttpPost]
        [MvcAuthorize(PermissionConst.CanCompanyBalanceEdit)]
        public virtual async Task<ActionResult> Edit(CompanyBalanceEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

           
            await _companyBalanceService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanyBalance.List());
        }


        [MvcAuthorize(PermissionConst.CanCompanyBalanceGetFileAjax)]
        public virtual async Task<JsonResult> GetFileAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest));

            var file = await _companyBalanceService.GetFileAsFineUploaderModelByIdAsync(id.Value);
            return Json(file, JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanCompanyBalanceList)]
        public virtual async Task<ActionResult> List(CompanyBalanceSearchRequest request)
        {
            var viewModel = await _companyBalanceFactory.PrepareListViewModelAsync(request);
            return View(MVC.CompanyBalance.Views.List, viewModel);
        }

     
        [MvcAuthorize(PermissionConst.CanCompanyBalanceMyList)]
        public virtual async Task<ActionResult> MyList(CompanyBalanceSearchRequest request)
        {
            var viewModel = await _companyBalanceFactory.PrepareListViewModelAsync(request, true);
            return View(MVC.CompanyBalance.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}