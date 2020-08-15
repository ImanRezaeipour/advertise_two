using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyOfficial;
using Advertise.Core.Objects;

namespace Advertise.Service.Services.Companies
{
    public interface ICompanyOfficialService
    {
        Task ApproveByViewModelAsync(CompanyOfficialEditViewModel viewModel);
        Task<int> CountByRequestAsync(CompanyOfficialSearchRequest request);
        Task CreateByViewModelAsync(CompanyOfficialCreateViewModel viewModel);
        Task EditByViewModelAsync(CompanyOfficialEditViewModel viewModel);
        Task<CompanyOfficial> FindByIdAsync(Guid companyOfficialId);
        Task<IList<CompanyOfficial>> GetByRequestAsync(CompanyOfficialSearchRequest request);
        IQueryable<CompanyOfficial> QueryByRequestAsync(CompanyOfficialSearchRequest request);
        Task RejectByViewModelAsync(CompanyOfficialEditViewModel viewModel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyOfficialId"></param>
        /// <returns></returns>
        Task<IList<FineUploaderObject>> GetFileOfficialNewspaperAddressAsFineUploaderModelByIdAsync(Guid companyOfficialId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyOfficialId"></param>
        /// <returns></returns>
        Task<IList<FineUploaderObject>> GetFileNationalCardAsFineUploaderModelByIdAsync(Guid companyOfficialId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyOfficialId"></param>
        /// <returns></returns>
        Task<IList<FineUploaderObject>> GetFileBusinessLicenseAsFineUploaderModelByIdAsync(Guid companyOfficialId);
    }
}