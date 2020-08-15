using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Adses
{
    public class AdsOption : BaseEntity
    {
        public virtual string Title { get; set; }
        public virtual int? Capacity { get; set; }
        public virtual decimal? Price { get; set; }
        public virtual AdsPositionType? PositionType { get; set; }
        public virtual AdsType? Type { get; set; }
    }
}