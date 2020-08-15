using System;
using Advertise.Core.Models.Ads;
using System.Threading.Tasks;

namespace Advertise.Service.Factories.Adses
{
    public interface IAdsFactory
    {
        Task<AdsCreateViewModel> PrepareCreateViewModel(AdsCreateViewModel viewModelPrepare = null);
        Task<AdsEditViewModel> PrepareEditViewModelAsync(Guid id);
    }
}