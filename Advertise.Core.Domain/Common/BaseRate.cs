using Advertise.Core.Types;

namespace Advertise.Core.Domains.Common
{
    public class BaseRate : BaseEntity
    {
        #region Public Properties

        public virtual bool? IsApprove { get; set; }
        public virtual RateType? Rate { get; set; }

        #endregion Public Properties
    }
}