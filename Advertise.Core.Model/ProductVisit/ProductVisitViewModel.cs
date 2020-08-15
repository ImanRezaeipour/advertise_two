using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.ProductVisit
{

    public class ProductVisitViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     نمایش یا عدم نمایش نقد و بررسی
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// توضیح برای عدم تائید
        /// </summary>
        public string RejectDescription { get; set; }

        /// <summary>
        ///تائید یا عدم تائید
        /// </summary>
        public StateType State { get; set; }

        #endregion Public Properties
    }
}