using Advertise.Core.Exceptions;
using Advertise.Core.Models.Manufacturer;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Manufacturers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Helpers;
using Advertise.Service.Services.Common;
using Advertise.Core.Types;
using Advertise.Core.Utilities;

namespace Advertise.Service.Factories.Manufacturers
{
    public class ManufacturerFactory : IManufacturerFactory
    {
        private readonly IManufacturerService _manufacturerService;
        private readonly IMapper _mapper;
        private readonly IListManager _listManager;
        private readonly ICommonService _commonService;

        public ManufacturerFactory(IManufacturerService manufacturerService, IMapper mapper, IListManager listManager, ICommonService commonService)
        {
            _manufacturerService = manufacturerService;
            _mapper = mapper;
            _listManager = listManager;
            _commonService = commonService;
        }

        public async Task<ManufacturerEditViewModel> PrepareEditViewModelAsync(Guid id, ManufacturerEditViewModel viewModelPrepare = null)
        {
            var manufaturer = await _manufacturerService.FindByIdAsync(id);

            if (manufaturer == null)
                throw new FactoryException();

            var viewModel = viewModelPrepare ?? _mapper.Map<ManufacturerEditViewModel>(manufaturer);
            viewModel.CountryList = EnumHelper.CastToSelectListItems<CountryType>();//await _listManager.GetCountryAsync();

            return viewModel;
        }

        public async Task<ManufacturerCreateViewModel> PrepareCreateViewModelAsync(ManufacturerCreateViewModel viewModelPrepare = null)
        {
            var viewModel = viewModelPrepare ?? new ManufacturerCreateViewModel();
            viewModel.CountryList = EnumHelper.CastToSelectListItems<CountryType>();

            return viewModel;
        }

        public async Task<ManufacturerListViewModel> PrepareListViewModelAsync(ManufacturerSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            var manufacturers = await _manufacturerService.GetByRequestAsync(request);
            var manufacturerViewModels = _mapper.Map<List<ManufacturerViewModel>>(manufacturers);
            request.TotalCount = await _manufacturerService.CountByRequestAsync(request);

            var manufacturerListViewModel = new ManufacturerListViewModel
            {
                SearchRequest = request,
                Manufacturers = manufacturerViewModels,
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
                PageSizeList = await _listManager.GetPageSizeListAsync()
            };

            return manufacturerListViewModel;
        }
    }
}