using Advertise.Core.Constants;
using Advertise.Core.Models.Permission;
using Advertise.Service.Factories.Permissions;
using Advertise.Service.Services.Permissions;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class PermissionController : BaseController
    {
        #region Private Fields

        private readonly IPermissionFactory _permissionFactory;
        private readonly IPermissionService _permissionService;

        #endregion Private Fields

        #region Public Constructors

     
        public PermissionController(IPermissionService permissionService, IPermissionFactory permissionFactory)
        {
            _permissionService = permissionService;
            _permissionFactory = permissionFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        public virtual async Task<ActionResult> Create()
        {
            return View(MVC.Permission.Views.Create);
        }


        [HttpPost]
        public virtual async Task<ActionResult> Create(PermissionCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            if (ModelState.IsValid == false)
            {
                this.MessageSuccess("خطایی رخ داده مجدد امتحان کنید");
                return View(MVC.Permission.Views.Create, viewModel);
            }

            await _permissionService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Permission.List());
        }


        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _permissionFactory.PrepareEditViewModelAsync(id.Value);
            return View(MVC.Permission.Views.Edit, viewModel);
        }


        [HttpPost]
        public virtual async Task<ActionResult> Edit(PermissionEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            if (ModelState.IsValid == false)
            {
                this.MessageSuccess("خطایی رخ داده مجدد امتحان کنید");
                return View(MVC.Permission.Views.Edit, viewModel);
            }

            await _permissionService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Permission.List());
        }

      
        [MvcAuthorize(PermissionConst.CanPermissionGetListAjax)]
        public virtual async Task<JsonResult> GetListAjax()
        {
            var permissions = await _permissionService.GetAllPermissionsAsync();
            return Json(AjaxResult.Succeeded(permissions), JsonRequestBehavior.AllowGet);
        }

      
        public virtual async Task<JsonResult> GetListByRoleIdAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var permissions = await _permissionService.GetAllTreeByRoleIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(permissions), JsonRequestBehavior.AllowGet);
        }


        public virtual async Task<JsonResult> GetPermissionsAjax()
        {
            var permissions = await _permissionService.GetAllTreeAsync();
            return Json(AjaxResult.Succeeded(permissions), JsonRequestBehavior.AllowGet);
        }


        public virtual async Task<ActionResult> List(PermissionSearchRequest request)
        {
            var viewModel = await _permissionFactory.PrepareListViewModel(request);
            return View(MVC.Permission.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}