using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Plan
{

    public class PlanSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }

        public Guid? UserId { get; set; }

        #endregion Public Properties
    }
}