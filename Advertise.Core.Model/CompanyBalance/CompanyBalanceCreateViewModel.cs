using Advertise.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Advertise.Core.Models.CompanyBalance
{
    public class CompanyBalanceCreateViewModel
    {
        #region Public Properties

        /// <summary>
        /// مبلغ تراکنش
        /// </summary>
        public int? Amount { get; set; }

        public string AttachmentFile { get; set; }

        /// <summary>
        /// شناسه شرکت
        /// </summary>
        public Guid? CompanyId { get; set; }

        public IEnumerable<SelectListItem> CompanyList { get; set; }

        /// <summary>
        /// واریز کننده
        /// </summary>
        public string Depositor { get; set; }

        /// <summary>
        /// توضیحات تراکنش
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// شماره سند
        /// </summary>
        public string DocumentNumber { get; set; }

        /// <summary>
        /// شماره پیگیری
        /// </summary>
        public string IssueTracking { get; set; }

        public Guid? SettingTransactionId { get; set; }

        public IEnumerable<SelectListItem> SettingTransactionList { get; set; }

        /// <summary>
        /// تاریخ و زمان تراکنش
        /// </summary>
        public DateTime? TransactionedOn { get; set; }

        #endregion Public Properties
    }
}