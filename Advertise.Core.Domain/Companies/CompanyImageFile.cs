using System;
using Advertise.Core.Domains.Common;

namespace Advertise.Core.Domains.Companies
{
    public class CompanyImageFile : BaseImage
    {
        #region Properties

        /// <summary>
        ///     ترتیب عکس
        /// </summary>
        public virtual int? Order { get; set; }

   
        /// <summary>
        ///
        /// </summary>
        public virtual bool? IsWatermark { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        ///     کداختصاصی محصول
        /// </summary>
        public virtual CompanyImage CompanyImage { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CompanyImageId { get; set; }

      

        #endregion
    }
}
