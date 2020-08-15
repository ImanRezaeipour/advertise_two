using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.CompanyReview
{

    public class CompanyReviewViewModel : BaseViewModel
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

        /// <summary>
        /// </summary>
        public string CompanyAlias { get; set; }

        /// <summary>
        /// </summary>
        public string CompanyLogo { get; set; }

        public string CompanyLogoFileName { get; set; }

        public string CompanyTitle { get; set; }

        /// <summary>
        /// </summary>
        public DateTime CreatedOn { get; set; }

        public string FullName { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// توضیح برای عدم تائید
        /// </summary>
        public string RejectDescription { get; set; }

        /// <summary>
        ///تائید یا عدم تائید
        /// </summary>
        public StateType State { get; set; }

        /// <summary>
        /// </summary>
        public string Title { get; set; }

        public Guid UserId { get; set; }

        #endregion Public Properties
    }
}