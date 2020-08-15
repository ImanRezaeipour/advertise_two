using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyFollow;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.Users;
using System;
using System.Threading.Tasks;
using Advertise.Core.Helpers;
using Advertise.Core.Types;
using Advertise.Service.Services.List;

namespace Advertise.Service.Factories.Companies
{

    public class CompanyFollowFactory : ICompanyFollowFactory
    {
        #region Private Fields

        private readonly ICompanyFollowService _companyFollowService;
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;
        private readonly IListManager _listManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyFollowService"></param>
        /// <param name="userService"></param>
        /// <param name="companyService"></param>
        public CompanyFollowFactory(ICompanyFollowService companyFollowService, IUserService userService, ICompanyService companyService, IListManager listManager)
        {
            _companyFollowService = companyFollowService;
            _userService = userService;
            _companyService = companyService;
            _listManager = listManager;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="isCurrentUser"></param>
        /// <param name="follower"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<CompanyFollowListViewModel> PrepareListViewModelAsync(bool isCurrentUser = false, bool follower = false, Guid? userId = null)
        {
            CompanyFollowSearchRequest request;
            if (follower)
            {
                var user = isCurrentUser ? await _userService.GetCurrentUserAsync() : await _userService.FindByIdAsync(userId.GetValueOrDefault());

                var company = await _companyService.FindByUserIdAsync(user.Id);

                request = new CompanyFollowSearchRequest
                {
                    PageSize = PageSize.All,
                    CompanyId = company.Id,
                    IsFollow = true
                };
            }
            else
            {
                request = new CompanyFollowSearchRequest
                {
                    PageSize = PageSize.All,
                    IsFollow = true

                };
            }

            var listViewModel = await _companyFollowService.ListByRequestAsync(request, isCurrentUser, userId);
            listViewModel.PageSizeList = await _listManager.GetPageSizeListAsync();
            return listViewModel;
        }

        #endregion Public Methods
    }
}