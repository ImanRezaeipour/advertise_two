using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Permission
{
    public class PermissionCreateViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool IsCallback { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool IsPermission { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Title { get; set; }

        #endregion Public Properties
    }
}