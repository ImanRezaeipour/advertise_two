using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Role;

namespace Advertise.Service.Factories.Users
{
    public interface IRoleFactory
    {
        Task<RoleEditViewModel> PrepareEditViewModelAsync(Guid roleId);
        Task<RoleListViewModel> PrepareListViewModelAsync(RoleSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
    }
}