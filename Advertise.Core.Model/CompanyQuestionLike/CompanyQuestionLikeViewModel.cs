using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CompanyQuestionLike
{

    public class CompanyQuestionLikeViewModel : BaseViewModel
    {
        #region Public Properties

        public string BrandName { get; set; }

        public Guid CompanyId { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// </summary>
        public bool IsLike { get; set; }

        public string LogoFileName { get; set; }
        public string PhoneNumber { get; set; }

        #endregion Public Properties
    }
}