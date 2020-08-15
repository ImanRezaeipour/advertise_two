using Advertise.Core.Constants;
using Advertise.Core.Models.CompanyQuestion;
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

    public partial class CompanyQuestionController : BaseController
    {
        #region Private Fields

        private readonly ICompanyQuestionFactory _companyQuestionFactory;
        private readonly ICompanyQuestionService _companyQuestionService;

        #endregion Private Fields

        #region Public Constructors

      
        public CompanyQuestionController(ICompanyQuestionService companyQuestionService, ICompanyQuestionFactory companyQuestionFactory)
        {
            _companyQuestionService = companyQuestionService;
            _companyQuestionFactory = companyQuestionFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanCompanyQustionCreate)]
        [HttpPost]
        public virtual async Task<JsonResult> CreateAjax(CompanyQuestionCreateViewModel viewModel)
        {
            if (viewModel == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _companyQuestionService.CreateByViewModelAsync(viewModel);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanCompanyQustionCreate)]
        [MvcSiteMapNode(ParentKey = "Public_Home_Index", Title = "پرسش و پاسخ", Key = "Public_CompanyQustion_New")]
        [ImportModelData(typeof(CompanyQuestionCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            return View(MVC.CompanyQuestion.Views._Create);
        }


        [MvcAuthorize(PermissionConst.CanCompanyQustionDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest));

            await _companyQuestionService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcSiteMapNode(ParentKey = "Panel_CompanyQustion_List", Title = "ویرایش", Key = "Panel_CompanyQustion_Edit", PreservedRouteParameters = "id")]
        [MvcAuthorize(PermissionConst.CanCompanyQustionEdit)]
        [ImportModelData(typeof(CompanyQuestionEditViewModel))]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _companyQuestionFactory.PrepareEditViewModelAsync(id.Value);
            return View(MVC.CompanyQuestion.Views.Edit, viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanCompanyQustionEdit)]
        public virtual async Task<ActionResult> Edit(CompanyQuestionEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

          
            await _companyQuestionService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanyQuestion.Edit());
        }


        [MvcAuthorize(PermissionConst.CanCompanyQustionList)]
        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "سوالات", Key = "Panel_CompanyQustion_List")]
        public virtual async Task<ActionResult> List(CompanyQuestionSearchRequest request)
        {
            var viewModel = await _companyQuestionFactory.PrepareListViewModelAsync(request);
            return View(MVC.CompanyQuestion.Views.List, viewModel);
        }


        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanCompanyQustionEditApprove)]
        public virtual async Task<ActionResult> EditApprove(CompanyQuestionEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _companyQuestionService.ApproveByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanyQuestion.List());
        }


        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanCompanyQustionEditReject)]
        public virtual async Task<ActionResult> EditReject(CompanyQuestionEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);


            await _companyQuestionService.RejectByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanyQuestion.List());
        }



        [MvcAuthorize(PermissionConst.CanCompanyQustionMyList)]
        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "سوالات من", Key = "Profile_CompanyQustion_MyGridList")]
        public virtual async Task<ActionResult> MyList(CompanyQuestionSearchRequest request)
        {
            var viewModel = await _companyQuestionFactory.PrepareListViewModelAsync(request, true);
            return View(MVC.CompanyQuestion.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}