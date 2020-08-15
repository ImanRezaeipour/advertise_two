using Advertise.Core.Domains.Companies;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyBalance;
using Advertise.Data.DbContexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Managers.Events;
using Advertise.Service.Managers.File;
using Advertise.Service.Services.WebContext;
using Advertise.Service.Validators.Companies;
using FineUploaderObject = Advertise.Core.Objects.FineUploaderObject;

namespace Advertise.Service.Services.Companies
{
    /// <summary>
    ///
    /// </summary>
    public class CompanyBalanceService : ICompanyBalanceService
    {
        #region Private Fields

        private readonly IDbSet<CompanyBalance> _companyBalanceRepository;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        ///  <summary>
        ///
        ///  </summary>
        ///  <param name="unitOfWork"></param>
        ///  <param name="mapper"></param>
        /// <param name="eventPublisher"></param>
        public CompanyBalanceService(IUnitOfWork unitOfWork, IMapper mapper, IEventPublisher eventPublisher, IWebContextManager webContextManager)
        {
            _unitOfWork = unitOfWork;
            _companyBalanceRepository = unitOfWork.Set<CompanyBalance>();
            _mapper = mapper;
            _eventPublisher = eventPublisher;
            _webContextManager = webContextManager;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(CompanyBalanceSearchRequest request)
        {
            return await QueryByRequest(request).CountAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(CompanyBalanceCreateValidator),"Create")]
        public async Task CreateByViewModelAsync(CompanyBalanceCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var companyBalance = _mapper.Map<CompanyBalance>(viewModel);
            companyBalance.CreatedById = _webContextManager.CurrentUserId;
            _companyBalanceRepository.Add(companyBalance);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(companyBalance);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyBalanceId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid companyBalanceId)
        {
            var companyBalance = await _companyBalanceRepository.FirstOrDefaultAsync(model => model.Id == companyBalanceId);
            _companyBalanceRepository.Remove(companyBalance);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(companyBalance);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(CompanyBalanceEditValidator),"Edit")]
        public async Task EditByViewModelAsync(CompanyBalanceEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var companyBalance = await _companyBalanceRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, companyBalance);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(companyBalance);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyBalanceId"></param>
        /// <returns></returns>
        public async Task<CompanyBalance> FindByIdAsync(Guid companyBalanceId)
        {
            return await _companyBalanceRepository.FirstOrDefaultAsync(model => model.Id == companyBalanceId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IList<CompanyBalance>> GetByRequestAsync(CompanyBalanceSearchRequest request)
        {
            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyBalanceId"></param>
        /// <returns></returns>
        public async Task<IList<FineUploaderObject>> GetFileAsFineUploaderModelByIdAsync(Guid companyBalanceId)
        {
            return (await _companyBalanceRepository.AsNoTracking()
                    .Where(model => model.Id == companyBalanceId)
                    .Select(model => new
                    {
                        model.Id,
                        model.AttachmentFile
                    }).ToListAsync())
                .Select(model => new FineUploaderObject
                {
                    id = model.Id.ToString(),
                    uuid = model.Id.ToString(),
                    name = model.AttachmentFile,
                    thumbnailUrl = FileConst.ImagesWebPath.PlusWord(model.AttachmentFile),
                    size = new FileInfo(HttpContext.Current.Server.MapPath(FileConst.ImagesWebPath.PlusWord(model.AttachmentFile))).Length.ToString()
                }).ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IQueryable<CompanyBalance> QueryByRequest(CompanyBalanceSearchRequest request)
        {
            var companyBalances = _companyBalanceRepository.AsNoTracking().AsQueryable();

            if (request.CreatedOn != null)
                companyBalances = companyBalances.Where(model => model.CreatedOn == request.CreatedOn);
            if (request.CompanyId.HasValue)
                companyBalances = companyBalances.Where(model => model.CompanyId == request.CompanyId);
            if (request.Term.HasValue())
                companyBalances = companyBalances.Where(model => model.Depositor .Contains(request.Term)|| model.Description.Contains(request.Term) || model.DocumentNumber.Contains(request.Term) || model.IssueTracking.Contains(request.Term) );
            if (request.CreatedById.HasValue)
                companyBalances = companyBalances.Where(model => model.CreatedById == request.CreatedById);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Asc;

            companyBalances = companyBalances.OrderBy($"{request.SortMember} {request.SortDirection}");

            return companyBalances;
        }

        #endregion Public Methods
    }
}