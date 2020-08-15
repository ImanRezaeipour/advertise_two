using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Models.ProductSpecification;

namespace Advertise.Service.Factories.Products
{
    public interface IProductSpecificationFactory
    {
        Task<IList<ProductSpecificationCreateViewModel>> PrepareCreateViewModelAsync(Guid categoryId);
        Task<ProductSpecificationDetailViewModel> PrepareDetailViewModelAsync(Guid productSpecificationId);
        Task<IList<ProductSpecificationEditViewModel>> PrepareEditViewModelAsync(Guid productId);
        Task<ProductSpecificationListViewModel> PrepareListViewModelAsync(ProductSpecificationSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
    }
}