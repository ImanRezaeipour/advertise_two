using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanySocial;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.List;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertise.Service.Factories.Companies
{

    public class CompanySocialFactory : ICompanySocialFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly ICompanyService _companyService;
        private readonly ICompanySocialService _companySocialService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="companySocialService"></param>
        /// <param name="mapper"></param>
        /// <param name="webContextManager"></param>
        /// <param name="companyService"></param>
        /// <param name="commonService"></param>
        /// <param name="listManager"></param>
        public CompanySocialFactory(ICompanySocialService companySocialService, IMapper mapper, IWebContextManager webContextManager, ICompanyService companyService, ICommonService commonService, IListManager listManager)
        {
            _companySocialService = companySocialService;
            _mapper = mapper;
            _webContextManager = webContextManager;
            _companyService = companyService;
            _commonService = commonService;
            _listManager = listManager;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="companySocialId"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="viewModelPrepare"></param>
        /// <returns></returns>
        public async Task<CompanySocialEditViewModel> PrepareEditViewModelAsync(Guid? companySocialId = null, bool isCurrentUser = false, CompanySocialEditViewModel viewModelPrepare = null)
        {
            var viewModel = viewModelPrepare;
            CompanySocial companySocial;
            if (viewModel == null)
            {
                companySocial = await _companySocialService.FindAsync(companySocialId.GetValueOrDefault());
                viewModel = _mapper.Map<CompanySocialEditViewModel>(companySocial);
            }
            if (isCurrentUser)
            {
                companySocial = await _companySocialService.FindByUserIdAsync(_webContextManager.CurrentUserId);
                viewModel = _mapper.Map<CompanySocialEditViewModel>(companySocial);
                if (viewModel == null)
                {
                    var companya = await _companyService.FindByUserIdAsync(_webContextManager.CurrentUserId);
                    viewModel = new CompanySocialEditViewModel
                    {
                        CompanyId = companya.Id
                    };
                    viewModel.IsMine = true;
                    return viewModel;
                }

                viewModel.IsMine = true;
            }
            

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<CompanySocialListViewModel> PrepareListViewModelAsync(CompanySocialSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _companySocialService.CountByRequestAsync(request);
            var companySocials = await _companySocialService.GetByRequestAsync(request);
            var companySocialViewModel = _mapper.Map<IList<CompanySocialViewModel>>(companySocials);
            var companySocialList = new CompanySocialListViewModel
            {
                SearchRequest = request,
                CompanySocials = companySocialViewModel,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
                SortMemberList = await _listManager.GetSortMemberListByTitleAsync()
            };

            return companySocialList;
        }

        #endregion Public Methods
    }
}