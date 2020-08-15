using System;
using System.Threading.Tasks;

namespace Advertise.Service.Services.ExportImport
{
    public interface IExportManager
    {
        #region Public Methods

        Task<byte[]> GetCategoryAsExcelAsync();

        Task<byte[]> GetCatalogTemplateAsExcelAsync(Guid categoryId);

        #endregion Public Methods
    }
}