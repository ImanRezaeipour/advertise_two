using System.Collections.Generic;

namespace Advertise.Service.Managers.Events
{
    public interface ISubscriptionService
    {
        #region Public Methods

        IList<IEventHandler<T>> GetSubscriptions<T>();

        #endregion Public Methods
    }
}