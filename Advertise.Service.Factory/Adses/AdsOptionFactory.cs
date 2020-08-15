using Advertise.Core.Models.AdsOption;
using Advertise.Core.Types;
using Advertise.Core.Utilities;
using Advertise.Service.Services.Ads;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Helpers;

namespace Advertise.Service.Factories.Adses
{
    public class AdsOptionFactory : IAdsOptionFactory
    {
        #region Private Fields

        private readonly IAdsOptionService _adsOptionService;
        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        public AdsOptionFactory(IListManager listManager, ICommonService commonService, IAdsOptionService adsOptionService, IMapper mapper)
        {
            _listManager = listManager;
            _commonService = commonService;
            _adsOptionService = adsOptionService;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<AdsOptionCreateViewModel> PrepareCreateViewModelAsync(AdsOptionCreateViewModel viewModelPrepare = null)
        {
            var viewModel = viewModelPrepare ?? new AdsOptionCreateViewModel();
            viewModel.TypeList = EnumHelper.CastToSelectListItems<AdsType>();
            viewModel.PositionList = EnumHelper.CastToSelectListItems<AdsPositionType>();

            return viewModel;
        }

        public async Task<AdsOptionEditViewModel> PrepareEditViewModelAsync(Guid id)
        {
            var adsOption = await _adsOptionService.FindByIdAsync(id);
            var viewModel = _mapper.Map<AdsOptionEditViewModel>(adsOption);
            viewModel.TypeList = EnumHelper.CastToSelectListItems<AdsType>();
            viewModel.PositionList = EnumHelper.CastToSelectListItems<AdsPositionType>();

            return viewModel;
        }

        public async Task<AdsOptionListViewModel> PrepareListViewModelAsync(AdsOptionSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            var categories = await _adsOptionService.GetByRequestAsync(request);
            var categoryList = _mapper.Map<List<AdsOptionViewModel>>(categories);
            request.TotalCount = categories.Count;
            var categoriesList = new AdsOptionListViewModel
            {
                SearchRequest = request,
                AdsOptions = categoryList,
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
                PageSizeList = await _listManager.GetPageSizeListAsync()
            };

            return categoriesList;
        }

        #endregion Public Methods
    }
}