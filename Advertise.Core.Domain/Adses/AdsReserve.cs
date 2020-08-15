using System;
using Advertise.Core.Domains.Common;

namespace Advertise.Core.Domains.Adses
{

    public class AdsReserve:BaseEntity
    {
        #region Properties

        /// <summary>
        ///     روز نمایش هر اسلاید
        /// </summary>
        public virtual DateTime? Day { get; set; }


        #endregion Properties

        #region NavigationProperties

        /// <summary>
        /// </summary>
        public virtual Ads Ads { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? AdsId { get; set; }

        #endregion NavigationProperties
    }
}