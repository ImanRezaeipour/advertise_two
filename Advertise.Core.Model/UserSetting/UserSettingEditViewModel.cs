using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SelectListItem = Advertise.Core.Models.Common.SelectListItem;

namespace Advertise.Core.Models.UserSetting
{
    /// <summary>
    ///     ویو مدل نمایش گروه کاربری
    /// </summary>
    public class UserSettingEditViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid Id { get; set; }
        public bool IsEnableDateOfBirth { get; set; }
        public bool IsEnableSpecificationletter { get; set; }
        public bool IsHideSpecificationletterBlock { get; set; }
        public LanguageType Language { get; set; }
        public IEnumerable<SelectListItem> LanguageList { get; set; }
        public ThemeType Theme { get; set; }
        public IEnumerable<SelectListItem> ThemeList { get; set; }

        #endregion Public Properties
    }
}