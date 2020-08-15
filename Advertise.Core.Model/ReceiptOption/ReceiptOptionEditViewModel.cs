using Advertise.Core.Models.Common;
using System;

namespace Advertise.Core.Models.ReceiptOption
{

    public class ReceiptOptionEditViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        ///     کد دسته‌بندی کالا
        /// </summary>
        public string CategoryCode { get; set; }

        /// <summary>
        ///     عنوان دسته‌بندی کالا
        /// </summary>
        public string CategoryTitle { get; set; }

        /// <summary>
        ///     کد محصول
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        ///     کد فروشگاه
        /// </summary>
        public string CompanyCode { get; set; }

        /// <summary>
        ///     عنوان فروشگاه
        /// </summary>
        public string CompanyTitle { get; set; }

        /// <summary>
        ///     تعداد هر کالا
        /// </summary>
        public decimal? Count { get; set; }

        /// <summary>
        ///     میزان درصد تخفیف به ازای هر کالا
        /// </summary>
        public decimal? DiscountPercent { get; set; }

        public Guid Id { get; set; }

        /// <summary>
        ///     قیمت واحد هرکالا پیش از خرید
        /// </summary>
        public decimal? PreviousPrice { get; set; }

        /// <summary>
        ///     قیمت واحد هر کالا
        /// </summary>
        public decimal? Price { get; set; }

        public string Title { get; set; }

        /// <summary>
        ///     قیمت کل به ازای هر کالا
        /// </summary>
        public decimal? TotalPrice { get; set; }

        #endregion Public Properties
    }
}