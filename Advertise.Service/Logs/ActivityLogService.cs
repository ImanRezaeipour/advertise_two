using Advertise.Core.Domains.Logs;
using Advertise.Core.Extensions;
using Advertise.Core.Models.ActivityLog;
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

namespace Advertise.Service.Services.Logs
{

    public class ActivityLogService : IActivityLogService
    {

        #region Private Fields

        private readonly IDbSet<ActivityLog> _activityLogRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        ///  <summary>
        ///
        ///  </summary>
        ///  <param name="mapper"></param>
        ///  <param name="unitOfWork"></param>
        /// <param name="listManager"></param>
        /// <param name="webContextManager"></param>
        public ActivityLogService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _activityLogRepository = unitOfWork.Set<ActivityLog>();
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(ActivityLogSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }


        public async Task CreateByViewModelAsync(ActivityLogCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentException(nameof(viewModel));

            var activityLog = _mapper.Map<ActivityLog>(viewModel);
            activityLog.CreatedById = _webContextManager.CurrentUserId;
            _activityLogRepository.Add(activityLog);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(activityLog);
        }

        /// <summary>
        /// </summary>
        /// <param name="activityLogId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid activityLogId)
        {
            var activityLog = await _activityLogRepository.FirstOrDefaultAsync(model => model.Id == activityLogId);
            _activityLogRepository.Remove(activityLog);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(activityLog);
        }


        public async Task EditByViewModelAsync(ActivityLogEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var activityLog = await _activityLogRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, activityLog);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(activityLog);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="activityLogId"></param>
        /// <returns></returns>
        public async Task<ActivityLog> FindByIdAsync(Guid activityLogId)
        {
            return await _activityLogRepository
                  .FirstOrDefaultAsync(model => model.Id == activityLogId);
        }


        public async Task<IList<ActivityLog>> GetByRequestAsync(ActivityLogSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ActivityLogListViewModel> ListByRequestAsync(ActivityLogSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            if (isCurrentUser)
                request.CreatedById = _webContextManager.CurrentUserId;
            else if (userId != null)
                request.CreatedById = userId;
            else
                request.CreatedById = null;
            request.TotalCount = await CountByRequestAsync(request);
            var activityLogs = await GetByRequestAsync(request);
            var activityLogsViewModel = _mapper.Map<IList<ActivityLogViewModel>>(activityLogs);
            var activityLogsList = new ActivityLogListViewModel
            {
                SearchRequest = request,
                Activities = activityLogsViewModel
            };

            return activityLogsList;
        }


        public IQueryable<ActivityLog> QueryByRequest(ActivityLogSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var activityLogs = _activityLogRepository.AsNoTracking().AsQueryable();
            if (request.CreatedById.HasValue)
                activityLogs = activityLogs.Where(model => model.CreatedById == request.CreatedById);
            if (request.Term.HasValue())
                activityLogs = activityLogs.Where(model => model.Title.Contains(request.Term));
            activityLogs = activityLogs.OrderBy($"{request.SortMember} {request.SortDirection}");

            return activityLogs;
        }

        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods

    }
}