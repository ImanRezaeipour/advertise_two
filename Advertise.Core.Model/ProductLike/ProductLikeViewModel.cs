using Advertise.Core.Models.Common;
using Advertise.Core.Models.Product;
using Advertise.Core.Models.User;
using System;

namespace Advertise.Core.Models.ProductLike
{

    public class ProductLikeViewModel : BaseViewModel
    {
        #region Public Properties

        public string BrandName { get; set; }

        public Guid CompanyId { get; set; }

        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// </summary>
        public bool IsFollow { get; set; }

        public UserViewModel LikedBy { get; set; }
        public string LogoFileName { get; set; }
        public string PhoneNumber { get; set; }
        public ProductViewModel Product { get; set; }

        public UserViewModel User { get; set; }

        #endregion Public Properties
    }
}