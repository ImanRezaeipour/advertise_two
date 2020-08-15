using Advertise.Core.Models.Address;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SelectListItem = Advertise.Core.Models.Common.SelectListItem;

namespace Advertise.Core.Models.Company
{
    public class CompanyEditViewModel : BaseViewModel
    {
        #region Public Properties

        public AddressViewModel Address { get; set; }

        public Guid AddressId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public IEnumerable<SelectListItem> AddressProvince { get; set; }

        public string Alias { get; set; }

        public string CategoryAlias { get; set; }

        public Guid CategoryId { get; set; }

        public bool CategoryRoot { get; set; }

        public string CategoryTitle { get; set; }

        /// <summary>
        /// روش تسویه حاب مالی
        /// </summary>
        public ClearingType? Clearing { get; set; }

        public IEnumerable<SelectListItem> ClearingList { get; set; }
        public string CoverFileName { get; set; }
        public Guid CreatedById { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public EmployeeRangeType? EmployeeRange { get; set; }

        public IEnumerable<SelectListItem> EmployeeRangeList { get; set; }

        public Guid Id { get; set; }

        // public DateTime EstablishedOn { get; set; }
        public bool IsSetAlias { get; set; }

        public string LogoFileName { get; set; }

        public string MobileNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string RejectDescription { get; set; }

        /// <summary>
        /// شماره حساب شبا
        /// </summary>
        public string ShebaNumber { get; set; }

        /// <summary>
        /// شماره کارت شتاب
        /// </summary>
        public string ShetabNumber { get; set; }

        public string Slogan { get; set; }

        public string Title { get; set; }

        // todo: add correct regular for this
        public string WebSite { get; set; }

        #endregion Public Properties
    }
}