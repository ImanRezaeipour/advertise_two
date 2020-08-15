using Advertise.Core.Types;

namespace Advertise.Core.Domains.Common
{
    public class BaseBanner : BaseEntity
    {
        /// <summary>
        ///     عنوان بنر
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///     نام عکس بنر
        /// </summary>
        public virtual string ImageFileName { get; set; }

        /// <summary>
        ///     (نام انتیتی مربوط به بنر (دسته‌بندی، کمپانی یا محصول
        /// </summary>
        public virtual string EntityName { get; set; }

        /// <summary>
        ///     (کدشناسایی بنر مربوط به آدرس دهی (نام مستعار دسته‌بندی، نام مستعار کمپانی یا کد محصول
        /// </summary>
        public virtual string EntityId { get; set; }

        /// <summary>
        ///     مشخص می‌کند که آیا نوبت به بنر رسیده‌است یا خیر
        /// </summary>
        public virtual bool? IsApprove { get; set; }

        /// <summary>
        ///     مدت زمان رزرو هر بنر در سایت
        /// </summary>
        public virtual DurationType? DurationType { get; set; }

        public virtual decimal? FinalPrice { get; set; }


    }
}
