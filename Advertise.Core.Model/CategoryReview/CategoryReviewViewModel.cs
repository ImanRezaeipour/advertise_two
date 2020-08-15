using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.CategoryReview
{

    public class CategoryReviewViewModel : BaseViewModel
    {
        #region Public Properties

        public string AvatarFileName { get; set; }

        /// <summary>
        /// </summary>
        public string Body { get; set; }

        public string CategoryAlias { get; set; }

        public string CategoryFileName { get; set; }

        public Guid CategoryId { get; set; }

        public string CategoryImageFileName { get; set; }

        public string CategoryTitle { get; set; }

        public DateTime CreatedOn { get; set; }

        public string FullName { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        public string ImageFileName { get; set; }

        /// <summary>
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// توضیح برای عدم تائید
        /// </summary>
        public string RejectDescription { get; set; }

        /// <summary>
        ///تائید یا عدم تائید
        /// </summary>
        public StateType State { get; set; }

        public string Title { get; set; }
        public string TitleCategory { get; set; }
        public Guid UserId { get; set; }

        #endregion Public Properties
    }
}