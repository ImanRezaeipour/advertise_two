using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Seos
{
    /// <summary>
    /// 
    /// </summary>
    public class SeoUrl : BaseEntity
    {
        #region Public Properties

        public string AbsoulateUrl { get; set; }

        public string CurrentUrl { get; set; }

        public bool? IsActive { get; set; }

        public RedirectionType? Redirection { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        #endregion Public Properties
    }
}