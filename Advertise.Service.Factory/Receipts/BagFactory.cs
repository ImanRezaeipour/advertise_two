using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Models.Address;
using Advertise.Core.Models.Bag;
using Advertise.Core.Models.Common;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Locations;
using Advertise.Service.Services.Receipts;
using Advertise.Service.Services.Users;
using Advertise.Service.Services.WebContext;
using AutoMapper;

namespace Advertise.Service.Factories.Receipts
{
    /// <summary>
    /// 
    /// </summary>
    public class BagFactory : IBagFactory
    {
        #region Private Fields

        private readonly IAddressService _addressService;
        private readonly IBagService _bagService;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        private readonly IWebContextManager _webContextManager;
        private readonly IUserService _userService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="commonService"></param>
        /// <param name="addressService"></param>
        /// <param name="bagService"></param>
        /// <param name="webContextManager"></param>
        public BagFactory(ICommonService commonService, IAddressService addressService, IBagService bagService, IWebContextManager webContextManager, IMapper mapper, IUserService userService)
        {
            _commonService = commonService;
            _addressService = addressService;
            _bagService = bagService;
            _webContextManager = webContextManager;
            _mapper = mapper;
            _userService = userService;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<BagDetailViewModel> PrepareDetailViewModelAsync()
        {
            var viewModel = new BagDetailViewModel();

            var request = new BagSearchRequest
            {
                SortDirection = SortDirection.Desc,
                SortMember = SortMember.CreatedOn,
                CreatedById = _webContextManager.CurrentUserId,
                PageSize = PageSize.Count100,
                PageIndex = 1
            };
            var bags = await _bagService.GetByRequestAsync(request);

            viewModel.Bags = _mapper.Map<List<BagViewModel>>(bags);

            return viewModel;
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        ///  <param name="userId"></param>
        ///  <returns></returns>
        public async Task<BagListViewModel> PrepareListViewModelAsync(BagSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.PageSize = PageSize.All;
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            var bags = await _bagService.GetByRequestAsync(request);
            request.TotalCount = bags.Count;
            var bagsViewModel = _mapper.Map<IList<BagViewModel>>(bags);
            var bagsList = new BagListViewModel
            {
                SearchRequest = request,
                Bags = bagsViewModel
            };

            return bagsList;
        }


        public async Task<BagMyInfoViewModel> PrepareMyInfoViewModelAsync()
        {
            var bag = await _bagService.FindByUserIdAsync(_webContextManager.CurrentUserId);
            var viewModel = _mapper.Map<BagMyInfoViewModel>(bag);

            var address = await _userService.GetAddressByIdAsync(_webContextManager.CurrentUserId);
            viewModel.Address = _mapper.Map<AddressViewModel>(address);
            viewModel.AddressProvince = await _addressService.GetProvinceAsSelectListItemAsync();

            return viewModel;
        }

        #endregion Public Methods
    }
}