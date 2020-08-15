using System.Threading.Tasks;
using Advertise.Core.Models.ExportImport;

namespace Advertise.Service.Factories.ExportImport
{
    public interface IExportFactory
    {
        Task<ExportIndexViewModel> PrepareIndexViewModelAsync();
    }
}