using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Products;
using Advertise.Core.Models.ProductSpecification;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Products
{
    public interface IProductSpecificationService
    {
        #region Public Methods

        Task<int> CountByRequestAsync(ProductSpecificationSearchRequest request);


        Task  CreateByViewModelAsync(ProductSpecificationCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productSpecId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid productSpecId);


        Task  EditByViewModelAsync(ProductSpecificationEditViewModel viewModel);

        Task<ProductSpecification> FindByIdAsync(Guid productSpecificationId);

        Task<IList<ProductSpecification>> GetByProductIdAsync(Guid productId);


        Task<IList<ProductSpecification>> GetByRequestAsync(ProductSpecificationSearchRequest request);

        Task  RemoveRangeAsync(IList<ProductSpecification> productSpecifications);


        Task  SeedAsync();

        #endregion Public Methods


        IQueryable<ProductSpecification> QueryByRequest(ProductSpecificationSearchRequest request);
    }
}