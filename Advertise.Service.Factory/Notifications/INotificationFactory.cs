using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Notification;

namespace Advertise.Service.Factories.Notifications
{
    public interface INotificationFactory
    {
        ///  <summary>
        ///
        ///  </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        ///  <param name="userId"></param>
        ///  <returns></returns>
        Task<NotificationListViewModel> PrepareListViewModelAsync(NotificationSearchRequest request, bool isCurrentUser = false, Guid? userId = null);
    }
}