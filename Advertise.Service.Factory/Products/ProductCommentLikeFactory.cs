using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Models.ProductCommentLike;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Products;
using AutoMapper;

namespace Advertise.Service.Factories.Products
{

    public class ProductCommentLikeFactory : IProductCommentLikeFactory
    {

        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IProductCommentLikeService _productCommentLikeService;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="listManager"></param>
        /// <param name="commonService"></param>
        /// <param name="productCommentLikeService"></param>
        public ProductCommentLikeFactory(IListManager listManager, ICommonService commonService, IProductCommentLikeService productCommentLikeService, IMapper mapper)
        {
            _listManager = listManager;
            _commonService = commonService;
            _productCommentLikeService = productCommentLikeService;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        ///  <param name="userId"></param>
        ///  <returns></returns>
        public async Task<ProductCommentLikeListViewModel> PrepareListViewModelAsync(ProductCommentLikeSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.LikedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _productCommentLikeService.CountByRequestAsync(request);
            var productComments = await _productCommentLikeService.GetByRequestAsync(request);
            var productCommentViewModel = _mapper.Map<IList<ProductCommentLikeViewModel>>(productComments);
            var viewModel = new ProductCommentLikeListViewModel
            {
                SearchRequest = request,
                ProductComments = productCommentViewModel
            };
            viewModel.PageSizeList = await _listManager.GetPageSizeListAsync();
            viewModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();

            return viewModel;
        }

        #endregion Public Methods

    }
}