using Advertise.Core.Domains.Products;
using Advertise.Core.Domains.Users;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.ProductCommentLike;
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

    public class ProductCommentLikeService : IProductCommentLikeService
    {
        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<ProductCommentLike> _productCommentLikeRepository;
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
        public ProductCommentLikeService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _productCommentLikeRepository = unitOfWork.Set<ProductCommentLike>();
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(ProductCommentLikeSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productCommentId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ProductCommentLike> FindByIdAsync(Guid productCommentId, Guid userId)
        {
            return await _productCommentLikeRepository
                 .FirstOrDefaultAsync(model => model.CommentId == productCommentId && model.LikedById == userId);
        }


        public async Task<IList<ProductCommentLike>> GetByRequestAsync(ProductCommentLikeSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var productCommentLikes = await QueryByRequest(request).ToPagedListAsync(request);

            return productCommentLikes;
        }

        /// <summary>
        /// لیست آی دی افرادی که این دسته را فالو کرده اند
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public async Task<IList<User>> GetUsersByCompanyIdAsync(Guid questionId)
        {
            return await _productCommentLikeRepository
           .AsNoTracking()
           .Include(model => model.LikedById)
           .Where(model => model.CommentId == questionId && model.IsLike.GetValueOrDefault())
           .Select(model => model.LikedBy)
           .ToListAsync();
        }

        /// <summary>
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public async Task<bool> IsLikeCurrentUserByIdAsync(Guid productCommentId)
        {
            return await _productCommentLikeRepository
                 .AsNoTracking()
                 .AnyAsync(model => model.CommentId == productCommentId && model.LikedById == _webContextManager.CurrentUserId && model.IsLike.GetValueOrDefault());
        }


        public IQueryable<ProductCommentLike> QueryByRequest(ProductCommentLikeSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var productCommentLikes = _productCommentLikeRepository.AsNoTracking().AsQueryable()
                .Include(model => model.LikedBy)
                .Include(model => model.Comment);
            if (request.CommentId.HasValue)
                productCommentLikes = productCommentLikes.Where(model => model.CommentId == request.CommentId);
            if (request.LikedById.HasValue)
                productCommentLikes = productCommentLikes.Where(model => model.LikedById == request.LikedById);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            productCommentLikes = productCommentLikes.OrderBy($"{request.SortMember} {request.SortDirection}");

            return productCommentLikes;
        }


        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productCommentId"></param>
        /// <returns></returns>
        public async Task ToggleCurrentUserByIdAsync(Guid productCommentId)
        {
            var productCommentLike = await FindByIdAsync(productCommentId, _webContextManager.CurrentUserId);
            if (productCommentLike != null)
            {
                productCommentLike.IsLike = productCommentLike.IsLike != null && !productCommentLike.IsLike.Value;
                await _unitOfWork.SaveAllChangesAsync();
                _eventPublisher.EntityUpdated(productCommentLike);
            }

            var newProductCommentLike = new ProductCommentLike
            {
                CommentId = productCommentId,
                IsLike = true,
                LikedById = _webContextManager.CurrentUserId
            };
            _productCommentLikeRepository.Add(newProductCommentLike);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityInserted(newProductCommentLike);
        }

        #endregion Public Methods
    }
}