using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Models.Sms;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Communications;
using Advertise.Service.Services.List;
using AutoMapper;

namespace Advertise.Service.Factories.Messages
{

    public class SmsFactory : ISmsFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly ISmsService _smsService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="smsService"></param>
        /// <param name="mapper"></param>
        /// <param name="commonService"></param>
        /// <param name="listManager"></param>
        public SmsFactory(ISmsService smsService, IMapper mapper, ICommonService commonService, IListManager listManager)
        {
            _smsService = smsService;
            _mapper = mapper;
            _commonService = commonService;
            _listManager = listManager;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<SmsListViewModel> PrepareListViewModelAsync(SmsSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _smsService.CountByRequestAsync(request);
            var sms = await _smsService.GetByRequestAsync(request);
            var smsViewModel = _mapper.Map<IList<SmsViewModel>>(sms);
            var viewModel = new SmsListViewModel
            {
                SearchRequest = request,
                Smses = smsViewModel
            };
            viewModel.PageSizeList = await _listManager.GetPageSizeListAsync();
            viewModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();

            return viewModel;
        }

        #endregion Public Methods
    }
}