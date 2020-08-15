using Advertise.Core.Constants;
using Advertise.Service.Factories.Catalogs;
using Advertise.Service.Services.Catalogs;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Results;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Advertise.Core.Models.Catalog;
using Advertise.Service.Services.Permissions;
using Advertise.Web.Framework.Filters;

namespace Advertise.Web.Controllers
{

    public partial class CatalogController : Controller
    {
        #region Private Fields

        private readonly ICatalogFactory _catalogFactory;
        private readonly ICatalogService _catalogService;

        #endregion Private Fields

        #region Public Constructors

     
        public CatalogController(ICatalogService catalogService, ICatalogFactory catalogFactory)
        {
            _catalogService = catalogService;
            _catalogFactory = catalogFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [MvcAuthorize(PermissionConst.CanCatalogCreate)]

        public virtual async Task<ActionResult> Create(CatalogCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _catalogService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Catalog.Create());
        }


        [MvcAuthorize(PermissionConst.CanCatalogCreate)]
        public virtual async Task<ActionResult> Create()
        {
            var viewModel = await _catalogFactory.PrepareCreateViewModelAsync();
            return View(MVC.Catalog.Views.Create, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanCatalogDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _catalogService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanCatalogEdit)]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _catalogFactory.PrepareEditViewModelAsync(id.Value);
            return viewModel == null ? View(MVC.Error.Views.InternalServerError) : View(MVC.Catalog.Views.Edit, viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [MvcAuthorize(PermissionConst.CanCatalogEdit)]

        public virtual async Task<ActionResult> Edit(CatalogEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _catalogService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Catalog.List());
        }


        [MvcAuthorize(PermissionConst.CanCatalogList)]

        public virtual async Task<ActionResult> List(CatalogSearchRequest request)
        {
            var viewModel = await _catalogFactory.PrepareListViewModelAsync(request);
            return View(MVC.Catalog.Views.List, viewModel);
        }


        public virtual async Task<JsonResult> GetFileAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest));

            var file = await _catalogService.GetFileAsFineUploaderModelByIdAsync(id.Value);
            return Json(file, JsonRequestBehavior.AllowGet);
        }


        public virtual async Task<JsonResult> GetFilesAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest));

            var files = await _catalogService.GetFilesAsFineUploaderModelByIdAsync(id.Value);
            return Json(files, JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}