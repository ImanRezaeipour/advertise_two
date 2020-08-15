using Advertise.Core.Exceptions;
using Advertise.Core.Models.CompanyOfficial;
using Advertise.Service.Services.Companies;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Helpers;
using Advertise.Core.Types;
using Advertise.Core.Utilities;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using iTextSharp.text;

namespace Advertise.Service.Factories.Companies
{
    public class CompanyOfficialFactory : ICompanyOfficialFactory
    {

        #region Private Fields

        private readonly ICompanyOfficialService _companyOfficialService;
        private readonly IMapper _mapper;
        private readonly IListManager _listManager;
        private readonly ICommonService _commonService;

        #endregion Private Fields

        #region Public Constructors

        public CompanyOfficialFactory(ICompanyOfficialService companyOfficialService, IMapper mapper, IListManager listManager, ICommonService commonService )
        {
            _companyOfficialService = companyOfficialService;
            _mapper = mapper;
            _commonService = commonService;
            _listManager = listManager;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<CompanyOfficialEditViewModel> PrepareEditViewModelAsync(Guid companyOfficialId, bool applyCurrentUser = false, CompanyOfficialEditViewModel viewModelApply = null)
        {
            var companyOfficial = await _companyOfficialService.FindByIdAsync(companyOfficialId);
            if (companyOfficial == null)
                throw new FactoryException();

            var viewModel = viewModelApply ?? _mapper.Map<CompanyOfficialEditViewModel>(companyOfficial);

            if (applyCurrentUser)
                viewModel.IsMine = true;
            return viewModel;
        }


        public async Task<CompanyOfficialListViewModel> PrepareListViewModRelAsync(CompanyOfficialSearchRequest request,
            bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _companyOfficialService.CountByRequestAsync(request);
            var companies = await _companyOfficialService.GetByRequestAsync(request);
            var companyViewModel = _mapper.Map<IList<CompanyOfficialViewModel>>(companies);
            var companyList = new CompanyOfficialListViewModel
            {
                SearchRequest = request,
                CompanyOfficials = companyViewModel,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
                SortMemberList = await _listManager.GetSortMemberListByTitleAsync(),
                StateList = EnumHelper.CastToSelectListItems<ActiveType>()
            };

            if (isCurrentUser)
                companyList.CompanyOfficials.ForEach(p => p.IsMine = true);

            return companyList;
        }

        #endregion Public Methods
    }
}