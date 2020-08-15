using Advertise.Core.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.Role
{

    public class RoleCreateViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///     نام گروه کاربری
        /// </summary>
        public string Name { get; set; }

        public string Permissions { get; set; }

        #endregion Public Properties
    }
}