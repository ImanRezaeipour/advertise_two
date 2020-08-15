using Advertise.Core.Domains.Products;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.ProductNotify;
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

    public class ProductNotifyService : IProductNotifyService
    {
        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<ProductNotify> _productNotifyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        /// <param name="eventPublisher"></param>
        public ProductNotifyService(IUnitOfWork unitOfWork, IMapper mapper, IEventPublisher eventPublisher, IWebContextManager webContextManager)
        {
            _unitOfWork = unitOfWork;
            _productNotifyRepository = unitOfWork.Set<ProductNotify>();
            _mapper = mapper;
            _eventPublisher = eventPublisher;
            _webContextManager = webContextManager;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(ProductNotifySearchRequest request)
        {
            return await QueryByRequest(request).CountAsync();
        }


        public async Task CreateByViewModelAsync(ProductNotifyViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var productNotify = _mapper.Map<ProductNotify>(viewModel);
            productNotify.CreatedById = _webContextManager.CurrentUserId;
            _productNotifyRepository.Add(productNotify);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(productNotify);
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="productId"></param>
        /// <param name="applyCurrentUser"></param>
        /// <returns></returns>
        public async Task DeleteByProductIdAsync(Guid productId, bool? applyCurrentUser = false)
        {
            if (productId == null)
                throw new ArgumentNullException(nameof(productId));

            var productNotify = await FindByProductIdAync(productId, applyCurrentUser);
            _productNotifyRepository.Remove(productNotify);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(productNotify);
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="productId"></param>
        /// <param name="applyCurrentUser"></param>
        /// <returns></returns>
        public async Task<ProductNotify> FindByProductIdAync(Guid productId, bool? applyCurrentUser = false)
        {
            var productNotifyQuery = _productNotifyRepository.AsQueryable();
            if (applyCurrentUser == true)
                productNotifyQuery = productNotifyQuery.Where(model => model.CreatedById == _webContextManager.CurrentUserId);

            return await productNotifyQuery.FirstOrDefaultAsync(model => model.ProductId == productId);
        }

        /// <summary>
        /// لیست همه کاربران گوش به زنگ برای تغییرات محصول
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<IList<Guid?>> GetUsersByProductIdAsync(Guid productId)
        {
            if (productId == null)
                throw new ArgumentNullException(nameof(productId));

            return await _productNotifyRepository
                  .AsNoTracking()
                  .Where(model => model.ProductId == productId)
                  .Select(model => model.CreatedById)
                  .ToListAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> IsExistAsync(Guid productId, Guid userId)
        {
            return await _productNotifyRepository.AnyAsync(model => model.ProductId == productId && model.CreatedById == userId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="applyCurrentUser"></param>
        /// <returns></returns>
        public async Task<bool> IsExistByProductIdAsync(Guid productId, bool? applyCurrentUser)
        {
            var query = _productNotifyRepository.AsQueryable();
            if (applyCurrentUser == true)
                query = query.Where(model => model.CreatedById == _webContextManager.CurrentUserId);
            return await query.AnyAsync(model => model.ProductId == productId);
        }


        public IQueryable<ProductNotify> QueryByRequest(ProductNotifySearchRequest request)
        {
            var productNotifies = _productNotifyRepository.AsNoTracking().AsQueryable();

            if (request.CreatedById != null)
                productNotifies = productNotifies.Where(model => model.CreatedById == request.CreatedById);
            if (request.ProductId != null)
                productNotifies = productNotifies.Where(model => model.ProductId == request.ProductId);

            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Asc;

            productNotifies = productNotifies.OrderBy($"{request.SortMember} {request.SortDirection}");

            return productNotifies;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task ToggleByProductIdAsync(Guid productId)
        {
            var isExistNotify = await IsExistByProductIdAsync(productId, true);
            if (isExistNotify)
            {
                await DeleteByProductIdAsync(productId, true);
            }
            else
            {
                var viewModel = new ProductNotifyViewModel
                {
                    ProductId = productId
                };
                await CreateByViewModelAsync(viewModel);
            }
        }

        #endregion Public Methods
    }
}