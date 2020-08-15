using Advertise.Core.Domains.Products;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.ProductFeature;
using Advertise.Data.DbContexts;
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

    public class ProductFeatureService : IProductFeatureService
    {
        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<ProductFeature> _productFeatureRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="eventPublisher"></param>
        public ProductFeatureService(IMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
            _productFeatureRepository = unitOfWork.Set<ProductFeature>();
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(ProductFeatureSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }


        public async Task CreateByViewModelAsync(ProductFeatureCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var productFeature = _mapper.Map<ProductFeature>(viewModel);
            _productFeatureRepository.Add(productFeature);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityInserted(productFeature);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productFeatureId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid productFeatureId)
        {
            if (productFeatureId == null)
                throw new ArgumentNullException(nameof(productFeatureId));

            var productFeature = await _productFeatureRepository.FirstOrDefaultAsync(model => model.Id == productFeatureId);
            _productFeatureRepository.Remove(productFeature);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(productFeature);
        }


        public async Task EditByViewModelAsync(ProductFeatureEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var productFeature = await _productFeatureRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, productFeature);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityUpdated(productFeature);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productFeatureId"></param>
        /// <returns></returns>
        public async Task<ProductFeature> FindByIdAsync(Guid productFeatureId)
        {
            if (productFeatureId == null)
                throw new ArgumentNullException(nameof(productFeatureId));

            return await _productFeatureRepository
                 .FirstOrDefaultAsync(model => model.Id == productFeatureId);
        }


        public async Task<IList<ProductFeature>> GetByRequestAsync(ProductFeatureSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }


        public async Task<ProductFeatureListViewModel> ListByRequestAsync(ProductFeatureSearchRequest request)
        {
            request.TotalCount = await CountByRequestAsync(request);
            var productComments = await GetByRequestAsync(request);
            var productCommentViewModel = _mapper.Map<IList<ProductFeatureViewModel>>(productComments);
            return new ProductFeatureListViewModel
            {
                SearchRequest = request,
                ProductFeatures = productCommentViewModel
            };
        }


        public IQueryable<ProductFeature> QueryByRequest(ProductFeatureSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var productFeatures = _productFeatureRepository.AsNoTracking().AsQueryable();
            if (request.ProductId.HasValue)
                productFeatures = productFeatures.Where(model => model.ProductId == request.ProductId);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            productFeatures = productFeatures.OrderBy($"{request.SortMember} {request.SortDirection}");

            return productFeatures;
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="productFeatures"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync(IList<ProductFeature> productFeatures)
        {
            if (productFeatures == null)
                throw new ArgumentNullException(nameof(productFeatures));

            foreach (var productFeature in productFeatures)
                _productFeatureRepository.Remove(productFeature);
        }


        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}