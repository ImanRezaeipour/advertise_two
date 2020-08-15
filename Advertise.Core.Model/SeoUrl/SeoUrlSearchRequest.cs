using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.SeoUrl
{
    public class SeoUrlSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }

        #endregion Public Properties
    }
}