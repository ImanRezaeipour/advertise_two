using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Catalogs;
using Advertise.Core.Models.CatalogImage;

namespace Advertise.Service.Services.Catalogs
{
    public interface ICatalogImageService
    {
        Task<IList<CatalogImage>> GetByCatalogIdAsync(Guid catalogId);
        Task<IList<CatalogImage>> GetByRequestAsync(CatalogImageSearchRequest request);
        IQueryable<CatalogImage> QueryByRequest(CatalogImageSearchRequest request);
    }
}