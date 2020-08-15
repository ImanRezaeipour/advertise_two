 using System;
 using Advertise.Core.Domains.Common;

namespace Advertise.Core.Domains.Companies
{
    public class CompanyOfficial : BaseEntity
    {
        #region Public Properties

        /// <summary>
        /// کپی جواز کسب
        /// </summary>
        public virtual string BusinessLicenseFileName { get; set; }

        /// <summary>
        /// آیا تایید شده است
        /// </summary>
        public virtual bool? IsApprove { get; set; }

        /// <summary>
        /// آیا اتمام شده است
        /// </summary>
        public virtual bool IsComplete { get; set; }

        /// <summary>
        /// کپی کارت ملی
        /// </summary>
        public virtual string NationalCardFileName { get; set; }

        /// <summary>
        /// آدرس روزنامه رسمی
        /// </summary>
        public virtual string OfficialNewspaperAddress { get; set; }



        #endregion Public Properties


        #region NavigationProperties 

        public virtual Company Company { get; set; }

        public virtual Guid? CompanyId { get; set; }



        #endregion
    }
}