using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Company
{
    public class CompanyInfoViewModel : BaseViewModel
    {
        #region Public Properties

        public string Description { get; set; }
        public string FacebookLink { get; set; }
        public string GooglePlusLink { get; set; }
        public Guid Id { get; set; }
        public string InstagramLink { get; set; }
        public string TelegramLink { get; set; }
        public string TwitterLink { get; set; }
        public string YoutubeLink { get; set; }

        #endregion Public Properties
    }
}