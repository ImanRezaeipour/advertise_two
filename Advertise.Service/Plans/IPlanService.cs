using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Plans;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Plan;

namespace Advertise.Service.Services.Plans
{
    public interface IPlanService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<Plan> FindByCodeAsync(string code);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Plan> FindByIdAsync(Guid id);

        Task CreateByViewModelAsync(PlanCreateViewModel viewModel);
        Task EditByViewModelAsync(PlanEditViewModel viewModel);
        Task DeleteByIdAsync(Guid? planId);
        IQueryable<Plan> QueryByRequest(PlanSearchRequest request);
        Task<IList<Plan>> GetByRequestAsync(PlanSearchRequest request);
        Task<int> CountByRequestAsync(PlanSearchRequest request);
        Task<IList<SelectListItem>> GetAllAsSelectListItemAsync();
    }
}