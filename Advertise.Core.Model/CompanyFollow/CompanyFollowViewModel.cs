using Advertise.Core.Models.Common;
using Advertise.Core.Models.Company;
using System;

namespace Advertise.Core.Models.CompanyFollow
{
    /// <inheritdoc />

    public class CompanyFollowViewModel : BaseViewModel
    {
        #region Public Properties

        public string AvatarFileName { get; set; }
        public CompanyDetailViewModel Company { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? FollowedById { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }

        #endregion Public Properties
    }
}