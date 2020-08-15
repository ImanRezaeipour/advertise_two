using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.SmsOperator
{
    public class SmsOperatorEditViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsAllowExecuteCommand { get; set; }
        public bool IsAllowReadCommand { get; set; }
        public string MobileNumber { get; set; }

        #endregion Public Properties
    }
}