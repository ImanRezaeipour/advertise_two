using System.Threading.Tasks;
using Advertise.Core.Models.ExportImport;

namespace Advertise.Service.Factories.ExportImport
{
    public interface IImportFactory
    {
        Task<ImportIndexViewModel> PrepareIndexViewModelAsync();
    }
}