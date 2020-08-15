using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Plan;

namespace Advertise.Service.Factories.Plans
{
    public interface IPlanFactory
    {
        Task<PlanListViewModel> PrepareListViewModelAsync(PlanSearchRequest request,bool isCurrentUser = false, Guid? userId = null);
        Task<PlanCreateViewModel> PrepareCreateViewModelAsync(PlanCreateViewModel viewModelPrepare = null);
        Task<PlanEditViewModel> PrepareEditViewModelAsync(Guid id, PlanEditViewModel viewModelPrepare = null);
    }
}