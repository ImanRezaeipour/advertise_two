using System;
using System.Threading.Tasks;
using Advertise.Core.Models.ProductImage;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Products;
using AutoMapper;

namespace Advertise.Service.Factories.Products
{

    public class ProductImageFactory : IProductImageFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IProductImageService _productImageService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="listManager"></param>
        /// <param name="commonService"></param>
        /// <param name="mapper"></param>
        /// <param name="productImageService"></param>
        public ProductImageFactory(IListManager listManager, ICommonService commonService, IMapper mapper, IProductImageService productImageService)
        {
            _listManager = listManager;
            _commonService = commonService;
            _mapper = mapper;
            _productImageService = productImageService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// </summary>
        /// <param name="productImageId"></param>
        /// <returns></returns>
        public async Task<ProductImageDetailViewModel> PrepareDetailViewModelAsync(Guid productImageId)
        {
            if (productImageId == null)
                throw new ArgumentNullException(nameof(productImageId));

            var productImage = await _productImageService.FindByIdAsync(productImageId);
            var viewModel = _mapper.Map<ProductImageDetailViewModel>(productImage);

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="productImageId"></param>
        /// <returns></returns>
        public async Task<ProductImageEditViewModel> PrepareEditViewModelAsync(Guid productImageId)
        {
            if (productImageId == null)
                throw new ArgumentNullException(nameof(productImageId));

            var productImage = await _productImageService.FindByIdAsync(productImageId);
            var viewModel = _mapper.Map<ProductImageEditViewModel>(productImage);

            return viewModel;
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        ///  <param name="userId"></param>
        ///  <returns></returns>
        public async Task<ProductImageListViewModel> PrepareListViewModelAsync(ProductImageSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            var viewModel = await _productImageService.ListByRequestAsync(request);

            viewModel.PageSizeList = await _listManager.GetPageSizeListAsync();
            viewModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();

            return viewModel;
        }

        #endregion Public Methods
    }
}