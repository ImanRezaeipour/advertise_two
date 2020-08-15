using Advertise.Core.Domains.Specifications;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.SpecificationOption;
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
using Advertise.Service.Validators.Specifications;

namespace Advertise.Service.Services.Specifications
{
    /// <summary>
    /// </summary>
    public class SpecificationOptionService : ISpecificationOptionService
    {

        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<SpecificationOption> _specificationOptionRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="eventPublisher"></param>
        public SpecificationOptionService(IMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
            _specificationOptionRepository = unitOfWork.Set<SpecificationOption>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(SpecificationOptionSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }
        

        [Validation(typeof(SpecificationOptionCreateValidator), "Edit")]
        public async Task CreateByViewModelAsync(SpecificationOptionCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var specificationOptions = _mapper.Map<List<SpecificationOption>>(viewModel.Options);
            foreach (var option in specificationOptions)
            {
                option.SpecificationId = viewModel.SpecificationId;
            }

            foreach (var specificationOption in specificationOptions)
                _specificationOptionRepository.Add(specificationOption);

            await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="specificationOptionId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid specificationOptionId)
        {
            var specificationOption = await _specificationOptionRepository.FirstOrDefaultAsync(model => model.Id == specificationOptionId);
            _specificationOptionRepository.Remove(specificationOption);

            await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(SpecificationOptionEditValidator), "Edit")]
        public async Task EditByViewModelAsync(SpecificationOptionEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var specificationOption = await _specificationOptionRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, specificationOption);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityUpdated(specificationOption);
        }

        /// <summary>
        /// </summary>
        /// <param name="specificationOptionId"></param>
        /// <returns></returns>
        public async Task<SpecificationOption> FindByIdAsync(Guid specificationOptionId)
        {
            return await _specificationOptionRepository
                .FirstOrDefaultAsync(model => model.Id == specificationOptionId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="specificationOptionId"></param>
        /// <returns></returns>
        public async Task<SpecificationOption> FindWithCategoryAsync(Guid specificationOptionId)
        {
            return await _specificationOptionRepository
                .Include(cat => cat.Specification.Category)
                .FirstOrDefaultAsync(model => model.Id == specificationOptionId);
        }


        public async Task<IList<SpecificationOption>> GetByRequestAsync(SpecificationOptionSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specificationOptionTitle"></param>
        /// <param name="specificationId"></param>
        /// <returns></returns>
        public async Task<Guid?> GetIdByTitleAsync(string specificationOptionTitle, Guid specificationId)
        {
            return await _specificationOptionRepository.AsNoTracking()
                .Where(model => model.Title == specificationOptionTitle && model.SpecificationId == specificationId)
                .Select(model => model.Id)
                .SingleOrDefaultAsync();
        }

        public Guid? GetIdByTitle(string specificationOptionTitle, Guid specificationId)
        {
            return  _specificationOptionRepository.AsNoTracking()
                .Where(model => model.Title == specificationOptionTitle && model.SpecificationId == specificationId)
                .Select(model => model.Id)
                .SingleOrDefault();
        }

        /// <summary>
        /// </summary>
        /// <param name="specificationId"></param>
        /// <returns></returns>
        public async Task<IList<SpecificationOption>> GetSpecificationOptionsBySpecificationIdAsync(Guid specificationId)
        {
            return await _specificationOptionRepository
                .AsNoTracking()
                .Where(model => model.SpecificationId == specificationId)
                .ToListAsync();
        }

        public async Task<IList<SelectListItem>> GetAsSelectListBySpecificationIdAsync(Guid specificationId)
        {
            return await _specificationOptionRepository.AsNoTracking()
                .Where(model => model.SpecificationId == specificationId)
                .Select(model => new SelectListItem
                {
                    Text = model.Title,
                    Value = model.Id.ToString()
                })
                .ToListAsync();
        }

        /// <summary>
        /// </summary>
        /// <param name="specificationId"></param>
        /// <returns></returns>
        public async Task<IList<SpecificationOptionViewModel>> GetViewModelBySpecificationIdAsync(Guid specificationId)
        {
            var specificationOptions = await _specificationOptionRepository
                .AsNoTracking()
                .Where(model => model.SpecificationId == specificationId)
                .ToListAsync();

            return _mapper.Map<List<SpecificationOptionViewModel>>(specificationOptions);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IQueryable<SpecificationOption> QueryByRequest(SpecificationOptionSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var specificationOptions = _specificationOptionRepository.AsNoTracking().AsQueryable()
                .Include(model => model.Specification);
            if (request.SpecificationId.HasValue)
                specificationOptions = specificationOptions.Where(model => model.SpecificationId == request.SpecificationId);
            if (request.Term.HasValue())
                specificationOptions = specificationOptions.Where(model => model.Description.Contains(request.Term) || model.Title.Contains(request.Term));
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            specificationOptions = specificationOptions.OrderBy($"{request.SortMember} {request.SortDirection}");

            return specificationOptions;
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