using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CompanyVisit
{
    public class CompanyVisitCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid CompanyId { get; set; }
        public bool IsVisit { get; set; }

        public Guid UserId { get; set; }

        #endregion Public Properties
    }
}