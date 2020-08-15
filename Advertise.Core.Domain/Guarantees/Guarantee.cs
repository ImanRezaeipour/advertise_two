using Advertise.Core.Domains.Common;

namespace Advertise.Core.Domains.Guarantees
{

    public class Guarantee : BaseEntity
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string Email { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string MobileNumber { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string PhoneNumber { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string Title { get; set; }

        #endregion Public Properties
    }
}