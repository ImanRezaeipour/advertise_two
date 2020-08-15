using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Receipts;
using Advertise.Core.Models.ReceiptPayment;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Receipts
{

    public interface IReceiptPaymentService
    {

        /// <summary>
        /// </summary>
        /// <param name="paymentId"></param>
        /// <returns></returns>
        Task<ReceiptPayment> FindByIdAsync(Guid paymentId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authorityCode"></param>
        /// <returns></returns>
        Task<ReceiptPayment> FindByAuthorityCodeAsync(string authorityCode);

       

        Task<string> CreateAsync();


        Task<ServiceResult> CallbackByViewModelAsync(ReceiptPaymentCallbackViewModel viewModel);


        Task<IList<ReceiptPayment>> GetByRequestAsync(ReceiptPaymentSearchRequest request);

        Task<int> CountByRequestAsync(ReceiptPaymentSearchRequest request);


        IQueryable<ReceiptPayment> QueryByRequest(ReceiptPaymentSearchRequest request);
    }
}