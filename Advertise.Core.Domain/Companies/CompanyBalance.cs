using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Settings;
using Advertise.Core.Domains.Users;

namespace Advertise.Core.Domains.Companies
{
    /// <summary>
    /// تسویه حساب (تراز مالی) با شرکت ها
    /// </summary>
    public class CompanyBalance : BaseEntity
    {

        /// <summary>
        /// مبلغ تراکنش
        /// </summary>
        public virtual int? Amount { get; set; }

        /// <summary>
        /// تاریخ و زمان تراکنش
        /// </summary>
        public virtual DateTime? TransactionedOn { get; set; }

        /// <summary>
        /// توضیحات تراکنش
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// شماره پیگیری
        /// </summary>
        public virtual string IssueTracking { get; set; }

        /// <summary>
        /// شماره سند
        /// </summary>
        public virtual string DocumentNumber { get; set; }

       /// <summary>
        /// واریز کننده
        /// </summary>
        public virtual string Depositor { get; set; }

        /// <summary>
        /// شرکت
        /// </summary>
        public virtual Company Company { get; set; }

        /// <summary>
        /// شناسه شرکت
        /// </summary>
        public virtual Guid? CompanyId { get; set; }

        public virtual  SettingTransaction SettingTransaction { get; set; }
        public virtual  Guid? SettingTransactionId { get; set; }

        public virtual string AttachmentFile { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual Guid? CreatedById { get; set; }

    }
}
