using Advertise.Core.Constants;
using Advertise.Core.Models.Tag;
using Advertise.Service.Factories.Tags;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Services.Tags;
using Advertise.Web.Framework.Extensions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class TagController : Controller
    {
        #region Private Fields

        private readonly ITagFactory _tagFactory;
        private readonly ITagService _tagService;

        #endregion Private Fields

        #region Public Constructors


        public TagController(ITagService tag, ITagFactory tagFactory)
        {
            _tagService = tag;
            _tagFactory = tagFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [MvcAuthorize(PermissionConst.CanTagCreate)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Create(TagCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _tagService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Tag.Create());
        }


        [MvcSiteMapNode(ParentKey = "Panel_Tag_List", Title = "ایجاد", Key = "Panel_Tag_New")]
        [MvcAuthorize(PermissionConst.CanTagCreate)]
        [ImportModelData(typeof(TagCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            var viewModel = await _tagFactory.PrepareCreateViewModelAsync();
            return View(MVC.Tag.Views.Create, viewModel);
        }


        [MvcAuthorize(PermissionConst.CanTagDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _tagService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcSiteMapNode(ParentKey = "Panel_Tag_List", Title = "ویرایش", Key = "Panel_Tag_Edit", PreservedRouteParameters = "id")]
        [MvcAuthorize(PermissionConst.CanTagEdit)]
        [ImportModelData(typeof(TagEditViewModel))]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _tagFactory.PrepareEditViewModelAsync(id.Value);
            return View(MVC.Tag.Views.Edit, viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanTagEdit)]
        public virtual async Task<ActionResult> Edit(TagEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _tagService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Tag.Edit(viewModel.Id));
        }


        public virtual async Task<JsonResult> GetFileAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var file = await _tagService.GetFileAsFineUploaderModelByIdAsync(id.Value);
            return Json(file, JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanTagList)]
        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "برچسب ها", Key = "Panel_Tag_List")]
        public virtual async Task<ActionResult> List(TagSearchRequest request)
        {
            var viewModel = await _tagFactory.PrepareListViewModelAsync(request);
            return View(MVC.Tag.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}