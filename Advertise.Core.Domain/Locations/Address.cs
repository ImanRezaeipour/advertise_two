using System;
using System.Collections.Generic;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Domains.Receipts;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Locations
{

    public class Address : BaseEntity
    {
        #region Properties

        /// <summary>
        ///     طول جغرافیایی
        /// </summary>
        public virtual string Latitude { get; set; }

        /// <summary>
        ///     عرض جغرافیای
        /// </summary>
        public virtual string Longitude { get; set; }


        /// <summary>
        /// </summary>
        public virtual string Street { get; set; }

        /// <summary>
        /// </summary>
        public virtual string Extra { get; set; }

        /// <summary>
        ///     کد پستی شرکت
        /// </summary>
        public virtual string PostalCode { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        ///     آدرسی که در فاکتور خرید نهایی ذخیره می‌گردد.
        /// </summary>
        public virtual ICollection<Receipt> Receipts { get; set; }

        /// <summary>
        ///     کد اختصاصی آدرس
        /// </summary>
        public virtual City City { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CityId { get; set; }

        /// <summary>
        ///     کد اختصاصی کاربر
        /// </summary>
        public virtual ICollection<UserMeta> Metas { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual ICollection<Company> Companies { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        #endregion
    }
}