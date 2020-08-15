using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.SeoUrl
{
    public class SeoUrlViewModel : BaseViewModel
    {
        #region Public Properties

        public string AbsoulateUrl { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CurrentUrl { get; set; }
        public Guid Id { get; set; }
        public bool IsActive { get; set; }

        public RedirectionType Redirection { get; set; }

        #endregion Public Properties
    }
}