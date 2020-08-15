using System;
using System.ComponentModel.DataAnnotations.Schema;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Locations;
using Advertise.Core.Domains.Logs;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Users
{
    /// <summary>
    ///     نشان دهنده کاربر
    /// </summary>
    public class UserMeta : BaseEntity
    {
        #region Properties

      
        /// <summary>
        ///     نام کاربر
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        ///     نام خانوادگی کاربر
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        ///     نام نمایشی کاربر
        /// </summary>
        public virtual string DisplayName { get; set; }

        /// <summary>
        ///     کد ملی کاربر
        /// </summary>
        public virtual string NationalCode { get; set; }

        /// <summary>
        ///     تاریخ تولد کاربر
        /// </summary>
        public virtual DateTime? BirthOn { get; set; }

        /// <summary>
        ///     تاریخ ازدواج کاربر
        /// </summary>
        public virtual DateTime? MarriedOn { get; set; }

        /// <summary>
        ///     عکس یا لوگو کاربر
        /// </summary>
        public virtual string AvatarFileName { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public Guid UserId { get; set; }

        /// <summary>
        ///     آیا کاربر فعال است؟
        /// </summary>
        public virtual bool? IsActive { get; set; }

        /// <summary>
        ///     جنسیت کاربر
        /// </summary>
        public virtual GenderType? Gender { get; set; }

        /// <summary>
        /// </summary>
        public virtual string AboutMe { get; set; }

        /// <summary>
        /// شماره تلفن ثابت
        /// </summary>
        public virtual string HomeNumber { get; set; }
        public virtual string PhoneNumber { get; set; }

        /// <summary>
        ///
        /// </summary>
        [NotMapped]
        public virtual string FullName => FirstName + " " + LastName;

        #endregion

        #region NavigationProperties

   
        /// <summary>
        ///     شهر محل زندگی کاربر
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        ///     کلید خارجی شهر
        /// </summary>
        public virtual Guid? AddressId { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }



        #endregion
    }
}