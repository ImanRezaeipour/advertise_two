using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Receipts;
using Advertise.Core.Models.ReceiptOption;

namespace Advertise.Service.Services.Receipts
{
   public  interface IReceiptOptionService
    {
        Task<int> CountByRequestAsync(ReceiptOptionSearchRequest request);


     

       
        Task<IList<ReceiptOption>> GetMyReceiptOptionsByReceiptIdAsync(Guid receiptId, Guid? userId = null);


        Task<IList<ReceiptOption>> GetByRequestAsync(ReceiptOptionSearchRequest request);


        IQueryable<ReceiptOption> QueryByRequest(ReceiptOptionSearchRequest request);

        decimal? GetSumTotalPriceAsync(Guid userId);
    }
}