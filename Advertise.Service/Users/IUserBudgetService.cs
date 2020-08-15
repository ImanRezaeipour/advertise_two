using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Users;
using Advertise.Core.Models.UserBudget;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Users
{
    public interface IUserBudgetService {


        Task CreateByViewModelAsync(UserBudgetCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="userBudgetId"></param>
        /// <returns></returns>
        Task DeleteByIdAsync(Guid userBudgetId);


        Task<UserBudget> FindAsync(Guid userBudgetId);



        Task SeedAsync();


        Task EditByViewModelAsync(UserBudgetEditViewModel viewModel);


        Task<IList<UserBudget>> GetByRequestAsync(UserBudgetSearchRequest request);

        Task<int> CountByRequestAsync(UserBudgetSearchRequest request);


        IQueryable<UserBudget> QueryByRequest(UserBudgetSearchRequest request);
    }
}