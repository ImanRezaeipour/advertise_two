using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.ProductTag
{

    public class ProductTagViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// </summary>
        public ColorType TagColor { get; set; }

        /// <summary>
        /// </summary>
        public string TagTitle { get; set; }

        #endregion Public Properties
    }
}