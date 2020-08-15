using System;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.Tag
{
    /// <summary>
    ///     ویو مدل نمایش گروه کاربری
    /// </summary>
    public class TagViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public string Code { get; set; }

        public string Color { get; set; }

        /// <summary>
        /// </summary>
        public string CostValue { get; set; }

        public DateTime CreatedOn { get; set; }

        /// <summary>
        ///     توضیح سرویس
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        public string DurationDay { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string LogoFileName { get; set; }

        /// <summary>
        ///     عنوان سریس
        /// </summary>
        public string Title { get; set; }

        #endregion Public Properties
    }
}