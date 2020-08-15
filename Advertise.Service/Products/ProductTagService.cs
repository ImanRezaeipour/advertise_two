using Advertise.Core.Domains.Products;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.ProductTag;
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

    public class ProductTagService : IProductTagService
    {
        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<ProductTag> _productTagRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="eventPublisher"></param>
        public ProductTagService(IMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
            _productTagRepository = unitOfWork.Set<ProductTag>();
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
            var request = new ProductTagSearchRequest
            {
                ProductId = productId,
                SortDirection = SortDirection.Desc,
                SortMember = SortMember.CreatedOn,
                PageSize = PageSize.Count10,
            };
            return await CountByRequestAsync(request);
        }


        public async Task<int> CountByRequestAsync(ProductTagSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }


        public async Task CreateByViewModelAsync(ProductTagCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var productTag = _mapper.Map<ProductTag>(viewModel);
            _productTagRepository.Add(productTag);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(productTag);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productTagId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid productTagId)
        {
            var productTag = await _productTagRepository.FirstOrDefaultAsync(model => model.Id == productTagId);
            _productTagRepository.Remove(productTag);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityDeleted(productTag);
        }


        public async Task EditByViewModelAsync(ProductTagEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var productTag = await _productTagRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, productTag);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityUpdated(productTag);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productTagId"></param>
        /// <returns></returns>
        public async Task<ProductTag> FindByIdAsync(Guid productTagId)
        {
            return await _productTagRepository
                 .FirstOrDefaultAsync(model => model.Id == productTagId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<IList<ProductTag>> GetByProductIdAsync(Guid productId)
        {
            var requestTag = new ProductTagSearchRequest
            {
                SortDirection = SortDirection.Desc,
                SortMember = SortMember.CreatedOn,
                ProductId = productId,
                PageSize = PageSize.Count10,
                PageIndex = 1
            };
            return await GetByRequestAsync(requestTag);
        }


        public async Task<IList<ProductTag>> GetByRequestAsync(ProductTagSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<ProductTagListViewModel> GetTagsByProductIdAsync(Guid productId)
        {
            var request = new ProductTagSearchRequest
            {
                ProductId = productId
            };
            return await ListByRequestAsync(request);
        }


        public async Task<ProductTagListViewModel> ListByRequestAsync(ProductTagSearchRequest request)
        {
            request.TotalCount = await CountByRequestAsync(request);
            var productTags = await GetByRequestAsync(request);
            var productTagViewModel = _mapper.Map<IList<ProductTagViewModel>>(productTags);
            return new ProductTagListViewModel
            {
                SearchRequest = request,
                ProductTags = productTagViewModel
            };
        }


        public IQueryable<ProductTag> QueryByRequest(ProductTagSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var productTags = _productTagRepository.AsNoTracking().AsQueryable();
            if (request.ProductId.HasValue)
                productTags = productTags.Where(model => model.ProductId == request.ProductId);
           if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            productTags = productTags.OrderBy($"{request.SortMember} {request.SortDirection}");

            return productTags;
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="productTags"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync(IList<ProductTag> productTags)
        {
            if (productTags == null)
                throw new ArgumentNullException(nameof(productTags));

            foreach (var productTag in productTags)
                _productTagRepository.Remove(productTag);
        }


        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}