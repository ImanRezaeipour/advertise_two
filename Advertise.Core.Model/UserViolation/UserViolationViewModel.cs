using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.UserViolation
{

    public class UserViolationViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// </summary>
        public bool IsRead { get; set; }

        /// <summary>
        /// عنوان گزارش
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// متن گزارش
        /// </summary>
        public string ReasonDescription { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string TargetFullName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string TargetUserName { get; set; }

        /// <summary>
        /// نوع گزارش
        /// </summary>
        public ReasonType Type { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UserAvatar { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UserFullName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UserUserName { get; set; }

        #endregion Public Properties
    }
}