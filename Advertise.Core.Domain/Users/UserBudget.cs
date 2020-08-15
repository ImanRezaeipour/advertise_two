using System;
using Advertise.Core.Domains.Common;
using Advertise.Core.Domains.Receipts;

namespace Advertise.Core.Domains.Users
{
    /// <summary>
    ///     نشان دهنده بودجه حساب مالی کاربر
    /// </summary>
    public class UserBudget : BaseEntity
    {
        #region Properties

        /// <summary>
        ///     بودجه باقی مانده حساب مالی کاربر
        /// </summary>
        public virtual int? RemainValue { get; set; }

        /// <summary>
        ///     افزایش و کاهش حساب مالی کاربر
        /// </summary>
        public virtual int? IncDecValue { get; set; }

        /// <summary>
        /// </summary>
        public virtual string Description { get; set; }

        #endregion

        #region NavigationProperties

     
        /// <summary>
        ///
        /// </summary>
        public virtual ReceiptPayment Payment { get; set; }

        /// <summary>
        ///
        /// </summary>
        public virtual Guid? PaymentId { get; set; }

        #endregion
    }
}