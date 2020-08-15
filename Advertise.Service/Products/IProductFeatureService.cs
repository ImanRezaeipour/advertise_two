using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Products;
using Advertise.Core.Models.ProductFeature;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Products
{
    public interface IProductFeatureService {


        Task  CreateByViewModelAsync(ProductFeatureCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productFeatureId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid productFeatureId);


        Task<ProductFeature> FindByIdAsync(Guid productFeatureId);

       
      

        Task<ProductFeatureListViewModel> ListByRequestAsync(ProductFeatureSearchRequest request);

        ///  <summary>
        /// 
        ///  </summary>
        /// <param name="productFeatures"></param>
        /// <returns></returns>
        Task RemoveRangeAsync(IList<ProductFeature> productFeatures);


        Task  SeedAsync();


        Task  EditByViewModelAsync(ProductFeatureEditViewModel viewModel);


        Task<IList<ProductFeature>> GetByRequestAsync(ProductFeatureSearchRequest request);

        Task<int> CountByRequestAsync(ProductFeatureSearchRequest request);


       IQueryable<ProductFeature> QueryByRequest(ProductFeatureSearchRequest request);
    }
}