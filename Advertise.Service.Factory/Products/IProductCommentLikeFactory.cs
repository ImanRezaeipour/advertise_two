using System;
using System.Threading.Tasks;
using Advertise.Core.Models.ProductCommentLike;

namespace Advertise.Service.Factories.Products
{
    public interface IProductCommentLikeFactory
    {
        Task<ProductCommentLikeListViewModel> PrepareListViewModelAsync(ProductCommentLikeSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
    }
}