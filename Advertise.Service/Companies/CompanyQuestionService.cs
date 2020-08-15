using Advertise.Core.Domains.Companies;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyQuestion;
using Advertise.Core.Types;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Managers.Events;
using Advertise.Service.Validators.Companies;

namespace Advertise.Service.Services.Companies
{
    /// <summary>
    /// </summary>
    public class CompanyQuestionService : ICompanyQuestionService
    {
        #region Private Fields

        private readonly IDbSet<CompanyQuestion> _companyQuestionRepository;
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
        /// <param name="webContextManager"></param>
        public CompanyQuestionService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _companyQuestionRepository = unitOfWork.Set<CompanyQuestion>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(CompanyQuestionEditValidator),"Edit")]
        public async Task ApproveByViewModelAsync(CompanyQuestionEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var companyQuestion = await FindByIdAsync(viewModel.Id);
            _mapper.Map(viewModel, companyQuestion);
            companyQuestion.ApprovedById = _webContextManager.CurrentUserId;
            companyQuestion.State = StateType.Approved;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(companyQuestion);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(CompanyQuestionSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(CompanyQuestionCreateValidator),"Create")]
        public async Task CreateByViewModelAsync(CompanyQuestionCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentException(nameof(viewModel));

            var companyQuestion = _mapper.Map<CompanyQuestion>(viewModel);
            companyQuestion.State = StateType.Pending;
            companyQuestion.CreatedById = _webContextManager.CurrentUserId;
            companyQuestion.CreatedOn = DateTime.Now;
           _companyQuestionRepository.Add(companyQuestion);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(companyQuestion);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyQuestionId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid companyQuestionId)
        {
            var companyQuestion = await FindByIdAsync(companyQuestionId);
            _companyQuestionRepository.Remove(companyQuestion);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(companyQuestion);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(CompanyQuestionEditValidator),"Edit")]
       public async Task EditByViewModelAsync(CompanyQuestionEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentException(nameof(viewModel));

            var companyQuestion = await FindByIdAsync(viewModel.Id);
            _mapper.Map(viewModel, companyQuestion);
            companyQuestion.ModifiedById = _webContextManager.CurrentUserId;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(companyQuestion);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyQuestionId"></param>
        /// <returns></returns>
        public async Task<CompanyQuestion> FindByIdAsync(Guid companyQuestionId)
        {
            return await _companyQuestionRepository
                .SingleOrDefaultAsync(question => question.Id == companyQuestionId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<IList<CompanyQuestion>> GetByCompanyIdAsync(Guid companyId)
        {
            return await _companyQuestionRepository.AsNoTracking()
                .Where(question => question.CompanyId == companyId)
                .ToListAsync();
        }


        public async Task<IList<CompanyQuestion>> GetByRequestAsync(CompanyQuestionSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        public async Task<IList<CompanyQuestion>> GetAllByCompanyIdAsync(Guid companyId)
        {
            var companies = await _companyQuestionRepository.AsNoTracking()
                .Where(model => model.State == StateType.Approved && model.CompanyId == companyId)
                .OrderByDescending(model => model.CreatedOn)
                .ToListAsync();

            var tempList = new List<CompanyQuestion>();
            foreach (var company in companies.Where(model => model.ReplyId == null))
            {
                tempList.Add(company);
                tempList.AddRange(companies.Where(model => model.ReplyId == company.Id));
                
            }
            return tempList;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IQueryable<CompanyQuestion> QueryByRequest(CompanyQuestionSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companyQuestions = _companyQuestionRepository.AsNoTracking().AsQueryable();

            if (request.CreatedById.HasValue)
                companyQuestions = companyQuestions.Where(model => model.CreatedById == request.CreatedById);
            if (request.State.HasValue)
                companyQuestions = companyQuestions.Where(model => model.State == request.State);
            if (request.CompanyId.HasValue)
                companyQuestions = companyQuestions.Where(model => model.CompanyId == request.CompanyId);

            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;

            companyQuestions = companyQuestions.OrderBy($"{request.SortMember} {request.SortDirection}");

            return companyQuestions;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(CompanyQuestionEditValidator),"Edit")]
        public async Task RejectByViewModelAsync(CompanyQuestionEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var companyQuestion = await FindByIdAsync(viewModel.Id);
            _mapper.Map(viewModel, companyQuestion);
            companyQuestion.State = StateType.Rejected;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(companyQuestion);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task RemoveRangeByCompanyId(Guid companyId)
        {
            var companyQuestions = await GetByCompanyIdAsync(companyId);
            foreach (var companyQuestion in companyQuestions)
                await DeleteByIdAsync(companyQuestion.Id);
        }

        #endregion Public Methods
    }
}