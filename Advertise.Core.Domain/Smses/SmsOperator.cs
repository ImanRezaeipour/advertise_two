using Advertise.Core.Domains.Common;

namespace Advertise.Core.Domains.Smses
{
    public class SmsOperator : BaseEntity
    {
        #region Public Properties

        public virtual bool IsActive { get; set; }
        public virtual bool IsAllowExecuteCommand { get; set; }
        public virtual bool IsAllowReadCommand { get; set; }
        public virtual string MobileNumber { get; set; }

        #endregion Public Properties
    }
}