
using System;
using Advertise.Core.Models.Common;

namespace Advertise.Core.Models.Guarantee
{
    public class GuaranteeEditViewModel:BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public  Guid Id { get; set; }
        public string Description { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Title { get; set; }

        #endregion Public Properties

    }
}
