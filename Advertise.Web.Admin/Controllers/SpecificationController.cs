using Advertise.Core.Constants;
using Advertise.Core.Models.Specification;
using Advertise.Service.Factories.Specifications;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Specifications;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class SpecificationController : BaseController
    {
        #region Private Fields

        private readonly ISpecificationFactory _specificationFactory;
        private readonly ISpecificationService _specificationService;

        #endregion Private Fields

        #region Public Constructors

        public SpecificationController(ISpecificationService specificationService, ISpecificationFactory specificationFactory)
        {
            _specificationService = specificationService;
            _specificationFactory = specificationFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanSpecificationCreate)]
        public virtual async Task<ActionResult> Create(SpecificationCreateViewModel viewModel)
        {
           await _specificationService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Specification.Create());
        }


        [MvcSiteMapNode(ParentKey = "Panel_Specification_List", Title = "ایجاد", Key = "Panel_Specification_New")]
        [MvcAuthorize(PermissionConst.CanSpecificationCreate)]
        [ImportModelData(typeof(SpecificationCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            var viewModel = await _specificationFactory.PrepareCreateViewModelAsync();
            return View(MVC.Specification.Views.Create, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanSpecificationDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _specificationService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanSpecificationEdit)]
        [MvcSiteMapNode(ParentKey = "Panel_Specification_List", Title = "ویرایش", Key = "Panel_Specification_Edit", PreservedRouteParameters = "id")]
        [ImportModelData(typeof(SpecificationEditViewModel))]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _specificationFactory.PrepareEditViewModelAsync(id.Value);
            return viewModel != null ? View(MVC.Specification.Views.Edit, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanSpecificationEdit)]
        public virtual async Task<ActionResult> Edit(SpecificationEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

           await _specificationService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Specification.List());
        }


        [MvcAuthorize(PermissionConst.CanSpecificationGetListByCategoryAjax)]
        public virtual async Task<JsonResult> GetListByCategoryAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var specifications = await _specificationService.GetObjectByCategoryAsync(id.Value);
            return Json(AjaxResult.Succeeded(specifications), JsonRequestBehavior.AllowGet);
        }

        public virtual async Task<ActionResult> GetListByCategory(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel= await _specificationService.GetObjectByCategoryAsync(id.Value);
            return View(MVC.Product.Views._ListSpecification,viewModel);

        }


        public virtual async Task<JsonResult> GetListSpecificationAjax(Guid id)
        {
            var specifications = await _specificationService.GetObjectByCategoryAsync(id);
            return Json(AjaxResult.Succeeded(specifications), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanSpecificationList)]
        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "مشخصه ها", Key = "Panel_Specification_List")]
        public virtual async Task<ActionResult> List(SpecificationSearchRequest request)
        {
            var viewModel = await _specificationFactory.PrepareListViewModelAsync(request);
            return View(MVC.Specification.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}