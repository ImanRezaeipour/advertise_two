using Advertise.Core.Constants;
using Advertise.Core.Models.CompanyAttachment;
using Advertise.Service.Factories.Companies;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Validators.Companies;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Advertise.Core.Types;

namespace Advertise.Web.Controllers
{

    public partial class CompanyAttachmentController : BaseController
    {
        #region Private Fields

        private readonly ICompanyAttachmentFactory _companyAttachmentFactory;
        private readonly ICompanyAttachmentService _companyAttachmentService;

        #endregion Private Fields

        #region Public Constructors

     
        public CompanyAttachmentController(ICompanyAttachmentService companyAttachmentService, ICompanyAttachmentFactory companyAttachmentFactory)
        {
            _companyAttachmentService = companyAttachmentService;
            _companyAttachmentFactory = companyAttachmentFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanCompanyAttachmentCreate)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(CompanyAttachmentCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _companyAttachmentService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanyAttachment.Create());
        }


        [MvcAuthorize(PermissionConst.CanCompanyAttachmentCreate)]
        [MvcSiteMapNode(ParentKey = "Profile_CompanyAttachment_ListMe", Title = "ایجاد", Key = "Profile_CompanyAttachment_New")]
        [ImportModelData(typeof(CompanyAttachmentCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            return View(MVC.CompanyAttachment.Views.Create);
        }


        [MvcAuthorize(PermissionConst.CanCompanyAttachmentDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _companyAttachmentService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanCompanyAttachmentEdit)]
        [MvcSiteMapNode(ParentKey = "Panel_CompanyAttachment_List", Title = "ویرایش", Key = "Panel_CompanyAttachment_Edit", PreservedRouteParameters = "id")]
        [ImportModelData(typeof(CompanyAttachmentEditViewModel))]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.NotFound);

            var viewModel = await _companyAttachmentFactory.PrepareEditViewModelAsync(id.Value);
            return viewModel != null ? View(MVC.CompanyAttachment.Views.Edit, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanCompanyAttachmentEditApprove)]
        public virtual async Task<ActionResult> EditApprove(CompanyAttachmentEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            
            await _companyAttachmentService.EditApproveByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanyAttachment.List());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> EditReject(CompanyAttachmentEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);


            await _companyAttachmentService.EditRejectByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanyAttachment.List());
        }


        public virtual async Task<JsonResult> GetFilesAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest));

            var files = await _companyAttachmentService.GetFilesAsFineUploaderModelByIdAsync(id.Value);
            return Json(files, JsonRequestBehavior.AllowGet);
        }



        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "فایل ها", Key = "Panel_CompanyAttachment_List")]
        [MvcAuthorize(PermissionConst.CanCompanyAttachmentList)]
        public virtual async Task<ActionResult> List(CompanyAttachmentSearchRequest request)
        {
            var viewModel = await _companyAttachmentFactory.PrepareListViewModelAsync(request);
            return View(MVC.CompanyAttachment.Views.List, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanCompanyAttachmentMyDeleteAjax)]
        public virtual async Task<JsonResult> MyDeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);


            await _companyAttachmentService.DeleteByIdAsync(id.Value, true);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanCompanyAttachmentMyEdit)]
        [MvcSiteMapNode(ParentKey = "Profile_CompanyAttachment_ListMe", Title = "ویرایش", Key = "Profile_CompanyAttachment_Edit", PreservedRouteParameters = "id")]
        [ImportModelData(typeof(CompanyAttachmentEditViewModel))]
        public virtual async Task<ActionResult> MyEdit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _companyAttachmentFactory.PrepareEditViewModelAsync(id.Value, true);
            return viewModel != null ? View(MVC.CompanyAttachment.Views.Edit, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanCompanyAttachmentMyEdit)]
        public virtual async Task<ActionResult> MyEdit(CompanyAttachmentEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _companyAttachmentService.EditByViewModelAsync(viewModel, true);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanyAttachment.MyList());
        }


        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "فایل من", Key = "Profile_CompanyAttachment_ListMe")]
        [MvcAuthorize(PermissionConst.CanCompanyAttachmentMyList)]
        public virtual async Task<ActionResult> MyList(CompanyAttachmentSearchRequest request)
        {
            var viewModel = await _companyAttachmentFactory.PrepareListViewModelAsync(request, true);
            return View(MVC.CompanyAttachment.Views.List, viewModel);
        }

        [AllowCrossSite]
        public virtual async Task<ActionResult> Detail(Guid? id, string slug = "")
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _companyAttachmentFactory.PrepareDetailViewModelAsync(id.Value);
            return viewModel == null ? View(MVC.Error.Views.InternalServerError) : View(MVC.CompanyAttachment.Views.Detail, viewModel);
        }


        public virtual async Task<JsonResult> ApproveAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _companyAttachmentService.SetStateByIdAsync(id.Value, StateType.Approved);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        public virtual async Task<JsonResult> RejectAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _companyAttachmentService.SetStateByIdAsync(id.Value, StateType.Rejected);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}