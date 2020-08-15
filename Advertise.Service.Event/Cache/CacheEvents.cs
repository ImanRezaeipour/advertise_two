using Advertise.Core.Domains.Categories;
using Advertise.Core.Events;
using System;
using System.Threading.Tasks;
using Advertise.Service.Managers.Events;

namespace Advertise.Service.Events
{
    /// <summary>
    /// 
    /// </summary>
    public class CacheEvents :
        IEventHandler<EntityInserted<Category>>
    {
        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventMessage"></param>
        public async Task HandleEvent(EntityInserted<Category> eventMessage)
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}