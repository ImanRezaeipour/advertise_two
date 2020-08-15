using System;
using System.Collections.Generic;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Products;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Keywords
{
    public class Keyword : BaseEntity
    {
        public virtual string Title { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual ICollection<ProductKeyword> ProductKeywords { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual Guid? CreatedById { get; set; }
    }
}
