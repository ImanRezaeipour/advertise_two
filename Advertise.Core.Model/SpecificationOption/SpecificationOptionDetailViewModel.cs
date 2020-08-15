using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.SpecificationOption
{

    public class SpecificationOptionDetailViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///     توضیح بیشتر برای گزینه‌ی مورد نظر
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// </summary>
        public Guid SpecificationId { get; set; }

        /// <summary>
        ///     عنوان گزینه‌ی مورد نظر
        /// </summary>
        public string Title { get; set; }

        #endregion Public Properties
    }
}