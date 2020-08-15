using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CompanyConversation
{

    public class CompanyConversationSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }
        public Guid? RecivedById { get; set; }

        #endregion Public Properties
    }
}