using Advertise.Core.Constants;
using Advertise.Core.Models.CategoryReview;
using Advertise.Service.Factories.Categories;
using Advertise.Service.Services.Categories;
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

    public partial class CategoryReviewController : BaseController
    {
        #region Private Fields

        private readonly ICategoryReviewFactory _categoryReviewFactory;
        private readonly ICategoryReviewService _categoryReviewService;

        #endregion Private Fields

        #region Public Constructors

      
        public CategoryReviewController(ICategoryReviewService categoryReviewService, ICategoryReviewFactory categoryReviewFactory)
        {
            _categoryReviewService = categoryReviewService;
            _categoryReviewFactory = categoryReviewFactory;
        }

        #endregion Public Constructors

        #region Public Methods


        [HttpPost]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanCategoryReviewCreate)]
        [ValidateInput(false)]
        public virtual async Task<ActionResult> Create(CategoryReviewCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);
               

            await _categoryReviewService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CategoryReview.Create());
        }


        [MvcAuthorize(PermissionConst.CanCategoryReviewCreate)]
        [MvcSiteMapNode(ParentKey = "Panel_CategoryReview_List", Title = "نقد و بررسی دسته ها", Key = "Panel_CategoryReview_New")]
        [ImportModelData(typeof(CategoryReviewCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            return View(MVC.CategoryReview.Views.Create);
        }


        [MvcAuthorize(PermissionConst.CanCategoryReviewDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _categoryReviewService.DeleteByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanCategoryReviewEdit)]
        [MvcSiteMapNode(ParentKey = "Panel_CategoryReview_List", Title = "نقد و بررسی دسته ها", Key = "Panel_CategoryReview_Edit", PreservedRouteParameters = "id")]
        [ImportModelData(typeof(CategoryReviewEditViewModel))]
        public virtual async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _categoryReviewFactory.PrepareEditViewModelAsync(id.Value);
            return viewModel != null ? View(MVC.CategoryReview.Views.Edit, viewModel) : View(MVC.Error.Views.InternalServerError);
        }


        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [MvcAuthorize(PermissionConst.CanCategoryReviewEdit)]
        public virtual async Task<ActionResult> Edit(CategoryReviewEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

          await _categoryReviewService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.CategoryReview.List());
        }


        [MvcAuthorize(PermissionConst.CanCategoryReviewList)]
        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "نقد و بررسی دسته ها", Key = "Panel_CategoryReview_List")]
        public virtual async Task<ActionResult> List(CategoryReviewSearchRequest request)
        {
            var viewModel = await _categoryReviewFactory.PrepareListViewModelAsync(request);
            return View(MVC.CategoryReview.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}