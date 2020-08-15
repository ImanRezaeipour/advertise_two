using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Helpers;
using Advertise.Core.Models.News;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Newses;
using AutoMapper;
using Advertise.Core.Utilities;
using Advertise.Core.Types;

namespace Advertise.Service.Factories.Newses
{
    /// <summary>
    /// 
    /// </summary>
    public class NewsFactory : INewsFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly INewsService _newsService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listManager"></param>
        /// <param name="mapper"></param>
        /// <param name="commonService"></param>
        /// <param name="newsService"></param>
        public NewsFactory(IListManager listManager, IMapper mapper, ICommonService commonService, INewsService newsService)
        {
            _listManager = listManager;
            _mapper = mapper;
            _commonService = commonService;
            _newsService = newsService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="newsId"></param>
        /// <returns></returns>
        public async Task<NewsEditViewModel> PrepareEditViewModelAsync(Guid newsId)
        {
            var news = await _newsService.FindByIdAsync(newsId);
            var viewModel = _mapper.Map<NewsEditViewModel>(news);

            return viewModel;
        }


        public async Task<NewsListViewModel> PrepareListViewModelAsync(NewsSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _newsService.CountByRequestAsync(request);
            var newses = await _newsService.GetByRequestAsync(request);
            var newsViewModel = _mapper.Map<IList<NewsViewModel>>(newses);
            var viewModel = new NewsListViewModel
            {
                SearchRequest = request,
                News = newsViewModel,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
                ActiveList = EnumHelper.CastToSelectListItems<ActiveType>()
            };
            //await _listManager.GetActiveListAsync();

            return viewModel;
        }

        #endregion Public Methods
    }
}