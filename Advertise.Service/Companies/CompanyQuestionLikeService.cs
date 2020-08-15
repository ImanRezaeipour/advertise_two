using Advertise.Core.Domains.Companies;
using Advertise.Core.Domains.Users;
using Advertise.Core.Extensions;
using Advertise.Core.Models.CompanyQuestionLike;
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

    public class CompanyQuestionLikeService : ICompanyQuestionLikeService
    {

        #region Private Fields

        private readonly IDbSet<CompanyQuestionLike> _companyQuestionLikeRepository;
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
        public CompanyQuestionLikeService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _companyQuestionLikeRepository = unitOfWork.Set<CompanyQuestionLike>();
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<int> CountByRequestAsync(CompanyQuestionLikeSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companyQuestionLikes = await QueryByRequest(request).CountAsync();

            return companyQuestionLikes;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<CompanyQuestionLike> FindAsync(Guid companyId, Guid userId)
        {
            var companyQuestionLike = await _companyQuestionLikeRepository
                .FirstOrDefaultAsync(model => model.QuestionId == companyId && model.LikedById == userId);

            return companyQuestionLike;
        }


        public async Task<IList<CompanyQuestionLike>> GetByRequestAsync(CompanyQuestionLikeSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companyQuestionLikes = await QueryByRequest(request).ToPagedListAsync(request);

            return companyQuestionLikes;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public async Task<IList<User>> GetUsersByCompanyIdAsync(Guid questionId)
        {
            var users = await _companyQuestionLikeRepository
                .AsNoTracking()
                .Include(model => model.LikedById)
                .Where(model => model.QuestionId == questionId && model.IsLike.GetValueOrDefault())
                .Select(model => model.LikedBy)
                .ToListAsync();

            return users;
        }

        /// <summary>
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public async Task<bool> IsLikeByCurrentUserAsync(Guid questionId)
        {
            var isLike = await _companyQuestionLikeRepository
                .AsNoTracking()
                .AnyAsync(model => model.QuestionId == questionId && model.LikedById == _webContextManager.CurrentUserId && model.IsLike.GetValueOrDefault());

            return isLike;
        }

        /// <summary>
        /// به محض ورود کاربر به جزئیات هر دسته فالو یا عدم فالو نشان داده شود
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="userId">    </param>
        /// <returns></returns>
        public async Task<bool> IsLikeByUserIdAsync(Guid questionId, Guid userId)
        {
            var isLike = await _companyQuestionLikeRepository
                .AsNoTracking()
                .AnyAsync(model => model.QuestionId == questionId && model.LikedById == userId && model.IsLike.GetValueOrDefault());

            return isLike;
        }


        public async Task<CompanyQuestionLikeListViewModel> ListByRequestAsync(CompanyQuestionLikeSearchRequest request)
        {
            request.TotalCount = await CountByRequestAsync(request);
            var companyQuestionLikes = await GetByRequestAsync(request);
            var companyQuestionLikeViewModel = _mapper.Map<IList<CompanyQuestionLikeViewModel>>(companyQuestionLikes);
            var companyQuestionLikeList = new CompanyQuestionLikeListViewModel
            {
                SearchRequest = request,
                CompanyQuestionLikes = companyQuestionLikeViewModel
            };

            return companyQuestionLikeList;
        }


        public IQueryable<CompanyQuestionLike> QueryByRequest(CompanyQuestionLikeSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companyQuestionLikes = _companyQuestionLikeRepository.AsNoTracking().AsQueryable()
                .Include(model => model.LikedBy)
                .Include(model => model.Question);
            if (request.QuestionId.HasValue)
                companyQuestionLikes = companyQuestionLikes.Where(model => model.QuestionId == request.QuestionId);
            if (request.LikedById.HasValue)
                companyQuestionLikes = companyQuestionLikes.Where(model => model.LikedById == request.LikedById);
            companyQuestionLikes = companyQuestionLikes.OrderBy($"{request.SortMember} {request.SortDirection}");

            return companyQuestionLikes;
        }

        ///  <summary>
        ///
        ///  </summary>
        /// <param name="companyQuestionLikes"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync(IList<CompanyQuestionLike> companyQuestionLikes)
        {
            if (companyQuestionLikes == null)
                throw new ArgumentNullException(nameof(companyQuestionLikes));

            foreach (var companyQuestionLike in companyQuestionLikes)
                _companyQuestionLikeRepository.Remove(companyQuestionLike);
        }


        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="isLike"></param>
        /// <returns></returns>
        public async Task SetIsLikeByCurrentUserAsync(Guid questionId, bool isLike)
        {
            var companyQuestionLike = await _companyQuestionLikeRepository
                .FirstOrDefaultAsync(model => model.QuestionId == questionId && model.LikedById == _webContextManager.CurrentUserId);
            companyQuestionLike.IsLike = isLike;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="questionId"></param>
        /// <returns></returns>
        public async Task ToggleLikeByCurrentUserAsync(Guid questionId)
        {
            var companyQuestionLike = await FindAsync(questionId, _webContextManager.CurrentUserId);
            if (companyQuestionLike != null)
            {
                await SetIsLikeByCurrentUserAsync(questionId, !companyQuestionLike.IsLike.GetValueOrDefault());

                await _unitOfWork.SaveAllChangesAsync();

                _eventPublisher.EntityUpdated(companyQuestionLike);
            }

            var newCompanyQuestionLike = new CompanyQuestionLike()
            {
                QuestionId = questionId,
                IsLike = true,
                LikedById = _webContextManager.CurrentUserId
            };
            _companyQuestionLikeRepository.Add(newCompanyQuestionLike);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(newCompanyQuestionLike);
        }

        #endregion Public Methods

    }
}