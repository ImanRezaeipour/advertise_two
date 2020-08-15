using Advertise.Core.Domains.Catalogs;
using Advertise.Core.Extensions;
using Advertise.Core.Models.CatalogImage;
using Advertise.Core.Models.Common;
using Advertise.Data.DbContexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Managers.Events;

namespace Advertise.Service.Services.Catalogs
{

    public class CatalogImageService : ICatalogImageService
    {
        #region Private Fields

        private readonly IDbSet<CatalogImage> _catalogImageRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        /// <param name="eventPublisher"></param>
        public CatalogImageService(IUnitOfWork unitOfWork, IMapper mapper, IEventPublisher eventPublisher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _eventPublisher = eventPublisher;
            _catalogImageRepository = unitOfWork.Set<CatalogImage>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="catalogId"></param>
        /// <returns></returns>
        public async Task<IList<CatalogImage>> GetByCatalogIdAsync(Guid catalogId)
        {
            var request = new CatalogImageSearchRequest
            {
                CatalogId = catalogId
            };

            return await GetByRequestAsync(request);
        }


        public async Task<IList<CatalogImage>> GetByRequestAsync(CatalogImageSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }


        public IQueryable<CatalogImage> QueryByRequest(CatalogImageSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var catalogImages = _catalogImageRepository.AsNoTracking().AsQueryable();

            if (request.CreatedOn != null)
                catalogImages = catalogImages.Where(image => image.CreatedOn == request.CreatedOn);
            if (request.CatalogId != null)
                catalogImages = catalogImages.Where(image => image.CatalogId == request.CatalogId);

            //if (string.IsNullOrEmpty(request.SortMember))
            //    request.SortMember = SortMember.CreatedOn;
            //if (string.IsNullOrEmpty(request.SortDirection))
            //    request.SortDirection = SortDirection.Desc;

            catalogImages = catalogImages.OrderBy($"{request.SortMember ?? SortMember.CreatedOn} {request.SortDirection ?? SortDirection.Desc}");

            return catalogImages;
        }

        #endregion Public Methods
    }
}