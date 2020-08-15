using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Catalogs;
using Advertise.Core.Models.CatalogFeature;

namespace Advertise.Service.Services.Catalogs
{
    public interface ICatalogFeatureService
    {
        Task<IList<CatalogFeature>> GetByRequestAsync(CatalogFeatureSearchRequest request);
        IQueryable<CatalogFeature> QueryByRequest(CatalogFeatureSearchRequest request);
    }
}