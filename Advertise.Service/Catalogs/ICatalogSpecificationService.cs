using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Core.Domains.Catalogs;
using Advertise.Core.Models.CatalogSpecification;

namespace Advertise.Service.Services.Catalogs
{
    public interface ICatalogSpecificationService
    {
        Task<IList<CatalogSpecification>> GetByCatalogIdAsync(Guid catalogId);


        IQueryable<CatalogSpecification> QueryByRequest(CatalogSpecificationSearchRequest request);


        Task<IList<CatalogSpecification>> GetByRequestAsync(CatalogSpecificationSearchRequest request);

        Task<Guid?> GetCatalogIdBySpecificationId(Guid specificationId, Guid specificationOptionId);
    }
}