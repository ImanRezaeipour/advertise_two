using Advertise.Core.Models.Address;
using Advertise.Core.Models.Common;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Locations;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertise.Service.Factories.Locations
{

    public class AddressFactory : IAddressFactory
    {
        #region Private Fields

        private readonly IAddressService _addressService;
        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="addressService"></param>
        /// <param name="mapper"></param>
        /// <param name="commonService"></param>
        /// <param name="listManager"></param>
        public AddressFactory(IAddressService addressService, IMapper mapper, ICommonService commonService, IListManager listManager)
        {
            _addressService = addressService;
            _mapper = mapper;
            _commonService = commonService;
            _listManager = listManager;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        public async Task<AddressEditViewModel> PrepareEditViewModelAsync(Guid addressId)
        {
            var address = await _addressService.FindByIdAsync(addressId);
            var viewModel = _mapper.Map<AddressEditViewModel>(address);

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<AddressListViewModel> PrepareListViewModelAsync(AddressSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.SortDirection = SortDirection.Desc;
            request.UserId = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _addressService.CountByRequestAsync(request);
            var addresses = await _addressService.GetByRequestAsync(request);
            var addressesViewModel = _mapper.Map<IList<AddressViewModel>>(addresses);
            var viewModel = new AddressListViewModel
            {
                SearchRequest = request,
                Addresses = addressesViewModel
            };
            viewModel.PageSizeList = await _listManager.GetPageSizeListAsync();
            viewModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();

            return viewModel;
        }

        #endregion Public Methods
    }
}