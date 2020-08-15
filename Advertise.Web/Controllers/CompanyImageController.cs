using Advertise.Core.Constants;
using Advertise.Core.Models.CompanyImage;
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

    public partial class CompanyImageController : BaseController
    {
        #region Private Fields

        private readonly ICompanyImageFactory _companyImageFactory;
        private readonly ICompanyImageService _companyImageService;

        #endregion Private Fields

        #region Public Constructors

        public CompanyImageController(ICompanyImageService companyImageService, ICompanyImageFactory companyImageFactory)
        {
            _companyImageService = companyImageService;
            _companyImageFactory = companyImageFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanCompanyImageCreate)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(CompanyImageCreateViewModel viewModel)
        {
          await _companyImageService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanyImage.Create());
        }


        [MvcAuthorize(PermissionConst.CanCompanyImageCreate)]
        [ImportModelData(typeof(CompanyImageCreateViewModel))]
        [MvcSiteMapNode(ParentKey = "Profile_companyImage_ListMe", Title = "ایجاد", Key = "Profile_companyImage_New")]
        public virtual async Task<ActionResult> Create()
        {
            return View(MVC.CompanyImage.Views.Create);
        }


        [MvcAuthorize(PermissionConst.CanCompanyImageDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _companyImageService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanCompanyImageEdit)]
        [MvcSiteMapNode(ParentKey = "Panel_companyImage_List", Title = "ویرایش", Key = "Panel_companyImage_Edit", PreservedRouteParameters = "id")]
        [ImportModelData(typeof(CompanyImageEditViewModel))]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _companyImageFactory.PrepareEditViewModelAsync(id.Value);
            return viewModel != null ? View(MVC.CompanyImage.Views.Edit, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanCompanyImageEditApprove)]
        public virtual async Task<ActionResult> EditApprove(CompanyImageEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _companyImageService.EditApproveByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanyImage.List());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> EditReject(CompanyImageEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            
            await _companyImageService.EditRejectByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanyImage.List());
        }


        public virtual async Task<JsonResult> GetFilesAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var files = await _companyImageService.GetFilesAsFineUploaderModelByIdAsync(id.Value);
            return Json(files, JsonRequestBehavior.AllowGet);
        }


        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "گالری ها", Key = "Panel_companyImage_List")]
        [MvcAuthorize(PermissionConst.CanCompanyImageList)]
        public virtual async Task<ActionResult> List(CompanyImageSearchRequest request)
        {
            var viewModel = await _companyImageFactory.PrepareListViewModelAsync(request);
            return View(MVC.CompanyImage.Views.List, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanCompanyImageMyDeleteAjax)]
        public virtual async Task<JsonResult> MyDeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _companyImageService.DeleteByIdAsync(id.Value, true);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanCompanyImageMyEdit)]
        [MvcSiteMapNode(ParentKey = "Profile_companyImage_ListMe", Title = "ویرایش", Key = "Profile_companyImage_Edit", PreservedRouteParameters = "id")]
        public virtual async Task<ActionResult> MyEdit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _companyImageFactory.PrepareEditViewModelAsync(id.Value, true);
            return viewModel != null ? View(MVC.CompanyImage.Views.Edit, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanCompanyImageMyEdit)]
        public virtual async Task<ActionResult> MyEdit(CompanyImageEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _companyImageService.EditByViewModelAsync(viewModel, true);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanyImage.MyList());
        }


        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "گالری من", Key = "Profile_companyImage_ListMe")]
        [MvcAuthorize(PermissionConst.CanCompanyImageMyList)]
        public virtual async Task<ActionResult> MyList(CompanyImageSearchRequest request)
        {
            var viewModel = await _companyImageFactory.PrepareListViewModelAsync(request, true);
            return View(MVC.CompanyImage.Views.List, viewModel);
        }

        public virtual async Task<JsonResult> ApproveAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _companyImageService.SetStateByIdAsync(id.Value, StateType.Approved);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        public virtual async Task<JsonResult> RejectAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _companyImageService.SetStateByIdAsync(id.Value, StateType.Rejected);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}