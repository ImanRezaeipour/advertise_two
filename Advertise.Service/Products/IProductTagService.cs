using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Products;
using Advertise.Core.Models.ProductTag;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Products
{
    public interface IProductTagService {

        Task  CreateByViewModelAsync(ProductTagCreateViewModel viewModel);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="productTags"></param>
        /// <returns></returns>
        Task RemoveRangeAsync(IList<ProductTag> productTags);

        Task<ProductTag> FindByIdAsync(Guid productTagId);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="productTagId"></param>
      /// <returns></returns>
        Task  DeleteByIdAsync(Guid productTagId);

       /// <summary>
       /// 
       /// </summary>
       /// <param name="request"></param>
       /// <returns></returns>
        Task<ProductTagListViewModel> ListByRequestAsync(ProductTagSearchRequest request);


        Task  EditByViewModelAsync(ProductTagEditViewModel viewModel);


        Task<ProductTagListViewModel> GetTagsByProductIdAsync(Guid productId);


        Task  SeedAsync();

        Task<IList<ProductTag>> GetByProductIdAsync(Guid productId);
        Task<int> CountAllByProductIdAsync(Guid productId);


        Task<IList<ProductTag>> GetByRequestAsync(ProductTagSearchRequest request);

        Task<int> CountByRequestAsync(ProductTagSearchRequest request);


        IQueryable<ProductTag> QueryByRequest(ProductTagSearchRequest request);
    }
}