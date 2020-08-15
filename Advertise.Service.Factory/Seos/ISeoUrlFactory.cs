using System;
using System.Threading.Tasks;
using Advertise.Core.Models.SeoUrl;

namespace Advertise.Service.Factories.Seos
{
    public interface ISeoUrlFactory
    {
        Task<SeoUrlEditViewModel> PrepareEditViewModelAsync(Guid id, SeoUrlEditViewModel viewModelPrepare = null);
        Task<SeoUrlListViewModel> PrepareListViewModelAsync(SeoUrlSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));


        Task<SeoUrlCreateViewModel> PrepareCreateViewModelAsync(SeoUrlCreateViewModel viewModelPrepare = null);
    }
}