using Advertise.Core.Domains.Statistics;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.Statistic;
using Advertise.Data.DbContexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Service.Managers.Events;

namespace Advertise.Service.Services.Statistics
{

    public class StatisticService : IStatisticService
    {

        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<Statistic> _statisticRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="eventPublisher"></param>
        public StatisticService(IMapper mapper, IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
            _statisticRepository = unitOfWork.Set<Statistic>();
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<int> CountAllAsync()
        {
            var searchRequest = new StatisticSearchRequest
            {
                PageSize = PageSize.All,
                SortDirection = SortDirection.Asc,
                SortMember = SortMember.CreatedOn,
                PageIndex = 1
            };
         return  await CountByRequestAsync(searchRequest);
;
        }


        public async Task<int> CountByRequestAsync(StatisticSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

         return  await QueryByRequest(request).CountAsync();
            }


        public void CreateByViewModel(StatisticCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var statistic = _mapper.Map<Statistic>(viewModel);
            _statisticRepository.Add(statistic);

            _unitOfWork.SaveAllChanges();
            _eventPublisher.EntityInserted(statistic);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="statisticId"></param>
        /// <returns></returns>
        public async Task DeleteByIdAsync(Guid statisticId)
        {
            if (statisticId == null)
                throw new ArgumentNullException(nameof(statisticId));

            var statistic = await _statisticRepository.FirstOrDefaultAsync(model => model.Id == statisticId);
            _statisticRepository.Remove(statistic);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityDeleted(statistic);
        }


        public async Task EditByViewModelAsync(StatisticEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var statistic = await _statisticRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            _mapper.Map(viewModel, statistic);

            await _unitOfWork.SaveAllChangesAsync();
            _eventPublisher.EntityUpdated(statistic);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="statisticId"></param>
        /// <returns></returns>
        public async Task<Statistic> FindByIdAsync(Guid statisticId)
        {
        return  await _statisticRepository
                .FirstOrDefaultAsync(model => model.Id == statisticId);
            }


        public async Task<IList<Statistic>> GetByRequestAsync(StatisticSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
            
        }


        public IQueryable<Statistic> QueryByRequest(StatisticSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var statistics = _statisticRepository.AsNoTracking().AsQueryable();
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;

            statistics = statistics.OrderBy($"{request.SortMember} {request.SortDirection}");

            return statistics;
        }

        public async Task SeedAsync()
        {
            throw new NotImplementedException();
        }

        #endregion Public Methods

    }
}