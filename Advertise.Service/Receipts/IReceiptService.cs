using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Locations;
using Advertise.Core.Domains.Receipts;
using Advertise.Core.Models.Address;
using Advertise.Core.Models.Receipt;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Receipts
{
    public interface IReceiptService {

        Task CreateByViewModel(ReceiptViewModel viewModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiptId"></param>
        /// <returns></returns>
        Task DeleteByIdAsync(Guid receiptId);

     


        Task FinalUpdateByViewModel(ReceiptViewModel viewModel);

        Task<Receipt> FindByIdAsync(Guid receiptId);
        Task<Receipt> FindByUserIdAsync(Guid userId, bool? isBuy = null);
        Task<Receipt> FindLastAddressByUserIdAsync(Guid userId);
        Task<Address> GetAddressByUserId(Guid userId);
        Task<AddressViewModel> GetAddressViewModelAsync(Guid receiptId);

      


        Task<bool> IsExistByUserIdAsync(Guid userId, bool? isBuy = null);

        Task<string> MaxCodeByRequestAsync(ReceiptSearchRequest request, string aggregateMember);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiptId"></param>
        /// <param name="isBuy"></param>
        /// <returns></returns>
        Task SetIsBuyByReceiptIdAsync(Guid receiptId, bool isBuy);

        Task EditAddressByIdAsync(Guid receiptId, Address address);


        Task EditByViewModelAsync(ReceiptViewModel viewModel);

        Task<string> GenerateCodeForReceiptAsync();


        Task<IList<Receipt>> GetByRequestAsync(ReceiptSearchRequest request);

        Task<int> CountByRequestAsync(ReceiptSearchRequest request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="receiptId"></param>
        /// <param name="invoiceNumber"></param>
        /// <returns></returns>
        Task SetInvoiceNumberAsync(Guid receiptId, string invoiceNumber);


        IQueryable<Receipt> QueryByRequest(ReceiptSearchRequest request);


        Task<bool> HasByCurrentUserAsync();
    }
}