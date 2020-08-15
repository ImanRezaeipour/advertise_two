using System;
using System.Threading.Tasks;
using Advertise.Core.Models.CompanyVideo;

namespace Advertise.Service.Factories.Companies
{
    public interface ICompanyVideoFactory
    {
        Task<CompanyVideoEditViewModel> PrepareEditViewModelAsync(Guid companyVideoId, bool applyCurrentUser = false);
        Task<CompanyVideoListViewModel> PrepareListViewModelAsync(CompanyVideoSearchRequest request, bool isCurrentUser = false, Guid? userId = null);
        Task<CompanyVideoDetailViewModel> PrepareDetailViewModelAsync(Guid companyVideoId);
    }
}