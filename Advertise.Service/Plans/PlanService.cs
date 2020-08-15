using Advertise.Core.Domains.Plans;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Plan;
using Advertise.Data.DbContexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Services.WebContext;
using Advertise.Service.Validators.Plans;
using SortDirection = Advertise.Core.Models.Common.SortDirection;

namespace Advertise.Service.Services.Plans
{
    /// <summary>
    ///
    /// </summary>
    public class PlanService : IPlanService
    {
        #region Private Fields

        private readonly IMapper _mapper;
        private readonly IDbSet<Plan> _planRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public PlanService(IUnitOfWork unitOfWork, IMapper mapper, IWebContextManager webContextManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webContextManager = webContextManager;
            _planRepository = unitOfWork.Set<Plan>();
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<int> CountByRequestAsync(PlanSearchRequest request)
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
        [Validation(typeof(PlanCreateValidator),"Create")]
        public async Task CreateByViewModelAsync(PlanCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new NullReferenceException(nameof(viewModel));

            var plan = _mapper.Map<Plan>(viewModel);
            plan.ModifiedOn = DateTime.Now;
            if (viewModel.PlanDuration != null) plan.DurationDay = viewModel.PlanDuration.Value.ToInt32();
            plan.CreatedById = _webContextManager.CurrentUserId;
            plan.CreatedOn = DateTime.Now;
            _planRepository.Add(plan);

            await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid? planId)
        {
            if (planId == Guid.Empty || planId == null)
                throw new NullReferenceException();

            var plan = await _planRepository.FirstOrDefaultAsync(model => model.Id == planId);
            _planRepository.Remove(plan);

            await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(PlanEditValidator),"Edit")]
        public async Task EditByViewModelAsync(PlanEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new NullReferenceException();
            var plan = await _planRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, plan);
            if (viewModel.PlanDuration != null) plan.DurationDay = viewModel.PlanDuration.Value.ToInt32();

            await _unitOfWork.SaveAllChangesAsync();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<Plan> FindByCodeAsync(string code)
        {
            return await _planRepository
                .FirstOrDefaultAsync(model => model.Code == code);
        }


        public async Task<Plan> FindByIdAsync(Guid id)
        {
            return await _planRepository
                   .FirstOrDefaultAsync(model => model.Id == id);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<IList<SelectListItem>> GetAllAsSelectListItemAsync()
        {
            var plans = await _planRepository.AsNoTracking()
                .Select(record => new SelectListItem
                {
                    Value = record.Id.ToString(),
                    Text = record.Title
                })
                .ToListAsync();
            return _mapper.Map<List<SelectListItem>>(plans);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IList<Plan>> GetByRequestAsync(PlanSearchRequest request)
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
        public IQueryable<Plan> QueryByRequest(PlanSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var plans = _planRepository.AsNoTracking().AsQueryable();

            if (request.CreatedById.HasValue)
                plans = plans.Where(model => model.CreatedById == request.CreatedById);
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortDirection = SortMember.ModifiedOn;

            plans = plans.SortBy($"{request.SortDirection} {request.SortMember}");

            return plans;
        }

        #endregion Public Methods
    }
}