using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Home
{
    public class ProfileViewModel : BaseViewModel
    {
        #region Public Properties

        public int FollowersCount { get; set; }
        public bool IsSetCompanyAlias { get; set; }
        public bool IsSetUsername { get; set; }
        public int ProductApprovedCount { get; set; }
        public int ProductPendingCount { get; set; }
        public int ProductRejectCount { get; set; }
        public decimal ReceiptSum { get; set; }
        public Guid UserId { get; set; }

        #endregion Public Properties
    }
}