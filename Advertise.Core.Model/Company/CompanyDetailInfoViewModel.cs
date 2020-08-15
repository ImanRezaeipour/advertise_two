using Advertise.Core.Models.Common;
using System;
using Advertise.Core.Models.Address;

namespace Advertise.Core.Models.Company
{
    public class CompanyDetailInfoViewModel : BaseViewModel
    {
        #region Public Properties

        public AddressViewModel Address { get; set; }
        public string Email { get; set; }
        public string FacebookLink { get; set; }
        public string GooglePlusLink { get; set; }
        public string InstagramLink { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string TelegramLink { get; set; }
        public string TwitterLink { get; set; }
        public string WebSite { get; set; }
        public string YoutubeLink { get; set; }

        #endregion Public Properties
    }
}