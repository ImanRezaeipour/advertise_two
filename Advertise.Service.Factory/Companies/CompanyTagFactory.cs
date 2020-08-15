using Advertise.Core.Models.CompanyTag;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.List;
using System;
using System.Threading.Tasks;

namespace Advertise.Service.Factories.Companies
{

    public class CompanyTagFactory : ICompanyTagFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly ICompanyTagService _companyTagService;
        private readonly IListManager _listManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyTagService"></param>
        /// <param name="commonService"></param>
        /// <param name="listManager"></param>
        public CompanyTagFactory(ICompanyTagService companyTagService, ICommonService commonService, IListManager listManager)
        {
            _companyTagService = companyTagService;
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
        public async Task<CompanyTagListViewModel> PrepareListViewModelAsync(CompanyTagSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            var viewModel = await _companyTagService.ListByRequestAsync(request);
            viewModel.PageSizeList = await _listManager.GetPageSizeListAsync();
            viewModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();

            return viewModel;
        }

        #endregion Public Methods
    }
}