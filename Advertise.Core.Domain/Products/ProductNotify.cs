using Advertise.Core.Domains.Common;
using System;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Products
{
    public class ProductNotify : BaseEntity
    {
        #region Public Properties

        public virtual Product Product { get; set; }
        public virtual Guid? ProductId { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }
        #endregion Public Properties
    }
}