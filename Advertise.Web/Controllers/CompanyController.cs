using Advertise.Core.Constants;
using Advertise.Core.Models.Company;
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

    public partial class CompanyController : BaseController
    {

        #region Private Fields

        private readonly ICompanyFactory _companyFactory;
        private readonly ICompanyService _companyService;
        #endregion Private Fields

        #region Public Constructors

 
        public CompanyController(ICompanyService companyService, ICompanyFactory companyFactory)
        {
            _companyService = companyService;
            _companyFactory = companyFactory;
        }

        #endregion Public Constructors

        #region Public Methods

       
    
    
        [AllowCrossSite]
        public virtual async Task<JsonResult> DetailInfoAjax(string id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var companyDetail = await _companyFactory.PrepareDetailInfoViewModelAsync(id);
            return Json(AjaxResult.Succeeded(companyDetail), JsonRequestBehavior.AllowGet);
        }

    
        [MvcAuthorize(PermissionConst.CanCompanyEdit)]
        [MvcSiteMapNode(ParentKey = "Panel_Company_List", Title = "ویرایش", Key = "Panel_Company_Edit", PreservedRouteParameters = "id")]
        [ImportModelData(typeof(CompanyEditViewModel))]
        public virtual async Task<ActionResult> Edit(string alias)
        {
            if (alias == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _companyFactory.PrepareEditViewModelAsync(alias);
            return viewModel != null ? View(MVC.Company.Views.Edit, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


    

     


        public virtual async Task<JsonResult> GetAllCompaniesAjax()
        {
            var companies = await _companyService.GetAllNearAsync();
            return Json(AjaxResult.Succeeded(companies), JsonRequestBehavior.AllowGet);
        }


        public virtual async Task<JsonResult> GetCountCompanyInCategoryAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var count = await _companyService.CountByCategoryIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(count), JsonRequestBehavior.AllowGet);
        }


        public virtual async Task<JsonResult> GetFileAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var file = await _companyService.GetFileAsFineUploaderModelByIdAsync(id.Value);
            return Json(file, JsonRequestBehavior.AllowGet);
        }


        public virtual async Task<JsonResult> GetFileCoverAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var fileCover = await _companyService.GetFileCoverAsFineUploaderModelByIdAsync(id.Value);
            return Json(fileCover, JsonRequestBehavior.AllowGet);
        }

     
        public virtual async Task<JsonResult> IsExistAliasAjax(string companyAlias)
        {
            if (companyAlias == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest));

            var isExist = await _companyService.IsExistByAliasAsync(companyAlias);
            return Json(AjaxResult.Succeeded(isExist), JsonRequestBehavior.AllowGet);
        }


    


        [MvcAuthorize(PermissionConst.CanCompanyMyEdit)]
        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "ویرایش", Key = "Profile_Company_EditMe")]
        [ImportModelData(typeof(CompanyEditViewModel))]
        public virtual async Task<ActionResult> MyEdit()
        {
            var viewModel = await _companyFactory.PrepareEditViewModelAsync(applyCurrentUser: true);
            return viewModel != null ? View(MVC.Company.Views.Edit, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        [MvcAuthorize(PermissionConst.CanCompanyMyEdit)]
        [ValidateInput(false)]
        public virtual async Task<ActionResult> MyEdit(CompanyEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);
            
            await _companyService.EditByViewModelAsync(viewModel, true);
            this.MessageSuccess(" عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Company.MyEdit());
        }

        [MvcSiteMapNode(ParentKey = "Public_Home_Index", Title = "جزئیات", Key = "Public_Company_Detail", PreservedRouteParameters = "id")]
        public virtual async Task<ActionResult> Detail(string alias, string slug = "")
        {
            if (alias == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _companyFactory.PrepareDetailViewModelAsync(alias, slug);
            return viewModel == null ? View(MVC.Error.Views.InternalServerError) : View(MVC.Company.Views.Detail, viewModel);
        }



        public virtual async Task<ActionResult> Near()
        {
            return View(MVC.Company.Views.Near);
        }

        [AjaxOnly]
        public virtual async Task<JsonResult> ApproveAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _companyService.SetStateByIdAsync(id.Value, StateType.Approved);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        [AjaxOnly]
        public virtual async Task<JsonResult> RejectAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _companyService.SetStateByIdAsync(id.Value, StateType.Rejected);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}