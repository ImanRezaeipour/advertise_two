using Advertise.Core.Models.PlanDiscount;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Plans;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertise.Service.Factories.Plans
{
    public class PlanDiscountFactory : IPlanDiscountFactory
    {
        #region Private Fields

        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IPlanDiscountService _planDiscountService;

        #endregion Private Fields

        #region Public Constructors

        public PlanDiscountFactory(IPlanDiscountService planDiscountService, IMapper mapper, IListManager listManager)
        {
            _planDiscountService = planDiscountService;
            _mapper = mapper;
            _listManager = listManager;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<PlanDiscountEditViewModel> PrepareEditViewModelAsync(Guid? id)
        {
            var planDiscount = await _planDiscountService.FindByIdAsync(id.GetValueOrDefault());
            var viewModel = _mapper.Map<PlanDiscountEditViewModel>(planDiscount);
            return viewModel;
        }

        public async Task<PlanDiscountListViewModel> PrepareListViewModelAsync(PlanDiscountSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.UserId = userId;
            request.TotalCount = await _planDiscountService.CountByRequestAsync(request);
            var list = await _planDiscountService.GetByRequestAsync(request);
            var planDiscounts = _mapper.Map<IList<PlanDiscountViewModel>>(list);
            var planListViewModel = new PlanDiscountListViewModel
            {
                PlanDiscounts = planDiscounts,
                SearchRequest = request
            };

            planListViewModel.PageSizeList = await _listManager.GetPageSizeListAsync();
            planListViewModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();
            return planListViewModel;
        }

        #endregion Public Methods
    }
}