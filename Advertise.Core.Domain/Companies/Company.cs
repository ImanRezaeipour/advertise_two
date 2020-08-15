using System;
using System.Collections.Generic;
using Advertise.Core.Domains.Categories;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Locations;
using Advertise.Core.Domains.Products;
using Advertise.Core.Domains.Users;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Companies
{
    public class Company : BaseEntity
    {
        #region Properties

        /// <summary>
        ///     کد کمپانی
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        ///     نام شرکت
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// نام اختصاری شرکت
        /// </summary>
        public virtual string Alias { get; set; }

        /// <summary>
        ///     توضیحات مربوط به شرکت
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        ///     لوگوی شرکت
        /// </summary>
        public virtual string LogoFileName { get; set; }

        /// <summary>
        /// عکی کاور شرکت
        /// </summary>
        public virtual string CoverFileName { get; set; }

        /// <summary>
        /// رنگ شرکت
        /// </summary>
        public virtual string Color { get; set; }

        /// <summary>
        /// شعار شرکت
        /// </summary>
        public virtual string Slogan { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string BackgroundFileName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string ShortUrl { get; set; }

        /// <summary>
        ///     شماره تلفن(های) شرکت
        /// </summary>
        public virtual string PhoneNumber { get; set; }

        /// <summary>
        ///     شماره همراه
        /// </summary>
        public virtual string MobileNumber { get; set; }

        /// <summary>
        ///     آدرس ایمیل شرکت
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        ///     آدرس وب سایت شرکت
        /// </summary>
        public virtual string WebSite { get; set; }

        /// <summary>
        /// تعداد کارمندان
        /// </summary>
        public virtual EmployeeRangeType? EmployeeRange { get; set; }

        /// <summary>
        ///     سال تاسیس
        /// </summary>
        public virtual DateTime? EstablishedOn { get; set; }

        /// <summary>
        /// </summary>
        public virtual string MetaTitle{ get; set; }

        /// <summary>
        /// </summary>
        public virtual string MetaKeywords { get; set; }

        /// <summary>
        /// </summary>
        public virtual string MetaDescription { get; set; }

        /// <summary>
        ///تائید یا عدم تائید 
        /// </summary>
        public virtual StateType? State { get; set; }

        /// <summary>
        /// توضیح برای عدم تائید
        /// </summary>
        public virtual string RejectDescription { get; set; }

        /// <summary>
        /// عکس برای آیتم نشان‌دهنده کمپانی
        /// </summary>
        public virtual string PreviewImageFileName { get; set; }

        /// <summary>
        /// شماره کارت شتاب
        /// </summary>
        public virtual string ShetabNumber { get; set; }

        /// <summary>
        /// شماره حساب شبا
        /// </summary>
        public virtual string ShebaNumber { get; set; }

        /// <summary>
        /// روش تسویه حاب مالی
        /// </summary>
        public virtual ClearingType? Clearing { get; set; }

        #endregion

        #region NavigationProperties

      
        /// <summary>
        /// تایید کننده
        /// </summary>
        public virtual User ApprovedBy { get; set; }

        /// <summary>
        /// شناسه تایید کننده
        /// </summary>
        public virtual Guid? ApprovedById { get; set; }

        /// <summary>
        ///     آدرس شرکت
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// شناسه آدرس
        /// </summary>
        public virtual Guid? AddressId { get; set; }

        /// <summary>
        /// دسته بندی
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// شناسه دسته بندی
        /// </summary>
        public virtual Guid? CategoryId{ get; set; }

        /// <summary>
        /// فابل های الصاقی
        /// </summary>
        public virtual ICollection<CompanyAttachment> Attachments { get; set; }

        /// <summary>
        /// پیروان
        /// </summary>
        public virtual ICollection<CompanyFollow> Follows { get; set; }

        /// <summary>
        /// گالری تصاویر
        /// </summary>
        public virtual ICollection<CompanyImage> Images { get; set; }

        /// <summary>
        /// </summary>
        public virtual ICollection<CompanyQuestion> Questions { get; set; }

        /// <summary>
        /// </summary>
        public virtual ICollection<CompanyReview> Reviews { get; set; }

        /// <summary>
        /// </summary>
        public virtual ICollection<CompanySocial> Socials { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CompanyHour> CompanyHours { get; set; }

        public virtual ICollection<CompanyOfficial> CompanyOfficials { get; set; }

        /// <summary>
        /// </summary>
        public virtual ICollection<CompanyVisit> Visits { get; set; }

        /// <summary>
        /// محصولات
        /// </summary>
        public virtual ICollection<Product> Products { get; set; }

        /// <summary>
        /// </summary>
        public virtual ICollection<CompanySlide> Slides { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }


        #endregion
    }
}