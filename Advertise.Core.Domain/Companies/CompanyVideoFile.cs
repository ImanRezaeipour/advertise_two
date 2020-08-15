using System;
using Advertise.Core.Domains.Common;

namespace Advertise.Core.Domains.Companies
{
    /// <summary>
    /// ویدئوهای کمپانی
    /// </summary>
    public class CompanyVideoFile:BaseEntity
    {

        #region Properties
        /// <summary>
        /// نام ویدئو
        /// </summary>
        public virtual string FileName { get; set; }
        /// <summary>
        /// حجم فایل ویدئو
        /// </summary>
        public virtual string FileSize { get; set; }
        /// <summary>
        /// پسوند فایل ویدئو
        /// </summary>
        public virtual string FileExtension { get; set; }
        /// <summary>
        /// وضوح نمایش ویدئو
        /// </summary>
        public virtual string FileResolution { get; set; }

        /// <summary>
        ///     ترتیب ویدئو
        /// </summary>
        public virtual int? Order { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual bool? IsWatermark { get; set; }
        public virtual string WatermarkName { get; set; }
        public virtual string ThumbName { get; set; }

        #endregion

        #region NavigationProperties

        /// <summary>
        ///     کداختصاصی محصول
        /// </summary>
        public virtual CompanyVideo CompanyVideo { get; set; }

        /// <summary>
        /// </summary>
        public virtual Guid? CompanyVideoId { get; set; }

       
        #endregion
    }
}
