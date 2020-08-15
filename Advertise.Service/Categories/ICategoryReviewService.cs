using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Categories;
using Advertise.Core.Models.CategoryReview;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Categories
{
    public interface ICategoryReviewService {

        Task<int> CountByRequestAsync(CategoryReviewSearchRequest request);


        Task CreateByViewModelAsync(CategoryReviewCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryReviewId"></param>
        /// <returns></returns>
        Task DeleteByIdAsync(Guid categoryReviewId);


        Task<IList<CategoryReview>> GetByRequestAsync(CategoryReviewSearchRequest request);

        Task<CategoryReview> FindByIdAsync(Guid categoryReviewId);

        /// <summary>
        /// لیست بررسی های دسته
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<IList<CategoryReview>> GetByCategoryIdAsync(Guid categoryId);


        Task SeedAsync();

       

        Task EditByViewModelAsync(CategoryReviewEditViewModel viewModel);


      IQueryable<CategoryReview> QueryByRequest(CategoryReviewSearchRequest request);
    }
}