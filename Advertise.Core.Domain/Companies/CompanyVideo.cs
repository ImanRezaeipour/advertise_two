using System;
using System.Collections.Generic;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Companies
{
    /// <summary>
    /// مشخصات ویدئوها
    /// </summary>
    public class CompanyVideo : BaseEntity
    {

        #region Properties

        /// <summary>
        ///     ترتیب گالری ویدئو
        /// </summary>
        public virtual int? Order { get; set; }

        /// <summary>
        /// عنوان گالری ویدئو
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///تائید شدن ویدئو توسط اپراتور
        /// </summary>
        public virtual StateType? State { get; set; }

        /// <summary>
        /// توضیح برای عدم تائید
        /// </summary>
        public virtual string RejectDescription { get; set; }
        #endregion

        #region NavigationProperties

        /// <summary>
        ///     نام کمپانی
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// شناسه کمپانی
        /// </summary>
        public virtual Guid? CompanyId { get; set; }

        public virtual User User { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ApprovedById { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CompanyVideoFile> VideoFiles { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

        #endregion



    }
}
