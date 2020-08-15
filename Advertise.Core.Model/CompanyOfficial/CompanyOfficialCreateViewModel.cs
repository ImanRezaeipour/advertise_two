using System;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.CompanyOfficial
{
    public class CompanyOfficialCreateViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// کپی جواز کسب
        /// </summary>
        public string BusinessLicenseFileName { get; set; }

        /// <summary>
        /// کپی کارت ملی
        /// </summary>
        public string NationalCardFileName { get; set; }

        /// <summary>
        /// آدرس روزنامه رسمی
        /// </summary>
        public string OfficialNewspaperAddress { get; set; }



        #endregion Public Properties
    }
}