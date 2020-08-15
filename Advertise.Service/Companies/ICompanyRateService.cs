using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.CompanyRate;

namespace Advertise.Service.Services.Companies
{
    public interface ICompanyRateService
    {
        Task<int> CountByRequestAsync(CompanyRateSearchRequest request);
        Task CreateByViewModelAsync(CompanyRateViewModel viewModel);
        IQueryable<CompanyRate> QueryByRequest(CompanyRateSearchRequest request);
        Task<decimal> RateByRequestAsync(CompanyRateSearchRequest request);
    }
}