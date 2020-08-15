using Advertise.Core.Constants;
using Advertise.Core.Models.SeoUrl;
using Advertise.Service.Factories.Seos;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Seo;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class SeoUrlController : Controller
    {
        #region Private Fields

        private readonly ISeoUrlFactory _seoUrlFactory;
        private readonly ISeoUrlService _seoUrlService;

        #endregion Private Fields

        #region Public Constructors


        public SeoUrlController(ISeoUrlService seoUrlService, ISeoUrlFactory seoUrlFactory)
        {
            _seoUrlService = seoUrlService;
            _seoUrlFactory = seoUrlFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanSeoUrlCreate)]
        [ImportModelData(typeof(SeoUrlCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            var viewModel = await _seoUrlFactory.PrepareCreateViewModelAsync();
            return View(MVC.SeoUrl.Views.Create, viewModel);
        }


        [HttpPost]
        [MvcAuthorize(PermissionConst.CanSeoUrlCreate)]
        public virtual async Task<ActionResult> Create(SeoUrlCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

           
            await _seoUrlService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("با موفقیت اضافه گردید");
            return RedirectToAction(MVC.SeoUrl.Create());
        }


        [MvcAuthorize(PermissionConst.CanSeoUrlDeleteAjax)]
        public virtual async Task<ActionResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _seoUrlService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanSeoUrlEdit)]
        [ImportModelData(typeof(SeoUrlEditViewModel))]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _seoUrlFactory.PrepareEditViewModelAsync(id.Value);
            return viewModel != null ? View(MVC.SeoUrl.Views.Edit, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


        [HttpPost]
        [MvcAuthorize(PermissionConst.CanSeoUrlEdit)]
        public virtual async Task<ActionResult> Edit(SeoUrlEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

           
            await _seoUrlService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("با موفقیت اضافه گردید");
            return RedirectToAction(MVC.SeoUrl.List());
        }


        [MvcAuthorize(PermissionConst.CanSeoUrlList)]
        public virtual async Task<ActionResult> List(SeoUrlSearchRequest request)
        {
            var viewModel = await _seoUrlFactory.PrepareListViewModelAsync(request);
            return viewModel != null ? View(MVC.SeoUrl.Views.List, viewModel) : View(MVC.Error.Views.InternalServerError);
        }

        #endregion Public Methods
    }
}