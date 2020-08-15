using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Core.Domains.Products;
using Advertise.Core.Domains.Users;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.ProductLike;
using Advertise.Data.DbContexts;
using Advertise.Service.Managers.Events;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.WebContext;
using AutoMapper;

namespace Advertise.Service.Services.Products
{

    public class ProductLikeService : IProductLikeService
    {

        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<ProductLike> _productLikeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        ///   <summary>
        ///
        ///   </summary>
        ///   <param name="mapper"></param>
        ///   <param name="unitOfWork"></param>
        /// <param name="webContextManager"></param>
        public ProductLikeService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher)
        {
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _productLikeRepository = unitOfWork.Set<ProductLike>();
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<int> CountAllLikedByProductIdAsync(Guid productId)
        {
            var request = new ProductLikeSearchRequest
            {
                ProductId = productId,
                IsLike = true
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
            var request = new ProductLikeSearchRequest
            {
                PageSize = PageSize.All,
                ProductId = productId
            };
           return await CountByRequestAsync(request);
            
        }


        public async Task<List<ProductLikeViewModel>> GetByProductsAsync(List<Guid> productsId)
        {
            var listProductLike = await _productLikeRepository
                .Where(model => productsId.Contains((Guid)model.ProductId) && model.IsLike == true)
                .Distinct()
                .ToListAsync();
           return  _mapper.Map<List<ProductLikeViewModel>>(listProductLike);
        }


        public async Task<int> CountByRequestAsync(ProductLikeSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

           return await  QueryByRequest(request).CountAsync();
            }


        public async Task  CreateByViewModelAsync(ProductLikeCreateViewModel viewModel)
        {
            var productLike = _mapper.Map<ProductLike>(viewModel);
            productLike.LikedById = _webContextManager.CurrentUserId;
            _productLikeRepository.Add(productLike);

         await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityInserted(productLike);
        }

        public async Task RemoveRangeByproductLikesAsync(IList<ProductLike> productLikes)
        {
            if (productLikes == null)
                throw new ArgumentNullException(nameof(productLikes));

            foreach (var productLike in productLikes)
                _productLikeRepository.Remove(productLike);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productLikeId"></param>
        /// <returns></returns>
        public async Task  DeleteByIdAsync(Guid productLikeId)
        {
            var productLike = await _productLikeRepository.FirstOrDefaultAsync(model => model.Id == productLikeId);
            _productLikeRepository.Remove(productLike);

             await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityDeleted(productLike);

        }


        public async Task  EditByViewModelAsync(ProductLikeEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var productLike = await _productLikeRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, productLike);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityUpdated(productLike);

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productLikeId"></param>
        /// <returns></returns>
        public async Task<ProductLike> FindByIdAsync(Guid productLikeId)
        {
           return  await _productLikeRepository
                .FirstOrDefaultAsync(model => model.Id == productLikeId);
        }

        ///  <summary>
        /// 
        ///  </summary>
        /// <param name="productId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ProductLike> FindByProductIdAsync( Guid productId, Guid? userId =null)
        {
            var query = _productLikeRepository.AsQueryable();
            query = query.Where(model => model.ProductId == productId);

            if (userId.HasValue)
                query = query.Where(model => model.LikedById == userId);

            return await query.FirstOrDefaultAsync();
        }


        public async Task<IList<ProductLike>> GetByRequestAsync(ProductLikeSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return  await QueryByRequest(request).ToPagedListAsync(request);
            
        }


        public async Task<List<Guid>> GetMostLikedProductIdAsync()
        {
            var mostLikeds = await _productLikeRepository
                .AsNoTracking()
                .GroupBy(model => model.ProductId)
                .Select(model => new
                {
                    Id = model.Key.ToString(),
                    Count = model.Count()
                })
                .OrderByDescending(model => model.Count)
                .Take(15)
                .ToListAsync();
            return mostLikeds.Select(model => new Guid(model.Id)).ToList();
            
        }

        /// <summary>
        /// لیست آی دی افرادی که این دسته را فالو کرده اند
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<IList<User>> GetUsersByProductAsync(Guid productId)
        {
         return  await _productLikeRepository
                .Include(model => model.LikedById)
                .AsNoTracking()
                .Where(model => model.ProductId == productId && model.IsLike == true)
                .Select(model => model.LikedBy)
                .ToListAsync();
            
        }

        /// <summary>
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<bool> IsLikeCurrentUserByProductIdAsync(Guid productId)
        {
           return  await _productLikeRepository
                .AsNoTracking()
                .AnyAsync(model => model.ProductId == productId && model.LikedById == _webContextManager.CurrentUserId && model.IsLike == true);
            
        }

        /// <summary>
        /// به محض ورود کاربر به جزئیات هر دسته فالو یا عدم فالو نشان داده شود
        /// </summary>
        /// <param name="userId">   </param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<bool> IsLikeByProductIdAsync(Guid productId, Guid userId)
        {
           return  await _productLikeRepository
                .AsNoTracking()
                .AnyAsync(model => model.ProductId == productId && model.LikedById == userId && model.IsLike.GetValueOrDefault());
            }


        public IQueryable<ProductLike> QueryByRequest(ProductLikeSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var productLikes = _productLikeRepository.AsNoTracking().AsQueryable()
                .Include(model => model.LikedBy)
                .Include(model => model.LikedBy.Meta)
                .Include(model => model.Product)
                .Distinct();
            if (request.CompanyId.HasValue)
                productLikes = productLikes.Where(model => model.Product.CompanyId == request.CompanyId);
            if (request.ProductId.HasValue)
                productLikes = productLikes.Where(model => model.ProductId == request.ProductId);
            if (request.LikedById.HasValue)
                productLikes = productLikes.Where(model => model.LikedById == request.LikedById);
            if (request.IsLike.HasValue)
                productLikes = productLikes.Where(model => model.IsLike == request.IsLike);

            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;

            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            productLikes = productLikes.OrderBy($"{request.SortMember} {request.SortDirection}");

            return productLikes;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="productLikes"></param>
        /// <returns></returns>
        public async Task  RemoveRangeAsync(IList<ProductLike> productLikes)
        {
            if (productLikes == null)
                throw new ArgumentNullException(nameof(productLikes));

            foreach (var productLike in productLikes)
                _productLikeRepository.Remove(productLike);
        }


        public async Task  SeedAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task ToggleCurrentUserByProductIdAsync(Guid productId)
        {
            var productLike = await FindByProductIdAsync(productId, _webContextManager.CurrentUserId);
            if (productLike != null)
            {
                productLike.IsLike = !productLike.IsLike.GetValueOrDefault();

                await _unitOfWork.SaveAllChangesAsync();
                _eventPublisher.EntityUpdated(productLike);
            }

            else
            {
                var newProductLike = new ProductLike
                {
                    ProductId = productId,
                    IsLike = true,
                    LikedById = _webContextManager.CurrentUserId
                };
                _productLikeRepository.Add(newProductLike);

                await _unitOfWork.SaveAllChangesAsync();
                _eventPublisher.EntityInserted(newProductLike);

            }

        }

        #endregion Public Methods

    }
}