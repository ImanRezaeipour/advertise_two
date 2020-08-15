using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Helpers;
using Advertise.Core.Models.ProductReview;
using Advertise.Core.Types;
using Advertise.Core.Utilities;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Products;
using AutoMapper;

namespace Advertise.Service.Factories.Products
{
    public class ProductReviewFactory : IProductReviewFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IProductReviewService _productReviewService;
        private readonly IProductService _productService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="listManager"></param>
        /// <param name="commonService"></param>
        /// <param name="productReviewService"></param>
        /// <param name="mapper"></param>
        public ProductReviewFactory(IListManager listManager, ICommonService commonService, IProductReviewService productReviewService, IMapper mapper, IProductService productService)
        {
            _listManager = listManager;
            _commonService = commonService;
            _productReviewService = productReviewService;
            _mapper = mapper;
            _productService = productService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// </summary>
        /// <param name="productReviewId"></param>
        /// <returns></returns>
        public async Task<ProductReviewDetailViewModel> PrepareDetailViewModelAsync(Guid productReviewId)
        {
            var productReview = await _productReviewService.FindByIdAsync(productReviewId);
            var viewModel = _mapper.Map<ProductReviewDetailViewModel>(productReview);

            return viewModel;
        }


        public async Task<ProductReviewCreateViewModel> PrepareCreateViewModelAsync(ProductReviewCreateViewModel viewModelPrepare= null)
        {
            var viewModel = viewModelPrepare?? new ProductReviewCreateViewModel();

            viewModel.ProductList = await _productService.GetAsSelectListAsync();
            return viewModel;

        }

        /// <summary>
        /// </summary>
        /// <param name="productReviewId"></param>
        /// <returns></returns>
        public async Task<ProductReviewEditViewModel> PrepareEditViewModelAsync(Guid productReviewId)
        {
            var productReview = await _productReviewService.FindByIdAsync(productReviewId);
            var viewModel = _mapper.Map<ProductReviewEditViewModel>(productReview);

            return viewModel;
        }


        public async Task<ProductReviewListViewModel> PrepareListViewModelAsync(ProductReviewSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _productReviewService.CountByRequestAsync(request);
            var productReviews = await _productReviewService.GetByRequestAsync(request);
            var productReviewViewModel = _mapper.Map<IList<ProductReviewViewModel>>(productReviews);
            var viewModel = new ProductReviewListViewModel
            {
                SearchRequest = request,
                ProductReviews = productReviewViewModel,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
                StateList = EnumHelper.CastToSelectListItems<StateType>(),
                ActiveList = EnumHelper.CastToSelectListItems<ActiveType>()
            };

            return viewModel;
        }

        #endregion Public Methods
    }
}