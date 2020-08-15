using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.UserOnline
{
    public class UserOnlineViewModel : BaseViewModel
    {
        #region Public Properties

        public bool IsActive { get; set; }
        public string SessionId { get; set; }

        #endregion Public Properties
    }
}