using System;
using System.Threading.Tasks;
using Advertise.Core.Models.ProductFeature;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Products;
using AutoMapper;

namespace Advertise.Service.Factories.Products
{

    public class ProductFeatureFactory : IProductFeatureFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IProductFeatureService _productFeatureService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="listManager"></param>
        /// <param name="commonService"></param>
        /// <param name="mapper"></param>
        /// <param name="productFeatureService"></param>
        public ProductFeatureFactory(IListManager listManager, ICommonService commonService, IMapper mapper, IProductFeatureService productFeatureService)
        {
            _listManager = listManager;
            _commonService = commonService;
            _mapper = mapper;
            _productFeatureService = productFeatureService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// </summary>
        /// <param name="productFeatureId"></param>
        /// <returns></returns>
        public async Task<ProductFeatureDetailViewModel> PrepareDetailViewModelAsync(Guid productFeatureId)
        {
            if (productFeatureId == null)
                throw new ArgumentNullException(nameof(productFeatureId));

            var productFeature = await _productFeatureService.FindByIdAsync(productFeatureId);
            var viewModel = _mapper.Map<ProductFeatureDetailViewModel>(productFeature);

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="productFeatureId"></param>
        /// <returns></returns>
        public async Task<ProductFeatureEditViewModel> PrepareEditViewModelAsync(Guid productFeatureId)
        {
            if (productFeatureId == null)
                throw new ArgumentNullException(nameof(productFeatureId));

            var productFeature = await _productFeatureService.FindByIdAsync(productFeatureId);
            var viewModel = _mapper.Map<ProductFeatureEditViewModel>(productFeature);

            return viewModel;
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        ///  <param name="userId"></param>
        ///  <returns></returns>
        public async Task<ProductFeatureListViewModel> PrepareListViewModelAsync(ProductFeatureSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            var viewModel = await _productFeatureService.ListByRequestAsync(request);

            viewModel.PageSizeList = await _listManager.GetPageSizeListAsync();
            viewModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();

            return viewModel;
        }

        #endregion Public Methods
    }
}