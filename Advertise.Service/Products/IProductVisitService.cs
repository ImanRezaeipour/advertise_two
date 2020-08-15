using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Products;
using Advertise.Core.Models.ProductVisit;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Products
{
    public interface IProductVisitService {
        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<int> CountByProductIdAsync(Guid productId);

      
        Task CreateAsync(ProductVisit productVisit);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task  CreateByProductIdAsync(Guid productId);

        /// <summary>
        /// </summary>
        /// <param name="productVisitId"></param>
        /// <returns></returns>
        Task<ProductVisit> FindByIdAsync(Guid productVisitId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<ProductVisit> FindByProductIdAsync(Guid productId);

        

        Task<List<Guid>> GetMostVisitProductIdAsync();

      

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ProductVisitListViewModel> ListByRequestAsync(ProductVisitSearchRequest request, bool isCurrentUser = false, Guid? userId = null);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productVisits"></param>
        /// <returns></returns>
        Task  RemoveRangeAsync(IList<ProductVisit> productVisits);


        Task  SeedAsync();

        Task<int> CountAllByProductIdAsync(Guid productId);


        Task<IList<ProductVisit>> GetByRequestAsync(ProductVisitSearchRequest request);


        Task<int> CountByRequestAsync(ProductVisitSearchRequest request);


        IQueryable<ProductVisit> QueryByRequest(ProductVisitSearchRequest request);


        Task<IList<Guid>> GetLastProductIdByCurrentUserAsync();
    }
}