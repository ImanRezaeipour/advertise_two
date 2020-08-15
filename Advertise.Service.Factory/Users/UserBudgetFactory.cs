using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Models.UserBudget;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Users;
using AutoMapper;

namespace Advertise.Service.Factories.Users
{

    public class UserBudgetFactory : IUserBudgetFactory
    {
        #region Private Fields

        private readonly IListManager _listManager;
        private readonly IUserBudgetService _userBudgetService;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="listManager"></param>
        /// <param name="userBudgetService"></param>
        public UserBudgetFactory(IListManager listManager, IUserBudgetService userBudgetService, IMapper mapper)
        {
            _listManager = listManager;
            _userBudgetService = userBudgetService;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserBudgetListViewModel> PrepareListViewModelAsync(bool isCurrentUser = false, Guid? userId = null)
        {
            var request = new UserBudgetSearchRequest();
            request.TotalCount = await _userBudgetService.CountByRequestAsync(request);
            var userBudget = await _userBudgetService.GetByRequestAsync(request);
            var userBudgetViewModel = _mapper.Map<IList<UserBudgetViewModel>>(userBudget);
            var viewModel = new UserBudgetListViewModel
            {
                SearchRequest = request,
                UserBudgets = userBudgetViewModel
            };
            viewModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();
            viewModel.PageSizeList = await _listManager.GetPageSizeListAsync();

            return viewModel;
        }

        #endregion Public Methods
    }
}