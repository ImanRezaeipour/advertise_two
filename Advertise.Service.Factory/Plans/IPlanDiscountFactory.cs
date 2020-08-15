using System;
using System.Threading.Tasks;
using Advertise.Core.Models.PlanDiscount;

namespace Advertise.Service.Factories.Plans
{
    public interface IPlanDiscountFactory
    {
        Task<PlanDiscountListViewModel> PrepareListViewModelAsync(PlanDiscountSearchRequest request, bool isCurrentUser = false, Guid? userId = null);
        Task<PlanDiscountEditViewModel> PrepareEditViewModelAsync(Guid? id);
    }
}