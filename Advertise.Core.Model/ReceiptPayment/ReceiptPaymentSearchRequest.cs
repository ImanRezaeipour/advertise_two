using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.ReceiptPayment
{
    public class ReceiptPaymentSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public string AuthorityCode { get; set; }
        public Guid? CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public StateType? State { get; set; }

        #endregion Public Properties
    }
}