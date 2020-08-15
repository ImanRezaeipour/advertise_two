using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Helpers;
using Advertise.Core.Models.Newsletter;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Newsletters;
using AutoMapper;
using Advertise.Core.Utilities;
using Advertise.Core.Types;

namespace Advertise.Service.Factories.Newsletters
{

    public class NewsletterFactory : INewsletterFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly INewsletterService _newsletterService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="listManager"></param>
        /// <param name="commonService"></param>
        /// <param name="mapper"></param>
        /// <param name="newsletterService"></param>
        public NewsletterFactory(IListManager listManager, ICommonService commonService, IMapper mapper, INewsletterService newsletterService)
        {
            _listManager = listManager;
            _commonService = commonService;
            _mapper = mapper;
            _newsletterService = newsletterService;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<NewsletterCreateViewModel> PrepareCreateViewModelAsync(NewsletterCreateViewModel viewModelPrepare= null)
        {
            var viewModel = viewModelPrepare?? new NewsletterCreateViewModel();

            viewModel.MeetList = EnumHelper.CastToSelectListItems<MeetType>(); //await _listManager.GetMeetTypeAsSelectListItemAsync();
            return viewModel;
        }


        public async Task<NewsletterListViewModel> PrepareListViewModelAsync(NewsletterSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _newsletterService.CountByRequestAsync(request);
            var newsletters = await _newsletterService.GetByRequestAsync(request);
            var newsletterViewModel = _mapper.Map<IList<NewsletterViewModel>>(newsletters);
            var newsnletterList = new NewsletterListViewModel
            {
                Newsletter = newsletterViewModel,
                SearchRequest = request
            };

            newsnletterList.PageSizeList = await _listManager.GetPageSizeListAsync();
            newsnletterList.SortDirectionList = await _listManager.GetSortDirectionListAsync();
            newsnletterList.MeetList = EnumHelper.CastToSelectListItems<MeetType>();// await _listManager.GetMeetTypeAsSelectListItemAsync();

            return newsnletterList;
        }

        #endregion Public Methods
    }
}