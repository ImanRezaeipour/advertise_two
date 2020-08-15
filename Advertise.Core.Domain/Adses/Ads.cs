using System;
using System.Collections.Generic;
using Advertise.Core.Domains.Categories;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Adses
{
    public class Ads : BaseEntity
    {
        public virtual string Title { get; set; }

        public virtual string ImageFileName { get; set; }

        public virtual string EntityName { get; set; }

        public virtual Guid? EntityId { get; set; }

        public virtual Guid? TargetId { get; set; }
        
        public virtual bool? IsApprove { get; set; }

        public virtual DurationType? DurationType { get; set; }

        public virtual decimal? FinalPrice { get; set; }

        public virtual int? Order { get; set; }

        public virtual User Owner { get; set; }
        
        public virtual Guid? OwnerId { get; set; }

        public virtual AdsOption AdsOption { get; set; }

        public virtual Guid? AdsOptionId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Guid? CategoryId { get; set; }

        public virtual ICollection<AdsPayment> Payments { get; set; }

        public virtual ICollection<AdsReserve> Reserves { get; set; }
    }
}