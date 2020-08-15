using Advertise.Core.Domains.Categories;
using Advertise.Core.Extensions;
using Advertise.Core.Models.CategoryReview;
using Advertise.Core.Models.Common;
using Advertise.Data.DbContexts;
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
using Advertise.Service.Services.WebContext;
using Advertise.Service.Validators.Categories;

namespace Advertise.Service.Services.Categories
{
    /// <summary>
    /// </summary>
    public class CategoryReviewService : ICategoryReviewService
    {

        #region Private Fields

        private readonly IDbSet<CategoryReview> _categoryReviewRepository;
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
        /// <param name="eventPublisher"></param>
        public CategoryReviewService(IMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher, IWebContextManager webContextManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
            _webContextManager = webContextManager;
            _categoryReviewRepository = unitOfWork.Set<CategoryReview>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(CategoryReviewSearchRequest request)
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
        [Validation(typeof(CategoryReviewCreateValidator),"Create")]
        public async Task CreateByViewModelAsync(CategoryReviewCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentException(nameof(viewModel));

            var categoryReview = _mapper.Map<CategoryReview>(viewModel);
            categoryReview.Body = categoryReview.Body.ToSafeHtml();
            categoryReview.IsActive = true;
            categoryReview.CreatedById = _webContextManager.CurrentUserId;
            categoryReview.CreatedOn = DateTime.Now;
            _categoryReviewRepository.Add(categoryReview);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(categoryReview);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryReviewId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid categoryReviewId)
        {
            var categoryReview = await _categoryReviewRepository.FirstOrDefaultAsync(model => model.Id == categoryReviewId);
            _categoryReviewRepository.Remove(categoryReview);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(categoryReview);
        }


        [Validation(typeof(CategoryReviewEditValidator),"Edit")]
        public async Task EditByViewModelAsync(CategoryReviewEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var categoryReview = await _categoryReviewRepository.AsNoTracking().FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, categoryReview);
            categoryReview.Body = categoryReview.Body.ToSafeHtml();
            categoryReview.CategoryId = viewModel.CategoryId;

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(categoryReview);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryReviewId"></param>
        /// <returns></returns>
        public async Task<CategoryReview> FindByIdAsync(Guid categoryReviewId)
        {
            return await _categoryReviewRepository
                  .FirstOrDefaultAsync(model => model.Id == categoryReviewId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<IList<CategoryReview>> GetByCategoryIdAsync(Guid categoryId)
        {
            return await _categoryReviewRepository
                .AsNoTracking()
                .Where(model => model.CategoryId == categoryId && model.IsActive.Value)
                .ToListAsync();
        }


        public async Task<IList<CategoryReview>> GetByRequestAsync(CategoryReviewSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IQueryable<CategoryReview> QueryByRequest(CategoryReviewSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var categoryReviews = _categoryReviewRepository.AsNoTracking().AsQueryable()
                .Include(model => model.CreatedBy)
                .Include(model => model.CreatedBy.Meta)
                .Include(model => model.Category);
            if (request.Term.HasValue())
                categoryReviews = categoryReviews.Where(model => model.Title.Contains(request.Term) || model.Body.Contains(request.Term));
            if (request.IsActive.HasValue)
                if (request.IsActive.Value.ToString() != "-1")
                    categoryReviews = categoryReviews.Where(model => model.IsActive == request.IsActive);
            if (request.CreatedById.HasValue)
                categoryReviews = categoryReviews.Where(model => model.CreatedById == request.CreatedById);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            categoryReviews = categoryReviews.OrderBy($"{request.SortMember} {request.SortDirection}");

            return categoryReviews;
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