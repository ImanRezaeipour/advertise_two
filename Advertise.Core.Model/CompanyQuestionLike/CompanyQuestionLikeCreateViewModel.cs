using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CompanyQuestionLike
{
    public class CompanyQuestionLikeCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid CompanyQuestionId { get; set; }
        public bool IsLike { get; set; }
        public Guid UserId { get; set; }

        #endregion Public Properties
    }
}