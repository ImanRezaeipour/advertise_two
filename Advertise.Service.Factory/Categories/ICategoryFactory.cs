using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Category;
using Advertise.Core.Models.Company;
using Advertise.Core.Models.Home;
using Advertise.Core.Models.Product;

namespace Advertise.Service.Factories.Categories
{
    public interface ICategoryFactory
    {

        Task<CategoryCreateViewModel> PrepareCreateViewModelAsync();

        /// <summary>
        ///نمایش جزئیات دسته
        /// </summary>
        /// <param name="categoryAlias"></param>
        /// <returns></returns>
        Task<CategoryDetailViewModel> PrepareDetailViewModelAsync(string categoryAlias, string slug);

        /// <summary>
        /// </summary>
        /// <param name="categoryAlias"></param>
        /// <returns></returns>
        Task<CategoryEditViewModel> PrepareEditViewModelAsync(string categoryAlias);


        Task<CategoryListViewModel> PrepareListViewModelAsync(CategorySearchRequest request, bool isCurrentUser = false, Guid? userId = null);

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<CompanyListViewModel> PrepareCompanyListViewModelAsync(Guid categoryId);


        Task<MainMenuViewModel> PrepareMainMenuViewModelAsync();

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<ProductListViewModel> PrepareProductListViewModelAsync(Guid categoryId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="currentTitle"></param>
        /// <param name="isAllSearch"></param>
        /// <returns></returns>
        Task<CategoryBreadCrumbViewModel> PrepareBreadCrumbViewModelAsync(Guid categoryId, string currentTitle, bool? isAllSearch);
    }
}