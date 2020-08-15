using System;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Products;
using Advertise.Core.Models.ProductRate;

namespace Advertise.Service.Services.Products
{
    public interface IProductRateService
    {
        Task<int> CountByRequestAsync(ProductRateSearchRequest request);
        Task CreateByViewModelAsync(ProductRateCreateViewModel viewModel);
        IQueryable<ProductRate> QueryByRequest(ProductRateSearchRequest request);
        Task<decimal> RateByRequestAsync(ProductRateSearchRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<bool> IsRatedCurrentUserByProductAsync(Guid productId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<int> GetUserCountByProductIdAsync(Guid productId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<decimal> GetRateByProductIdAsync(Guid productId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<int> GetRateByCurrentUserAsync(Guid productId);
    }
}