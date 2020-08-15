using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Domains.Locations;
using Advertise.Core.Exceptions;
using Advertise.Core.Helpers;
using Advertise.Core.Models.Address;
using Advertise.Core.Models.Bag;
using Advertise.Core.Models.City;
using Advertise.Core.Models.Home;
using Advertise.Core.Models.User;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Locations;
using Advertise.Service.Services.Plans;
using Advertise.Service.Services.Receipts;
using Advertise.Service.Services.Users;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using Advertise.Core.Utilities;
using Advertise.Core.Types;

namespace Advertise.Service.Factories.Users
{

    public class UserFactory : IUserFactory
    {
        #region Private Fields

        private readonly IAddressService _addressService;
        private readonly IBagService _bagService;
        private readonly ICommonService _commonService;
        private readonly ICompanyService _companyService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IRoleService _roleService;
        private readonly IPlanService _planService;
        private readonly IUserService _userService;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="listManager"></param>
        /// <param name="bagService"></param>
        /// <param name="mapper"></param>
        /// <param name="roleService"></param>
        /// <param name="addressService"></param>
        /// <param name="companyService"></param>
        /// <param name="webContextManager"></param>
        /// <param name="commonService"></param>
        /// <param name="userService"></param>
        public UserFactory(IListManager listManager, IBagService bagService, IMapper mapper, IRoleService roleService, IAddressService addressService, ICompanyService companyService, IWebContextManager webContextManager, ICommonService commonService, IUserService userService, IPlanService planService)
        {
            _listManager = listManager;
            _bagService = bagService;
            _mapper = mapper;
            _roleService = roleService;
            _addressService = addressService;
            _companyService = companyService;
            _webContextManager = webContextManager;
            _commonService = commonService;
            _userService = userService;
            _planService = planService;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<DashboardHeaderViewModel> PrepareDashboardHeaderViewModelAsync()
        {
            var userMeta = await _userService.FindUserMetaByCurrentUserAsync();
            var viewModel = _mapper.Map<DashboardHeaderViewModel>(userMeta);

            return viewModel;
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="userName"></param>
       /// <returns></returns>
        public async Task<UserDetailViewModel> PrepareDetailViewModelAsync(string userName)
        {
            var userNovinak = userName.StartsWith(CodeConst.Novinak);
            if (userNovinak)
                throw new ValidationException(" وجود کلمه نویناک");

            var user = await _userService.FindByUserNameAsync(userName);
            var userMeta = await _userService.GetUserMetaByIdAsync(user.Id);
            var viewModel = _mapper.Map<UserDetailViewModel>(userMeta);
            var company = await _companyService.FindByUserIdAsync(viewModel.CreatedById);
            viewModel.CompanyTitle = company.Title;
            viewModel.CompanyAlias = company.Alias;
            viewModel.CompanyId = company.Id;
            viewModel.UserName = user.UserName;

            return viewModel;
        }

        public async Task<UserEditViewModel> PrepareEditViewModelAsync(string userName = null, bool isCurrentUser = false, UserEditViewModel viewModelPrepare = null)
        {
            var user = isCurrentUser ? await _userService.GetCurrentUserAsync() : await _userService.FindByUserNameAsync(userName);
            var viewModel = viewModelPrepare ?? _mapper.Map<UserEditViewModel>(user);

            var userMeta = await _userService.GetUserMetaByIdAsync(viewModel.Id);
            if(userMeta == null)
                throw new FactoryException("اطلاعات تکمیلی موجود نمی باشد");

            viewModel.FirstName = userMeta.FirstName;
            viewModel.LastName = userMeta.LastName;
            viewModel.AvatarFileName = userMeta.AvatarFileName;
            viewModel.Gender = userMeta.Gender.GetValueOrDefault();
            viewModel.NationalCode = userMeta.NationalCode;
            viewModel.HomeNumber = userMeta.HomeNumber;
            viewModel.RoleList = await _roleService.GetRolesAsSelectListAsync();
            viewModel.GenderList = EnumHelper.CastToSelectListItems<GenderType>();// await _listManager.GetTypeGenderList();
            viewModel.AddressProvince = await _addressService.GetProvinceAsSelectListItemAsync();
            viewModel.IsSetUserName = !viewModel.UserName.StartsWith(CodeConst.Novinak);

            var role = await _roleService.FindByUserIdAsync(viewModel.Id);
            if (role != null)
                viewModel.RoleId = role.Id;

            var address = await _addressService.FindByIdAsync(userMeta.AddressId.GetValueOrDefault());
            if (address != null)
            {
                viewModel.Address = _mapper.Map<AddressViewModel>(address);
                if (viewModel.Address.City == null)
                    viewModel.Address.City = new CityViewModel();
            }
            else
            {
                viewModel.Address = new AddressViewModel
                {
                    City = new CityViewModel()
                };
            }

            if (isCurrentUser)
                viewModel.IsMine = true;

            return viewModel;
        }


        public async Task<UserHeaderViewModel> PrepareHeaderViewModelAsync()
        {
            var userMeta = await _userService.GetUserMetaByIdAsync(_webContextManager.CurrentUserId);
            var user = await _userService.FindByIdAsync(_webContextManager.CurrentUserId);
            var viewModel = _mapper.Map<UserHeaderViewModel>(userMeta);

            viewModel.DisplayName = await _userService.GetCurrentUserNameAsync();
            viewModel.IsSetUserName = await _userService.HasUserNameByCurrentUserAsync();
            viewModel.IsSetSubdomain = await _companyService.HasAliasByCurrentUserAsync();
            viewModel.UserName = user.UserName;
            var bagRequest = new BagSearchRequest
            {
                CreatedById = _webContextManager.CurrentUserId
            };
            viewModel.BagCount = await _bagService.CountByRequestAsync(bagRequest);

            return viewModel;
        }


        public async Task<UserListViewModel> PrepareListViewModelAsync(UserSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _userService.CountByRequestAsync(request);
            var user = await _userService.GetUsersByRequestAsync(request);
            var userViewModel = _mapper.Map<IList<UserViewModel>>(user);
            var viewModel = new UserListViewModel
            {
                SearchRequest = request,
                Users = userViewModel
            };
            viewModel.PageSizeList = await _listManager.GetPageSizeListAsync();
            viewModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();
            viewModel.IsActiveList = EnumHelper.CastToSelectListItems<ActiveType>(); //await _listManager.GetIsActiveListAsync();
            viewModel.IsBanList = await _listManager.GetIsBanListAsync();
            viewModel.IsVerifyList = await _listManager.GetIsVerifyListAsync();

            return viewModel;
        }


        public async Task<ProfileHeaderViewModel> PrepareProfileHeaderViewModelAsync()
        {
            var userMeta = await _userService.FindUserMetaByCurrentUserAsync();
            var viewModel = _mapper.Map<ProfileHeaderViewModel>(userMeta);

            return viewModel;
        }

        #endregion Public Methods
    }
}