using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.ReceiptOption
{
    /// <summary>
    /// مدل درخواست برای محصولات فروخته شده
    /// </summary>
    public class ReceiptOptionSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        /// <summary>
        /// لیستی برای تعیین جنس شناسه کاربر
        /// </summary>
        public ReceiptOptionListType? ListType { get; set; }

        /// <summary>
        /// شناسه رسید
        /// </summary>
        public Guid? ReceiptId { get; set; }

        /// <summary>
        ///  شناسه خریدار یا فروشنده بسته به نوع لیست
        /// </summary>
        public Guid? UserId { get; set; }

        #endregion Public Properties
    }
}