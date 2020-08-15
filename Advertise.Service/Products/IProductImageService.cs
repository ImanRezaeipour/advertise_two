using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Products;
using Advertise.Core.Models.ProductImage;
using Advertise.Service.Managers.File;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Products
{
    public interface IProductImageService {

        Task  CreateByViewModelAsync(ProductImageCreateViewModel viewModel);

        Task  RemoveRangeAsync(IList<ProductImage> productImages);
        Task<ProductImage> FindByIdAsync(Guid productImageId);

        

       


        Task  DeleteByIdAsync(Guid productImageId);


        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ProductImageListViewModel> ListByRequestAsync(ProductImageSearchRequest request);



        Task  EditByViewModelAsync(ProductImageEditViewModel viewModel);


        Task<int> CountAllByProductIdAsync(Guid productId);
        Task<IList<ProductImage>> GetByProductIdAsync(Guid productId);


        /// استفاده در محصول
        Task<IList<ProductImage>> GetByRequestAsync(ProductImageSearchRequest request);


        Task<int> CountByRequestAsync(ProductImageSearchRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<List<FileModel>> GetByProductIdAsFileModelAsync(Guid productId);


        IQueryable<ProductImage> QueryByRequest(ProductImageSearchRequest request);
    }
}