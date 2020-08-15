using Advertise.Core.Domains.Users;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.UserOnline;
using Advertise.Data.DbContexts;
using AutoMapper;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Managers.Events;

namespace Advertise.Service.Services.Users
{

    public class UserOnlineService : IUserOnlineService
    {
        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<UserOnline> _userOnlineRepository;

        #endregion Private Fields

        #region Public Constructors

        ///  <summary>
        ///
        ///  </summary>
        ///  <param name="unitOfWork"></param>
        ///  <param name="mapper"></param>
        /// <param name="eventPublisher"></param>
        public UserOnlineService(IUnitOfWork unitOfWork, IMapper mapper, IEventPublisher eventPublisher)
        {
            _unitOfWork = unitOfWork;
            _userOnlineRepository = unitOfWork.Set<UserOnline>();
            _mapper = mapper;
            _eventPublisher = eventPublisher;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountAllAsync()
        {
            var request = new UserOnlineSearchRequest
            {
                IsActive = true
            };
            return await CountByRequestAsync(request);
        }


        public async Task<int> CountByRequestAsync(UserOnlineSearchRequest request)
        {
            return await QueryByRequest(request).CountAsync();
        }


        public void CreateByViewModel(UserOnlineViewModel viewModel)
        {
            var userOnline = _mapper.Map<UserOnline>(viewModel);
            _userOnlineRepository.Add(userOnline);

            _unitOfWork.SaveAllChanges();

            _eventPublisher.EntityInserted(userOnline);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        public void DeleteBySessionId(string sessionId)
        {
            var userOnline = _userOnlineRepository.FirstOrDefault(model => model.SessionId == sessionId);
            _userOnlineRepository.Remove(userOnline);

            _unitOfWork.SaveAllChanges();

            _eventPublisher.EntityDeleted(userOnline);
        }


        public IQueryable<UserOnline> QueryByRequest(UserOnlineSearchRequest request)
        {
            var userOnlines = _userOnlineRepository.AsNoTracking().AsQueryable();

            if (request.CreatedById != null)
                userOnlines = userOnlines.Where(model => model.CreatedById == request.CreatedById);

            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Asc;

            userOnlines = userOnlines.OrderBy($"{request.SortMember} {request.SortDirection}");

            return userOnlines;
        }

        #endregion Public Methods
    }
}