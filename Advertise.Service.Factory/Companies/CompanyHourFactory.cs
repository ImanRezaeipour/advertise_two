using Advertise.Core.Models.CompanyHour;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.List;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Core.Helpers;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using Advertise.Core.Utilities;

namespace Advertise.Service.Factories.Companies
{

    public class CompanyHourFactory : ICompanyHourFactory
    {
        #region Private Fields

        private readonly ICompanyHourService _companyHourService;
        private readonly IMapper _mapper;
        private readonly IWebContextManager _webContextManager;
        private readonly IListManager _listManager;
        private readonly ICommonService _commonService;

        #endregion Private Fields

        #region Public Constructors

 
        public CompanyHourFactory(ICompanyHourService companyHourService, IMapper mapper, IWebContextManager webContextManager, IListManager listManager, ICommonService commonService)
        {
            _companyHourService = companyHourService;
            _mapper = mapper;
            _webContextManager = webContextManager;
            _listManager = listManager;
            _commonService = commonService;
        }

        #endregion Public Constructors

        #region Public Methods

     
        public async Task<CompanyHourEditViewModel> PrepareEditViewModelAsync(Guid? companyHourId = null, bool isCurrentUser = false, CompanyHourEditViewModel viewModelPrepare = null)
        {
            var request = new CompanyHourSearchRequest
            {
                CompanyId = _webContextManager.CurrentCompanyId,
            };
            var list = await _companyHourService.GetByRequestAsync(request);
            var listViewModel = _mapper.Map<IList<CompanyHourViewModel>>(list);
            var editViewModel = viewModelPrepare ?? new CompanyHourEditViewModel();
            editViewModel.CompanyHours = listViewModel;
            editViewModel.DayList = EnumHelper.CastToSelectListItems<DayType>();
            return editViewModel;
        }

        public async Task<CompanyHourListViewModel> PrepareListViewModRelAsync(CompanyHourSearchRequest request,bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _companyHourService.CountByRequestAsync(request);
            var companies = await _companyHourService.GetByRequestAsync(request);
            var companyViewModel = _mapper.Map<IList<CompanyHourViewModel>>(companies);
            var companyList = new CompanyHourListViewModel
            {
                SearchRequest = request,
                CompanyHours = companyViewModel,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
                SortMemberList = await _listManager.GetSortMemberListByTitleAsync(),
            };

            if (isCurrentUser)
                companyList.CompanyHours.ForEach(p => p.IsMine = true);

            return companyList;
        }

        #endregion Public Methods
    }
}