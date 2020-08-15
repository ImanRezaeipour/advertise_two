using Advertise.Core.Domains.Locations;
using Advertise.Core.Domains.Products;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Product;
using Advertise.Core.Models.ProductLike;
using Advertise.Core.Objects;
using Advertise.Core.Types;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Validators.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Advertise.Service.Services.Products
{
    public interface IProductService
    {
        #region Public Methods


        Task EditApproveByViewModelAsync(ProductEditViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="aggregateMember"></param>
        /// <returns></returns>
        Task<decimal?> AverageByRequestAsync(ProductSearchRequest request, string aggregateMember);

        /// <summary>
        ///
        /// </summary>
        /// <param name="code"></param>
        /// <param name="slug"></param>
        /// <returns></returns>
        Task<bool> CompareCodeAndSlugAsync(string code, string slug);


        Task<int> CountAllAsync();

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<int> CountByCategoryIdAsync(Guid categoryId);

        Task<int> CountByCompanyIdAsync(Guid companyId, StateType? state = null);

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<int> CountByRequestAsync(ProductSearchRequest request, bool isCurrentUser = false, Guid? userId = null);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productState"></param>
        /// <returns></returns>
        Task<int> CountByStateAsync(StateType productState);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        Task<int> CountByUserIdAsync(Guid userId, StateType state);


        Task CreateBulkByViewModelAsync(ProductBulkCreateViewModel viewModel);


        Task CreateByViewModelAsync(ProductCreateViewModel viewModel);

        /// <summary>
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        Task DeleteByCodeAsync(string productCode, bool isCurrentUser = false);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task DeleteByUserIdAsync(Guid userId);

        Task EditAsync(ProductEditViewModel viewModel, Product orginalProduct);


        Task EditBulkByViewModelAsync(ProductBulkEditViewModel viewModel);


        Task EditByViewModelAsync(ProductEditViewModel viewModel, bool isCurrentUser = false);


        Task EditCatalogByViewModelAsync(ProductEditCatalogViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productCode"></param>
        /// <returns></returns>
        Task<Product> FindByCodeAsync(string productCode);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<Product> FindByIdAsync(Guid productId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<Product> FindByUserIdWithCodeAsync(Guid userId, string code);


        Task<string> GenerateCodeAsync();

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<Address> GetAddressByIdAsync(Guid productId);

        Task<IList<SelectListItem>> GetAllCurrentUserAsSelectListItem();

        Task<IList<ProductViewModel>> GetApprovedByCompanyIdAsync(Guid companyId);


        Task<IList<SelectListItem>> GetAsSelectListAsync();

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Product GetByIdAsync(Guid productId);


        Task<IList<Product>> GetByRequestAsync(ProductSearchRequest request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<IList<FineUploaderObject>> GetFileAsFineUploaderModelByIdAsync(Guid productId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<IList<FineUploaderObject>> GetFilesAsFineUploaderModelByIdAsync(Guid productId);

        Task<ProductLikeListViewModel> GetMyListProductLikeAsync();

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IList<Product>> GetProductsByUserIdAsync(Guid userId);

        Task<bool> IsApprovedAsync(string code);

        Task<bool> IsMineByCodeAsync(string productCode);

      /// <summary>
      /// 
      /// </summary>
      /// <param name="request"></param>
      /// <param name="agg"></param>
      /// <returns></returns>
        Task<decimal?> MaxByRequestAsync(ProductSearchRequest request, Expression<Func<Product, decimal?>> agg);

       /// <summary>
       /// 
       /// </summary>
       /// <param name="request"></param>
       /// <param name="code"></param>
       /// <returns></returns>
        Task<string> MaxCodeByRequestAsync(ProductSearchRequest request, Expression<Func<Product, string>> code);

       /// <summary>
       /// 
       /// </summary>
       /// <param name="request"></param>
       /// <param name="agg"></param>
       /// <returns></returns>
        Task<decimal?> MinByRequestAsync(ProductSearchRequest request, Expression<Func<Product, decimal?>> agg );


        IQueryable<Product> QueryByRequest(ProductSearchRequest request);


        Task EditRejectByViewModelAsync(ProductEditViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="aggregateMember"></param>
        /// <returns></returns>
        Task<decimal?> SumByRequestAsync(ProductSearchRequest request, string aggregateMember);

        #endregion Public Methods

        Task<IList<SelectListItem>> CastQueryDictionaryToRequestValues(Dictionary<string, List<string>> queryDictionary);
        Task<IList<Product>> GetByCodeWithCurrentUser(string productCode);
        Task SetStateByIdAsync(Guid productId, StateType state);
    }
}