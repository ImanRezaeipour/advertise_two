using Advertise.Core.Constants;
using Advertise.Core.Models.CompanySocial;
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

    public partial class CompanySocialController : BaseController
    {
        #region Private Fields

        private readonly ICompanySocialFactory _companySocialFactory;
        private readonly ICompanySocialService _companySocialService;

        #endregion Private Fields

        #region Public Constructors

      
        public CompanySocialController(ICompanySocialService companySocialService, ICompanySocialFactory companySocialFactory)
        {
            _companySocialService = companySocialService;
            _companySocialFactory = companySocialFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanCompanySocialCreate)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(CompanySocialCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            if (!ModelState.IsValid)
            {
                this.MessageError("خطایی بوجود آمده دوباره امتحان کنید");
                return View(MVC.CompanySocial.Views.Create,viewModel);
            }


            await _companySocialService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanySocial.Create());
        }


        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "ایجاد", Key = "Profile_CompanySocial_Create")]
        [MvcAuthorize(PermissionConst.CanCompanySocialCreate)]
        public virtual async Task<ActionResult> Create()
        {
            return View(MVC.CompanySocial.Views.Create);
        }


        [MvcAuthorize(PermissionConst.CanCompanySocialDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _companySocialService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcSiteMapNode(ParentKey = "Panel_CompanySocial_List", Title = "ویرایش", Key = "Panel_CompanySocial_Edit", PreservedRouteParameters = "id")]
        [MvcAuthorize(PermissionConst.CanCompanySocialEdit)]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _companySocialFactory.PrepareEditViewModelAsync(id.Value);
            return View(MVC.CompanySocial.Views.Edit, viewModel);
        }





        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "ویرایش", Key = "Profile_CompanySocial_Edit", PreservedRouteParameters = "id")]
        [MvcAuthorize(PermissionConst.CanCompanySocialMyEdit)]
        public virtual async Task<ActionResult> MyEdit()
        {
            var viewModel = await _companySocialFactory.PrepareEditViewModelAsync(null, true);
            return viewModel == null ? View(MVC.CompanySocial.Views.Create) : View(MVC.CompanySocial.Views.Edit, viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanCompanySocialMyEdit)]
        public virtual async Task<ActionResult> MyEdit(CompanySocialEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            if (!ModelState.IsValid)
            {
                this.MessageError("خطایی رخ داده دوباره امتحان کنید");
                var viewModelPrepare = await _companySocialFactory.PrepareEditViewModelAsync(null, true);
                return View(MVC.CompanySocial.Views.Edit, viewModelPrepare);

            }

            await _companySocialService.EditByViewModelAsync(viewModel, true);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CompanySocial.MyEdit());
        }

        #endregion Public Methods
    }
}