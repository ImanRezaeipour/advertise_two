using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CompanySocial
{

    public class CompanySocialSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CompanyId { get; set; }
        public Guid? CreatedById { get; set; }

        #endregion Public Properties
    }
}