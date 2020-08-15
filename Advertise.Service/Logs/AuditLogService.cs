using Advertise.Core.Domains.Logs;
using Advertise.Core.Extensions;
using Advertise.Core.Models.AuditLog;
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

namespace Advertise.Service.Services.Logs
{

    public class AuditLogService : IAuditLogService
    {
        #region Private Fields

        private readonly IDbSet<AuditLog> _auditLogRepository;
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
        public AuditLogService(IMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher, IWebContextManager webContextManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
            _webContextManager = webContextManager;
            _auditLogRepository = unitOfWork.Set<AuditLog>();
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(AuditLogSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }

        /// <summary>
        ///ایجاد دسته
        /// </summary>
        /// <param name="viewModel"></param>
        public async Task CreateByViewModelAsync(AuditLogCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentException(nameof(viewModel));

            var auditLog = _mapper.Map<AuditLog>(viewModel);
            auditLog.CreatedById = _webContextManager.CurrentUserId;
            _auditLogRepository.Add(auditLog);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(auditLog);
        }

        /// <summary>
        /// </summary>
        /// <param name="auditLogId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid auditLogId)
        {
            var auditLog = await _auditLogRepository.FirstOrDefaultAsync(model => model.Id == auditLogId);
            _auditLogRepository.Remove(auditLog);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(auditLog);
        }


        public async Task EditByViewModelAsync(AuditLogEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var auditLog = await _auditLogRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, auditLog);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(auditLog);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="auditLogId"></param>
        /// <returns></returns>
        public async Task<AuditLog> FindByIdAsync(Guid auditLogId)
        {
            return await _auditLogRepository
                  .FirstOrDefaultAsync(model => model.Id == auditLogId);
        }


        public async Task<IList<AuditLog>> GetByRequestAsync(AuditLogSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }


        public async Task<AuditLogListViewModel> ListByRequestAsync(AuditLogSearchRequest request)
        {
            request.TotalCount = await CountByRequestAsync(request);
            var auditLogs = await GetByRequestAsync(request);
            var auditLogsViewModel = _mapper.Map<IList<AuditLogViewModel>>(auditLogs);
            return new AuditLogListViewModel
            {
                SearchRequest = request,
                AuditLogs = auditLogsViewModel
            };
        }


        public IQueryable<AuditLog> QueryByRequest(AuditLogSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var auditLogs = _auditLogRepository.AsNoTracking().AsQueryable();
            if (request.CreatedById.HasValue)
                auditLogs = auditLogs.Where(model => model.CreatedById == request.CreatedById);
            auditLogs = auditLogs.OrderBy($"{request.SortMember} {request.SortDirection}");

            return auditLogs;
        }


        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}