using System;
using System.Threading.Tasks;
using Advertise.Core.Models.CategoryReview;

namespace Advertise.Service.Factories.Categories
{
    public interface ICategoryReviewFactory
    {
        Task<CategoryReviewDetailViewModel> PrepareDetailViewModelAsync(Guid categoryReviewId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<CategoryReviewListViewModel> PrepareListViewModelAsync(CategoryReviewSearchRequest request, bool isCurrentUser = false, Guid? userId = null);

        Task<CategoryReviewEditViewModel> PrepareEditViewModelAsync(Guid categoryReviewId);
    }
}