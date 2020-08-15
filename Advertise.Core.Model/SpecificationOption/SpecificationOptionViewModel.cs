using Advertise.Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.SpecificationOption
{

    public class SpecificationOptionViewModel : BaseViewModel
    {
        #region Public Properties

        public string CategoryAlias { get; set; }

        public string CategoryImageFileName { get; set; }

        public string CategoryMetaTitle { get; set; }

        public string CategoryTitle { get; set; }

        public DateTime CreatedOn { get; set; }

        /// <summary>
        ///     توضیح بیشتر برای گزینه‌ی مورد نظر
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        public int Order { get; set; }

        /// <summary>
        /// </summary>
        public Guid SpecificationId { get; set; }

        /// <summary>
        /// </summary>
        public string SpecificationTitle { get; set; }

        /// <summary>
        ///     عنوان گزینه‌ی مورد نظر
        /// </summary>
        public string Title { get; set; }

        public bool? IsSelected { get; set; }

        #endregion Public Properties
    }
}