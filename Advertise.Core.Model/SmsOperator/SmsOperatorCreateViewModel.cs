using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.SmsOperator
{
    public class SmsOperatorCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public bool IsActive { get; set; }
        public bool IsAllowExecuteCommand { get; set; }
        public bool IsAllowReadCommand { get; set; }
        public string MobileNumber { get; set; }

        #endregion Public Properties
    }
}