using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.Category
{

    public class CategorySearchRequest : BaseSearchRequest
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public Guid? CreatedById { get; set; }

        public Guid? Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? IsActive { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Guid? ParentId { get; set; }

        public CategoryType? Type { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? WithMany { get; set; }

        public bool? WithRoot { get; set; }

        #endregion Public Properties
    }
}