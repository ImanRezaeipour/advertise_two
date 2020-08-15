using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.AdsReserve
{

    public class AdsReserveCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid? AdsId { get; set; }
        public DateTime? Day { get; set; }
        public DurationType DurationType { get; set; }
        public Guid? AdsOptionId { get; set; }

        #endregion Public Properties
    }
}