using Advertise.Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.Account
{

    public class RegisterViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool TermOfService { get; set; }

        #endregion Public Properties
    }
}