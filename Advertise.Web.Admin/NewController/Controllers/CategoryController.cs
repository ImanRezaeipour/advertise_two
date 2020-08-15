using Advertise.Core.Constants;
using Advertise.Core.Models.Category;
using Advertise.Service.Factories.Categories;
using Advertise.Service.Services.Categories;
using Advertise.Service.Services.Permissions;
using Advertise.Service.Validators.Categories;
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
    public partial class CategoryController : BaseController
    {

        #region Private Fields

        private readonly ICategoryFactory _categoryFactory;
        private readonly ICategoryService _categoryService;

        #endregion Private Fields

        #region Public Constructors

      
        public CategoryController(ICategoryService categoryService, ICategoryFactory categoryFactory)
        {
            _categoryService = categoryService;
            _categoryFactory = categoryFactory;
        }

        #endregion Public Constructors

        #region Public Methods

      
        [ChildActionOnly]
        public virtual ActionResult BreadCrumb(Guid? categoryId, string currentTitle, bool? isAllSearch)
        {
            if (categoryId == null)
                throw new ArgumentNullException(nameof(categoryId));

            var viewModel = AsyncContext.Run(() => _categoryFactory.PrepareBreadCrumbViewModelAsync(categoryId.Value, currentTitle, isAllSearch));
            return PartialView(MVC.Category.Views._BreadCrumb, viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [MvcAuthorize(PermissionConst.CanCategoryCreate)]
        public virtual async Task<ActionResult> Create(CategoryCreateViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _categoryService.CreateByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Category.Create());
        }


        [MvcSiteMapNode(ParentKey = "Panel_Category_List", Title = "ایجاد دسته", Key = "Panel_Category_New")]
        [MvcAuthorize(PermissionConst.CanCategoryCreate)]
        [ImportModelData(typeof(CategoryCreateViewModel))]
        public virtual async Task<ActionResult> Create()
        {
            var viewModel = await _categoryFactory.PrepareCreateViewModelAsync();
            return View(MVC.Category.Views.Create, viewModel);
        }

      
        [MvcAuthorize(PermissionConst.CanCategoryDeleteAjax)]
        public virtual async Task<JsonResult> DeleteAjax(string code)
        {
            if (code == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _categoryService.DeleteByAliasAsync(code);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        [MvcSiteMapNode(ParentKey = "Public_Home_Index", Title = "جزئیات دسته", Key = "Public_Category_Detail", PreservedRouteParameters = "alias")]
        public virtual async Task<ActionResult> Detail(string alias, string slug = "")
        {
            if (alias == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _categoryFactory.PrepareDetailViewModelAsync(alias, slug);
            return viewModel == null ? View(MVC.Error.Views.InternalServerError) : View(MVC.Category.Views.Detail, viewModel);
        }




        [MvcSiteMapNode(ParentKey = "Panel_Category_List", Title = "ویرایش دسته", Key = "Panel_Category_Edit", PreservedRouteParameters = "alias")]
        [MvcAuthorize(PermissionConst.CanCategoryEdit)]
        [ImportModelData(typeof(CategoryEditViewModel))]
        public virtual async Task<ActionResult> Edit(string alias)
        {  
            if (alias == null)
                return View(MVC.Error.Views.BadRequest);

            var viewModel = await _categoryFactory.PrepareEditViewModelAsync(alias);
            return viewModel == null ? View(MVC.Error.Views.InternalServerError) : View(MVC.Category.Views.Edit, viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [MvcAuthorize(PermissionConst.CanCategoryEdit)]
        public virtual async Task<ActionResult> Edit(CategoryEditViewModel viewModel)
        {
            if (viewModel == null)
                return View(MVC.Error.Views.BadRequest);

            await _categoryService.EditByViewModelAsync(viewModel);
            this.MessageSuccess("عملیات با موفقیت انجام شد");
            return RedirectToAction(MVC.Category.List());
        }


        [MvcAuthorize(PermissionConst.CanCategoryGetCategoriesAjax)]
        public virtual async Task<JsonResult> GetCategoriesAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest));

            var categories = await _categoryService.GetSubCategoriesByParentIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(categories), JsonRequestBehavior.AllowGet);
        }


        public virtual async Task<JsonResult> GetFileAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest));

            var files = await _categoryService.GetFileAsFineUploaderModelByIdAsync(id.Value);
            return Json(files, JsonRequestBehavior.AllowGet);
        }


        public virtual async Task<JsonResult> GetMainCategoriesAjax()
        {
            var categories = await _categoryService.GetMainCategoriesAsync();
            return Json(AjaxResult.Succeeded(categories), JsonRequestBehavior.AllowGet);
        }

     
        public virtual async Task<JsonResult> GetRelatedCategoriesAjax(string alias)
        {
            var categories = await _categoryService.GetRaletedCategoriesByAliasAsync(alias);
            return Json(AjaxResult.Succeeded(categories), JsonRequestBehavior.AllowGet);
        }


        [MvcAuthorize(PermissionConst.CanCategoryGetSubCatergoriesWithRootAjax)]
        public virtual async Task<JsonResult> GetSubCatergoriesWithRootAjax(Guid? id)
        {
            if (id == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var categories = await _categoryService.GetSubCatergoriesWithRootByIdAsync(id.Value);
            return Json(AjaxResult.Succeeded(categories), JsonRequestBehavior.AllowGet);
        }


        public virtual async Task<JsonResult> GetTreeAjax()
        {
            var categories = await _categoryService.GetAllAsync();
            return Json(AjaxResult.Succeeded(categories), JsonRequestBehavior.AllowGet);
        }


        [MvcSiteMapNode(ParentKey = "Panel_Home_Index", Title = "دسته ها", Key = "Panel_Category_List")]
        [MvcAuthorize(PermissionConst.CanCategoryList)]
        public virtual async Task<ActionResult> List(CategorySearchRequest request)
        {
            var viewModel = await _categoryFactory.PrepareListViewModelAsync(request);
            return View(MVC.Category.Views.List, viewModel);
        }

        #endregion Public Methods
    }
}