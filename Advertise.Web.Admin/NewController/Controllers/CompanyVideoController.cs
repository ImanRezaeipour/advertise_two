using Advertise.Core.Constants;
using Advertise.Core.Models.CompanyVideo;
using Advertise.Service.Factories.Companies;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Validators.Video;
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
    /// <inheritdoc />

    public partial class CompanyVideoController : BaseController
    {
        #region Private Fields

        private readonly ICompanyVideoFactory _companyVideoFactory;
        private readonly ICompanyVideoService _companyVideoService;

        #endregion Private Fields

        #region Public Constructors

    
        public CompanyVideoController(ICompanyVideoService companyVideoService, ICompanyVideoFactory companyVideoFactory)
        {
            _companyVideoService = companyVideoService;
            _companyVideoFactory = companyVideoFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcSiteMapNode(ParentKey = "Profile_companyVideo_ListMe", Title = "ایجاد", Key = "Profile_companyVideo_New")]
        [MvcAuthorize(PermissionConst.CanCompanyVideoCreate)]
        [ImportModelData(typeof(CompanyVideoCreateViewModel))]
        public virtual ActionResult Create()
        {
            return View(MVC.CompanyVideo.Views.Create);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanCompanyVideoCreate)]
        public virtual async Task<ActionResult> Create(CompanyVideoCreateViewModel viewModel)
        {
           
            await _companyVideoService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanyVideo.Create());
        }


        [MvcAuthorize(PermissionConst.CanCompanyVideoDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _companyVideoService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcSiteMapNode(ParentKey = "Panel_companyVideo_List", Title = "ویرایش", Key = "Panel_companyVideo_Edit", PreservedRouteParameters = "id")]
        [MvcAuthorize(PermissionConst.CanCompanyVideoEdit)]
        [ImportModelData(typeof(CompanyVideoEditViewModel))]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _companyVideoFactory.PrepareEditViewModelAsync(id.Value);
            return viewModel != null ? View(MVC.CompanyVideo.Views.Edit, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


        [MvcAuthorize(PermissionConst.CanCompanyVideoEditApprove)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> EditApprove(CompanyVideoEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

          
            await _companyVideoService.EditApproveByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanyVideo.List());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanCompanyVideoEditReject)]
        public virtual async Task<ActionResult> EditReject(CompanyVideoEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);
            
            await _companyVideoService.EditRejectByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanyVideo.List());
        }


        public virtual async Task<JsonResult> GetFilesAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var files = await _companyVideoService.GetFilesAsFineUploaderModelByIdAsync(id.Value);
            return Json(files, JsonRequestBehavior.AllowGet);
        }


        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "ویدئو ها", Key = "Panel_companyVideo_List")]
        [MvcAuthorize(PermissionConst.CanCompanyVideoList)]
        public virtual async Task<ActionResult> List(CompanyVideoSearchRequest request)
        {
            var viewModel = await _companyVideoFactory.PrepareListViewModelAsync(request);
            return View(MVC.CompanyVideo.Views.List, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanCompanyVideoMyDeleteAjax)]
        public virtual async Task<JsonResult> MyDeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _companyVideoService.DeleteByIdAsync(id.Value, true);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcSiteMapNode(ParentKey = "Profile_companyVideo_ListMe", Title = "ویرایش", Key = "Profile_companyVideo_Edit", PreservedRouteParameters = "id")]
        [MvcAuthorize(PermissionConst.CanCompanyVideoMyEdit)]
        [ImportModelData(typeof(CompanyVideoEditViewModel))]
        public virtual async Task<ActionResult> MyEdit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.NotFound);

            var viewModel = await _companyVideoFactory.PrepareEditViewModelAsync(id.Value, true);
            return View(MVC.CompanyVideo.Views.Edit, viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanCompanyVideoMyEdit)]
        public virtual async Task<ActionResult> MyEdit(CompanyVideoEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _companyVideoService.EditByViewModelAsync(viewModel, true);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanyVideo.MyList());
        }


        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "ویدئوهای من", Key = "Profile_companyVideo_ListMe")]
        [MvcAuthorize(PermissionConst.CanCompanyVideoMyList)]
        public virtual async Task<ActionResult> MyList(CompanyVideoSearchRequest request)
        {
            var viewModel = await _companyVideoFactory.PrepareListViewModelAsync(request, true);
            return View(MVC.CompanyVideo.Views.List, viewModel);
        }

        [AllowCrossSite]
        public virtual async Task<ActionResult> Detail(Guid? id, string slug = "")
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _companyVideoFactory.PrepareDetailViewModelAsync(id.Value);
            return viewModel == null ? View(MVC.Error.Views.InternalServerError) : View(MVC.CompanyVideo.Views.Detail, viewModel);
        }


        public virtual async Task<JsonResult> ApproveAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _companyVideoService.SetStateByIdAsync(id.Value, StateType.Approved);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        public virtual async Task<JsonResult> RejectAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _companyVideoService.SetStateByIdAsync(id.Value, StateType.Rejected);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}