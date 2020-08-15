using Advertise.Core.Domains.Companies;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyRate;
using Advertise.Data.DbContexts;
using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Managers.Events;
using Advertise.Service.Services.WebContext;

namespace Advertise.Service.Services.Companies
{

    public class CompanyRateService : ICompanyRateService
    {
        #region Private Fields

        private readonly IDbSet<CompanyRate> _companyRateRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
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
        public CompanyRateService(IUnitOfWork unitOfWork, IMapper mapper, IEventPublisher eventPublisher, IWebContextManager webContextManager)
        {
            _unitOfWork = unitOfWork;
            _companyRateRepository = unitOfWork.Set<CompanyRate>();
            _mapper = mapper;
            _eventPublisher = eventPublisher;
            _webContextManager = webContextManager;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(CompanyRateSearchRequest request)
        {
            var count = await QueryByRequest(request).CountAsync();

            return count;
        }


        public async Task CreateByViewModelAsync(CompanyRateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var companyRate = _mapper.Map<CompanyRate>(viewModel);
            companyRate.CreatedById = _webContextManager.CurrentUserId;
            _companyRateRepository.Add(companyRate);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(companyRate);
        }


        public IQueryable<CompanyRate> QueryByRequest(CompanyRateSearchRequest request)
        {
            var companyRates = _companyRateRepository.AsNoTracking().AsQueryable();

            if (request.CreatedById != null)
                companyRates = companyRates.Where(model => model.CreatedById == request.CreatedById);
            if (request.CompanyId != null)
                companyRates = companyRates.Where(model => model.CompanyId == request.CompanyId);

            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Asc;

            companyRates = companyRates.OrderBy($"{request.SortMember} {request.SortDirection}");

            return companyRates;
        }


        public async Task<decimal> RateByRequestAsync(CompanyRateSearchRequest request)
        {
            var rates = await QueryByRequest(request).SumAsync(model => model.Rate.ToInt32());
            var counts = await QueryByRequest(request).CountAsync();
            var rate = rates / counts;

            return rate;
        }

        #endregion Public Methods
    }
}