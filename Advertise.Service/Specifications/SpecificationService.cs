using Advertise.Core.Domains.Specifications;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Specification;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.Categories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Managers.Events;
using Advertise.Service.Validators.Specifications;
using Specification = Advertise.Core.Domains.Specifications.Specification;

namespace Advertise.Service.Services.Specifications
{
    /// <summary>
    /// </summary>
    public class SpecificationService : ISpecificationService
    {

        #region Private Fields

        private readonly ICategoryService _categoryService;
        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<Specification> _specificationRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="eventPublisher"></param>
        /// <param name="categoryService"></param>
        public SpecificationService(IMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher, ICategoryService categoryService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
            _categoryService = categoryService;
            _specificationRepository = unitOfWork.Set<Specification>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(SpecificationSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await (await QueryByRequest(request)).CountAsync();
        }


        [Validation(typeof(SpecificationCreateValidator), "Create")]
        public async Task CreateByViewModelAsync(SpecificationCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var specification = _mapper.Map<Specification>(viewModel);
            specification.CreatedOn = DateTime.Now;

            if (viewModel.Options == null)
                specification.Options.Clear();
            else
            {
                specification.Options.Clear();
                specification.Options = new HashSet<SpecificationOption>();
                var specificationOptions = _mapper.Map<List<SpecificationOption>>(viewModel.Options);
                foreach (var specificationOption in specificationOptions)
                {
                    specificationOption.CreatedOn = DateTime.Now;
                    specification.Options.Add(specificationOption);
                }
            }

            _specificationRepository.Add(specification);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(specification);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="specificationId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid specificationId)
        {
            var specification = await FindByIdAsync(specificationId);
            _specificationRepository.Remove(specification);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(specification);
        }

        /// <summary>
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(SpecificationEditValidator), "Edit")]
        public async Task EditByViewModelAsync(SpecificationEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var specification = await FindByIdAsync(viewModel.Id);
            _mapper.Map(viewModel, specification);

            specification.CategoryId = viewModel.CategoryId;

            if (viewModel.Options == null)
                specification.Options.Clear();
            else
            {
                specification.Options.Clear();
                //specification.Options = new HashSet<SpecificationOption>();
                var specificationOptions = _mapper.Map<List<SpecificationOption>>(viewModel.Options);
                foreach (var specificationOption in specificationOptions)
                {
                    specification.Options.Add(specificationOption);
                }
            }

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(specification);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="specificationId"></param>
        /// <returns></returns>
        public async Task<Specification> FindByIdAsync(Guid specificationId)
        {
            return await _specificationRepository.FirstOrDefaultAsync(model => model.Id == specificationId);
        }

        /// <summary>
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<IList<SelectListItem>> GetAsSelectListItemAsync(Guid categoryId)
        {
            var specificationList = await GetByCategoryIdAsync(categoryId);
            return specificationList.Select(record => new SelectListItem
            {
                Text = record.Title,
                Value = record.Id.ToString()
            }).ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<IList<Specification>> GetByCategoryIdAsync(Guid categoryId)
        {
            var specificationRequest = new SpecificationSearchRequest
            {
                PageSize = PageSize.All,
                CategoryId = categoryId,
                WithParentCategory = true,
                SortMember = "Order",
                SortDirection = SortDirection.Asc
            };
            return await GetByRequestAsync(specificationRequest);
        }


        public async Task<IList<Specification>> GetByRequestAsync(SpecificationSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await (await QueryByRequest(request)).ToPagedListAsync(request);
        }

        public Guid? GetIdByTitle(string specificationTitle, Guid categoryId)
        {
            var result =   _specificationRepository.AsNoTracking()
                .Where(model => model.Title == specificationTitle && model.CategoryId == categoryId)
                .Select(model => model.Id).FirstOrDefault();

            return result == Guid.Empty ? (Guid?) null : result;
        }

        public async Task<List<string>> GetTitlesAsync()
        {
            return await  _specificationRepository.AsNoTracking().Select(record => record.Title).ToListAsync();
        }

        /// <summary>
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<object> GetObjectByCategoryAsync(Guid categoryId)
        {
            var specification = await _specificationRepository
                .AsNoTracking()
                .Where(model => model.CategoryId == categoryId)
                .ToListAsync();

            var viewModel = _mapper.Map<List<SpecificationViewModel>>(specification);

            return viewModel;
        }

        public async Task<IList<SpecificationViewModel>> GetViewModelByCategoryAliasAsync(string categoryAlias)
        {
            var category = await _categoryService.FindByAliasAsync(categoryAlias);
            var specification = await _specificationRepository
            .AsNoTracking()
            .Where(model => model.CategoryId == category.Id && model.IsSearchable == true)
            .ToListAsync();

            var viewModel = _mapper.Map<List<SpecificationViewModel>>(specification);

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IQueryable<Specification>> QueryByRequest(SpecificationSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var specifications = _specificationRepository.AsNoTracking().AsQueryable()
                .Include(model => model.Category)
                .Include(model => model.Options);

            if (request.CategoryId.HasValue && request.WithParentCategory != true)
                specifications = specifications.Where(model => model.CategoryId == request.CategoryId);
            if (request.CategoryId.HasValue && request.WithParentCategory == true)
            {
                var categoryParentIds = (await _categoryService.GetParentsByIdAsync(request.CategoryId.Value)).Select(model => model.Id);
                specifications = specifications.Where(model => categoryParentIds.Contains(model.CategoryId.Value));
            }
            if (request.Term.HasValue())
                specifications = specifications.Where(model => model.Title.Contains(request.Term) || model.Description.Contains(request.Term));

            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;

            specifications = specifications.OrderBy($"{request.SortMember} {request.SortDirection}");

            return specifications;
        }

        #endregion Public Methods
    }
}