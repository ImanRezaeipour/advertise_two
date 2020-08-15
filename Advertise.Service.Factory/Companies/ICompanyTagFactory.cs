using System;
using System.Threading.Tasks;
using Advertise.Core.Models.CompanyTag;

namespace Advertise.Service.Factories.Companies
{
    public interface ICompanyTagFactory
    {
        Task<CompanyTagListViewModel> PrepareListViewModelAsync(CompanyTagSearchRequest request, bool isCurrentUser = false, Guid? userId = null);
    }
}