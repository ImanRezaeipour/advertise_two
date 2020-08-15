using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.CompanyQuestion
{

    public class CompanyQuestionSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CompanyId { get; set; }
        public Guid? CreatedById { get; set; }
        public Guid? ReplyId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public StateType? State { get; set; }

        #endregion Public Properties
    }
}