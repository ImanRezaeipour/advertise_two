using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Categories;
using Advertise.Core.Models.Category;
using Advertise.Core.Models.Common;
using Advertise.Core.Objects;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Categories
{
    public interface ICategoryService
    {
        #region Public Methods

        Task<int> CountAllAsync();

        Task<int> CountByRequestAsync(CategorySearchRequest request);

        /// <summary>
        ///ایجاد دسته
        /// </summary>
        /// <param name="viewModel"></param>
        Task CreateByViewModelAsync(CategoryCreateViewModel viewModel);

        Task DeleteByAliasAsync(string categoryAlias);

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task DeleteByIdAsync(Guid categoryId);


        Task EditByViewModelAsync(CategoryEditViewModel viewModel);


        Task<Category> FindByIdAsync(Guid categoryId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryAlias"></param>
        /// <returns></returns>
        Task<Category> FindByAliasAsync(string categoryAlias);

        Task<Category> FindByCodeAsync(string categoryCode);

        Task<Category> FindParentAsync(Guid categoryId);

        Task<Category> GetRootAsync();


     IQueryable<Category> QueryByRequest(CategorySearchRequest request);


        Task<object> GetAllAsync();


        Task<IList<CategoryViewModel>> GetAllSalableTypeAsync();

        Task<IList<Category>> GetByRequestAsync(CategorySearchRequest request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        Task<IList<CategoryViewModel>> GetCategoriesByParentId(Guid parentId);

        Task<IList<Category>> GetChildsByIdAsync(Guid categoryId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<IList<FineUploaderObject>> GetFileAsFineUploaderModelByIdAsync(Guid categoryId);

        Task<IList<SelectListItem>> GetMainCategoriesAsSelectListItemAsync();

        Task<IList<CategoryViewModel>> GetMainCategoriesAsync();

        Task<object> GetSubCategoriesByParentIdAsync(Guid parentId);


        Task SeedAsync();

        #endregion Public Methods


        Task<List<SelectListItem>> GetAllAsSelectListAsync();

        Task<object> GetSubCatergoriesWithRootByIdAsync(Guid categoryId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alias"></param>
        /// <param name="slug"></param>
        /// <returns></returns>
        Task<bool> IsCompareNameAndSlugAsync(string alias, string slug);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CategoryOption> GetCategoryOptionByIdAsync(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<IList<Category>> GetParentsByIdAsync(Guid categoryId, bool? withRoot = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="alias"></param>
        /// <returns></returns>
        Task<Guid> GetIdByAliasAsync(string alias);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryAlias"></param>
        /// <returns></returns>
        Task<IList<CategoryViewModel>> GetRaletedCategoriesByAliasAsync(string categoryAlias);

        Task<bool> IsRootAsync(Guid categoryId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IList<CategoryViewModel>> GetAsViewModelByRequestAsync(CategorySearchRequest request);

        /// <summary>
        /// لیست دسته های مجاز برای ثبت محصول برای کاربر جاری
        /// </summary>
        /// <returns></returns>
        Task<IList<SelectListItem>> GetAllowedAsSelectListAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<IList<Guid>> GetAllChildsByIdAsync(Guid categoryId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryList"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        Task<IEnumerable<Category>> GetAllChildsByIdAsync(List<Category> categoryList, Category category);


        Task<IList<Select2Object>> GetAllowedAsSelect2ObjectAsync();
    }
}