using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyHour;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Companies
{
    public interface ICompanyHourService {

        Task  CreateByViewModelAsync(CompanyHourCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="HourId"></param>
        /// <returns></returns>
        Task  DeleteByIdAsync(Guid HourId);

        Task<CompanyHour> FindAsync(Guid companyHourId);
        Task<CompanyHour> FindByUserIdAsync(Guid userId);

        Task  RemoveRangeAsync(IList<CompanyHour> companyHours);


        Task  SeedAsync();


        Task  EditByViewModelAsync(CompanyHourEditViewModel viewModel);


        Task<IList<CompanyHour>> GetByRequestAsync(CompanyHourSearchRequest request);

        /// <returns></returns>
        Task<int> CountByRequestAsync(CompanyHourSearchRequest request);


      IQueryable<CompanyHour> QueryByRequest(CompanyHourSearchRequest request);
    }
}