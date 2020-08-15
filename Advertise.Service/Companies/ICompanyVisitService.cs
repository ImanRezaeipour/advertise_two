using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyVisit;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Companies
{
    public interface ICompanyVisitService
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<int> CountByCompanyIdAsync(Guid companyId);


        /// <summary>
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task  CreateByCompanyIdAsync(Guid companyId);

        Task<CompanyVisit> FindAsync(Guid companyVisitId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<CompanyVisit> FindByCompanyIdAsync(Guid companyId);


        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<CompanyVisitListViewModel> ListByRequestAsync(CompanyVisitSearchRequest request, bool isCurrentUser = false, Guid? userId = null);


        Task  SeedAsync();



        Task<IList<CompanyVisit>> GetByRequestAsync(CompanyVisitSearchRequest request);

        Task<int> CountByRequestAsync(CompanyVisitSearchRequest request);


        IQueryable<CompanyVisit> QueryByRequest(CompanyVisitSearchRequest request);
    }
}