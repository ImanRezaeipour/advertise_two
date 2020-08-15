using Advertise.Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.Complaint
{

    public class ComplaintDetailViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///
        /// </summary>
        [Required]
        public string Body { get; set; }

        /// <summary>
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Required]
        public string Title { get; set; }

        #endregion Public Properties
    }
}