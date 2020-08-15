using Advertise.Core.Constants;
using Advertise.Core.Models.User;
using Advertise.Service.Factories.Users;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Users;
using Advertise.Service.Validators.Accounts;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using Nito.AsyncEx;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class UserController : BaseController
    {
        #region Private Fields

        private readonly IUserFactory _userFactory;
        private readonly IUserService _userService;

        #endregion Private Fields

        #region Public Constructors

        public UserController(IUserService userService,  IUserFactory userFactory)
        {
            _userService = userService;
            _userFactory = userFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanUserDelete)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _userService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcSiteMapNode(ParentKey = "Public_Home_Index", Title = "جزئیات", Key = "Panel_User_Detail", PreservedRouteParameters = "userUserName")]
        public virtual async Task<ActionResult> Detail(string userName, string slug = "")
        {
            if (userName == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _userFactory.PrepareDetailViewModelAsync(userName);
            return viewModel != null ? View(MVC.User.Views.Detail, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


        public virtual async Task<JsonResult> DetailAjax(string id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var userDetail = await _userFactory.PrepareDetailViewModelAsync(id);
            return Json(AjaxResult.Succeeded(userDetail), JsonRequestBehavior.AllowGet);
        }

        [MvcAuthorize(PermissionConst.CanUserEdit)]
        [MvcSiteMapNode(ParentKey = "Panel_User_List", Title = "تنظیم پسورد", Key = "Panel_User_Edit", PreservedRouteParameters = "username")]
        [ImportModelData(typeof(UserEditViewModel))]
        public virtual async Task<ActionResult> Edit(string username)
        {
            if (username == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _userFactory.PrepareEditViewModelAsync(username);
            return viewModel != null ? View(MVC.User.Views.Edit, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanUserEdit)]
        public virtual async Task<ActionResult> Edit(UserEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _userService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با  موفقیت انجام شد");
            return RedirectToAction(MVC.User.List());
        }


        public virtual async Task<JsonResult> GetFileAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var file = await _userService.GetFileAsFineUploaderModelByIdAsync(id.Value);
            return Json(file, JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanUserList)]
        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "کاربران", Key = "Panel_User_List")]
        public virtual async Task<ActionResult> List(UserSearchRequest request)
        {
            var viewModel = await _userFactory.PrepareListViewModelAsync(request);
            return View(MVC.User.Views.List, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanUserMyEdit)]
        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "ویرایش", Key = "Profile_UserMeta_MyEdit")]
        [ImportModelData(typeof(UserEditViewModel))]
        public virtual async Task<ActionResult> MyEdit()
        {
            var viewModel = await _userFactory.PrepareEditViewModelAsync(isCurrentUser: true);
            return viewModel != null ? View(MVC.User.Views.Edit, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanUserMyEdit)]
        public virtual async Task<ActionResult> MyEdit(UserEditMeViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _userService.EditMetaByViewModelAsync(viewModel, true);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Profile.Dashboard());
        }


        [ChildActionOnly]
        public virtual ActionResult UserHeader()
        {
            var viewModel = AsyncContext.Run(_userFactory.PrepareHeaderViewModelAsync);
            return PartialView(MVC.User.Views._Header, viewModel);
        }

        #endregion Public Methods
    }
}