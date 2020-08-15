using Advertise.Core.Domains.Products;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.ProductReview;
using Advertise.Core.Types;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Managers.Events;
using Advertise.Service.Managers.Html;
using Advertise.Service.Validators.Product;

namespace Advertise.Service.Services.Products
{
    /// <summary>
    /// </summary>
    public class ProductReviewService : IProductReviewService
    {
        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<Product> _productRepository;
        private readonly IDbSet<ProductReview> _productReviewRepository;
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
        public ProductReviewService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _productRepository = unitOfWork.Set<Product>();
            _productReviewRepository = unitOfWork.Set<ProductReview>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(ProductReviewSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }

        /// <summary>
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(ProductReviewCreateValidator),"Create")]
        public async Task CreateByViewModelAsync(ProductReviewCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var productReview = _mapper.Map<ProductReview>(viewModel);
            productReview.Body = productReview.Body.ToSafeHtml();
            productReview.CreatedById = _webContextManager.CurrentUserId;
            _productReviewRepository.Add(productReview);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityInserted(productReview);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productReviewId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid productReviewId)
        {
            var productReview = await _productReviewRepository.FirstOrDefaultAsync(model => model.Id == productReviewId);
            _productReviewRepository.Remove(productReview);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityDeleted(productReview);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(ProductReviewEditValidator),"Edit")]
        public async Task EditApproveByViewModelAsync(ProductReviewEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var productReview = await _productReviewRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            productReview.ApprovedById = _webContextManager.CurrentUserId;
            productReview.State = StateType.Approved;
            _mapper.Map(viewModel, productReview);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityUpdated(productReview);
        }

        /// <summary>
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(ProductReviewEditValidator), "Edit")]
        public async Task EditByViewModelAsync(ProductReviewEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var productReview = await _productReviewRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            var companyMap = _mapper.Map(viewModel, productReview);
            companyMap.Body = companyMap.Body.ToSafeHtml();

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityUpdated(productReview);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(ProductReviewEditValidator), "Edit")]
        public async Task EditRejectByViewModelAsync(ProductReviewEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var productReview = await _productReviewRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            productReview.State = StateType.Rejected;
            _mapper.Map(viewModel, productReview);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityUpdated(productReview);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productReviewId"></param>
        /// <returns></returns>
        public async Task<ProductReview> FindByIdAsync(Guid productReviewId)
        {
            if (productReviewId == null)
                throw new ArgumentNullException(nameof(productReviewId));

            return await _productReviewRepository
                    .FirstOrDefaultAsync(model => model.Id == productReviewId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<IList<ProductReview>> GetByProductIdAsync(Guid productId)
        {
            var request = new ProductReviewSearchRequest
            {
                ProductId = productId
            };
            return await GetByRequestAsync(request);
        }


        public async Task<IList<ProductReview>> GetByRequestAsync(ProductReviewSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IList<SelectListItem>> GetProductIdAsync()
        {
            var list = await _productRepository
                .AsNoTracking()
                .Where(model => model.State == StateType.All)
                .ToListAsync();

            return list.Select(item => new SelectListItem
            {
                Text = item.Title,
                Value = item.Id.ToString()
            }).ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IQueryable<ProductReview> QueryByRequest(ProductReviewSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var productReviews = _productReviewRepository.AsNoTracking().AsQueryable()
                .Include(model => model.CreatedBy)
                .Include(model => model.CreatedBy.Meta)
                .Include(model => model.Product);
            if (request.ProductId.HasValue)
                productReviews = productReviews.Where(model => model.ProductId == request.ProductId);
            if (request.ProductCode.HasValue())
                productReviews = productReviews.Where(model => model.Product.Code == request.ProductCode);
            if (request.Term.HasValue())
                productReviews = productReviews.Where(model => model.Body.Contains(request.Term));
            if (request.IsActive.HasValue)
                productReviews = productReviews.Where(model => model.IsActive == request.IsActive);
            if (request.State.HasValue)
                productReviews = productReviews.Where(model => model.State == request.State);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            productReviews = productReviews.OrderBy($"{request.SortMember} {request.SortDirection}");

            return productReviews;
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="productReviews"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync(IList<ProductReview> productReviews)
        {
            if (productReviews == null)
                throw new ArgumentNullException(nameof(productReviews));

            foreach (var productReview in productReviews)
                _productReviewRepository.Remove(productReview);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}