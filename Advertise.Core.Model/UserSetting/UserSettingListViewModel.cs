using System.Collections.Generic;
using Advertise.Core.Models.Common;
using SelectListItem = Advertise.Core.Models.Common.SelectListItem;

namespace Advertise.Core.Models.UserSetting
{
    public class UserSettingListViewModel:BaseViewModel 
    {
        #region Public Properties

        public IEnumerable<SelectListItem> PageSizeList { get; set; }
        public UserSettingSearchRequest SearchRequest { get; set; }
        public IEnumerable<SelectListItem> SortDirectionList { get; set; }
        public IEnumerable<SelectListItem> SortMemberList { get; set; }
        public IEnumerable<UserSettingViewModel> UserSettings { get; set; }

        #endregion Public Properties
    }
}