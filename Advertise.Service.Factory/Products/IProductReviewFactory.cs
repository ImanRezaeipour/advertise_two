using System;
using System.Threading.Tasks;
using Advertise.Core.Models.ProductReview;

namespace Advertise.Service.Factories.Products
{
    public interface IProductReviewFactory
    {
        Task<ProductReviewDetailViewModel> PrepareDetailViewModelAsync(Guid productReviewId);
        Task<ProductReviewEditViewModel> PrepareEditViewModelAsync(Guid productReviewId);
        Task<ProductReviewListViewModel> PrepareListViewModelAsync(ProductReviewSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));


        Task<ProductReviewCreateViewModel> PrepareCreateViewModelAsync(ProductReviewCreateViewModel viewModelPrepare = null);
    }
}