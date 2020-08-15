using Advertise.Core.Domains.Users;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.UserViolation;
using Advertise.Data.DbContexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Managers.Events;
using Advertise.Service.Services.WebContext;

namespace Advertise.Service.Services.Users
{

    public class UserViolationService : IUserViolationService
    {

        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<UserViolation> _userViolationRepository;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        ///   <summary>
        ///
        ///   </summary>
        ///   <param name="mapper"></param>
        ///  <param name="unitOfWork"></param>
        /// <param name="eventPublisher"></param>
        public UserViolationService(IMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher, IWebContextManager webContextManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
            _webContextManager = webContextManager;
            _userViolationRepository = unitOfWork.Set<UserViolation>();
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(UserViolationSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }


        public async Task CreateByViewModelAsync(UserViolationCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var userViolation = _mapper.Map<UserViolation>(viewModel);
            userViolation.ReportedById = _webContextManager.CurrentUserId;
            userViolation.CreatedOn = DateTime.Now;
            _userViolationRepository.Add(userViolation);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(userViolation);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userViolationId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid userViolationId)
        {
            if (userViolationId == null)
                throw new ArgumentNullException(nameof(userViolationId));

            var userViolation = await FindByIdAsync(userViolationId);
            _userViolationRepository.Remove(userViolation);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(userViolation);
        }


        public async Task EditByViewModelAsync(UserViolationEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var userViolation = await FindByIdAsync(viewModel.Id);
            _mapper.Map(viewModel, userViolation);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(userViolation);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="userViolationId"></param>
        /// <returns></returns>
        public async Task<UserViolation> FindByIdAsync(Guid userViolationId)
        {
            return await _userViolationRepository.FirstOrDefaultAsync(model => model.Id == userViolationId);
        }


        public async Task<IList<UserViolation>> GetByRequestAsync(UserViolationSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }


        public IQueryable<UserViolation> QueryByRequest(UserViolationSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var userViolations = _userViolationRepository.AsNoTracking().AsQueryable();

            if (request.Term.HasValue())
                userViolations = userViolations.Where(model => model.ReasonDescription.Contains(request.Term));
            if (request.IsRead.HasValue)
                userViolations = userViolations.Where(model => model.IsRead == request.IsRead);
            if (request.ReasonType.HasValue)
                userViolations = userViolations.Where(model => model.Reason == request.ReasonType);
            if (request.ReportType.HasValue)
                userViolations = userViolations.Where(model => model.Type == request.ReportType);

            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;

            userViolations = userViolations.OrderBy($"{request.SortMember} {request.SortDirection}");

            return userViolations;
        }

        #endregion Public Methods

    }
}