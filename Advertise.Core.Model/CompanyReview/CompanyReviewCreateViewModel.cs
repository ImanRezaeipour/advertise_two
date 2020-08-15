using Advertise.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.CompanyReview
{
    public class CompanyReviewCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public string Body { get; set; }

        public Guid CompanyId { get; set; }
        public IEnumerable<SelectListItem> CompanyList { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }

        #endregion Public Properties
    }
}