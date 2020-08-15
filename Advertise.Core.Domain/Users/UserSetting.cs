using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Users
{

    public class UserSetting : BaseEntity
    {
        #region Properties

        /// <summary>
        ///     زبان انتخابی کاربر
        /// </summary>
        public LanguageType? Language { get; set; }

        /// <summary>
        ///     تم انتخابی کاربر
        /// </summary>
        public ThemeType? Theme { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Specificationletter' form field is enabled
        /// </summary>
        public bool? IsEnableSpecificationletter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to hide Specificationletter box
        /// </summary>
        public bool? IsHideSpecificationletterBlock { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether 'Date of Birth' is enabled
        /// </summary>
        public bool? IsEnableDateOfBirth { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        #endregion


    }
}