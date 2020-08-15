using System;
using Advertise.Core.Domains.Common;

namespace Advertise.Core.Domains.Newses
{
    /// <summary>
    ///     نشان دهنده پیام های عمومی
    /// </summary>
    public class News : BaseEntity
    {
        #region Properties

        /// <summary>
        ///     عنوان پیام عمومی
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///     متن پیام عمومی
        /// </summary>
        public virtual string Body { get; set; }

        /// <summary>
        ///     دیده شدن و نشدن پیام
        /// </summary>
        public virtual bool? IsActive { get; set; }

        /// <summary>
        /// </summary>
        public virtual DateTime? ExpiredOn { get; set; }

        #endregion

      }
}