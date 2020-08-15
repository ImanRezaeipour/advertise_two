using System;
using System.Threading.Tasks;
using Advertise.Core.Models.ReceiptPayment;

namespace Advertise.Service.Factories.Receipts
{
    public interface IReceiptPaymentFactory
    {
        Task<ReceiptPaymentCompleteViewModel> PrepareCompleteViewModelAsync(string authority);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ReceiptPaymentListViewModel> PrepareListViewModelAsync(ReceiptPaymentSearchRequest request, bool isCurrentUser = false, Guid? userId = null);
    }
}