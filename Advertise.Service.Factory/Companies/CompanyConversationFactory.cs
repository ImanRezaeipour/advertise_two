using Advertise.Core.Models.CompanyConversation;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.List;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertise.Service.Factories.Companies
{

    public class CompanyConversationFactory : ICompanyConversationFactory
    {
        #region Private Fields

        private readonly ICompanyConversationService _companyConversationService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyConversationService"></param>
        /// <param name="listManager"></param>
        /// <param name="mapper"></param>
        /// <param name="webContextManager"></param>
        public CompanyConversationFactory(ICompanyConversationService companyConversationService, IListManager listManager, IMapper mapper, IWebContextManager webContextManager)
        {
            _companyConversationService = companyConversationService;
            _listManager = listManager;
            _mapper = mapper;
            _webContextManager = webContextManager;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="conversationId"></param>
        /// <returns></returns>
        public async Task<CompanyConversationEditViewModel> PrepareEditViewModelAsync(Guid conversationId)
        {
            var conversation = await _companyConversationService.FindByIdAsync(conversationId);
            var viewModel = _mapper.Map<CompanyConversationEditViewModel>(conversation);

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<CompanyConversationListViewModel> PrepareListViewModelAsync(CompanyConversationSearchRequest request,bool isCurrentUser = false, Guid? userId = null)
        {
            if (isCurrentUser)
                request.CreatedById = _webContextManager.CurrentUserId;
            else if (userId != null)
                request.CreatedById = userId;
            else
                request.CreatedById = null;
            request.TotalCount = await _companyConversationService.CountByRequestAsync(request);
            var conversations = await _companyConversationService.GetByRequestAsync(request);
            var conversationViewModel = _mapper.Map<IList<CompanyConversationViewModel>>(conversations);
            var conversationList = new CompanyConversationListViewModel
            {
                SearchRequest = request,
                Conversations = conversationViewModel
            };

            conversationList.CreatedIdConversationList = await _companyConversationService.GetUsersAsSelectListAsync();
            conversationList.OwnedById = _webContextManager.CurrentUserId;

            if (isCurrentUser)
                conversationList.IsMine = true;

            return conversationList;
        }

        #endregion Public Methods
    }
}