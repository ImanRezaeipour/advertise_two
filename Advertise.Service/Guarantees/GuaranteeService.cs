using Advertise.Core.Domains.Guarantees;
using Advertise.Core.Exceptions;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Guarantee;
using Advertise.Core.Objects;
using Advertise.Data.DbContexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Managers.Events;
using Advertise.Service.Services.Categories;
using Advertise.Service.Services.WebContext;

namespace Advertise.Service.Services.Guarantees
{

    public class GuaranteeService : IGuaranteeService
    {
        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IDbSet<Guarantee> _guaranteeRepository;
        private readonly ICategoryService _categoryService;
        private readonly IWebContextManager _webContextManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="eventPublisher"></param>
        /// <param name="mapper"></param>
        public GuaranteeService(IUnitOfWork unitOfWork, IEventPublisher eventPublisher, IMapper mapper, ICategoryService categoryService, IWebContextManager webContextManager)
        {
            _unitOfWork = unitOfWork;
            _guaranteeRepository = unitOfWork.Set<Guarantee>();
            _eventPublisher = eventPublisher;
            _mapper = mapper;
            _categoryService = categoryService;
            _webContextManager = webContextManager;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<int> CountByRequestAsync(GuaranteeSearchRequest request)
        {
            if (request == null)
                throw new ServiceException();

            return await QueryByRequest(request).CountAsync();
        }

        public async Task CreateByViewModelAsync(GuaranteeCreateViewModel viewModel)
        {
            var manufaturer = _mapper.Map<Guarantee>(viewModel);
            _guaranteeRepository.Add(manufaturer);
            await _unitOfWork.SaveAllChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var manufaturer = await FindByIdAsync(id);
            if (manufaturer == null)
                throw new ServiceException();

            _guaranteeRepository.Remove(manufaturer);
            await _unitOfWork.SaveAllChangesAsync();
        }

        public async Task EditByViewMoodelAsync(GuaranteeEditViewModel viewModel)
        {
            var manufaturer = await FindByIdAsync(viewModel.Id);
            if (manufaturer == null)
                throw new ServiceException();

            _mapper.Map(viewModel, manufaturer);
            await _unitOfWork.SaveAllChangesAsync();
        }

        public async Task<Guarantee> FindByIdAsync(Guid id)
        {
            return await _guaranteeRepository.SingleOrDefaultAsync(model => model.Id == id);
        }

        public async Task<IList<Select2Object>> GetAsSelect2ObjectAsync()
        {
            //todo:
            var subCategories = await _categoryService.GetChildsByIdAsync(_webContextManager.CurrentCategoryId);
            return await _guaranteeRepository.AsNoTracking()
                .Select(model => new Select2Object
                {
                    id = model.Id,
                    text = model.Title
                }).ToListAsync();
        }


        public async Task<IList<SelectListItem>> GetAsSelectListAsync()
        {
            return await _guaranteeRepository.AsNoTracking()
                .Select(model => new SelectListItem
                {
                    Text = model.Title,
                    Value = model.Id.ToString()
                })
                .ToListAsync();
        }

        public async Task<IList<Guarantee>> GetByRequestAsync(GuaranteeSearchRequest request)
        {
            if (request == null)
                throw new ServiceException();

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        public IQueryable<Guarantee> QueryByRequest(GuaranteeSearchRequest request)
        {
            var manufaturers = _guaranteeRepository.AsNoTracking().AsQueryable();

            if (request.Term.HasValue())
                manufaturers = manufaturers.Where(model => model.Title.Contains(request.Term));
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            return manufaturers.OrderBy($"{request.SortMember} {request.SortDirection}");
        }

        #endregion Public Methods
    }
}