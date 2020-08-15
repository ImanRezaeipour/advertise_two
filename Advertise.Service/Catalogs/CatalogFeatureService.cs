using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Advertise.Core.Domains.Catalogs;
using Advertise.Core.Extensions;
using Advertise.Core.Models.CatalogFeature;
using Advertise.Core.Models.Common;
using Advertise.Data.DbContexts;
using Advertise.Service.Managers.Events;
using AutoMapper;

namespace Advertise.Service.Services.Catalogs
{
    public class CatalogFeatureService : ICatalogFeatureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<CatalogFeature> _catalogFeatureRepository;
        private readonly IMapper _mapper;
        private readonly IEventPublisher _eventPublisher;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        /// <param name="eventPublisher"></param>
        public CatalogFeatureService(IUnitOfWork unitOfWork, IMapper mapper, IEventPublisher eventPublisher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _eventPublisher = eventPublisher;
            _catalogFeatureRepository = unitOfWork.Set<CatalogFeature>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IQueryable<CatalogFeature> QueryByRequest(CatalogFeatureSearchRequest request)
        {
            if(request == null)
                throw new ArgumentNullException(nameof(request));

            var catalogFeatures = _catalogFeatureRepository.AsNoTracking().AsQueryable();

            if (request.CreatedOn != null)
                catalogFeatures = catalogFeatures.Where(feature => feature.CreatedOn == request.CreatedOn);
            if (request.CatalogId != null)
                catalogFeatures = catalogFeatures.Where(feature => feature.CatalogId == request.CatalogId);

            catalogFeatures = catalogFeatures.OrderBy($"{request.SortMember ?? SortMember.CreatedOn} {request.SortDirection ?? SortDirection.Desc}");

            return catalogFeatures;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IList<CatalogFeature>> GetByRequestAsync(CatalogFeatureSearchRequest request)
        {
            if(request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }
    }
}
