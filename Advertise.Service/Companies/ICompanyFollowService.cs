using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Domains.Users;
using Advertise.Core.Models.CompanyFollow;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Companies
{
    public interface ICompanyFollowService {
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyFollowId"></param>
        /// <returns></returns>
        Task<CompanyFollow> FindAsync(Guid companyFollowId);

        Task<CompanyFollow> FindByCompanyIdAsync(Guid userId, Guid companyId);


        /// <summary>
        /// لیست آی دی افرادی که این دسته را فالو کرده اند
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<IList<User>> GetUsersByCompanyIdAsync(Guid companyId);

        /// <summary>
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<bool> IsFollowByCurrentUserAsync(Guid companyId);

        /// <summary>
        /// به محض ورود کاربر به جزئیات هر دسته فالو یا عدم فالو نشان داده شود
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="userId">    </param>
        /// <returns></returns>
        Task<bool> IsFollowByUserIdAsync(Guid companyId, Guid userId);

        Task RemoveRangeAsync(IList<CompanyFollow> companyFollows);


        Task  SeedAsync();

     /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task  ToggleFollowCurrentUserByCompanyIdAsync(Guid companyId);

        Task<int> CountAsync(Guid comapnyId);
        Task<int> CountAllFollowByCompanyIdAsync(Guid companyId);


        Task<IList<CompanyFollow>> GetByRequestAsync(CompanyFollowSearchRequest request);

        Task<int> CountByRequestAsync(CompanyFollowSearchRequest request);


        Task<CompanyFollow> FindByUserIdAsync(Guid userId);


        IQueryable<CompanyFollow> QueryByRequest(CompanyFollowSearchRequest request);

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<CompanyFollowListViewModel> ListByRequestAsync(CompanyFollowSearchRequest request, bool isCurrentUser = false, Guid? userId = null);
    }
}