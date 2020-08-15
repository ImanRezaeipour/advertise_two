using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.UserSetting
{
    public class UserSettingSearchRequest : BaseSearchRequest
    {
        #region Public Properties

        public Guid? CreatedById { get; set; }

        #endregion Public Properties
    }
}