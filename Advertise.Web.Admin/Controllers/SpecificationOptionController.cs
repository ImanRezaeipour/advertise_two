using Advertise.Core.Constants;
using Advertise.Core.Models.SpecificationOption;
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

    public partial class SpecificationOptionController : BaseController
    {
        #region Private Fields

        private readonly ISpecificationOptionFactory _specificationOptionFactory;
        private readonly ISpecificationOptionService _specificationOptionService;

        #endregion Private Fields

        #region Public Constructors

        public SpecificationOptionController(ISpecificationOptionService specificationOptionService, ISpecificationOptionFactory specificationOptionFactory)
        {
            _specificationOptionService = specificationOptionService;
            _specificationOptionFactory = specificationOptionFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanSpecificationOptionCreate)]
        public virtual async Task<ActionResult> Create(SpecificationOptionCreateViewModel viewModel)
        {
           await _specificationOptionService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.SpecificationOption.Create());
        }


        [MvcAuthorize(PermissionConst.CanSpecificationOptionCreate)]
        [MvcSiteMapNode(ParentKey = "Panel_SpecificationOption_List", Title = "ویرایش", Key = "Panel_SpecificationOption_New")]
        [ImportModelData(typeof(SpecificationOptionCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            var viewModel = await _specificationOptionFactory.PrepareCreateViewModelAsync();
            return View(MVC.SpecificationOption.Views.Create, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanSpecificationOptionDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _specificationOptionService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanSpecificationOptionEdit)]
        [MvcSiteMapNode(ParentKey = "Panel_SpecificationOption_List", Title = "ویرایش", Key = "Panel_SpecificationOption_Edit", PreservedRouteParameters = "id")]
        [ImportModelData(typeof(SpecificationOptionEditViewModel))]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _specificationOptionFactory.PrepareEditViewModelAsync(id.Value);
            return viewModel != null ? View(MVC.SpecificationOption.Views.Edit, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanSpecificationOptionEdit)]
        public virtual async Task<ActionResult> Edit(SpecificationOptionEditViewModel viewModel)
        {
           await _specificationOptionService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.SpecificationOption.Edit(viewModel.Id));
        }


        [MvcAuthorize(PermissionConst.CanSpecificationOptionList)]
        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "مقدار مشخصه ها", Key = "Panel_SpecificationOption_List")]
        public virtual async Task<ActionResult> List(SpecificationOptionSearchRequest request)
        {
            var viewModel = await _specificationOptionFactory.PrepareListViewModelAsync(request);
            return View(MVC.SpecificationOption.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}