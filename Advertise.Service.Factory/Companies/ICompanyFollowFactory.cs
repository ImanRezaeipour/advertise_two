using System;
using System.Threading.Tasks;
using Advertise.Core.Models.CompanyFollow;

namespace Advertise.Service.Factories.Companies
{
    public interface ICompanyFollowFactory
    {
        Task<CompanyFollowListViewModel> PrepareListViewModelAsync(bool isCurrentUser = false, bool follower = false, Guid? userId = null);
    }
}