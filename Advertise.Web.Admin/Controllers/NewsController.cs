using Advertise.Core.Constants;
using Advertise.Core.Models.News;
using Advertise.Service.Factories.Newses;
using Advertise.Service.Services.Newses;
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

    public partial class NewsController : BaseController
    {
        #region Private Fields

        private readonly INewsFactory _newsFactory;
        private readonly INewsService _newsService;

        #endregion Private Fields

        #region Public Constructors

     
        public NewsController(INewsService newsService, INewsFactory newsFactory)
        {
            _newsService = newsService;
            _newsFactory = newsFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanNewsCreate)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(NewsCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);
           
            await _newsService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.News.Create());
        }


        [MvcAuthorize(PermissionConst.CanNewsCreate)]
        [MvcSiteMapNode(ParentKey = "Panel_News_List", Title = "ایجاد", Key = "Panel_News_New")]
        [ImportModelData(typeof(NewsCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            return View(MVC.News.Views.Create);
        }


        [MvcAuthorize(PermissionConst.CanNewsDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _newsService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanNewsEdit)]
        [MvcSiteMapNode(ParentKey = "Panel_News_List", Title = "ویرایش", Key = "Panel_News_Edit", PreservedRouteParameters = "id")]
        [ImportModelData(typeof(NewsEditViewModel))]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _newsFactory.PrepareEditViewModelAsync(id.Value);
            return viewModel != null ? View(MVC.News.Views.Edit, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


        [HttpPost]
        [MvcAuthorize(PermissionConst.CanNewsEdit)]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Edit(NewsEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

           
            await _newsService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.News.Edit(viewModel.Id));
        }


        [MvcAuthorize(PermissionConst.CanNewsList)]
        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "خبرها", Key = "Panel_News_List")]
        public virtual async Task<ActionResult> List(NewsSearchRequest request)
        {
            var viewModel = await _newsFactory.PrepareListViewModelAsync(request);
            return View(MVC.News.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}