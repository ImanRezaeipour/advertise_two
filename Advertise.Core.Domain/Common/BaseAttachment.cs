namespace Advertise.Core.Domains.Common
{
    public class BaseAttachment : BaseEntity
    {
  

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
