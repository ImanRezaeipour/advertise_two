using Advertise.Core.Models.Address;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.User
{
    public class UserEditViewModel : BaseViewModel
    {
        #region Public Properties

        public AddressViewModel Address { get; set; }

        public IEnumerable<SelectListItem> AddressProvince { get; set; }

        public string AvatarFileName { get; set; }

        public string BannedReason { get; set; }

       // public string Email { get; set; }

        public string FirstName { get; set; }

        public GenderType? Gender { get; set; }

        public IEnumerable<SelectListItem> GenderList { get; set; }

        public string HomeNumber { get; set; }

        public Guid Id { get; set; }

        public bool IsBan { get; set; }

        public bool IsSetUserName { get; set; }

        public string LastName { get; set; }

        public string NationalCode { get; set; }

        public string PhoneNumber { get; set; }

        public Guid RoleId { get; set; }

        public IEnumerable<SelectListItem> RoleList { get; set; }

        public string UserName { get; set; }

        #endregion Public Properties
    }
}