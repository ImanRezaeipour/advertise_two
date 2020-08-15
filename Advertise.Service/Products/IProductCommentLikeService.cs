using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Products;
using Advertise.Core.Domains.Users;
using Advertise.Core.Models.ProductCommentLike;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Products
{
    public interface IProductCommentLikeService {


        Task<ProductCommentLike> FindByIdAsync(Guid productCommentId, Guid userId);


      
        /// <summary>
        /// لیست آی دی افرادی که این دسته را فالو کرده اند
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        Task<IList<User>> GetUsersByCompanyIdAsync(Guid questionId);

        /// <summary>
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        Task<bool> IsLikeCurrentUserByIdAsync(Guid questionId);


        Task  SeedAsync();

        /// <summary>
        ///
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        Task  ToggleCurrentUserByIdAsync(Guid questionId);


        Task<IList<ProductCommentLike>> GetByRequestAsync(ProductCommentLikeSearchRequest request);

        /// <returns></returns>
        Task<int> CountByRequestAsync(ProductCommentLikeSearchRequest request);


        IQueryable<ProductCommentLike> QueryByRequest(ProductCommentLikeSearchRequest request);
    }
}