using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CategoryFollow
{

    public class CategoryFollowCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid CategoryId { get; set; }

        public Guid FollowedById { get; set; }

        /// <summary>
        ///     با توجه به اینکه این گزینه نیازی به نمایش جهت ایجاد ندارد خط زیر هم بلااستفاده است
        /// </summary>
        public bool IsFollow { get; set; }

        #endregion Public Properties
    }
}