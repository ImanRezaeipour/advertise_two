using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Email
{

    public class EmailEditViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///     نمایش یا عدم نمایش نفد و بررسی کمپانی
        /// </summary>
        public bool Active { get; set; }

        public string AvatarFileName { get; set; }

        /// <summary>
        /// </summary>
        public string Body { get; set; }

        public Guid CategoryId { get; set; }

        public string CategoryTitle { get; set; }

        public string CompanyLogoFileName { get; set; }

        public string FullName { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// توضیح برای عدم تائید
        /// </summary>
        public string RejectDescription { get; set; }

        public string TitleCompany { get; set; }
        public Guid UserId { get; set; }

        #endregion Public Properties
    }
}