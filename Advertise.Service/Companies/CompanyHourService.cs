using Advertise.Core.Domains.Companies;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyHour;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace Advertise.Service.Services.Companies
{

    public class CompanyHourService : ICompanyHourService
    {
        #region Private Fields

        private readonly IDbSet<Company> _companyRepository;
        private readonly IDbSet<CompanyHour> _companyHourRepository;
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
        public CompanyHourService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _companyRepository = unitOfWork.Set<Company>();
            _companyHourRepository = unitOfWork.Set<CompanyHour>();
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountByRequestAsync(CompanyHourSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companyHours = await QueryByRequest(request).CountAsync();

            return companyHours;
        }


        public async Task CreateByViewModelAsync(CompanyHourCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var Hour = _mapper.Map<CompanyHour>(viewModel);
            var company = await _companyRepository.FirstOrDefaultAsync(model => model.Id == _webContextManager.CurrentUserId);
            Hour.CompanyId = company.Id;
            Hour.CreatedById = _webContextManager.CurrentUserId;

            _companyHourRepository.Add(Hour);

            await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="HourId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid HourId)
        {
            var Hour = await _companyHourRepository.FirstOrDefaultAsync(model => model.Id == HourId);
            _companyHourRepository.Remove(Hour);

            await _unitOfWork.SaveAllChangesAsync();
        }


        public async Task EditByViewModelAsync(CompanyHourEditViewModel viewModel)
        {
            var companyId = _webContextManager.CurrentCompanyId;
            var companyHour1 = await _companyHourRepository.Where(model => model.CompanyId == companyId).ToListAsync();
            foreach (var item in companyHour1)
            {
                _companyHourRepository.Remove(item);
            }
            foreach (var item in viewModel.CompanyHours)
            {
                if (item.DayOfWeek != null)
                {
                    var companyHour = _mapper.Map<CompanyHour>(item);
                companyHour.CompanyId = _webContextManager.CurrentCompanyId;
                    companyHour.CreatedById = _webContextManager.CurrentUserId;
                _companyHourRepository.Add(companyHour);
                }
                
            }
            await _unitOfWork.SaveAllChangesAsync();
        }
    


    /// <param name="companyHourId"></param>
    /// <returns></returns>
    public async Task<CompanyHour> FindAsync(Guid companyHourId)
    {
        var companyHour = await _companyHourRepository
            .FirstOrDefaultAsync(model => model.Id == companyHourId);

        return companyHour;
    }


    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<CompanyHour> FindByUserIdAsync(Guid userId)
    {
        var companyHour = await _companyHourRepository
            .FirstOrDefaultAsync(model => model.CreatedById == userId);

        return companyHour;
    }


    /// <param name="request"></param>
    /// <returns></returns>
    public IQueryable<CompanyHour> QueryByRequest(CompanyHourSearchRequest request)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var companyHours = _companyHourRepository.AsNoTracking().AsQueryable()
            .Include(model => model.CreatedBy)
            .Include(model => model.CreatedBy.Meta)
            .Include(model => model.Company);
        if (request.CreatedById.HasValue)
            companyHours = companyHours.Where(model => model.CreatedById == request.CreatedById);
        if (request.CompanyId.HasValue)
            companyHours = companyHours.Where(model => model.CompanyId == request.CompanyId);
        if (string.IsNullOrEmpty(request.SortMember))
            request.SortMember = SortMember.CreatedOn;
        if (string.IsNullOrEmpty(request.SortDirection))
            request.SortDirection = SortDirection.Desc;
        companyHours = companyHours.OrderBy($"{request.SortMember} {request.SortDirection}");

        return companyHours;
    }


    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<IList<CompanyHour>> GetByRequestAsync(CompanyHourSearchRequest request)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var companyHours = await QueryByRequest(request).ToPagedListAsync(request);

        return companyHours;
    }


    /// <param name="companyHours"></param>
    /// <returns></returns>
    public async Task RemoveRangeAsync(IList<CompanyHour> companyHours)
    {
        if (companyHours == null)
            throw new ArgumentNullException(nameof(companyHours));

        foreach (var companyHour in companyHours)
            _companyHourRepository.Remove(companyHour);
    }


    /// <returns></returns>
    public async Task SeedAsync()
    {
        throw new NotImplementedException();
    }

    #endregion Public Methods
}
}