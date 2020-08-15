using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Exceptions;
using Advertise.Core.Models.Guarantee;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Guarantees;
using Advertise.Service.Services.List;
using AutoMapper;

namespace Advertise.Service.Factories.Guarantee
{
    public class GuaranteeFactory : IGuaranteeFactory
    {
        private readonly IGuaranteeService _guaranteeService;
        private readonly IMapper _mapper;
        private readonly IListManager _listManager;
        private readonly ICommonService _commonService;

        public GuaranteeFactory(IGuaranteeService guaranteeService, IMapper mapper, IListManager listManager, ICommonService commonService)
        {
            _guaranteeService = guaranteeService;
            _mapper = mapper;
            _listManager = listManager;
            _commonService = commonService;
        }

        public async Task<GuaranteeEditViewModel> PrepareEditViewModelAsync(Guid id, GuaranteeEditViewModel viewModelPrepare = null)
        {
            var manufaturer = await _guaranteeService.FindByIdAsync(id);

            if (manufaturer == null)
                throw new FactoryException();

            var viewModel = viewModelPrepare ?? _mapper.Map<GuaranteeEditViewModel>(manufaturer);

            return viewModel;
        }

        public async Task<GuaranteeListViewModel> PrepareListViewModelAsync(GuaranteeSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            var guarantees = await _guaranteeService.GetByRequestAsync(request);
            var guaranteeViewModels = _mapper.Map<List<GuaranteeViewModel>>(guarantees);
            request.TotalCount = await _guaranteeService.CountByRequestAsync(request);

            var guaranteeListViewModel = new GuaranteeListViewModel
            {
                SearchRequest = request,
                Guarantees = guaranteeViewModels,
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
                PageSizeList = await _listManager.GetPageSizeListAsync()
            };

            return guaranteeListViewModel;
        }
    }
}