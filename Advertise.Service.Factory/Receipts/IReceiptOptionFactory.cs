using System;
using System.Threading.Tasks;
using Advertise.Core.Models.ReceiptOption;

namespace Advertise.Service.Factories.Receipts
{
    public interface IReceiptOptionFactory
    {
        Task<ReceiptOptionListViewModel> PrepareListViewModel(ReceiptOptionSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
    }
}