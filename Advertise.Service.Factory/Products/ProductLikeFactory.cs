using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Models.ProductLike;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Products;
using AutoMapper;

namespace Advertise.Service.Factories.Products
{

    public class ProductLikeFactory : IProductLikeFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IProductLikeService _productLikeService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors
/// <summary>
/// 
/// </summary>
/// <param name="commonService"></param>
/// <param name="productLikeService"></param>
/// <param name="mapper"></param>
        public ProductLikeFactory( ICommonService commonService, IProductLikeService productLikeService, IMapper mapper, IListManager listManager)
        {
            _commonService = commonService;
            _productLikeService = productLikeService;
            _mapper = mapper;
            _listManager = listManager;
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
        public async Task<ProductLikeListViewModel> PrepareListViewModelAsync(ProductLikeSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.LikedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _productLikeService.CountByRequestAsync(request);
            var productLikes = await _productLikeService.GetByRequestAsync(request);
            var productLikeViewModel = _mapper.Map<IList<ProductLikeViewModel>>(productLikes);
            var listViewModel = new ProductLikeListViewModel
            {
                SearchRequest = request,
                ProductLikes = productLikeViewModel,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
            };

            return listViewModel;
        }

        public async Task<ProductLikeListViewModel> PrepareLikerListViewModelAsync(ProductLikeSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.LikedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _productLikeService.CountByRequestAsync(request);
            var productLikes = await _productLikeService.GetByRequestAsync(request);
            var productLikeViewModel = _mapper.Map<IList<ProductLikeViewModel>>(productLikes);
            var listViewModel = new ProductLikeListViewModel
            {
                SearchRequest = request,
                ProductLikes = productLikeViewModel,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
            };

            return listViewModel;
        }

        #endregion Public Methods
    }
}