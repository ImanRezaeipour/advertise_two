using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Notifications;
using Advertise.Core.Models.Notification;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Notifications
{
    public interface INotificationService {

        /// <summary>
        /// ایجاد اعلان جدید
        /// </summary>
        /// <returns></returns>
        Task  CreateByViewModelAsync();


        Task  DeleteAllReadByCurrentUserAsync();

        Task  DeleteByIdAsync(Guid notificationId);

        Task<Notification> FindByIdAsync(Guid notificationId);



        Task  SeedAsync();


        Task<IList<Notification>> GetByRequestAsync(NotificationSearchRequest request);

        Task<int> CountByRequestAsync(NotificationSearchRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IQueryable<Notification> QueryByRequest(NotificationSearchRequest request);

        Task CreateAsync(Guid productId);
    }
}