using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Receipt;

namespace Advertise.Service.Factories.Receipts
{
    public interface IReceiptFactory
    {
        Task<ReceiptDetailViewModel> PrepareDetailViewModelAsync(Guid receiptId);
        Task<ReceiptEditViewModel> PrepareEditViewModelAsync(Guid receiptId);
        Task<ReceiptListViewModel> PrepareListViewModelAsync(ReceiptSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
        Task<ReceiptPreviewViewModel> PreparePreviewViewModelAsync(Guid? id);
        Task<ReceiptViewModel> PrepareViewModelAsync();


        Task<ReceiptViewModel> PrepareCreateViewModelAsync(ReceiptViewModel viewModelPrepare = null);
    }
}