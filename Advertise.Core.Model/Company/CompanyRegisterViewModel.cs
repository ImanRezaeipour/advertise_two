using Advertise.Core.Models.Address;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.Company
{

    public class CompanyRegisterViewModel : BaseViewModel
    {
        #region Public Properties

        public AddressViewModel Address { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid CreatedById { get; set; }

        public string Email { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///تائید یا عدم تائید
        /// </summary>
        public StateType State { get; set; }

        public string Title { get; set; }

        #endregion Public Properties
    }
}