using Advertise.Core.Domains.Companies;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.CompanyReview;
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
using Advertise.Service.Managers.Html;
using Advertise.Service.Validators.Companies;

namespace Advertise.Service.Services.Companies
{
    /// <summary>
    /// </summary>
    public class CompanyReviewService : ICompanyReviewService
    {

        #region Private Fields

        private readonly IDbSet<Company> _companyRepository;
        private readonly IDbSet<CompanyReview> _companyReviewRepository;
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
        public CompanyReviewService(IMapper mapper, IUnitOfWork unitOfWork, IWebContextManager webContextManager, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _eventPublisher = eventPublisher;
            _companyRepository = unitOfWork.Set<Company>();
            _companyReviewRepository = unitOfWork.Set<CompanyReview>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(CompanyReviewSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
            }

        /// <summary>
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(CompanyReviewCreateValidator),"Create")]
        public async Task CreateByViewModelAsync(CompanyReviewCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentException(nameof(viewModel));

            var companyReview = _mapper.Map<CompanyReview>(viewModel);
            companyReview.Body = companyReview.Body.ToSafeHtml();
            companyReview.State = StateType.Pending;
            companyReview.CreatedOn = DateTime.Now;
            _companyReviewRepository.Add(companyReview);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(companyReview);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyReviewId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid companyReviewId)
        {
            var review = await _companyReviewRepository.FirstOrDefaultAsync(model => model.Id == companyReviewId);
            _companyReviewRepository.Remove(review);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(review);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(CompanyReviewEditValidator))]
        public async Task ApproveByViewModelAsync(CompanyReviewEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var companyReview = await EditAsync(viewModel);

            companyReview.ApprovedById = _webContextManager.CurrentUserId;
            companyReview.State = StateType.Approved;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(companyReview);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(CompanyReviewEditValidator),"Edit")]
        public async Task EditByViewModelAsync(CompanyReviewEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentException(nameof(viewModel));

            var companyReview = await EditAsync(viewModel);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(companyReview);
        }

        [Validation(typeof(CompanyReviewEditValidator), "Edit")]
        public async Task<CompanyReview> EditAsync(CompanyReviewEditViewModel viewModel)
        {
            var companyReview = await _companyReviewRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, companyReview);
            companyReview.Body = companyReview.Body.ToSafeHtml();
            return companyReview;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(CompanyReviewEditValidator), "Edit")]
        public async Task RejectByViewModelAsync(CompanyReviewEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var companyReview = await EditAsync(viewModel);
            companyReview.State = StateType.Rejected;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(companyReview);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyReviewId"></param>
        /// <returns></returns>
        public async Task<CompanyReview> FindByIdAsync(Guid companyReviewId)
        {
            return await _companyReviewRepository
                .FirstOrDefaultAsync(model => model.Id == companyReviewId);
            }


        public async Task<IList<CompanyReview>> GetByRequestAsync(CompanyReviewSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
            }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IList<SelectListItem>> GetCompanyAsSelectListItemAsync()
        {
            var list = await _companyRepository
                .AsNoTracking()
                .Where(model => model.State == StateType.Approved).ToListAsync();
           return  list.Select(item => new SelectListItem
            {
                Text = item.Title,
                Value = item.Id.ToString()
            }).ToList();
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public async Task<IList<CompanyReview>> GetByCompanyIdAsync(Guid companyId,StateType? state= null)
        {
            var request = new CompanyReviewSearchRequest
            {
                CompanyId = companyId,
                State = state
            };
            var list = await GetByRequestAsync(request);

            return list;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IQueryable<CompanyReview> QueryByRequest(CompanyReviewSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var companyReviews = _companyReviewRepository.AsNoTracking().AsQueryable()
                .Include(model => model.Company);
            if (request.CompanyId.HasValue)
                companyReviews = companyReviews.Where(model => model.CompanyId == request.CompanyId);
            if (request.State.HasValue)
                if (request.State != StateType.All)
                    companyReviews = companyReviews.Where(model => model.State == request.State);
            if (request.IsActive.HasValue)
                if (request.IsActive == false || request.IsActive == true)
                    companyReviews = companyReviews.Where(model => model.IsActive == request.IsActive);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            companyReviews = companyReviews.OrderBy($"{request.SortMember} {request.SortDirection}");

            return companyReviews;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyReviews"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync(IList<CompanyReview> companyReviews)
        {
            if (companyReviews == null)
                throw new ArgumentNullException(nameof(companyReviews));

            foreach (var companyReview in companyReviews)
                _companyReviewRepository.Remove(companyReview);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods

    }
}