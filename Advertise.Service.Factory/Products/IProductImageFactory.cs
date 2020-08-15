using System;
using System.Threading.Tasks;
using Advertise.Core.Models.ProductImage;

namespace Advertise.Service.Factories.Products
{
    public interface IProductImageFactory
    {
        Task<ProductImageDetailViewModel> PrepareDetailViewModelAsync(Guid productImageId);
        Task<ProductImageEditViewModel> PrepareEditViewModelAsync(Guid productImageId);
        Task<ProductImageListViewModel> PrepareListViewModelAsync(ProductImageSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
    }
}