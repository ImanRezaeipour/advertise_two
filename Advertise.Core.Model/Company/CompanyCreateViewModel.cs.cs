using Advertise.Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;
using Advertise.Core.Types;

namespace Advertise.Core.Models.Company
{
    public class CompanyCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public string Alias { get; set; }

        public Guid CategoryId { get; set; }

        public Guid CreatedById { get; set; }

        public string Email { get; set; }

        public string MobileNumber { get; set; }

        public string Title { get; set; }

        public EmployeeRangeType? EmployeeRange { get; set; }

        #endregion Public Properties
    }
}