using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;

namespace Advertise.Core.Models.CompanyImage
{

    public class CompanyImageDetailViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        public string FileDimension { get; set; }

        /// <summary>
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// </summary>
        public string FileSize { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     ترتیب الویت نمایش عکسها
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// توضیح برای عدم تائید
        /// </summary>
        public string RejectDescription { get; set; }

        /// <summary>
        ///تائید یا عدم تائید
        /// </summary>
        public StateType State { get; set; }

        /// <summary>
        /// </summary>
        public string Title { get; set; }

        #endregion Public Properties
    }
}