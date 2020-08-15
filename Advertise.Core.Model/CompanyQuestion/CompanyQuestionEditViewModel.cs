using Advertise.Core.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.CompanyQuestion
{
    public class CompanyQuestionEditViewModel : BaseViewModel
    {
        #region Public Properties

        public string Body { get; set; }

        public Guid CompanyId { get; set; }
        public string CreatorFullName { get; set; }
        public string EditorFullName { get; set; }
        public Guid Id { get; set; }

        /// <summary>
        /// توضیح برای عدم تائید
        /// </summary>
        public string RejectDescription { get; set; }

        public string Title { get; set; }

        #endregion Public Properties
    }
}