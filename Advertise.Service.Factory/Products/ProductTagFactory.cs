using System;
using System.Threading.Tasks;
using Advertise.Core.Models.ProductTag;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Products;

namespace Advertise.Service.Factories.Products
{

    public class ProductTagFactory : IProductTagFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IProductTagService _productTagService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="listManager"></param>
        /// <param name="commonService"></param>
        /// <param name="productTagService"></param>
        public ProductTagFactory(IListManager listManager, ICommonService commonService, IProductTagService productTagService)
        {
            _listManager = listManager;
            _commonService = commonService;
            _productTagService = productTagService;
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
        public async Task<ProductTagListViewModel> PrepareListViewModelAsync(ProductTagSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            var viewModel = await _productTagService.ListByRequestAsync(request);

            viewModel.PageSizeList = await _listManager.GetPageSizeListAsync();
            viewModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();

            return viewModel;
        }

        #endregion Public Methods
    }
}