using Advertise.Core.Models.CompanyReview;
using Advertise.Core.Types;
using Advertise.Core.Utilities;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.List;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Helpers;

namespace Advertise.Service.Factories.Companies
{

    public class CompanyReviewFactory : ICompanyReviewFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly ICompanyReviewService _companyReviewService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="commonService"></param>
        /// <param name="companyReviewService"></param>
        /// <param name="listManager"></param>
        /// <param name="mapper"></param>
        public CompanyReviewFactory(ICommonService commonService, ICompanyReviewService companyReviewService, IListManager listManager, IMapper mapper)
        {
            _commonService = commonService;
            _companyReviewService = companyReviewService;
            _listManager = listManager;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyReviewId"></param>
        /// <returns></returns>
        public async Task<CompanyReviewDetailViewModel> PrepareDetailViewModelAsync(Guid companyReviewId)
        {
            var companyReview = await _companyReviewService.FindByIdAsync(companyReviewId);
            var viewModel = _mapper.Map<CompanyReviewDetailViewModel>(companyReview);

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyReviewId"></param>
        /// <returns></returns>
        public async Task<CompanyReviewEditViewModel> PrepareEditViewModelAsync(Guid companyReviewId)
        {
            var companyReview = await _companyReviewService.FindByIdAsync(companyReviewId);
            var viewModel = _mapper.Map<CompanyReviewEditViewModel>(companyReview);
            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<CompanyReviewListViewModel> PrepareListViewModelAsync(CompanyReviewSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _companyReviewService.CountByRequestAsync(request);
            var companyReviews = await _companyReviewService.GetByRequestAsync(request);
            var companyReviewViewModel = _mapper.Map<IList<CompanyReviewViewModel>>(companyReviews);
            var companyReviewList = new CompanyReviewListViewModel
            {
                SearchRequest = request,
                CompanyReviews = companyReviewViewModel
            };
            companyReviewList.PageSizeList = await _listManager.GetPageSizeListAsync();
            companyReviewList.SortDirectionList = await _listManager.GetSortDirectionListAsync();
            companyReviewList.ActiveList = EnumHelper.CastToSelectListItems<ActiveType>(); //await _listManager.GetActiveListAsync();

            return companyReviewList;
        }


        public async Task<CompanyReviewCreateViewModel> PrepareCreateViewModelAsync(CompanyReviewCreateViewModel viewModelPrepare = null)
        {
            var viewModel = viewModelPrepare ?? new CompanyReviewCreateViewModel();

            viewModel.CompanyList = await _companyReviewService.GetCompanyAsSelectListItemAsync();
            return viewModel;
        }

        #endregion Public Methods
    }
}