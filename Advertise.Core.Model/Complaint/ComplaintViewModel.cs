using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.Complaint
{

    public class ComplaintViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UserAvatar { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UserFullName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string UserUserName { get; set; }

        #endregion Public Properties
    }
}