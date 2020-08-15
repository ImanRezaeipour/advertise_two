using System;
using System.Threading.Tasks;
using Advertise.Core.Models.ProductTag;

namespace Advertise.Service.Factories.Products
{
    public interface IProductTagFactory
    {
        Task<ProductTagListViewModel> PrepareListViewModelAsync(ProductTagSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
    }
}