using Advertise.Core.Domains.Products;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.ProductComment;
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
using Advertise.Service.Validators.Product;

namespace Advertise.Service.Services.Products
{
    /// <summary>
    /// </summary>
    public class ProductCommentService : IProductCommentService
    {
        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<ProductComment> _productCommentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="webContextManager"></param>
        public ProductCommentService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _productCommentRepository = unitOfWork.Set<ProductComment>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(ProductCommentEditValidator), "Edit")]
        public async Task EditApproveByViewModelAsync(ProductCommentEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var productComment = await FindByIdAsync(viewModel.Id);
            _mapper.Map(viewModel, productComment);
            productComment.State = StateType.Approved;
            productComment.ApprovedById = _webContextManager.CurrentUserId;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(productComment);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(ProductCommentSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }

        /// <summary>
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(ProductCommentCreateValidator),"Create")]
        public async Task CreateByViewModelAsync(ProductCommentCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var productComment = _mapper.Map<ProductComment>(viewModel);
            productComment.State = StateType.Pending;
            productComment.CreatedOn = DateTime.Now;
            productComment.CommentedById = _webContextManager.CurrentUserId;
            _productCommentRepository.Add(productComment);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityInserted(productComment);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productCommentId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid productCommentId, bool isCurrentUser = false)
        {
            if (productCommentId == null)
                throw new ArgumentNullException(nameof(productCommentId));

            var productComment = await FindByIdAsync(productCommentId);
            if(isCurrentUser)
                return;

            _productCommentRepository.Remove(productComment);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityDeleted(productComment);
        }

        /// <summary>
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(ProductCommentEditValidator), "Edit")]
        public async Task EditByViewModelAsync(ProductCommentEditViewModel viewModel, bool isCurrentUser = false)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var productComment = await _productCommentRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            if(isCurrentUser)
                return;

            _mapper.Map(viewModel, productComment);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityUpdated(productComment);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productCommentId"></param>
        /// <returns></returns>
        public async Task<ProductComment> FindByIdAsync(Guid productCommentId)
        {
            return await _productCommentRepository
                .FirstOrDefaultAsync(model => model.Id == productCommentId);
        }


        public async Task<IList<ProductComment>> GetByRequestAsync(ProductCommentSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ProductCommentListViewModel> ListByRequestAsync(ProductCommentSearchRequest request)
        {
            request.TotalCount = await CountByRequestAsync(request);
            var productComments = await GetByRequestAsync(request);
            var productCommentsViewModel = _mapper.Map<IList<ProductCommentViewModel>>(productComments);
            return new ProductCommentListViewModel
            {
                SearchRequest = request,
                ProductComments = productCommentsViewModel
            };
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IQueryable<ProductComment> QueryByRequest(ProductCommentSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var productComments = _productCommentRepository.AsNoTracking().AsQueryable()
                .Include(model => model.Product)
                .Include(model => model.Product.Company);
            if (request.State.HasValue)
                if (request.State != StateType.All)
                    productComments = productComments.Where(productComment => productComment.State == request.State);
            if (request.CommentedById.HasValue)
                productComments = productComments.Where(model => model.CommentedById == request.CommentedById);
            if (request.ProductId.HasValue)
                productComments = productComments.Where(model => model.ProductId == request.ProductId);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            productComments = productComments.OrderBy($"{request.SortMember} {request.SortDirection}");

            return productComments;
        }

        /// <summary>
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(ProductCommentEditValidator), "Edit")]
        public async Task EditRejectByViewModelAsync(ProductCommentEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var productComment = await FindByIdAsync(viewModel.Id);
            _mapper.Map(viewModel, productComment);
            productComment.State = StateType.Rejected;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(productComment);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productComments"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync(IList<ProductComment> productComments)
        {
            if (productComments == null)
                throw new ArgumentNullException(nameof(productComments));

            foreach (var productComment in productComments)
            {
                _productCommentRepository.Remove(productComment);
            }

            await _unitOfWork.SaveAllChangesAsync();
        }

        public async Task SetStateByIdAsync(Guid productCommentId, StateType state)
        {
            var productComment = await FindByIdAsync(productCommentId);
            productComment.State = state;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(productComment);
        }

        #endregion Public Methods
    }
}