using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.AdsOption
{
    public class AdsOptionViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid Id { get; set; }
        public int? Order { get; set; }
        public AdsPositionType? PositionType { get; set; }
        public decimal? Price { get; set; }
        public string Title { get; set; }
        public AdsType? Type { get; set; }
        public DateTime? ReleaseTime { get; set; }

        #endregion Public Properties
    }
}