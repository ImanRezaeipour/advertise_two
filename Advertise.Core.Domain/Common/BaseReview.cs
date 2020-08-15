namespace Advertise.Core.Domains.Common
{
    public class BaseReview : BaseEntity
    {
        /// <summary>
        /// </summary>
        public virtual string Body { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string Title { get; set; }

        /// <summary>
        /// </summary>
        public virtual bool? IsActive { get; set; }
    }
}
