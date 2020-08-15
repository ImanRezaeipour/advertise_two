using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyTag;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Companies
{
    public interface ICompanyTagService {

        Task  CreateByViewModelAsync(CompanyTagCreateViewModel viewModel);

        Task<CompanyTag> FindAsync(Guid companyTagId);
        Task<CompanyTagListViewModel> GetByCompanyIdAsync(Guid companyId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyTagId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid companyTagId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<CompanyTagListViewModel> ListByRequestAsync(CompanyTagSearchRequest request);


        Task  EditByViewModelAsync(CompanyTagEditViewModel viewModel);


        Task  SeedAsync();

        Task<int> CountAllTagByCompanyIdAsync(Guid companyId);


        Task<IList<CompanyTag>> GetCompanyTagsByRequestAsync(CompanyTagSearchRequest request);

        Task<int> CountByRequestAsync(CompanyTagSearchRequest request);


        IQueryable<CompanyTag> QueryByRequest(CompanyTagSearchRequest request);
    }
}