using Advertise.Core.Models.City;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Locations;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertise.Service.Factories.Locations
{

    public class CityFactory : ICityFactory
    {
        #region Private Fields

        private readonly ICityService _cityService;
        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="cityService"></param>
        /// <param name="mapper"></param>
        /// <param name="commonService"></param>
        /// <param name="listManager"></param>
        public CityFactory(ICityService cityService, IMapper mapper, ICommonService commonService, IListManager listManager)
        {
            _cityService = cityService;
            _mapper = mapper;
            _commonService = commonService;
            _listManager = listManager;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public async Task<CityEditViewModel> PrepareEditViewModelAsync(Guid cityId)
        {
            var city = await _cityService.FindByIdAsync(cityId);
            var viewModel = _mapper.Map<CityEditViewModel>(city);

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<CityListViewModel> PrepareListViewModelAsync(CitySearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.UserId = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _cityService. CountByRequestAsync(request);
            var cityes = await _cityService.GetByRequestAsync(request);
            var cityesViewModel = _mapper.Map<IList<CityViewModel>>(cityes);
            var viewModel = new CityListViewModel
            {
                SearchRequest = request,
                Cities = cityesViewModel
            };
            viewModel.PageSizeList = await _listManager.GetPageSizeListAsync();
            viewModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();

            return viewModel;
        }

        #endregion Public Methods
    }
}