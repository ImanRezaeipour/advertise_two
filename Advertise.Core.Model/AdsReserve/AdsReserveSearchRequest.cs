using System;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.AdsReserve
{
   public class AdsReserveSearchRequest : BaseSearchRequest
    {
        public Guid? CreatedById { get; set; }
        public bool? IsApprove { get; set; }

        public DateTime? Day { get; set; }
        public Guid? OptionId { get; set; }
    }
}
