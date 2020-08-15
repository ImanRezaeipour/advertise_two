using Advertise.Core.Models.UserSetting;
using Advertise.Service.Factories.Users;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Users;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using MvcSiteMapProvider;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class UserSettingController : Controller
    {
        #region Private Fields

        private readonly IUserSettingFactory _userSettingFactory;
        private readonly IUserSettingService _userSettingService;

        #endregion Private Fields

        #region Public Constructors

        public UserSettingController(IUserSettingService userSettingService, IUserSettingFactory userSettingFactory)
        {
            _userSettingService = userSettingService;
            _userSettingFactory = userSettingFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanUserSettingEdit)]
        [MvcSiteMapNode(ParentKey = "Panel_UserSetting_List", Title = "ویرایش", Key = "Panel_UserSetting_Edit", PreservedRouteParameters = "id")]
        [ImportModelData(typeof(UserSettingEditViewModel))]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _userSettingFactory.PrepareEditViewModelAsync(id.Value);
            return View(MVC.UserSetting.Views.Edit, viewModel);
        }


     


        [MvcAuthorize(PermissionConst.CanUserSettingMyEdit)]
        [MvcSiteMapNode(ParentKey = "Panel_UserSetting_List", Title = "ویرایش", Key = "Panel_UserSetting_EditMe", PreservedRouteParameters = "id")]
        public virtual async Task<ActionResult> MyEdit()
        {
            var viewModel = await _userSettingFactory.PrepareEditViewModelAsync(isCurrentUser: true);
            return View(MVC.UserSetting.Views.Edit, viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanUserSettingMyEdit)]
        public virtual async Task<ActionResult> MyEdit(UserSettingEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _userSettingService.EditByViewModelAsync(viewModel, true);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.UserSetting.MyEdit());
        }

        #endregion Public Methods
    }
}