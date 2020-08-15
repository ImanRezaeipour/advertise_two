using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.SeoUrl
{
    public class SeoUrlCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public string AbsoulateUrl { get; set; }

        public string CurrentUrl { get; set; }

        public bool IsActive { get; set; }

        public RedirectionType Redirection { get; set; }

        public IEnumerable<SelectListItem> RedirectionTypeList { get; set; }

        #endregion Public Properties
    }
}