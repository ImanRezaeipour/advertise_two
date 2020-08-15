using Advertise.Core.Models.Address;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.User
{
    public class UserDetailInfoViewModel : BaseViewModel
    {
        #region Public Properties

        public AddressViewModel Address { get; set; }
        public string Email { get; set; }
        public string HomeNumber { get; set; }
        public string PhoneNumber { get; set; }

        #endregion Public Properties
    }
}