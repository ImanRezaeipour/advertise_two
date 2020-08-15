using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Receipts;
using Advertise.Core.Models.Address;
using Advertise.Core.Models.City;
using Advertise.Core.Models.Receipt;
using Advertise.Core.Models.ReceiptOption;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Locations;
using Advertise.Service.Services.Receipts;
using Advertise.Service.Services.Users;
using Advertise.Service.Services.WebContext;
using AutoMapper;

namespace Advertise.Service.Factories.Receipts
{
    public class ReceiptFactory : IReceiptFactory
    {
        #region Private Fields

        private readonly IAddressService _addressService;
        private readonly ICityService _cityService;
        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IReceiptOptionService _receiptOptionService;
        private readonly IReceiptService _receiptService;
        private readonly IUserService _userService;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="listManager"></param>
        /// <param name="commonService"></param>
        /// <param name="mapper"></param>
        /// <param name="webContextManager"></param>
        /// <param name="addressService"></param>
        /// <param name="receiptOptionService"></param>
        /// <param name="receiptService"></param>
        /// <param name="userService"></param>
        public ReceiptFactory(IListManager listManager, ICommonService commonService, IMapper mapper, IWebContextManager webContextManager, IAddressService addressService, IReceiptOptionService receiptOptionService, IReceiptService receiptService, IUserService userService, ICityService cityService)
        {
            _listManager = listManager;
            _commonService = commonService;
            _mapper = mapper;
            _webContextManager = webContextManager;
            _addressService = addressService;
            _receiptOptionService = receiptOptionService;
            _receiptService = receiptService;
            _userService = userService;
            _cityService = cityService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="receiptId"></param>
        /// <returns></returns>
        public async Task<ReceiptDetailViewModel> PrepareDetailViewModelAsync(Guid receiptId)
        {
            if (receiptId == null)
                throw new ArgumentNullException(nameof(receiptId));

            var receipt = _receiptService.FindByIdAsync(receiptId);
            var viewModel = _mapper.Map<ReceiptDetailViewModel>(receipt);

            return viewModel;
        }


        public async Task<ReceiptViewModel> PrepareCreateViewModelAsync(ReceiptViewModel viewModelPrepare = null)
        {
            var viewModel = viewModelPrepare?? new ReceiptViewModel();
            var user = await _userService.FindByIdAsync(_webContextManager.CurrentUserId);
            var userMeta = user.Meta;
            var receipt = await _receiptService.FindByUserIdAsync(_webContextManager.CurrentUserId);
            var receiptLastAddress = await _receiptService.FindLastAddressByUserIdAsync(_webContextManager.CurrentUserId);
            if (receipt != null)
            {
                if (receipt.Address != null)
                {
                    viewModel.Address = _mapper.Map<AddressCreateViewModel>(receipt.Address);
                    viewModel.Address.Street = receipt.Address.Street;
                    viewModel.Address.Extra = receipt.Address.Extra;
                    viewModel.Address.PostalCode = receipt.Address.PostalCode;
                }
            }
           
            else if (receiptLastAddress != null)
            {
                if (receiptLastAddress.Address != null)
                {
                    viewModel.Address = _mapper.Map<AddressCreateViewModel>(receiptLastAddress.Address);
                    viewModel.Address.Street = receiptLastAddress.Address.Street;
                    viewModel.Address.Extra = receiptLastAddress.Address.Extra;
                    viewModel.Address.PostalCode = receiptLastAddress.Address.PostalCode;
                }
            }
            else if (userMeta.Address != null)
            {
                viewModel.Address = _mapper.Map<AddressCreateViewModel>(userMeta.Address);
                viewModel.Address.Street = userMeta.Address.Street;
                viewModel.Address.Extra = userMeta.Address.Extra;
                viewModel.Address.PostalCode = userMeta.Address.PostalCode;
            }
            else
            {
                viewModel.Address = new AddressCreateViewModel();
            }

            if (viewModel.Address.City == null)
                viewModel.Address.City = new CityViewModel();

            viewModel.AddressProvince = await _addressService.GetProvinceAsSelectListItemAsync();
            viewModel.Email = user.Email;
            viewModel.PhoneNumber = userMeta.PhoneNumber;
            viewModel.FirstName = userMeta.FirstName;
            viewModel.LastName = userMeta.LastName;
            viewModel.HomeNumber = userMeta.HomeNumber;
            viewModel.NationalCode = userMeta.NationalCode;
            viewModel.TransfereeName = userMeta.FullName;
            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="receiptId"></param>
        /// <returns></returns>
        public async Task<ReceiptEditViewModel> PrepareEditViewModelAsync(Guid receiptId)
        {
            var receipt = await _receiptService.FindByIdAsync(receiptId);
            var viewModel = _mapper.Map<ReceiptEditViewModel>(receipt);

            return viewModel;
        }


        public async Task<ReceiptListViewModel> PrepareListViewModelAsync(ReceiptSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            //var viewModel = await _receiptService.ListByRequestAsync(request);

            request.TotalCount = await _receiptService.CountByRequestAsync(request);
            var receipts = await _receiptService.GetByRequestAsync(request);
            var map = _mapper.Map<List<ReceiptViewModel>>(receipts);
            var viewModel = new ReceiptListViewModel
            {
                Receipts = map,
                SearchRequest = request,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
            };

            if (isCurrentUser)
                viewModel.IsMine = true;

            return viewModel;
        }

        ///  <summary>
        /// 
        ///  </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ReceiptPreviewViewModel> PreparePreviewViewModelAsync(Guid? id= null)
        {
            object receipt = null;
            if (id != null)
                receipt = await _receiptService.FindByIdAsync(id.GetValueOrDefault());
             receipt = await _receiptService.FindByUserIdAsync(_webContextManager.CurrentUserId, false);

            var viewModel = _mapper.Map<ReceiptPreviewViewModel>(receipt);

            var address = await _receiptService.GetAddressViewModelAsync(viewModel.Id);
            if (address != null)
            {
                viewModel.Address = _mapper.Map<AddressViewModel>(address);
                var province = await _cityService.FindByIdAsync(address.City.ParentId);
                viewModel.Address.City.Name = address.City.Name;
                viewModel.ProvinceName = province.Name;
                if (viewModel.Address.City == null)
                    viewModel.Address.City = new CityViewModel();
            }
            else
            {
                viewModel.Address = new AddressViewModel { City = new CityViewModel() };
            }

            var receiptOptions = await _receiptOptionService.GetMyReceiptOptionsByReceiptIdAsync(viewModel.Id);
            viewModel.ReceiptOptions = receiptOptions.Select(model => new ReceiptOptionViewModel
            {
                TotalPrice = model.TotalPrice,
                CategoryTitle = model.CategoryTitle,
                Title = model.Title,
                CompanyTitle = model.CompanyTitle,
                PreviousPrice = model.PreviousPrice,
                Count = model.Count,
                Price = model.Price,
            }).ToList();

            return viewModel;
        }


        public async Task<ReceiptViewModel> PrepareViewModelAsync()
        {
            var viewModel = new ReceiptViewModel();

           

            return viewModel;
        }

        #endregion Public Methods
    }
}