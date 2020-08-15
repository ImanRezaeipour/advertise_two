using Advertise.Core.Models.CompanyBalance;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.List;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Service.Services.Settings;

namespace Advertise.Service.Factories.Companies
{

    public class CompanyBalanceFactory : ICompanyBalanceFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly ICompanyBalanceService _companyBalanceService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;
        private readonly ISettingTransactionService _settingTransactionService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyBalanceService"></param>
        /// <param name="mapper"></param>
        /// <param name="commonService"></param>
        /// <param name="listManager"></param>
        public CompanyBalanceFactory(ICompanyBalanceService companyBalanceService, IMapper mapper, ICommonService commonService, IListManager listManager, ICompanyService companyService, ISettingTransactionService settingTransactionService)
        {
            _companyBalanceService = companyBalanceService;
            _mapper = mapper;
            _commonService = commonService;
            _listManager = listManager;
            _companyService = companyService;
            _settingTransactionService = settingTransactionService;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<CompanyBalanceCreateViewModel> PrepareCreateViewModelAsync(CompanyBalanceCreateViewModel viewModelPrepare = null)
        {
            var viewModel = viewModelPrepare??  new CompanyBalanceCreateViewModel();

            viewModel.CompanyList = await _companyService.GetAllAsSelectListItemAsync();
            viewModel.SettingTransactionList = await _settingTransactionService.GetAllAsSelectItemListAsync();
           return viewModel;
        }


        public async Task<CompanyBalanceEditViewModel> PrepareEditViewModelAsync(Guid companyBalanceId, CompanyBalanceEditViewModel viewModelPrepare= null)
        {
            var viewModel = viewModelPrepare;
            if (viewModel == null)
            {
                var companyBalance = await _companyBalanceService.FindByIdAsync(companyBalanceId);
                viewModel = _mapper.Map<CompanyBalanceEditViewModel>(companyBalance);
            }
            viewModel.CompanyList = await _companyService.GetAllAsSelectListItemAsync();
            viewModel.SettingTransactionList = await _settingTransactionService.GetAllAsSelectItemListAsync();

            return viewModel;
        }


        public async Task<CompanyBalanceListViewModel> PrepareListViewModelAsync(CompanyBalanceSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            var userIdc = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.CreatedById = userIdc;
            if (userIdc != null)
                request.CompanyId = (await _companyService.FindByUserIdAsync(userIdc.Value)).Id;
            request.TotalCount = await _companyBalanceService.CountByRequestAsync(request);
            var companyBalances = await _companyBalanceService.GetByRequestAsync(request);
            var companyBalancesViewModel = _mapper.Map<IList<CompanyBalanceViewModel>>(companyBalances);
            var listViewModel = new CompanyBalanceListViewModel
            {
                SearchRequest = request,
                CompanyBalances = companyBalancesViewModel,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
            };

            if (isCurrentUser)
                listViewModel.IsMine = true;

            return listViewModel;
        }


        public async Task<CompanyBalanceViewModel> PrepareViewModelAsync()
        {
            var viewModel = new CompanyBalanceViewModel();

            return viewModel;
        }

        #endregion Public Methods
    }
}