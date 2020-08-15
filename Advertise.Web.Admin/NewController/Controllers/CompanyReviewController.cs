using Advertise.Core.Constants;
using Advertise.Core.Models.CompanyReview;
using Advertise.Service.Factories.Companies;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.Permissions;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class CompanyReviewController : BaseController
    {
        #region Private Fields

        private readonly ICompanyReviewFactory _companyReviewFactory;
        private readonly ICompanyReviewService _companyReviewService;

        #endregion Private Fields

        #region Public Constructors

     
        public CompanyReviewController(ICompanyReviewService companyReviewService, ICompanyReviewFactory companyReviewFactory)
        {
            _companyReviewService = companyReviewService;
            _companyReviewFactory = companyReviewFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanCompanyReviewCreate)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public virtual async Task<ActionResult> Create(CompanyReviewCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);


            await _companyReviewService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanyReview.Create());
        }


        [MvcAuthorize(PermissionConst.CanCompanyReviewCreate)]
        [MvcSiteMapNode(ParentKey = "Panel_CompanyReview_List", Title = "ایجاد", Key = "Panel_CompanyReview_New")]
        [ImportModelData(typeof(CompanyReviewCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            var viewModel = await _companyReviewFactory.PrepareCreateViewModelAsync();
            return View(MVC.CompanyReview.Views.Create, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanCompanyReviewDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _companyReviewService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanCompanyReviewEdit)]
        [MvcSiteMapNode(ParentKey = "Panel_CompanyReview_List", Title = "ویرایش", Key = "Panel_CompanyReview_Edit", PreservedRouteParameters = "id")]
        [ImportModelData(typeof(CompanyReviewEditViewModel))]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _companyReviewFactory.PrepareEditViewModelAsync(id.Value);
            return View(MVC.CompanyReview.Views.Edit, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanCompanyReviewEdit)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public virtual async Task<ActionResult> Edit(CompanyReviewEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _companyReviewService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanyReview.Edit(viewModel.Id));
        }


        [MvcAuthorize(PermissionConst.CanCompanyReviewList)]
        [MvcSiteMapNode(ParentKey = "Public_Home_Index", Title = "نقد و بررسی ها ", Key = "Panel_CompanyReview_List")]
        public virtual async Task<ActionResult> List(CompanyReviewSearchRequest request)
        {
            var viewModel = await _companyReviewFactory.PrepareListViewModelAsync(request);
            return View(MVC.CompanyReview.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}