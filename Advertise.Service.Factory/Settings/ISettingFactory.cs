using System.Threading.Tasks;
using Advertise.Core.Models.Setting;

namespace Advertise.Service.Factories.Settings
{
    public interface ISettingFactory
    {
        Task<SettingEditViewModel> PrepareEditViewModel();
    }
}