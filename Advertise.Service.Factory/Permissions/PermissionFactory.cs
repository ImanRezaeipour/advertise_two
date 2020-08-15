using Advertise.Core.Models.Permission;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Permissions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertise.Service.Factories.Permissions
{

    public class PermissionFactory : IPermissionFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IPermissionService _permissionService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="permissionService"></param>
        /// <param name="listManager"></param>
        /// <param name="commonService"></param>
        public PermissionFactory(IMapper mapper, IPermissionService permissionService, IListManager listManager, ICommonService commonService)
        {
            _mapper = mapper;
            _permissionService = permissionService;
            _listManager = listManager;
            _commonService = commonService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="permissionId"></param>
        /// <returns></returns>
        public async Task<PermissionEditViewModel> PrepareEditViewModelAsync(Guid permissionId)
        {
            var permission = await _permissionService.FindByIdAsync(permissionId);
            var viewModel = _mapper.Map<PermissionEditViewModel>(permission);

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<PermissionListViewModel> PrepareListViewModel(PermissionSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _permissionService.CountByRequestAsync(request);
            var list = await _permissionService.GetByRequestAsync(request);
            var permissions = _mapper.Map<IList<PermissionViewModel>>(list);
            var permissionListViewModel = new PermissionListViewModel
            {
                Permissions = permissions,
                SearchRequest = request,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
            };

            return permissionListViewModel;
        }

        #endregion Public Methods
    }
}