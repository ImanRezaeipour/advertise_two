using Advertise.Core.Models.Common;
using Advertise.Core.Types;

namespace Advertise.Core.Models.UserViolation
{

    public class UserViolationCreateViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// متن گزارش
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// نوع گزارش
        /// </summary>
        public ReasonType Type { get; set; }

        #endregion Public Properties
    }
}