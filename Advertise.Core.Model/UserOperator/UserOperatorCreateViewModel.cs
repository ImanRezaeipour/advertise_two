using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SelectListItem = Advertise.Core.Models.Common.SelectListItem;

namespace Advertise.Core.Models.UserOperator
{
    public class UserOperatorCreateViewModel : BaseViewModel
    {
        #region Public Properties

        public string Alias { get; set; }

        public decimal? Amount { get; set; }

        public Guid? CategoryId { get; set; }

        public string CompanyTitle { get; set; }
        public string Description { get; set; }

        /// <summary>
        ///
        /// </summary>
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MobileNumber { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Password { get; set; }

        public PaymentType PaymentType { get; set; }

        public IEnumerable<SelectListItem> PaymentTypeList { get; set; }

        public Guid? RoleId { get; set; }

        public IEnumerable<SelectListItem> RoleList { get; set; }
        
        #endregion Public Properties
    }
}