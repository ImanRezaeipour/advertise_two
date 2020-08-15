using System;
using System.Threading.Tasks;
using Advertise.Core.Models.PlanPayment;

namespace Advertise.Service.Factories.Plans
{
    public interface IPlanPaymentFactory
    {
        Task<PlanPaymentListViewModel> PrepareListViewModel(PlanPaymentSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
        Task<PlanPyamentCreateViewModel> PrepareCreateViewModel();
    }
}