using Advertise.Core.Domains.Companies;
using Advertise.Core.Domains.Users;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyFollow;
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

namespace Advertise.Service.Services.Companies
{

    public class CompanyFollowService : ICompanyFollowService
    {

        #region Private Fields

        private readonly IDbSet<CompanyFollow> _companyFollowRepository;
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
        public CompanyFollowService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _companyFollowRepository = unitOfWork.Set<CompanyFollow>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<int> CountAllFollowByCompanyIdAsync(Guid companyId)
        {
            var request = new CompanyFollowSearchRequest
            {
                CompanyId = companyId,
            };
            var result = await CountByRequestAsync(request);

            return result;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="comapnyId"></param>
        /// <returns></returns>
        public async Task<int> CountAsync(Guid comapnyId)
        {
            var request = new CompanyFollowSearchRequest
            {
                IsFollow = true,
                PageSize = PageSize.All,
                CompanyId = comapnyId
            };
            var count = await CountByRequestAsync(request);

            return count;
        }


        public async Task<int> CountByRequestAsync(CompanyFollowSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companyFollows = QueryByRequest(request);
            var companyFollowsCount = await companyFollows.CountAsync();

            return companyFollowsCount;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyFollowId"></param>
        /// <returns></returns>
        public async Task<CompanyFollow> FindAsync(Guid companyFollowId)
        {
            var companyFollow = await _companyFollowRepository
                .FirstOrDefaultAsync(model => model.Id == companyFollowId);

            return companyFollow;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<CompanyFollow> FindByCompanyIdAsync(Guid userId, Guid companyId)
        {
            var companyLike = await _companyFollowRepository
                .FirstOrDefaultAsync(model => model.FollowedById == userId && model.CompanyId == companyId);

            return companyLike;
        }


        public async Task<CompanyFollow> FindByUserIdAsync(Guid userId)
        {
            var companyLike = await _companyFollowRepository
                .FirstOrDefaultAsync(model => model.FollowedById == userId);

            return companyLike;
        }


        public async Task<IList<CompanyFollow>> GetByRequestAsync(CompanyFollowSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companyFollows = await QueryByRequest(request).ToPagedListAsync(request);

            return companyFollows;
        }

        /// <summary>
        /// لیست آی دی افرادی که این دسته را فالو کرده اند
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<IList<User>> GetUsersByCompanyIdAsync(Guid companyId)
        {
            var users = await _companyFollowRepository
                .AsNoTracking()
                .Include(model => model.FollowedBy)
                .Where(model => model.CompanyId == companyId && model.IsFollow == true)
                .Select(model => model.FollowedBy)
                .ToListAsync();

            return users;
        }

        /// <summary>
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<bool> IsFollowByCurrentUserAsync(Guid companyId)
        {
            var isFollow = await _companyFollowRepository
                .AsNoTracking()
                .AnyAsync(model => model.CompanyId == companyId && model.FollowedById == _webContextManager.CurrentUserId);

            return isFollow;
        }

        /// <summary>
        /// به محض ورود کاربر به جزئیات هر دسته فالو یا عدم فالو نشان داده شود
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="userId">    </param>
        /// <returns></returns>
        public async Task<bool> IsFollowByUserIdAsync(Guid companyId, Guid userId)
        {
            var isFollow = await _companyFollowRepository
                .AsNoTracking()
                .AnyAsync(model => model.CompanyId == companyId && model.FollowedById == userId && model.IsFollow == true);

            return isFollow;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<CompanyFollowListViewModel> ListByRequestAsync(CompanyFollowSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            if (isCurrentUser)
                request.FollowedById = _webContextManager.CurrentUserId;
            else if (userId != null)
                request.FollowedById = userId;
            else
                request.FollowedById = null;
            request.TotalCount = await CountByRequestAsync(request);
            var companyFollows = await GetByRequestAsync(request);
            var companyFollowViewModel = _mapper.Map<IList<CompanyFollowViewModel>>(companyFollows);
            var companyFollowList = new CompanyFollowListViewModel
            {
                SearchRequest = request,
                CompanyFollows = companyFollowViewModel
            };

            return companyFollowList;
        }


        public IQueryable<CompanyFollow> QueryByRequest(CompanyFollowSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companyFollows = _companyFollowRepository.AsNoTracking().AsQueryable()
                .Include(model => model.FollowedBy)
                .Include(model => model.FollowedBy.Meta)
                .Include(model => model.Company);
            if (request.CompanyId.HasValue)
                companyFollows = companyFollows.Where(model => model.CompanyId == request.CompanyId);
            if (request.FollowedById.HasValue)
                companyFollows = companyFollows.Where(model => model.FollowedById == request.FollowedById);
            if (request.IsFollow.HasValue)
                companyFollows = companyFollows.Where(model => model.IsFollow == request.IsFollow);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            companyFollows = companyFollows.OrderBy($"{request.SortMember} {request.SortDirection}");

            return companyFollows;
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="companyFollows"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync(IList<CompanyFollow> companyFollows)
        {
            if (companyFollows == null)
                throw new ArgumentNullException(nameof(companyFollows));

            foreach (var companyFollow in companyFollows)
                _companyFollowRepository.Remove(companyFollow);
        }


        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task ToggleFollowCurrentUserByCompanyIdAsync(Guid companyId)
        {
            var companyFollow = await FindByCompanyIdAsync(_webContextManager.CurrentUserId, companyId);
            if (companyFollow != null)
            {
                companyFollow.IsFollow = companyFollow.IsFollow != null && !companyFollow.IsFollow.Value;

                await _unitOfWork.SaveAllChangesAsync();

                _eventPublisher.EntityUpdated(companyFollow);
            }
            else
            {
                var newcompanyfollow = new CompanyFollow
                {
                    CompanyId = companyId,
                    IsFollow = true,
                    FollowedById = _webContextManager.CurrentUserId
                };
                _companyFollowRepository.Add(newcompanyfollow);

                await _unitOfWork.SaveAllChangesAsync();

                _eventPublisher.EntityInserted(newcompanyfollow);
            }
        }

        #endregion Public Methods

    }
}