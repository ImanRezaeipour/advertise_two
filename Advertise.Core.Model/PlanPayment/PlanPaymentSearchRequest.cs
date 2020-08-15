using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.PlanPayment
{
    public class PlanPaymentSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }

        #endregion Public Properties
    }
}