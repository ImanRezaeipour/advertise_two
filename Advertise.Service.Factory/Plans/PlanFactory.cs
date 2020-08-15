using Advertise.Core.Models.Plan;
using Advertise.Core.Types;
using Advertise.Core.Utilities;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Plans;
using Advertise.Service.Services.Users;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Helpers;

namespace Advertise.Service.Factories.Plans
{

    public class PlanFactory : IPlanFactory
    {
        #region Private Fields

        private readonly CommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IPlanService _planService;
        private readonly IRoleService _roleService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="planService"></param>
        /// <param name="listManager"></param>
        /// <param name="commonService"></param>
        /// <param name="mapper"></param>
        /// <param name="roleService"></param>
        public PlanFactory(IPlanService planService, IListManager listManager, CommonService commonService, IMapper mapper, IRoleService roleService)
        {
            _planService = planService;
            _listManager = listManager;
            _commonService = commonService;
            _mapper = mapper;
            _roleService = roleService;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<PlanCreateViewModel> PrepareCreateViewModelAsync(PlanCreateViewModel viewModelPrepare = null)
        {
            var viewModel = viewModelPrepare?? new PlanCreateViewModel();
            viewModel.RoleList = await _roleService.GetRolesAsSelectListAsync();
            viewModel.PlanDurationList = EnumHelper.CastToSelectListItems<PlanDurationType>(); //await _listManager.GetPlanDurationTypeSelectItemList();
            viewModel.ColorTypeList = EnumHelper.CastToSelectListItems<ColorType>();// _listManager.GetColorType();

            return viewModel;
        }


        public async Task<PlanEditViewModel> PrepareEditViewModelAsync(Guid id, PlanEditViewModel viewModelPrepare= null)
        {
            var plan = await _planService.FindByIdAsync(id);
            var viewModel = viewModelPrepare?? _mapper.Map<PlanEditViewModel>(plan);
            viewModel.RoleList = await _roleService.GetRolesAsSelectListAsync();
            viewModel.PlanDurationList = EnumHelper.CastToSelectListItems<PlanDurationType>();//await _listManager.GetPlanDurationTypeSelectItemList();
            viewModel.ColorTypeList = EnumHelper.CastToSelectListItems<ColorType>(); 

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<PlanListViewModel> PrepareListViewModelAsync(PlanSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.UserId = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _planService.CountByRequestAsync(request);
            var list = await _planService.GetByRequestAsync(request);
            var plans = _mapper.Map<IList<PlanViewModel>>(list);
            var planListViewModel = new PlanListViewModel
            {
                Plans = plans,
                SearchRequest = request,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
            };

            return planListViewModel;
        }

        #endregion Public Methods
    }
}