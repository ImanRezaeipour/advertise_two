using Advertise.Core.Models.PlanPayment;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Plans;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Models.Plan;
using AutoMapper;

namespace Advertise.Service.Factories.Plans
{

    public class PlanPaymentFactory : IPlanPaymentFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IPlanService _planService;
        private readonly IPlanPaymentService _planPaymentService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="commonService"></param>
        /// <param name="planPaymentService"></param>
        /// <param name="listManager"></param>
        public PlanPaymentFactory(ICommonService commonService, IPlanPaymentService planPaymentService, IListManager listManager, IPlanService planService, IMapper mapper)
        {
            _commonService = commonService;
            _planPaymentService = planPaymentService;
            _listManager = listManager;
            _planService = planService;
            _mapper = mapper;
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
        public async Task<PlanPaymentListViewModel> PrepareListViewModel(PlanPaymentSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _planPaymentService.CountByRequestAsync(request);
            var planPayments = await _planPaymentService.GetByRequestAsync(request);
            var planPaymentViewModel = _mapper.Map<IList<PlanPaymentViewModel>>(planPayments);
            var viewModel = new PlanPaymentListViewModel
            {
                PlanPayments = planPaymentViewModel,
                SearchRequest = request,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
            };

            if (isCurrentUser)
                viewModel.IsMine = true;

            return viewModel;
        }

        public async Task<PlanPyamentCreateViewModel> PrepareCreateViewModel()
        {
            var request = new PlanSearchRequest();
            var plans = await _planService.GetByRequestAsync(request);
            var planViewModel = _mapper.Map<IList<PlanViewModel>>(plans);
            var viewModel = new PlanPyamentCreateViewModel
            {
                Plans = planViewModel
            };
            return viewModel;
        }

        #endregion Public Methods
    }
}