using Advertise.Core.Domains.Products;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.ProductSpecification;
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

    public class ProductSpecificationService : IProductSpecificationService
    {
        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<ProductSpecification> _productSpecificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="eventPublisher"></param>
        public ProductSpecificationService(IMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
            _productSpecificationRepository = unitOfWork.Set<ProductSpecification>();
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(ProductSpecificationSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }


        public async Task CreateByViewModelAsync(ProductSpecificationCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var productSpecification = _mapper.Map<ProductSpecification>(viewModel);
            _productSpecificationRepository.Add(productSpecification);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(productSpecification);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productSpecId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid productSpecId)
        {
            var productSpec = await _productSpecificationRepository.FirstOrDefaultAsync(model => model.Id == productSpecId);
            _productSpecificationRepository.Remove(productSpec);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(productSpec);
        }


        public async Task EditByViewModelAsync(ProductSpecificationEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var productSpecification = await _productSpecificationRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, productSpecification);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityUpdated(productSpecification);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productSpecificationId"></param>
        /// <returns></returns>
        public async Task<ProductSpecification> FindByIdAsync(Guid productSpecificationId)
        {
            return await _productSpecificationRepository
                 .FirstOrDefaultAsync(model => model.Id == productSpecificationId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<IList<ProductSpecification>> GetByProductIdAsync(Guid productId)
        {
            var specificationRequest = new ProductSpecificationSearchRequest
            {
                SortDirection = SortDirection.Asc,
                SortMember = SortMember.CreatedOn,
                PageSize = PageSize.Count100,
                PageIndex = 1,
                ProductId = productId
            };
            return await GetByRequestAsync(specificationRequest);
        }


        public async Task<IList<ProductSpecification>> GetByRequestAsync(ProductSpecificationSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }


        public IQueryable<ProductSpecification> QueryByRequest(ProductSpecificationSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var productSpecifications = _productSpecificationRepository.AsNoTracking().AsQueryable()
                .Include(model => model.Product)
                .Include(model => model.Specification)
                .Include(model => model.SpecificationOption);
            if (request.ProductId.HasValue)
                productSpecifications = productSpecifications.Where(model => model.ProductId == request.ProductId);
               if (request.Term.HasValue())
                productSpecifications = productSpecifications.Where(model => model.Value.Contains(request.Term));
            productSpecifications = productSpecifications.OrderBy($"{request.SortMember ?? SortMember.CreatedOn} {request.SortDirection ?? SortDirection.Asc}");

            return productSpecifications;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productSpecifications"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync(IList<ProductSpecification> productSpecifications)
        {
            if (productSpecifications == null)
                throw new ArgumentNullException(nameof(productSpecifications));

            foreach (var productSpecification in productSpecifications)
                _productSpecificationRepository.Remove(productSpecification);
        }


        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}