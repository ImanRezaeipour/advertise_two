using Advertise.Core.Models.Manufacturer;
using Advertise.Service.Factories.Manufacturers;
using Advertise.Service.Services.Manufacturers;
using Advertise.Web.Framework.Extensions;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Advertise.Core.Constants;
using Advertise.Service.Services.Permissions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;

namespace Advertise.Web.Controllers
{
    public partial class ManufacturerController : Controller
    {
        #region Private Fields

        private readonly IManufacturerFactory _manufacturerFactory;
        private readonly IManufacturerService _manufacturerService;

        #endregion Private Fields

        #region Public Constructors

        public ManufacturerController(IManufacturerService manufacturerService, IManufacturerFactory manufacturerFactory)
        {
            _manufacturerService = manufacturerService;
            _manufacturerFactory = manufacturerFactory;
        }

        #endregion Public Constructors

        #region Public Methods

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanManufacturerCreate)]
        public virtual async Task<ActionResult> Create(ManufacturerCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

           
            await _manufacturerService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Manufacturer.Create());
        }

        [MvcAuthorize(PermissionConst.CanManufacturerCreate)]
        [ImportModelData(typeof(ManufacturerCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            var viewModel = await _manufacturerFactory.PrepareCreateViewModelAsync();
            return View(MVC.Manufacturer.Views.Create,viewModel);
        }


        [MvcAuthorize(PermissionConst.CanManufacturerEdit)]
        [ImportModelData(typeof(ManufacturerEditViewModel))]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _manufacturerFactory.PrepareEditViewModelAsync(id.Value);
            return View(MVC.Manufacturer.Views.Edit, viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanManufacturerEdit)]
        public virtual async Task<ActionResult> Edit(ManufacturerEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            
            await _manufacturerService.EditByViewMoodelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Manufacturer.Edit());
        }

        [MvcAuthorize(PermissionConst.CanManufacturerDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest),JsonRequestBehavior.AllowGet);

            await _manufacturerService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        [MvcAuthorize(PermissionConst.CanManufacturerList)]

        public virtual async Task<ActionResult> List(ManufacturerSearchRequest request)
        {
            var viewModel = await _manufacturerFactory.PrepareListViewModelAsync(request);
            return View(MVC.Manufacturer.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}