using System.Threading.Tasks;
using Advertise.Core.Domains.Products;
using Advertise.Core.Events;
using Advertise.Service.Managers.Events;
using Advertise.Service.Services.Notifications;

namespace Advertise.Service.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class NotificationEvents : 
        IEventHandler<EntityUpdated<Product>>
    {
        #region Private Fields

        private readonly INotificationService _notificationService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notificationService"></param>
        public NotificationEvents(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventMessage"></param>
        public async Task HandleEvent(EntityUpdated<Product> eventMessage)
        {
            await _notificationService.CreateAsync(eventMessage.Entity.Id);
        }

        #endregion Public Methods
    }
}