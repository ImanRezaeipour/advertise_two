using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyBalance;
using Advertise.Core.Objects;

namespace Advertise.Service.Services.Companies
{
    public interface ICompanyBalanceService
    {
        Task<int> CountByRequestAsync(CompanyBalanceSearchRequest request);
        Task CreateByViewModelAsync(CompanyBalanceCreateViewModel viewModel);
        Task DeleteByIdAsync(Guid companyBalanceId);
        Task EditByViewModelAsync(CompanyBalanceEditViewModel viewModel);
        Task<IList<CompanyBalance>> GetByRequestAsync(CompanyBalanceSearchRequest request);
        IQueryable<CompanyBalance> QueryByRequest(CompanyBalanceSearchRequest request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyBalanceId"></param>
        /// <returns></returns>
        Task<CompanyBalance> FindByIdAsync(Guid companyBalanceId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<IList<FineUploaderObject>> GetFileAsFineUploaderModelByIdAsync(Guid categoryId);
    }
}