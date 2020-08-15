using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Bag;

namespace Advertise.Service.Factories.Receipts
{
    public interface IBagFactory
    {
        Task<BagDetailViewModel> PrepareDetailViewModelAsync();
        Task<BagListViewModel> PrepareListViewModelAsync(BagSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
        Task<BagMyInfoViewModel> PrepareMyInfoViewModelAsync();
    }
}