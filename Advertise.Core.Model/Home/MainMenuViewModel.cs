using Advertise.Core.Models.Category;
using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Home
{
    public class MainMenuViewModel : BaseViewModel
    {
        #region Public Properties

        public IEnumerable<CategoryViewModel> Categories { get; set; }

        #endregion Public Properties
    }
}