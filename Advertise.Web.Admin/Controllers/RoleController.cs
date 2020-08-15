using Advertise.Core.Constants;
using Advertise.Core.Models.Role;
using Advertise.Service.Factories.Users;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Users;
using Advertise.Service.Validators.Roles;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class RoleController : BaseController
    {
        #region Private Fields

        private readonly IRoleFactory _roleFactory;
        private readonly IRoleService _roleService;

        #endregion Private Fields

        #region Public Constructors

        public RoleController(IRoleService roleService, IRoleFactory roleFactory)
        {
            _roleService = roleService;
            _roleFactory = roleFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanRoleCreate)]
        public virtual async Task<ActionResult> Create(RoleCreateViewModel viewModel)
        {
            await _roleService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Role.Create());
        }


        [MvcAuthorize(PermissionConst.CanRoleCreate)]
        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "نقش ها", Key = "Panel_Role_New")]
        [ImportModelData(typeof(RoleCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            return View(MVC.Role.Views.Create);
        }


        [MvcAuthorize(PermissionConst.CanRoleDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _roleService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanRoleEdit)]
        [MvcSiteMapNode(ParentKey = "Panel_Role_ItemList", Title = "ویرایش", Key = "Panel_Role_Edit", PreservedRouteParameters = "id")]
        [ImportModelData(typeof(RoleEditViewModel))]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _roleFactory.PrepareEditViewModelAsync(id.Value);
            return View(MVC.Role.Views.Edit, viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanRoleEdit)]
        public virtual async Task<ActionResult> Edit(RoleEditViewModel viewModel)
        {
           await _roleService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Role.List());
        }


        [MvcAuthorize(PermissionConst.CanRoleList)]
        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "نقش ها", Key = "Panel_Role_ItemList")]
        public virtual async Task<ActionResult> List(RoleSearchRequest request)
        {
            var viewModel = await _roleFactory.PrepareListViewModelAsync(request);
            return View(MVC.Role.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}