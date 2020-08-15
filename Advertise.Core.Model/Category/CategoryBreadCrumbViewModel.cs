using Advertise.Core.Models.Common;
using System.Collections.Generic;

namespace Advertise.Core.Models.Category
{
    public class CategoryBreadCrumbViewModel : BaseViewModel
    {
        #region Public Properties

        public string CurrentTitle { get; set; }
        public bool? IsAllSearch { get; set; }
        public IEnumerable<CategoryViewModel> Nodes { get; set; }

        #endregion Public Properties
    }
}