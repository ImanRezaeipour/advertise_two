using System;
using System.Threading.Tasks;
using Advertise.Core.Models.ProductComment;

namespace Advertise.Service.Factories.Products
{
    public interface IProductCommentFactory
    {
        Task<ProductCommentDetailViewModel> PrepareDetailViewModelAsync(Guid productCommentId);
        Task<ProductCommentListViewModel> PrepareListViewModelAsync(ProductCommentSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));

        /// <summary>
        /// </summary>
        /// <param name="productCommentId"></param>
        /// <returns></returns>
        Task<ProductCommentEditViewModel> PrepareEditViewModelAsync(Guid productCommentId, bool applyCurrentUser = false);
    }
}