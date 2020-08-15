using Advertise.Core.Domains.Common;
using Advertise.Core.Types;

namespace Advertise.Core.Domains.Manufacturers
{

    public class Manufacturer : BaseEntity
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public virtual CountryType? Country { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual string Name { get; set; }

        #endregion Public Properties
    }
}