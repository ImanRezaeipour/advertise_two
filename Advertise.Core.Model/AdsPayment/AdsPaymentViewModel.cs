using System;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;

namespace Advertise.Core.Models.AdsPayment
{
    public class AdsPaymentViewModel : BaseViewModel
    {
        /// <summary>
        ///     مبلغ پرداختی
        /// </summary>
        public decimal? Amount { get; set; }

        public Guid? AdsId { get; set; }
        public Guid? CategoryId { get; set; }
        public string AdsImage { get; set; }
        public string AdsTitle { get; set; }
        public string CompanyAlias { get; set; }
        public string CompanyTitle { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? Id { get; set; }

        /// <summary>
        ///     کد پیگیری پرداخت
        /// </summary>
        public string ReferenceCode { get; set; }
        public int AdsOrder { get; set; }
        public  AdsType? AdsType { get; set; }
        public  AdsPositionType? AdsPositionType { get; set; }
        public string CategoryTitle { get; set; }
        public string CategoryMetaTitle { get; set; }
        public string CategoryAlias { get; set; }
        public  DurationType? AdsDuration { get; set; }
        public  DateTime? StartDay { get; set; }
        public  DateTime? EndDay { get; set; }
    }
}