using Advertise.Core.Domains.Receipts;
using Advertise.Core.Models.ReceiptPayment;
using Advertise.Core.Profiles.Common;
using AutoMapper;

namespace Advertise.Core.Profiles.ReceiptPayments
{
    /// <summary>
    /// کلیه نگاشت ها برای تراکنش های مالی محصولات خریداری شده
    /// </summary>
    public class ReceiptPaymentProfile : BaseProfile
    {
        #region Public Constructors

        /// <summary>
        /// کلاس سازنده
        /// </summary>
        public ReceiptPaymentProfile()
        {
            CreateMap<ReceiptPayment, ReceiptPaymentListViewModel>(MemberList.None).ReverseMap();

            CreateMap<ReceiptPayment, ReceiptPaymentViewModel>(MemberList.None).ReverseMap();
        }

        #endregion Public Constructors
    }
}