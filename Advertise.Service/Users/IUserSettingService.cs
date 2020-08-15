using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Users;
using Advertise.Core.Models.UserSetting;
using Advertise.Service.Services.Common;

namespace Advertise.Service.Services.Users
{
    public interface IUserSettingService {
        Task CreateByViewModelAsync(UserSettingCreateViewModel viewModel);
        Task DeleteByIdAsync(Guid userSettingId);


        Task<UserSetting> FindByIdAsync(Guid userSettingId);
        Task<UserSetting> FindByUserIdAsync(Guid userId);



        Task<ServiceResult> SeedAsync();

        Task EditByViewModelAsync(UserSettingEditViewModel viewModel, bool applyCurrentUser = false);
        Task CreateByUserIdAsync(Guid userId);


        Task<IList<UserSetting>> GetByRequestAsync(UserSettingSearchRequest request);

        Task<int> CountByRequestAsync(UserSettingSearchRequest request);


        Task<string> GetMyLanguageAsync();


        IQueryable<UserSetting> QueryByRequest(UserSettingSearchRequest request);
    }
}