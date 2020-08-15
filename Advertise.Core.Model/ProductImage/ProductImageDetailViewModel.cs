using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.ProductImage
{

    public class ProductImageDetailViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// مسیر فایل
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     ترتیب الویت نمایش عکسها
        /// </summary>
        public int Order { get; set; }

        #endregion Public Properties
    }
}