using System;
using System.Threading.Tasks;
using Advertise.Core.Models.ProductLike;

namespace Advertise.Service.Factories.Products
{
    public interface IProductLikeFactory
    {
        Task<ProductLikeListViewModel> PrepareListViewModelAsync(ProductLikeSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
        Task<ProductLikeListViewModel> PrepareLikerListViewModelAsync(ProductLikeSearchRequest request, bool isCurrentUser = false, Guid? userId = null);
    }
}