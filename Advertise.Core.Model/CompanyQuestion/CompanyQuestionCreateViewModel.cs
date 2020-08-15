using Advertise.Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.CompanyQuestion
{

    public class CompanyQuestionCreateViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// </summary>
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Body { get; set; }

        public Guid CompanyId { get; set; }
        public Guid? ReplyId { get; set; }

        #endregion Public Properties
    }
}