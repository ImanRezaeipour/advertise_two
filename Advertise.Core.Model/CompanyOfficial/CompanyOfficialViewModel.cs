using System;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.CompanyOfficial
{
    public class CompanyOfficialViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// کپی جواز کسب
        /// </summary>
        public string BusinessLicenseFileName { get; set; }

        /// <summary>
        /// آیا تایید شده است
        /// </summary>
        public bool IsApprove { get; set; }

        /// <summary>
        /// آیا اتمام شده است
        /// </summary>
        public bool IsComplete { get; set; }

        public string CompanyTitle { get; set; }

        public string CompanyAlias { get; set; }

        public Guid Id { get; set; }

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