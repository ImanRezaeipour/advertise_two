using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Products;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.ProductReview;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Products
{
    public interface IProductReviewService {


        Task  CreateByViewModelAsync(ProductReviewCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productReviewId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid productReviewId);

        Task<ProductReview> FindByIdAsync(Guid productReviewId);

        ///  <summary>
        /// 
        ///  </summary>
        /// <param name="productReviews"></param>
        /// <returns></returns>
        Task RemoveRangeAsync(IList<ProductReview> productReviews);


        Task  SeedAsync();

        Task  EditApproveByViewModelAsync(ProductReviewEditViewModel viewModel);


        Task  EditByViewModelAsync(ProductReviewEditViewModel viewModel);


        Task  EditRejectByViewModelAsync(ProductReviewEditViewModel viewModel);

        Task<IList<ProductReview>> GetByProductIdAsync(Guid productId);


        Task<IList<SelectListItem>> GetProductIdAsync();


        Task<IList<ProductReview>> GetByRequestAsync(ProductReviewSearchRequest request);

        Task<int> CountByRequestAsync(ProductReviewSearchRequest request);


       IQueryable<ProductReview> QueryByRequest(ProductReviewSearchRequest request);
    }

}