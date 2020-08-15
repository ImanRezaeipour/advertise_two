namespace Advertise.Core.Domains.Common
{
    public class BaseImage : BaseEntity
    {
        /// <summary>
        ///     عنوان عکس
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        ///     نام فایل
        /// </summary>
        public virtual string FileName { get; set; }

        /// <summary>
        ///     حجم عکس
        /// </summary>
        public virtual string FileSize { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string FileExtension { get; set; }

        /// <summary>
        ///     سایز عکس
        /// </summary>
        public virtual string FileDimension { get; set; }
    }
}
