using Advertise.Core.Domains.Categories;
using Advertise.Core.Domains.Users;
using Advertise.Core.Extensions;
using Advertise.Core.Models.CategoryFollow;
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

namespace Advertise.Service.Services.Categories
{

    public class CategoryFollowService : ICategoryFollowService
    {

        #region Private Fields

        private readonly IDbSet<CategoryFollow> _categoryFollowRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
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
        public CategoryFollowService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _categoryFollowRepository = unitOfWork.Set<CategoryFollow>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<int> CountAllFollowByCategoryIdAsync(Guid categoryId)
        {
            var request = new CategoryFollowSearchRequest
            {
                CategoryId = categoryId,
                PageSize = PageSize.All,
                IsFollow = true
            };
            return await CountByRequestAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<int> CountByCategoryIdAsync(Guid categoryId)
        {
            return await _categoryFollowRepository
                .AsNoTracking()
                .CountAsync(model => model.CategoryId.GetValueOrDefault() == categoryId && model.IsFollow == true);
        }


        public async Task<int> CountByRequestAsync(CategoryFollowSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }

        /// <summary>
        /// تعداد فالوهایی کاربر
        /// </summary>
        /// <returns></returns>
        public async Task<int> CountByUserIdAsync(Guid userId)
        {
            return await _categoryFollowRepository
                 .AsNoTracking()
                 .CountAsync(model => model.FollowedById == userId && model.IsFollow == true);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<CategoryFollow> FindByCategoryIdAsync(Guid categoryId, Guid? userId = null)
        {
            return await _categoryFollowRepository
                 .FirstOrDefaultAsync(model => model.FollowedById == userId && model.CategoryId == categoryId && model.IsFollow == true);
        }


        public async Task<IList<CategoryFollow>> GetByRequestAsync(CategoryFollowSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var categoryFollows = await QueryByRequest(request).ToPagedListAsync(request);

            return categoryFollows;
        }

        /// <summary>
        /// لیست آی دی افرادی که این دسته را فالو کرده اند
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<IList<User>> GetUsersByCategoryIdAsync(Guid categoryId)
        {
            var users = await _categoryFollowRepository
                .AsNoTracking()
                .Include(model => model.FollowedBy)
                .Where(model => model.CategoryId == categoryId && model.IsFollow.Value).Select(model => model.FollowedBy)
                .ToListAsync();

            return users;
        }

        /// <summary>
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<bool> IsFollowCurrentUserByCategoryIdAsync(Guid categoryId)
        {
            return await _categoryFollowRepository
                .AsNoTracking()
                .AnyAsync(model => model.CategoryId == categoryId && model.FollowedById == _webContextManager.CurrentUserId);
        }

        /// <summary>
        /// به محض ورود کاربر به جزئیات هر دسته فالو یا عدم فالو نشان داده شود
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="userId">    </param>
        /// <returns></returns>
        public async Task<bool> IsFollowByCategoryIdAsync(Guid categoryId, Guid? userId = null)
        {
            return await _categoryFollowRepository
                .AsNoTracking()
                .AnyAsync(model => model.CategoryId == categoryId && model.FollowedById == userId && model.IsFollow == true);
        }


        public IQueryable<CategoryFollow> QueryByRequest(CategoryFollowSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var categoryFollows = _categoryFollowRepository.AsNoTracking().AsQueryable()
                .Include(model => model.FollowedBy)
                .Include(model => model.FollowedBy.Meta)
                .Include(model => model.Category);
            if (request.FollowedById.HasValue)
                categoryFollows = categoryFollows.Where(model => model.FollowedById == request.FollowedById);
            if (request.CategoryId.HasValue)
                categoryFollows = categoryFollows.Where(model => model.CategoryId == request.CategoryId);
            if (request.FollowedById.HasValue)
                categoryFollows = categoryFollows.Where(model => model.FollowedById == request.FollowedById);
            if (request.IsFollow.HasValue)
                categoryFollows = categoryFollows.Where(model => model.IsFollow == request.IsFollow);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            categoryFollows = categoryFollows.OrderBy($"{request.SortMember} {request.SortDirection}");

            return categoryFollows;
        }


        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task ToggleFollowCurrentUserByCategoryIdAsync(Guid categoryId)
        {
            var categoryFollow = await FindByCategoryIdAsync(categoryId, _webContextManager.CurrentUserId);
            if (categoryFollow != null)
            {
                categoryFollow.IsFollow = !categoryFollow.IsFollow;

                await _unitOfWork.SaveAllChangesAsync();

                _eventPublisher.EntityUpdated(categoryFollow);
            }
            else
            {
                var newCategoryfollow = new CategoryFollow
                {
                    CategoryId = categoryId,
                    IsFollow = true,
                    FollowedById = _webContextManager.CurrentUserId
                };
                _categoryFollowRepository.Add(newCategoryfollow);

                await _unitOfWork.SaveAllChangesAsync();

                _eventPublisher.EntityInserted(newCategoryfollow);
            }
        }

        #endregion Public Methods

    }
}