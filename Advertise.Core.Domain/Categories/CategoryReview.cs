using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Categories
{

    public class CategoryReview : BaseReview
    {
        #region NavigationProperties


        /// <summary>
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CategoryId { get; set; }


        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        #endregion
    }
}