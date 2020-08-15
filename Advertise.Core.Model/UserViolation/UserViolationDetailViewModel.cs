using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.UserViolation
{
    public class UserViolationDetailViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid Id { get; set; }

        public bool IsRead { get; set; }
        public string Reason { get; set; }
        public ReasonType Type { get; set; }

        #endregion Public Properties
    }
}