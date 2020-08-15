using Advertise.Core.Domains.Products;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.ProductRate;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Core.Exceptions;
using Advertise.Service.Managers.Events;

namespace Advertise.Service.Services.Products
{

    public class ProductRateService : IProductRateService
    {
        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<ProductRate> _productRateRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        ///  <summary>
        ///
        ///  </summary>
        ///  <param name="eventPublisher"></param>
        ///  <param name="mapper"></param>
        ///  <param name="unitOfWork"></param>
        /// <param name="webContextManager"></param>
        public ProductRateService(IEventPublisher eventPublisher, IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager)
        {
            _productRateRepository = unitOfWork.Set<ProductRate>();
            _eventPublisher = eventPublisher;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(ProductRateSearchRequest request)
        {
            return await QueryByRequest(request).CountAsync();
        }


        public async Task CreateByViewModelAsync(ProductRateCreateViewModel viewModel)
        {
            if (viewModel.ProductId != null)
            {
                var isRated = await IsRatedCurrentUserByProductAsync(viewModel.ProductId.Value);
                if (isRated)
                    throw new JsonValidationException("شما قبلا رای خود را داده اید");
            }

            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var productRate = _mapper.Map<ProductRate>(viewModel);
            productRate.CreatedById = _webContextManager.CurrentUserId;
            _productRateRepository.Add(productRate);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(productRate);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<decimal> GetRateByProductIdAsync(Guid productId)
        {
            var ratesSum = await _productRateRepository
                .AsNoTracking()
                .Where(model => model.ProductId == productId)
                .SumAsync(model => (int?)model.Rate) ?? 0;

            var ratesCount = await _productRateRepository
                .AsNoTracking()
                .Where(model => model.ProductId == productId)
                .CountAsync();

            if (ratesCount == 0)
                return 0;

            return ratesSum.ToDecimal() / ratesCount.ToDecimal();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<int> GetUserCountByProductIdAsync(Guid productId)
        {
            var request = new ProductRateSearchRequest
            {
                ProductId = productId
            };

            return await QueryByRequest(request).CountAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<int> GetRateByCurrentUserAsync(Guid productId)
        {
            return (await _productRateRepository.AsNoTracking()
                .Where(model =>model.CreatedById == _webContextManager.CurrentUserId && model.ProductId == productId)
                .Select(model => model.Rate)
                .SingleOrDefaultAsync())
                .ToInt32();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<bool> IsRatedCurrentUserByProductAsync(Guid productId)
        {
            return await _productRateRepository
                .AsNoTracking()
                .AnyAsync(model => model.ProductId == productId && model.CreatedById == _webContextManager.CurrentUserId);
        }


        public IQueryable<ProductRate> QueryByRequest(ProductRateSearchRequest request)
        {
            var productRates = _productRateRepository.AsNoTracking().AsQueryable();

            if (request.CreatedById != null)
                productRates = productRates.Where(model => model.CreatedById == request.CreatedById);
            if (request.ProductId != null)
                productRates = productRates.Where(model => model.ProductId == request.ProductId);

            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Asc;

            productRates = productRates.OrderBy($"{request.SortMember} {request.SortDirection}");

            return productRates;
        }


        public async Task<decimal> RateByRequestAsync(ProductRateSearchRequest request)
        {
            var rates = await QueryByRequest(request).SumAsync(model => model.Rate.ToInt32());
            var counts = await QueryByRequest(request).CountAsync();
            var rate = rates / counts;

            return rate;
        }

        #endregion Public Methods
    }
}