using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Statistic
{
    public class StatisticSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }

        #endregion Public Properties
    }
}