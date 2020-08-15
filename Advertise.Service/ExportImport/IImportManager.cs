using System;
using System.IO;
using System.Threading.Tasks;

namespace Advertise.Service.Services.ExportImport
{
    public interface IImportManager
    {
        Task ImportCategoriesFromXlsxAsync(Stream stream);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task ImportCatalogsFromXlsxAsync(Stream stream, Guid categoryId);
    }
}