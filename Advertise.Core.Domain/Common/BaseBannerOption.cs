using Advertise.Core.Types;

namespace Advertise.Core.Domains.Common
{
    public class BaseBannerOption : BaseEntity
    {

        /// <summary>
        ///     جایگاه قرارگیری هر بنر در صفحه
        /// </summary>
        public virtual string Position { get; set; }

        /// <summary>
        ///     عنوان جایگاه قرارگیری بنر
        /// </summary>
        public virtual string PositionTitle { get; set; }

        /// <summary>
        ///     ترتیب نمایش هر بنر
        /// </summary>
        public virtual int? Order { get; set; }

        /// <summary>
        ///     قیمت هر بنر
        /// </summary>
        public virtual decimal? Price { get; set; }

  

    }
}
