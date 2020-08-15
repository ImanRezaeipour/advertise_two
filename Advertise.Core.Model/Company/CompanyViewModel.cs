using Advertise.Core.Models.Address;
using Advertise.Core.Models.CategoryOption;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.Company
{
    public class CompanyViewModel : BaseViewModel
    {
        #region Public Properties

        public AddressViewModel Address { get; set; }
        public string Alias { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryAlias { get; set; }
        public string CategoryMetaTitle { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryOptionViewModel CategoryOption { get; set; }
        public string CategoryTitle { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int FollowerCount { get; set; }
        public Guid Id { get; set; }
        public Guid CreatedById { get; set; }
        public bool InitFollow { get; set; }
        public string LogoFileName { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string PreviewImageFileName { get; set; }
        public int ProductCount { get; set; }
        public string RejectDescription { get; set; }
        public StateType State { get; set; }
        public int TagCount { get; set; }
        public string TagTitle { get; set; }
        public string Title { get; set; }
        public string UserAvatar { get; set; }

        public string UserDisplayName { get; set; }

        public string UserFullName { get; set; }
        public string UserUserName { get; set; }

        public EmployeeRangeType EmployeeRange { get; set; }

        #endregion Public Properties
    }
}