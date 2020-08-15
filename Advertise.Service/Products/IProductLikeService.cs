using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Products;
using Advertise.Core.Domains.Users;
using Advertise.Core.Models.ProductLike;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Products
{
    public interface IProductLikeService {
        Task<int> CountByProductIdAsync(Guid productId);


        Task  CreateByViewModelAsync(ProductLikeCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productLikeId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid productLikeId);


        Task<ProductLike> FindByIdAsync(Guid productLikeId);

        Task<List<Guid>> GetMostLikedProductIdAsync();

      
        /// <summary>
        /// لیست آی دی افرادی که این دسته را فالو کرده اند
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<IList<User>> GetUsersByProductAsync(Guid productId);

        /// <summary>
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<bool> IsLikeCurrentUserByProductIdAsync(Guid productId);

        /// <summary>
        /// به محض ورود کاربر به جزئیات هر دسته فالو یا عدم فالو نشان داده شود
        /// </summary>
        /// <param name="userId">   </param>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<bool> IsLikeByProductIdAsync(Guid productId, Guid userId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productLikes"></param>
        /// <returns></returns>
        Task  RemoveRangeAsync(IList<ProductLike> productLikes);


        Task  SeedAsync();

        /// <summary>
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task  ToggleCurrentUserByProductIdAsync(Guid productId);


        Task  EditByViewModelAsync(ProductLikeEditViewModel viewModel);

        Task<int> CountAllLikedByProductIdAsync(Guid productId);


        Task<IList<ProductLike>> GetByRequestAsync(ProductLikeSearchRequest request);

        Task<int> CountByRequestAsync(ProductLikeSearchRequest request);


        IQueryable<ProductLike> QueryByRequest(ProductLikeSearchRequest request);

        Task<List<ProductLikeViewModel>> GetByProductsAsync(List<Guid> productsId);
        Task RemoveRangeByproductLikesAsync(IList<ProductLike> productLikes);
    }
}