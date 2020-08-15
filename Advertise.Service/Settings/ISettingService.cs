using System;
using System.Threading.Tasks;
using Advertise.Core.Domains.Settings;
using Advertise.Core.Models.Setting;

namespace Advertise.Service.Services.Settings
{
    public interface ISettingService
    {
        SettingViewModel GetFirst();


        Task EditByViewModel(SettingEditViewModel viewModel);


        Task<Setting> GetFirstAsync();
    }
}