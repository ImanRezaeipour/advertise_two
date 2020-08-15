using System;
using System.Threading.Tasks;
using Advertise.Core.Models.Home;
using Advertise.Core.Models.User;

namespace Advertise.Service.Factories.Users
{
    public interface IUserFactory
    {
        Task<DashboardHeaderViewModel> PrepareDashboardHeaderViewModelAsync();
        Task<UserDetailViewModel> PrepareDetailViewModelAsync(string userName);
        Task<UserEditViewModel> PrepareEditViewModelAsync(string userName = null, bool isCurrentUser = false, UserEditViewModel viewModelPrepare = null);
        Task<UserHeaderViewModel> PrepareHeaderViewModelAsync();
        Task<UserListViewModel> PrepareListViewModelAsync(UserSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
        Task<ProfileHeaderViewModel> PrepareProfileHeaderViewModelAsync();
    }
}