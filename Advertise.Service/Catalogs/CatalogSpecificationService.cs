using Advertise.Core.Domains.Catalogs;
using Advertise.Core.Extensions;
using Advertise.Core.Models.CatalogSpecification;
using Advertise.Core.Models.Common;
using Advertise.Data.DbContexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Services.Specifications;
using LinqKit;

namespace Advertise.Service.Services.Catalogs
{

    public class CatalogSpecificationService : ICatalogSpecificationService
    {
        #region Private Fields

        private readonly IDbSet<CatalogSpecification> _catalogSpecificationRepostory;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

       /// <summary>
       /// 
       /// </summary>
       /// <param name="unitOfWork"></param>
        public CatalogSpecificationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _catalogSpecificationRepostory = unitOfWork.Set<CatalogSpecification>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="catalogId"></param>
        /// <returns></returns>
        public async Task<IList<CatalogSpecification>> GetByCatalogIdAsync(Guid catalogId)
        {
            var request = new CatalogSpecificationSearchRequest
            {
                CatalogId = catalogId,
                PageSize = PageSize.All
            };

            return await GetByRequestAsync(request);
        }

        public async Task<Guid?> GetCatalogIdBySpecificationId(Guid specificationId, Guid specificationOptionId)
        {
            return await _catalogSpecificationRepostory.AsNoTracking()
                .Where(model =>
                    model.SpecificationId == specificationId && model.SpecificationOptionId == specificationOptionId).Select(model => model.CatalogId)
                .FirstOrDefaultAsync();
        }


        public async Task<IList<CatalogSpecification>> GetByRequestAsync(CatalogSpecificationSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }


        public IQueryable<CatalogSpecification> QueryByRequest(CatalogSpecificationSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var catalogSpecifications = _catalogSpecificationRepostory.AsNoTracking().AsQueryable();

            if (request.CreatedOn != null)
                catalogSpecifications = catalogSpecifications.Where(specification => specification.CreatedOn == request.CreatedOn);
            if (request.CatalogId != null)
                catalogSpecifications = catalogSpecifications.Where(specification => specification.CatalogId == request.CatalogId);

            catalogSpecifications = catalogSpecifications.OrderBy($"{request.SortMember ?? SortMember.CreatedOn} {request.SortDirection ?? SortDirection.Desc}");

            return catalogSpecifications;
        }

        #endregion Public Methods
    }
}