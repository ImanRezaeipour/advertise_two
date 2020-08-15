using System;
using System.Threading.Tasks;
using Advertise.Core.Models.AdsOption;

namespace Advertise.Service.Factories.Adses
{
    public interface IAdsOptionFactory
    {
        Task<AdsOptionCreateViewModel> PrepareCreateViewModelAsync(AdsOptionCreateViewModel viewModelPrepare = null);
        Task<AdsOptionEditViewModel> PrepareEditViewModelAsync(Guid id);


        Task<AdsOptionListViewModel> PrepareListViewModelAsync(AdsOptionSearchRequest request, bool isCurrentUser = false, Guid? userId = null);
    }
}