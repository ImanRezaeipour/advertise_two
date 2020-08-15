using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Plans;
using Advertise.Core.Models.PlanDiscount;

namespace Advertise.Service.Services.Plans
{
    public interface IPlanDiscountService
    {
        Task<PlanDiscount> FindByIdAsync(Guid planDiscountId);
        Task CreateByViewModelAsync(PlanDiscountCreateViewModel viewModel);
        Task EditByViewModelAsync(PlanDiscountEditViewModel viewModel);
        Task DeleteByIdAsync(Guid? planDiscountId);
        IQueryable<PlanDiscount> QueryByRequest(PlanDiscountSearchRequest request);
        Task<IList<PlanDiscount>> GetByRequestAsync(PlanDiscountSearchRequest request);
        Task<int> CountByRequestAsync(PlanDiscountSearchRequest request);
        Task<int?> GetPercentByCodeAsync(string planDiscountCode);
    }
}