using Advertise.Core.Domains.Plans;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.PlanDiscount;
using Advertise.Data.DbContexts;
using Advertise.Service.Managers.Events;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Validators.Plans;

namespace Advertise.Service.Services.Plans
{
    /// <summary>
    ///
    /// </summary>
    public class PlanDiscountService : IPlanDiscountService
    {
        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<PlanDiscount> _planDiscountRepository;
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
        public PlanDiscountService(IMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher, IWebContextManager webContextManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
            _webContextManager = webContextManager;
            _planDiscountRepository = _unitOfWork.Set<PlanDiscount>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(PlanDiscountSearchRequest request)
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
        [Validation(typeof(PlanDiscountCreateValidator),"Create")]
        public async Task CreateByViewModelAsync(PlanDiscountCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var planDiscount = _mapper.Map<PlanDiscount>(viewModel);
            planDiscount.CreatedOn = DateTime.Now;
            planDiscount.CreatedById = _webContextManager.CurrentUserId;
            _planDiscountRepository.Add(planDiscount);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityInserted(planDiscount);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="planDiscountId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid? planDiscountId)
        {
            if (planDiscountId == null)
                throw new ArgumentNullException(nameof(planDiscountId));

            var planDiscount = await FindByIdAsync(planDiscountId.Value);
            _planDiscountRepository.Remove(planDiscount);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityDeleted(planDiscount);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(PlanDiscountEditValidator),"Edit")]
        public async Task EditByViewModelAsync(PlanDiscountEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var planDiscount = await FindByIdAsync(viewModel.Id);
            _mapper.Map(viewModel, planDiscount);

            await _unitOfWork.SaveAllChangesAsync();

            _eventPublisher.EntityUpdated(planDiscount);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="planDiscountId"></param>
        /// <returns></returns>
        public async Task<PlanDiscount> FindByIdAsync(Guid planDiscountId)
        {
            return await _planDiscountRepository.SingleOrDefaultAsync(model => model.Id == planDiscountId);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IList<PlanDiscount>> GetByRequestAsync(PlanDiscountSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="planDiscountCode"></param>
        /// <returns></returns>
        public async Task<int?> GetPercentByCodeAsync(string planDiscountCode)
        {
            return await _planDiscountRepository.AsNoTracking()
                .Where(model => model.Code == planDiscountCode)
                .Select(model => model.Percent)
                .SingleOrDefaultAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IQueryable<PlanDiscount> QueryByRequest(PlanDiscountSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var planDiscount = _planDiscountRepository.AsNoTracking().AsQueryable();

            if (request.CreatedById.HasValue)
                planDiscount = planDiscount.Where(model => model.CreatedById == request.CreatedById);

            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortDirection = SortMember.CreatedOn;

            planDiscount = planDiscount.OrderBy($"{request.SortMember} {request.SortDirection}");

            return planDiscount;
        }

        #endregion Public Methods
    }
}