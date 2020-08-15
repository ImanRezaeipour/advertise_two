using System.Threading.Tasks;
using Advertise.Core.Models.SeoSetting;

namespace Advertise.Service.Factories.Seos
{
    public interface ISeoSettingFactory
    {
        Task<SeoSettingEditViewModel> PrepareEditViewModelAsync(SeoSettingEditViewModel viewModelPrepare = null);
    }
}