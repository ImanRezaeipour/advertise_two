using System.Threading.Tasks;
using Advertise.Core.Domains.Seos;
using Advertise.Core.Models.SeoSetting;

namespace Advertise.Service.Services.Seo
{
    public interface ISeoSettingService
    {
        SeoSettingViewModel GetFirst();


        Task<SeoSetting> GetFirstAsync();


        Task EditByViewModelAsync(SeoSettingEditViewModel viewModel);
    }
}