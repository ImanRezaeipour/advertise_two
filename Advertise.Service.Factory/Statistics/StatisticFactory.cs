using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Models.Statistic;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Statistics;
using AutoMapper;

namespace Advertise.Service.Factories.Statistics
{

    public class StatisticFactory : IStatisticFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IStatisticService _statisticService;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="listManager"></param>
        /// <param name="commonService"></param>
        /// <param name="statisticService"></param>
        public StatisticFactory(IListManager listManager, ICommonService commonService, IStatisticService statisticService, IMapper mapper)
        {
            _listManager = listManager;
            _commonService = commonService;
            _statisticService = statisticService;
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
        public async Task<StatisticListViewModel> PrepareListViewModelAsync(StatisticSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _statisticService.CountByRequestAsync(request);
            var statistic = await _statisticService.GetByRequestAsync(request);
            var statisticViewModel = _mapper.Map<IList<StatisticViewModel>>(statistic);
            var viewModel = new StatisticListViewModel
            {
                SearchRequest = request,
                Statistics = statisticViewModel
            };
            viewModel.PageSizeList = await _listManager.GetPageSizeListAsync();
            viewModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();

            return viewModel;
        }

        #endregion Public Methods
    }
}