using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Models.Email;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Communications;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Messages;
using AutoMapper;

namespace Advertise.Service.Factories.Messages
{

    public class EmailFactory : IEmailFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IEmailService _emailService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="emailService"></param>
        /// <param name="commonService"></param>
        /// <param name="listManager"></param>
        public EmailFactory(IEmailService emailService, ICommonService commonService, IListManager listManager, IMapper mapper)
        {
            _emailService = emailService;
            _commonService = commonService;
            _listManager = listManager;
            _mapper = mapper;
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
        public async Task<EmailListViewModel> PrepareListViewModelAsync(EmailSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _emailService.CountByRequestAsync(request);
            var emails = await _emailService.GetByRequestAsync(request);
            var emailViewModel = _mapper.Map<IList<EmailViewModel>>(emails);
            var viewModel = new EmailListViewModel
            {
                SearchRequest = request,
                Emails = emailViewModel
            };
            viewModel.PageSizeList = await _listManager.GetPageSizeListAsync();
            viewModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();

            return viewModel;
        }

        #endregion Public Methods
    }
}