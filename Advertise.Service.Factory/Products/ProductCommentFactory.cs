using System;
using System.Threading.Tasks;
using Advertise.Core.Helpers;
using Advertise.Core.Models.ProductComment;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Products;
using AutoMapper;
using Advertise.Core.Utilities;
using Advertise.Core.Types;

namespace Advertise.Service.Factories.Products
{

    public class ProductCommentFactory : IProductCommentFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IProductCommentService _productCommentService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="listManager"></param>
        /// <param name="commonService"></param>
        /// <param name="mapper"></param>
        /// <param name="productCommentService"></param>
        public ProductCommentFactory(IListManager listManager, ICommonService commonService, IMapper mapper, IProductCommentService productCommentService)
        {
            _listManager = listManager;
            _commonService = commonService;
            _mapper = mapper;
            _productCommentService = productCommentService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// </summary>
        /// <param name="productCommentId"></param>
        /// <returns></returns>
        public async Task<ProductCommentDetailViewModel> PrepareDetailViewModelAsync(Guid productCommentId)
        {
            if (productCommentId == Guid.Empty)
                throw new ArgumentNullException(nameof(productCommentId));

            var productComment = await _productCommentService.FindByIdAsync(productCommentId);
            var viewModel = _mapper.Map<ProductCommentDetailViewModel>(productComment);

            return viewModel;
        }


        /// <summary>
        /// </summary>
        /// <param name="productCommentId"></param>
        /// <returns></returns>
        public async Task<ProductCommentEditViewModel> PrepareEditViewModelAsync(Guid productCommentId, bool applyCurrentUser = false)
        {
            if (productCommentId == Guid.Empty)
                throw new ArgumentNullException(nameof(productCommentId));

            var productComment = await _productCommentService.FindByIdAsync(productCommentId);
            var viewModel = _mapper.Map<ProductCommentEditViewModel>(productComment);

            if (applyCurrentUser)
                viewModel.IsMine = true;

            return viewModel;
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        ///  <param name="userId"></param>
        ///  <returns></returns>
        public async Task<ProductCommentListViewModel> PrepareListViewModelAsync(ProductCommentSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CommentedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            var viewModel = await _productCommentService.ListByRequestAsync(request);

            viewModel.PageSizeList = await _listManager.GetPageSizeListAsync();
            viewModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();
            viewModel.StateTypeList = EnumHelper.CastToSelectListItems<StateType>();// await _listManager.GetStateTypeListAsync();

            if (isCurrentUser)
                viewModel.IsMine = true;

            return viewModel;
        }

        #endregion Public Methods
    }
}