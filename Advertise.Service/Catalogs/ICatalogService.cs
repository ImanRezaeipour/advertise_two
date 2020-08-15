using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Catalogs;
using Advertise.Core.Models.Catalog;
using Advertise.Core.Models.Common;
using Advertise.Core.Objects;

namespace Advertise.Service.Services.Catalogs
{
    public interface ICatalogService
    {
        Task<Catalog> FindByIdAsync(Guid catalogId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catalogId"></param>
        /// <returns></returns>
        Task DeleteByIdAsync(Guid catalogId);


        Task EditByViewModelAsync(CatalogEditViewModel viewModel);


        Task CreateByViewModelAsync(CatalogExportViewModel viewModel);


        Task<int> CountByRequestAsync(CatalogSearchRequest request);


        Task<IList<Catalog>> GetByRequestAsync(CatalogSearchRequest request);


        IQueryable<Catalog> QueryByRequest(CatalogSearchRequest request);


        Task CreateByViewModelAsync(CatalogCreateViewModel viewModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="catalogId"></param>
        /// <returns></returns>
        Task<IList<FineUploaderObject>> GetFilesAsFineUploaderModelByIdAsync(Guid catalogId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="catalogId"></param>
        /// <returns></returns>
        Task<IList<FineUploaderObject>> GetFileAsFineUploaderModelByIdAsync(Guid catalogId);


        Task<IList<SelectListItem>> GetAsSelectListAsync();


        Task<IList<Select2Object>> GetAsSelect2ObjectAsync();
    }
}