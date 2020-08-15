using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyVisit;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Core.Extensions;
using Advertise.Service.Managers.Events;

namespace Advertise.Service.Services.Companies
{

    public class CompanyVisitService : ICompanyVisitService
    {
        #region Private Fields

        private readonly IDbSet<CompanyVisit> _companyVisitRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;
        private readonly IEventPublisher _eventPublisher;

        #endregion Private Fields

        #region Public Constructors

        ///  <summary>
        ///
        ///  </summary>
        ///  <param name="mapper"></param>
        ///  <param name="unitOfWork"></param>
        /// <param name="webContextManager"></param>
        public CompanyVisitService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _companyVisitRepository = unitOfWork.Set<CompanyVisit>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<int> CountByCompanyIdAsync(Guid companyId)
        {
            if (companyId == null)
                throw new ArgumentException(nameof(companyId));

            var request = new CompanyVisitSearchRequest
            {
                CompanyId = companyId
            };
            var count = await CountByRequestAsync(request);

            return count;
        }


        public async Task<int> CountByRequestAsync(CompanyVisitSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companyVisites = await QueryByRequest(request).CountAsync();

            return companyVisites;
        }

        /// <summary>
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task  CreateByCompanyIdAsync(Guid companyId)
        {
            if (companyId == null)
                throw new ArgumentException(nameof(companyId));

            var companyVisit = new CompanyVisit
            {
                CompanyId = companyId,
                IsVisit = true,
                CreatedById = _webContextManager.CurrentUserId

            };
            _companyVisitRepository.Add(companyVisit);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(companyVisit);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyVisitId"></param>
        /// <returns></returns>
        public async Task<CompanyVisit> FindAsync(Guid companyVisitId)
        {
            var companyVisit = await _companyVisitRepository
                .FirstOrDefaultAsync(model => model.Id == companyVisitId);

            return companyVisit;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<CompanyVisit> FindByCompanyIdAsync(Guid companyId)
        {
            var companyVisit = await _companyVisitRepository
                .FirstOrDefaultAsync(model => model.CompanyId == companyId);

            return companyVisit;
        }


        public IQueryable<CompanyVisit> QueryByRequest(CompanyVisitSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companyVisites = _companyVisitRepository.AsNoTracking().AsQueryable();
            if (request.CreatedById.HasValue)
                companyVisites = companyVisites.Where(companyVisit => companyVisit.CreatedById == request.CreatedById);
            if (request.CompanyId.HasValue)
                companyVisites = companyVisites.Where(companyVisit => companyVisit.CompanyId == request.CompanyId);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            companyVisites = companyVisites.OrderBy($"{request.SortMember} {request.SortDirection}");

            return companyVisites;
        }


        public async Task<IList<CompanyVisit>> GetByRequestAsync(CompanyVisitSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companyVisites =  await QueryByRequest(request).ToPagedListAsync(request);
           
            return companyVisites;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<CompanyVisitListViewModel> ListByRequestAsync(CompanyVisitSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            if (isCurrentUser)
                request.CreatedById = _webContextManager.CurrentUserId;
            else if (userId != null)
                request.CreatedById = userId;
            else request.CreatedById = null;
            request.TotalCount = await CountByRequestAsync(request);
            var companyVisites = await GetByRequestAsync(request);
            var companyVisitesViewModel = _mapper.Map<IList<CompanyVisitViewModel>>(companyVisites);
            var listViewModel = new CompanyVisitListViewModel
            {
                SearchRequest = request,
                CompanyVisits = companyVisitesViewModel
            };

            return listViewModel;
        }


        public async Task  SeedAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods
    }
}