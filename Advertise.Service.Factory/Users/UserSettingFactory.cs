using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Domains.Users;
using Advertise.Core.Helpers;
using Advertise.Core.Models.UserSetting;
using Advertise.Core.Types;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Users;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using Advertise.Core.Utilities;

namespace Advertise.Service.Factories.Users
{

    public class UserSettingFactory : IUserSettingFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IUserSettingService _userSettingService;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="commonService"></param>
        /// <param name="listManager"></param>
        /// <param name="mapper"></param>
        /// <param name="userSettingService"></param>
        /// <param name="webContextManager"></param>
        public UserSettingFactory(ICommonService commonService, IListManager listManager, IMapper mapper, IUserSettingService userSettingService, IWebContextManager webContextManager)
        {
            _commonService = commonService;
            _listManager = listManager;
            _mapper = mapper;
            _userSettingService = userSettingService;
            _webContextManager = webContextManager;
        }

        #endregion Public Constructors

        #region Public Methods

      /// <summary>
      /// 
      /// </summary>
      /// <param name="id"></param>
      /// <param name="isCurrentUser"></param>
      /// <param name="viewModelPrepare"></param>
      /// <returns></returns>
        public async Task<UserSettingEditViewModel> PrepareEditViewModelAsync(Guid? id = null, bool isCurrentUser = false, UserSettingEditViewModel viewModelPrepare = null)
      {
          var userSetting = (isCurrentUser ? await _userSettingService.FindByUserIdAsync(_webContextManager.CurrentUserId) : await _userSettingService.FindByUserIdAsync(id.Value)) ??
                            new UserSetting
                            {
                                Language = LanguageType.Persian,
                                Theme = ThemeType.White
                            };
            var viewModel = _mapper.Map<UserSettingEditViewModel>(userSetting);
            viewModel.LanguageList = EnumHelper.CastToSelectListItems<LanguageType>(); //await _listManager.GetLanguageTypeList();
            viewModel.ThemeList = EnumHelper.CastToSelectListItems<ThemeType>();//await _listManager.GetThemeTypeList();

            if (isCurrentUser)
                viewModel.IsMine = true;

            return viewModel;
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        ///  <param name="userId"></param>
        ///  <returns></returns>
        public async Task<UserSettingListViewModel> PrepareListViewModelAsync(UserSettingSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _userSettingService.CountByRequestAsync(request);
            var userSetting = await _userSettingService.GetByRequestAsync(request);
            var userSettingViewModel = _mapper.Map<IList<UserSettingViewModel>>(userSetting);
            var viewModel = new UserSettingListViewModel
            {
                SearchRequest = request,
                UserSettings = userSettingViewModel,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync()
            };

            return viewModel;
        }

        #endregion Public Methods
    }
}