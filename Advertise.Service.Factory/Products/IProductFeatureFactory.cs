using System;
using System.Threading.Tasks;
using Advertise.Core.Models.ProductFeature;

namespace Advertise.Service.Factories.Products
{
    public interface IProductFeatureFactory
    {
        Task<ProductFeatureDetailViewModel> PrepareDetailViewModelAsync(Guid productFeatureId);
        Task<ProductFeatureEditViewModel> PrepareEditViewModelAsync(Guid productFeatureId);
        Task<ProductFeatureListViewModel> PrepareListViewModelAsync(ProductFeatureSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
    }
}