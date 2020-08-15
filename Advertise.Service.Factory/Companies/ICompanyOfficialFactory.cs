using System;
using System.Threading.Tasks;
using Advertise.Core.Models.CompanyOfficial;

namespace Advertise.Service.Factories.Companies
{
    public interface ICompanyOfficialFactory
    {
        Task<CompanyOfficialEditViewModel> PrepareEditViewModelAsync(Guid companyOfficialId, bool applyCurrentUser = false, CompanyOfficialEditViewModel viewModelApply = null);

        Task<CompanyOfficialListViewModel> PrepareListViewModRelAsync(CompanyOfficialSearchRequest request,
            bool isCurrentUser = false, Guid? userId = null);
    }
}