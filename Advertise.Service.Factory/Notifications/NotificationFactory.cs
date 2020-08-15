using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Models.Notification;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Notifications;
using AutoMapper;

namespace Advertise.Service.Factories.Notifications
{

    public class NotificationFactory : INotificationFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="listManager"></param>
        /// <param name="commonService"></param>
        /// <param name="notificationService"></param>
        public NotificationFactory(IListManager listManager, ICommonService commonService, INotificationService notificationService, IMapper mapper)
        {
            _listManager = listManager;
            _commonService = commonService;
            _notificationService = notificationService;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        ///  <param name="userId"></param>
        ///  <returns></returns>
        public async Task<NotificationListViewModel> PrepareListViewModelAsync(NotificationSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _notificationService.CountByRequestAsync(request);
            var notifications = await _notificationService.GetByRequestAsync(request);
            var notificationViewModel = _mapper.Map<IList<NotificationViewModel>>(notifications);
            var viewModel = new NotificationListViewModel
            {
                SearchRequest = request,
                Notifications = notificationViewModel,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
            };

            if (isCurrentUser)
                viewModel.IsMine = true;

            return viewModel;
        }

        #endregion Public Methods
    }
}

