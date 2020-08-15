using System;
using System.Threading.Tasks;
using Advertise.Core.Models.UserSetting;

namespace Advertise.Service.Factories.Users
{
    public interface IUserSettingFactory
    {
        Task<UserSettingEditViewModel> PrepareEditViewModelAsync(Guid? id = null, bool isCurrentUser = false, UserSettingEditViewModel viewModelPrepare = null);
        Task<UserSettingListViewModel> PrepareListViewModelAsync(UserSettingSearchRequest request, bool isCurrentUser = false, Guid? userId = default(Guid?));
    }
}