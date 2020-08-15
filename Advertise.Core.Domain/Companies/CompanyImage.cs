using System;
using System.Collections.Generic;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Users;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Companies
{
    /// <summary>
    ///     مشخصات عکس ها
    /// </summary>
    public class CompanyImage : BaseEntity
    {
        #region Properties

        /// <summary>
        ///     ترتیب گالری تصاویر
        /// </summary>
        public virtual int? Order { get; set; }

        /// <summary>
        ///تائید شدن عکس توسط اپراتور
        /// با موافقت آقای رضایی:)
        /// </summary>
        public virtual StateType? State { get; set; }

        /// <summary>
        /// عنوان گالری تصاویر
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string RejectDescription { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        ///     
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CompanyId { get; set; } /// <summary>
        ///     
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? ApprovedById { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CompanyImageFile> ImageFiles { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

       // public virtual User ModifiedBy { get; set; }
      //  public virtual Guid? ModifiedById { get; set; }

        #endregion
    }
}