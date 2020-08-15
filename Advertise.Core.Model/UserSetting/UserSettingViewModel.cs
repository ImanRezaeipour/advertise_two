using Advertise.Core.Types;

namespace Advertise.Core.Models.UserSetting
{
    /// <summary>
    ///     ویو مدل نمایش گروه کاربری
    /// </summary>
    public class UserSettingViewModel
    {
        #region Public Properties

        public bool IsEnableDateOfBirth { get; set; }
        public bool IsEnableSpecificationletter { get; set; }
        public bool IsHideSpecificationletterBlock { get; set; }
        public LanguageType Language { get; set; }

        public ThemeType Theme { get; set; }

        public string UserLastName { get; set; }

        #endregion Public Properties
    }
}