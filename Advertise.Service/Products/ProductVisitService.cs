using Advertise.Core.Domains.Products;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.ProductVisit;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Managers.Events;

namespace Advertise.Service.Services.Products
{

    public class ProductVisitService : IProductVisitService
    {
        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<ProductVisit> _productVisitRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        ///  <summary>
        ///
        ///  </summary>
        ///  <param name="mapper"></param>
        ///  <param name="unitOfWork"></param>
        /// <param name="webContextManager"></param>
        public ProductVisitService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _productVisitRepository = unitOfWork.Set<ProductVisit>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<int> CountAllByProductIdAsync(Guid productId)
        {
            var request = new ProductVisitSearchRequest
            {
                ProductId = productId,
            };
            return await CountByRequestAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<int> CountByProductIdAsync(Guid productId)
        {
            if (productId == null)
                throw new ArgumentNullException(nameof(productId));

            var request = new ProductVisitSearchRequest
            {
                PageSize = PageSize.All,
                SortDirection = SortDirection.Asc,
                SortMember = SortMember.CreatedOn,
                PageIndex = 1,
                ProductId = productId
            };
            return await CountByRequestAsync(request);
        }


        public async Task<int> CountByRequestAsync(ProductVisitSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productVisit"></param>
        /// <returns></returns>
        public async Task CreateAsync(ProductVisit productVisit)
        {
            if (productVisit == null)
                throw new ArgumentNullException(nameof(productVisit));

            _productVisitRepository.Add(productVisit);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityInserted(productVisit);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task CreateByProductIdAsync(Guid productId)
        {
            if (productId == null)
                throw new ArgumentNullException(nameof(productId));

            var productVisit = new ProductVisit
            {
                ProductId = productId,
                IsVisit = true,
                VisitedById = _webContextManager.CurrentUserId,
                CreatedOn = DateTime.Now
                
            };
            _productVisitRepository.Add(productVisit);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityInserted(productVisit);
        }

        /// <summary>
        /// </summary>
        /// <param name="productVisitId"></param>
        /// <returns></returns>
        public async Task<ProductVisit> FindByIdAsync(Guid productVisitId)
        {
            return await _productVisitRepository
                  .FirstOrDefaultAsync(model => model.Id == productVisitId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<ProductVisit> FindByProductIdAsync(Guid productId)
        {
            return await _productVisitRepository.FirstOrDefaultAsync(model => model.ProductId == productId);
        }


        public async Task<IList<ProductVisit>> GetByRequestAsync(ProductVisitSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }


        public async Task<List<Guid>> GetMostVisitProductIdAsync()
        {
            var mostVisits = await _productVisitRepository.AsNoTracking()
                .GroupBy(model => model.ProductId)
                .Select(model => new { Id = model.Key.ToString(), Count = model.Count() })
                .OrderByDescending(model => model.Count)
                .Take(15)
                .ToListAsync();

            return mostVisits.Select(model => new Guid(model.Id)).ToList();
        }


        public async Task<IList<Guid>> GetLastProductIdByCurrentUserAsync()
        {
            return await _productVisitRepository.AsNoTracking()
                .Where(model => model.VisitedById == _webContextManager.CurrentUserId)
                .OrderByDescending(model => model.CreatedOn)
                .Select(model => model.ProductId.Value)
                .Take(15)
                .ToListAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ProductVisitListViewModel> ListByRequestAsync(ProductVisitSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            if (isCurrentUser)
                request.CreatedById = _webContextManager.CurrentUserId;
            else if (userId != null)
                request.CreatedById = userId;
            else
                request.CreatedById = null;

            request.TotalCount = await CountByRequestAsync(request);
            var productVisit = await GetByRequestAsync(request);
            var productVisitViewModel = _mapper.Map<IList<ProductVisitViewModel>>(productVisit);
            return new ProductVisitListViewModel
            {
                SearchRequest = request,
                ProductVisits = productVisitViewModel
            };
        }


        public IQueryable<ProductVisit> QueryByRequest(ProductVisitSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var productVisits = _productVisitRepository.AsNoTracking().AsQueryable();
            if (request.ProductId.HasValue)
                productVisits = productVisits.Where(model => model.ProductId == request.ProductId);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            productVisits = productVisits.OrderBy($"{request.SortMember} {request.SortDirection}");

            return productVisits;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productVisits"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync(IList<ProductVisit> productVisits)
        {
            if (productVisits == null)
                throw new ArgumentNullException(nameof(productVisits));

            foreach (var productVisit in productVisits)
                _productVisitRepository.Remove(productVisit);
        }


        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}