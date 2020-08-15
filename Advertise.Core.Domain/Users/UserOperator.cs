using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Domains.Common;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Users
{
    public class UserOperator :BaseEntity
    {
        public virtual PaymentType? PaymentType { get; set; }
        public virtual decimal? Amount { get; set; }
        public virtual string Description { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

    }
}
