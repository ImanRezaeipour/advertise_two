using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Permission;

namespace Advertise.Service.Factories.Permissions
{
    public interface IPermissionFactory
    {
        Task<PermissionEditViewModel> PrepareEditViewModelAsync(Guid permissionId);
        Task<PermissionListViewModel> PrepareListViewModel(PermissionSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
    }
}