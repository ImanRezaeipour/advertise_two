using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.CompanySlide
{

    public class CompanySlideViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///     
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        ///     
        /// </summary>
        public Guid? CompanyId { get; set; }

        /// <summary>
        ///     
        /// </summary>
        public Guid? ProductId { get; set; }

        /// <summary>
        ///     نام عکس اسلاید
        /// </summary>
        public string ImageFileName { get; set; }

        /// <summary>
        ///     عنوان اسلاید
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     شماره اسلاید
        /// </summary>
        public int Order { get; set; }

        #endregion Public Properties
    }
}