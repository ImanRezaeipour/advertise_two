using Advertise.Core.Constants;
using Advertise.Core.Models.UserViolation;
using Advertise.Service.Factories.Users;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Users;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{
    public partial class UserViolationController : BaseController
    {
        #region Private Fields

        private readonly IUserViolationFactory _userViolationFactory;
        private readonly IUserViolationService _userViolationService;

        #endregion Private Fields

        #region Public Constructors


        public UserViolationController(IUserViolationService userViolationService, IUserViolationFactory userViolationFactory)
        {
            _userViolationService = userViolationService;
            _userViolationFactory = userViolationFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanUserViolationCreate)]
        public virtual async Task<ActionResult> Create(UserViolationCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            if (!ModelState.IsValid)
                return View(MVC.News.Views.Create, viewModel);

            await _userViolationService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("با موفقیت ثبت شد");
            return RedirectToAction(MVC.UserViolation.List());
        }


        [MvcAuthorize(PermissionConst.CanUserViolationCreate)]
        [MvcSiteMapNode(ParentKey = "Panel_Report_List", Title = "ایجاد", Key = "Panel_Report_New")]
        public virtual async Task<ActionResult> Create()
        {
            return View(MVC.UserViolation.Views.Create);
        }


        [MvcAuthorize(PermissionConst.CanUserViolationDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _userViolationService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcSiteMapNode(ParentKey = "Panel_Report_List", Title = "ویرایش", Key = "Panel_Report_Edit")]
        [MvcAuthorize(PermissionConst.CanUserViolationEdit)]
        public virtual async Task<ActionResult> Edit()
        {
            return View(MVC.UserViolation.Views.Edit);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanUserViolationEdit)]
        public virtual async Task<ActionResult> Edit(UserViolationEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            if (!ModelState.IsValid)
                return View(MVC.CompanySocial.Views.Edit, viewModel);

            await _userViolationService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("با موفقیت ویرایش شد");
            return RedirectToAction(MVC.UserViolation.List());
        }


        [MvcAuthorize(PermissionConst.CanUserViolationList)]
        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "گزارشات", Key = "Panel_Report_List")]
        public virtual async Task<ActionResult> List(UserViolationSearchRequest request)
        {
            var viewModel = await _userViolationFactory.PrepareListViewModelAsync(request);
            return View(MVC.UserViolation.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}