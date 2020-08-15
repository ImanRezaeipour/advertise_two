using Advertise.Core.Domains.Bags;
using Advertise.Core.Models.Bag;
using Advertise.Service.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertise.Service.Services.Receipts
{
    public interface IBagService
    {
        #region Public Methods


        Task<int> CountByRequestAsync(BagSearchRequest request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task CreateByIdAsync(Guid productId);


        Task DeleteByCurrentUserAsync();

        /// <summary>
        ///
        /// </summary>
        /// <param name="bagId"></param>
        /// <returns></returns>
        Task DeleteByIdAsync(Guid bagId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task DeleteByProductIdAsync(Guid productId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="bagId"></param>
        /// <returns></returns>
        Task<Bag> FindByIdAsync(Guid bagId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<Bag> FindByProductIdAsync(Guid productId, Guid userId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Bag> FindByUserIdAsync(Guid userId);


        Task<IList<Bag>> GetByRequestAsync(BagSearchRequest request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IList<Bag>> GetByUserIdAsync(Guid userId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<bool> IsExistByProductIdAsync(Guid productId, Guid? userId = null);


        Task<int> CountByCurrentUserAsync();


        IQueryable<Bag> QueryByRequest(BagSearchRequest request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="bags"></param>
        /// <returns></returns>
        Task RemoveRangeAsync(IList<Bag> bags);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productCount"></param>
        /// <returns></returns>
        Task SetProductCountByIdAsync(Guid productId, int productCount);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task ToggleByCurrentUserAsync(Guid productId);

        #endregion Public Methods
    }
}