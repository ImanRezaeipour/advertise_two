using Advertise.Core.Constants;
using Advertise.Service.Factories.Categories;
using Advertise.Service.Services.Categories;
using Advertise.Service.Services.Permissions;
using Advertise.Web.Framework.Filters;
using Advertise.Web.Framework.Results;
using MvcSiteMapProvider;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Advertise.Web.Controllers
{

    public partial class CategoryFollowController : BaseController
    {
        #region Private Fields

        private readonly ICategoryFollowFactory _categoryFollowFactory;
        private readonly ICategoryFollowService _categoryFollowService;

        #endregion Private Fields

        #region Public Constructors

      
        public CategoryFollowController(ICategoryFollowService categoryFollowService, ICategoryFollowFactory categoryFollowFactory)
        {
            _categoryFollowService = categoryFollowService;
            _categoryFollowFactory = categoryFollowFactory;
        }

        #endregion Public Constructors

        #region Public Methods

    
        public virtual async Task<JsonResult> CountFollowAjax(Guid? categoryId)
        {
            if (categoryId == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var follows = await _categoryFollowService.CountAllFollowByCategoryIdAsync(categoryId.Value);
            return Json(AjaxResult.Succeeded(follows), JsonRequestBehavior.AllowGet);
        }


        [MvcSiteMapNode(ParentKey = "Profile_Home_Index", Title = "لیست فالوهای من", Key = "Profile_CategoryFollow_MyFollowList")]
        public virtual async Task<ActionResult> MyFollowList()
        {
            var viewModel = await _categoryFollowFactory.PrepareListViewModelAsync(true);
            return View(MVC.CategoryFollow.Views.MyFollowList, viewModel);
        }

       
        [MvcAuthorize(PermissionConst.CanCategoryFollowMyIsFollowAjax)]
        public virtual async Task<JsonResult> MyIsFollowAjax(Guid? categoryId)
        {
            if (categoryId == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            var isFollow = await _categoryFollowService.IsFollowCurrentUserByCategoryIdAsync(categoryId.Value);
            return Json(AjaxResult.Succeeded(isFollow), JsonRequestBehavior.AllowGet);
        }

     
        [MvcAuthorize(PermissionConst.CanCategoryFollowMyToggleFollowAjax)]
        public virtual async Task<JsonResult> MyToggleAjax(Guid? categoryId)
        {
            if (categoryId == null)
                return Json(AjaxResult.Failed(AjaxErrorStatus.BadRequest), JsonRequestBehavior.AllowGet);

            await _categoryFollowService.ToggleFollowCurrentUserByCategoryIdAsync(categoryId.Value);
            return Json(AjaxResult.Succeeded(), JsonRequestBehavior.AllowGet);
        }

        #endregion Public Methods
    }
}