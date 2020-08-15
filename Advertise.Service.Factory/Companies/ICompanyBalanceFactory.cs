using System;
using System.Threading.Tasks;
using Advertise.Core.Models.CompanyBalance;

namespace Advertise.Service.Factories.Companies
{
    public interface ICompanyBalanceFactory
    {
        Task<CompanyBalanceCreateViewModel> PrepareCreateViewModelAsync(CompanyBalanceCreateViewModel viewModelPrepare = null);
        Task<CompanyBalanceEditViewModel> PrepareEditViewModelAsync(Guid  companyBalanceId, CompanyBalanceEditViewModel viewModelPrepare = null);
        Task<CompanyBalanceListViewModel> PrepareListViewModelAsync(CompanyBalanceSearchRequest request, bool isCurrentUser = false, Guid? userId = null);
        Task<CompanyBalanceViewModel> PrepareViewModelAsync();
    }
}