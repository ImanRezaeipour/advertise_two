using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.RolePermission
{
    public class RolePermissionViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public virtual Guid PermissionId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual Guid RoleId { get; set; }

        #endregion Public Properties
    }
}