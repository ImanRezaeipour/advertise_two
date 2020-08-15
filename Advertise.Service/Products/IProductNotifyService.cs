using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Products;
using Advertise.Core.Models.ProductNotify;

namespace Advertise.Service.Services.Products
{
    public interface IProductNotifyService
    {
        Task<int> CountByRequestAsync(ProductNotifySearchRequest request);
        Task CreateByViewModelAsync(ProductNotifyViewModel viewModel);
        Task DeleteByProductIdAsync(Guid productId, bool? applyCurrentUser);
        Task<ProductNotify> FindByProductIdAync(Guid productId, bool? applyCurrentUser = false);
        Task<bool> IsExistAsync(Guid productId, Guid userId);
        IQueryable<ProductNotify> QueryByRequest(ProductNotifySearchRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<IList<Guid?>> GetUsersByProductIdAsync(Guid productId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task ToggleByProductIdAsync(Guid productId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="applyCurrentUser"></param>
        /// <returns></returns>
        Task<bool> IsExistByProductIdAsync(Guid productId, bool? applyCurrentUser);
    }
}