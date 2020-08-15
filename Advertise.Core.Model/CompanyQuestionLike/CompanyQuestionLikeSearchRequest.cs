using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CompanyQuestionLike
{

    public class CompanyQuestionLikeSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public bool? IsLike { get; set; }

        public Guid? LikedById { get; set; }

        public Guid? QuestionId { get; set; }

        #endregion Public Properties
    }
}