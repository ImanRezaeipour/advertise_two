using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Models.UserOperator;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Users;
using AutoMapper;

namespace Advertise.Service.Factories.UserOperators
{
   

    public class UserOperatorFactory : IUserOperatorFactory
    {
        private readonly IUserOperationServive _userOperationServive;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        private readonly IListManager _listManager;

        public UserOperatorFactory(IUserOperationServive userOperationServive, ICommonService commonService,  IMapper mapper, IListManager listManager)
        {
            _userOperationServive = userOperationServive;
            _commonService = commonService;
            _mapper = mapper;
            _listManager = listManager;
        }

        public async Task<UserOperatorListViewModel> PrepareListViewModel(UserOperatorSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _userOperationServive.CountByRequest(request);
            var user = await _userOperationServive.GetByRequestAsync(request);
            var userViewModel = _mapper.Map<IList<UserOperatorViewModel>>(user);
            var viewModel = new UserOperatorListViewModel
            {
                SearchRequest = request,
                UserOperators = userViewModel
            };
            viewModel.PageSizeList = await _listManager.GetPageSizeListAsync();
            viewModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();
            
            return viewModel;
        }

    }
}
