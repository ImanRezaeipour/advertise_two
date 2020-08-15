using Advertise.Core.Models.UserViolation;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Users;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertise.Service.Factories.Users
{

    public class UserViolationFactory : IUserViolationFactory
    {

        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IUserViolationService _userViolationService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="listManager"></param>
        /// <param name="commonService"></param>
        /// <param name="mapper"></param>
        /// <param name="userViolationService"></param>
        public UserViolationFactory(IListManager listManager, ICommonService commonService, IMapper mapper, IUserViolationService userViolationService)
        {
            _listManager = listManager;
            _commonService = commonService;
            _mapper = mapper;
            _userViolationService = userViolationService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="userReportId"></param>
        /// <returns></returns>
        public async Task<UserViolationDetailViewModel> PrepareDetailViewModelAsync(Guid userReportId)
        {
            var userReport = await _userViolationService.FindByIdAsync(userReportId);
            var viewModel = _mapper.Map<UserViolationDetailViewModel>(userReport);

            return viewModel;
        }

        /// <summary>
        /// </summary>
        /// <param name="userReportId"></param>
        /// <returns></returns>
        public async Task<UserViolationEditViewModel> PrepareEditViewModelAsync(Guid userReportId)
        {
            var userReport = await _userViolationService.FindByIdAsync(userReportId);
            var viewModel = _mapper.Map<UserViolationEditViewModel>(userReport);

            return viewModel;
        }


        public async Task<UserViolationListViewModel> PrepareListViewModelAsync(UserViolationSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _userViolationService.CountByRequestAsync(request);
            var userReport = await _userViolationService.GetByRequestAsync(request);
            var userReportViewModel = _mapper.Map<IList<UserViolationViewModel>>(userReport);
            var viewModel = new UserViolationListViewModel
            {
                SearchRequest = request,
                UserViolations = userReportViewModel,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync()
                
            };

            return viewModel;
        }

        #endregion Public Methods

    }
}