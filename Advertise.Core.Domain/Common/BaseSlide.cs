using Advertise.Core.Types;

namespace Advertise.Core.Domains.Common
{
    public class BaseSlide : BaseEntity
    {
        /// <summary>
        ///     عنوان اسلاید
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///     نام عکس اسلاید
        /// </summary>
        public virtual string ImageFileName { get; set; }

        /// <summary>
        ///     (نام انتیتی مربوط به اسلاید (دسته‌بندی، کمپانی یا محصول
        /// </summary>
        public virtual string EntityName { get; set; }

        /// <summary>
        ///     (کدشناسایی اسلاید مربوط به آدرس دهی (نام مستعار دسته‌بندی، نام مستعار کمپانی یا کد محصول
        /// </summary>
        public virtual string EntityId { get; set; }

        /// <summary>
        ///     مشخص می‌کند که آیا نوبت به اسلاید رسیده‌است یا خیر
        /// </summary>
        public virtual bool? IsApprove { get; set; }

        /// <summary>
        ///     مدت زمان رزرو هر اسلاید در سایت
        /// </summary>
        public virtual DurationType? DurationType { get; set; }

        public virtual decimal? FinalPrice { get; set; }
    }
}
