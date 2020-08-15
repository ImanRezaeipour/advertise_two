using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Address
{
    public class AddressSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public DateTime? CreatedOn { get; set; }
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }

        #endregion Public Properties
    }
}