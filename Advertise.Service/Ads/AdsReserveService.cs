using Advertise.Core.Domains.Adses;
using Advertise.Core.Models.AdsReserve;
using Advertise.Core.Models.Common;
using Advertise.Data.DbContexts;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace Advertise.Service.Services.Ads
{
    public class AdsReserveService : IAdsReserveService
    {
        #region Private Fields

        private readonly IAdsOptionService _adsOptionService;
        private readonly IDbSet<AdsReserve> _adsReserveRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        public AdsReserveService(IUnitOfWork unitOfWork, IAdsOptionService adsOptionService)
        {
            _unitOfWork = unitOfWork;
            _adsOptionService = adsOptionService;
            _adsReserveRepository = unitOfWork.Set<AdsReserve>();
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<int> CountByRequestAsync(AdsReserveSearchRequest request)
        {
            return await QueryByRequest(request).CountAsync();
        }

        public async Task CreateByViewModelAsync(AdsReserveCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            if (viewModel.AdsOptionId == null)
                throw new ArgumentNullException(nameof(viewModel));

            var day = await GetReserveDayByOptionIdAsync(viewModel.AdsOptionId.Value);
            if(day == null)
                return;

            for (var duration = 0; duration < viewModel.DurationType.ToInt32(); duration++)
            {
                var adsReserve = new AdsReserve
                {
                    Day = day.Value.AddDays(duration),
                    AdsId = viewModel.AdsId
                };

                _adsReserveRepository.Add(adsReserve);
            }

            await _unitOfWork.SaveAllChangesAsync();
        }

        public async Task<DateTime?> GetReserveDayByOptionIdAsync(Guid optionId)
        {
            var capacity = await _adsOptionService.GetCapacityByIdAsync(optionId);
            if (capacity == 0)
                return null;

            for (var day = DateTime.Now.AddDays(1); day < DateTime.Now.AddDays(30); day = day.AddDays(1))
            {
                var request = new AdsReserveSearchRequest
                {
                    OptionId = optionId,
                    Day = day
                };
                var reservedCountForDate = await CountByRequestAsync(request);
                if (reservedCountForDate < capacity)
                    return day;
            }
            return null;
        }

        public IQueryable<AdsReserve> QueryByRequest(AdsReserveSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var adsReserve = _adsReserveRepository.AsNoTracking().AsQueryable()
                .Include(model => model.Ads);

            if (request.Day.HasValue)
                adsReserve = adsReserve.Where(reserve => reserve.Day == request.Day);
            if (request.OptionId.HasValue)
                adsReserve = adsReserve.Where(reserve => reserve.Ads.AdsOptionId == request.OptionId);

            adsReserve = adsReserve.OrderBy($"{request.SortMember ?? SortMember.CreatedOn} {request.SortDirection ?? SortDirection.Asc}");

            return adsReserve;
        }

        #endregion Public Methods
    }
}