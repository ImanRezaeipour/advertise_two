using Advertise.Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.Role
{

    public class RoleEditViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///     آی دی
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     نام گروه کاربری
        /// </summary>
        public string Name { get; set; }

        public string Permissions { get; set; }

        #endregion Public Properties
    }
}