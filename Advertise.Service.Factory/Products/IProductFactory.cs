using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Models.Product;
using Advertise.Core.Models.ProductReview;

namespace Advertise.Service.Factories.Products
{
    public interface IProductFactory
    {
        Task<ProductCreateViewModel> PrepareCreateViewModelAsync(ProductCreateViewModel viewModelPrepare = null);
        Task<ProductDetailViewModel> PrepareDetailViewModelAsync(string productCode);
        Task<ProductListViewModel> PrepareListViewModelAsync(ProductSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
        Task<ProductReviewListViewModel> PrepareReviewListViewModelAsync(Guid productId);
        Task<ProductSearchViewModel> PrepareSearchViewModelAsync(ProductSearchRequest request);

        /// <summary>
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="isMine"></param>
        /// <returns></returns>
        Task<ProductEditViewModel> PrepareEditViewModelAsync(string productCode, bool isMine = false, ProductEditViewModel viewModelPrepare = null);

        Task<ProductBulkCreateViewModel> PrepareBulkCreateViewModelAsync(ProductBulkCreateViewModel viewModelPrepare = null);


        Task<ProductBulkEditViewModel> PrepareBulkEditViewModelAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="isMine"></param>
        /// <param name="viewModelPrepare"></param>
        /// <returns></returns>
        Task<ProductBulkEditViewModel> PrepareEditCatalogViewModelAsync(string productCode, bool isMine = false, ProductBulkEditViewModel viewModelPrepare = null);
    }
}