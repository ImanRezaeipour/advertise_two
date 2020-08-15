using Advertise.Core.Models.CategoryOption;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;

namespace Advertise.Core.Models.Home
{
    public class ProfileMenuViewModel : BaseViewModel
    {
        #region Public Properties

        public string Alias { get; set; }
        public CategoryOptionViewModel CategoryOption { get; set; }
        public StateType State { get; set; }

        #endregion Public Properties
    }
}