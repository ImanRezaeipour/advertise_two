using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Keyword
{
    public class KeywordSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public DateTime? CreatedOn { get; set; }

        public bool? IsActive { get; set; }

        #endregion Public Properties
    }
}