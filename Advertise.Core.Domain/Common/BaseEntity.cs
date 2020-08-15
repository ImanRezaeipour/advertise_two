using System;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Domains.Common
{
    public abstract class BaseEntity : Entity
    {
        #region Public Properties

        public virtual DateTime? CreatedOn { get; set; }

        public virtual bool? IsDelete { get; set; }

        [Timestamp]
        public virtual byte?[] RowVersion { get; set; }

        #endregion Public Properties
    }
}