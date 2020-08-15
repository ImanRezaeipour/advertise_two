using System;
using System.Threading.Tasks;
using Advertise.Core.Models.CompanySlide;

namespace Advertise.Service.Factories.Companies
{
    public interface ICompanySlideFactory
    {
        Task<CompanySlideEditViewModel> PrepareEditViewModelAsync(Guid companySlideId);
        Task<CompanySlideListViewModel> PrepareListViewModelAsync(CompanySlideSearchRequest request, bool isCurrentUser = false, Guid? userId = null);
        Task<CompanySlideCreateViewModel> PrepareCreateViewModelAsync();
        Task<CompanySlideBulkEditViewModel> PrepareBulkEditViewModelAsync();
    }
}