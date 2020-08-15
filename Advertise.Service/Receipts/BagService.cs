using Advertise.Core.Domains.Bags;
using Advertise.Core.Exceptions;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Bag;
using Advertise.Core.Models.Common;
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

namespace Advertise.Service.Services.Receipts
{

    public class BagService : IBagService
    {

        #region Private Fields

        private readonly IDbSet<Bag> _bagRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        ///   <summary>
        ///
        ///   </summary>
        ///   <param name="mapper"></param>
        ///   <param name="unitOfWork"></param>
        ///  <param name="webContextManager"></param>
        /// <param name="eventPublisher"></param>
        public BagService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _bagRepository = unitOfWork.Set<Bag>();
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByCurrentUserAsync()
        {
            var request = new BagSearchRequest
            {
                SortDirection = SortDirection.Desc,
                PageSize = PageSize.Count100,
                CreatedById = _webContextManager.CurrentUserId
            };
            return await CountByRequestAsync(request);
        }


        public async Task<int> CountByRequestAsync(BagSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task CreateByIdAsync(Guid productId) 
        {
            var isBagExist = await FindByProductIdAsync(productId, _webContextManager.CurrentUserId);
            if (isBagExist == null)
            {

                var bag = new Bag
                {
                    ProductCount = 1,
                    ProductId = productId,
                    CreatedById = _webContextManager.CurrentUserId,
                    CreatedOn = DateTime.Now

                };
                _bagRepository.Add(bag);

                await _unitOfWork.SaveAllChangesAsync();

                _eventPublisher.EntityInserted(bag);
            }
        }


        public async Task DeleteByCurrentUserAsync()
        {
            var request = new BagSearchRequest
            {
                CreatedById = _webContextManager.CurrentUserId
            };
            var bags = await GetByRequestAsync(request);
            foreach (var bag in bags)
            {
                _bagRepository.Attach(bag);
                _bagRepository.Remove(bag);


                _eventPublisher.EntityDeleted(bag);
            }
            await _unitOfWork.SaveAllChangesAsync();

        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="bagId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid bagId)
        {
            if (bagId == null)
                throw new ArgumentNullException(nameof(bagId));

            var bag = await FindByIdAsync(bagId);
            _bagRepository.Remove(bag);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(bag);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task DeleteByProductIdAsync(Guid productId)
        {
            if (productId == null)
                throw new ArgumentNullException(nameof(productId));

            var bag = await FindByProductIdAsync(productId, _webContextManager.CurrentUserId);
            _bagRepository.Remove(bag);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(bag);
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="bagId"></param>
        /// <returns></returns>
        public async Task<Bag> FindByIdAsync(Guid bagId)
        {
            return await _bagRepository.SingleOrDefaultAsync(model => model.Id == bagId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<Bag> FindByProductIdAsync(Guid productId, Guid userId)
        {
            return await _bagRepository
                .FirstOrDefaultAsync(model => model.CreatedById == userId && model.ProductId == productId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Bag> FindByUserIdAsync(Guid userId)
        {
            if (userId == null)
                throw new ArgumentNullException(nameof(userId));

            return await _bagRepository.FirstOrDefaultAsync(model => model.CreatedById == userId);
        }


        public async Task<IList<Bag>> GetByRequestAsync(BagSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IList<Bag>> GetByUserIdAsync(Guid userId)
        {
            var request = new BagSearchRequest
            {
                PageSize = PageSize.Count100,
                SortMember = SortMember.ModifiedOn,
                CreatedById = _webContextManager.CurrentUserId
            };
            return await GetByRequestAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<bool> IsExistByProductIdAsync(Guid productId, Guid? userId = null)
        {
            var query = _bagRepository.AsNoTracking()
                .Where(model => model.ProductId == productId);
            if (userId != null)
                query = query.Where(model => model.CreatedById == userId);
            return await query.AnyAsync();
        }


        public IQueryable<Bag> QueryByRequest(BagSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var bags = _bagRepository.AsNoTracking().AsQueryable();

            if (request.CreatedById.HasValue)
                bags = bags.Where(model => model.CreatedById == request.CreatedById);
            if (request.Term.HasValue())
                bags = bags.Where(model => model.CreatedById == request.CreatedById);

            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;

            bags = bags.OrderBy($"{request.SortMember} {request.SortDirection}");

            return bags;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="bags"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync(IList<Bag> bags)
        {
            if (bags == null)
                throw new ArgumentNullException(nameof(bags));

            foreach (var bag in bags)
            {
                _bagRepository.Remove(bag);

                await _unitOfWork.SaveAllChangesAsync();

                _eventPublisher.EntityDeleted(bag);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productCount"></param>
        /// <returns></returns>
        public async Task SetProductCountByIdAsync(Guid productId, int productCount)
        {
            var bag = await FindByProductIdAsync(productId, _webContextManager.CurrentUserId);
            bag.ProductCount = productCount;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(bag);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task ToggleByCurrentUserAsync(Guid productId)
        {
            var bag = await FindByProductIdAsync(productId, _webContextManager.CurrentUserId);
            if (bag == null)
            {
                var newBag = new Bag
                {
                    ProductId = productId,
                    CreatedById = _webContextManager.CurrentUserId
                };
                _bagRepository.Add(newBag);

                await _unitOfWork.SaveAllChangesAsync();

                _eventPublisher.EntityInserted(newBag);
            }
            _bagRepository.Remove(bag);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(bag);
        }

        #endregion Public Methods

    }
}