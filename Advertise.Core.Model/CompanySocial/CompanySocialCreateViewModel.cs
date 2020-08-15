using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CompanySocial
{
    public class CompanySocialCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public Guid CompanyId { get; set; }
        public string FacebookLink { get; set; }
        public string GooglePlusLink { get; set; }
        public string InstagramLink { get; set; }
        public string TelegramLink { get; set; }
        public string TwitterLink { get; set; }
        public string YoutubeLink { get; set; }

        #endregion Public Properties
    }
}