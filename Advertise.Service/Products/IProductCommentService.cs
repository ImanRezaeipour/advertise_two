using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Products;
using Advertise.Core.Models.ProductComment;
using Advertise.Core.Types;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Products
{
    public interface IProductCommentService {

        Task  EditApproveByViewModelAsync(ProductCommentEditViewModel viewModel);

        Task RemoveRangeAsync(IList<ProductComment> productComments);
        Task<ProductComment> FindByIdAsync(Guid productCommentId);


        Task  CreateByViewModelAsync(ProductCommentCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="productCommentId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid productCommentId, bool isCurrentUser = false);


        Task<ProductCommentListViewModel> ListByRequestAsync(ProductCommentSearchRequest request);


        Task  EditRejectByViewModelAsync(ProductCommentEditViewModel viewModel);


        Task  EditByViewModelAsync(ProductCommentEditViewModel viewModel, bool isCurrentUser = false);



        Task<IList<ProductComment>> GetByRequestAsync(ProductCommentSearchRequest request);


        Task<int> CountByRequestAsync(ProductCommentSearchRequest request);


        IQueryable<ProductComment> QueryByRequest(ProductCommentSearchRequest request);
        Task SetStateByIdAsync(Guid productCommentId, StateType state);
    }
}