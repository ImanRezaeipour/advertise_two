using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.CompanyVideo
{
    public class CompanyVideoSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CompanyId { get; set; }
        public Guid? CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? Id { get; set; }

        public StateType? State { get; set; }
        public Guid? UserId { get; set; }

        #endregion Public Properties
    }
}