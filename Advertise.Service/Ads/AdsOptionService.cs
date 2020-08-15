using Advertise.Core.Domains.Adses;
using Advertise.Core.Extensions;
using Advertise.Core.Models.AdsOption;
using Advertise.Core.Models.Common;
using Advertise.Core.Types;
using Advertise.Data.DbContexts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace Advertise.Service.Services.Ads
{
    public class AdsOptionService : IAdsOptionService
    {
        #region Private Fields

        private readonly IDbSet<AdsOption> _adsOptionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        public AdsOptionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _adsOptionRepository = unitOfWork.Set<AdsOption>();
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<int> CountByRequestAsync(AdsOptionSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }

        public async Task CreateByViewModelAsync(AdsOptionCreateViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var adsOption = _mapper.Map<AdsOption>(viewModel);

            _adsOptionRepository.Add(adsOption);

            await _unitOfWork.SaveAllChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid adsOptionId)
        {
            var adsOption = await FindByIdAsync(adsOptionId);

            _adsOptionRepository.Remove(adsOption);

            await _unitOfWork.SaveAllChangesAsync();
        }

        public async Task EditByViewModelAsync(AdsOptionEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var adsOption = await FindByIdAsync(viewModel.Id);
            if (adsOption == null)
                throw new ArgumentNullException(nameof(adsOption));

            _mapper.Map(viewModel, adsOption);

            await _unitOfWork.SaveAllChangesAsync();
        }

        public async Task<AdsOption> FindByIdAsync(Guid adsOptionId)
        {
            return await _adsOptionRepository.FirstOrDefaultAsync(model => model.Id == adsOptionId);
        }

        public async Task<IList<SelectListItem>> GetAsSelectListAsync(AdsType type, AdsPositionType? position = null)
        {
            var request = new AdsOptionSearchRequest
            {
                Position = position,
                Type = type
            };
            return await QueryByRequest(request).Select(record => new SelectListItem
            {
                Value = record.Id.ToString(),
                Text = " تبلیغ " + record.Title + " در جایگاه " + record.PositionType + " به مبلغ " + record.Price
            }).ToListAsync();
        }

        public async Task<IList<AdsOption>> GetByRequestAsync(AdsOptionSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }

        public async Task<int> GetCapacityByIdAsync(Guid optionId)
        {
            return (await FindByIdAsync(optionId)).Capacity ?? 0;
        }

        public async Task<decimal> GetPriceByIdAsync(Guid optionId, DurationType durationType)
        {
            var option = await FindByIdAsync(optionId);
            return option.Price.GetValueOrDefault() * durationType.ToInt32();
        }

        public IQueryable<AdsOption> QueryByRequest(AdsOptionSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var adsOptions = _adsOptionRepository.AsNoTracking().AsQueryable();

            if (request.Term.HasValue())
                adsOptions = adsOptions.Where(model => model.Title.Contains(request.Term));
            if (request.Position.HasValue)
                adsOptions = adsOptions.Where(model => model.PositionType == request.Position);
            if (request.Type.HasValue)
                adsOptions = adsOptions.Where(model => model.Type == request.Type);

            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Desc;
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;

            adsOptions = adsOptions.OrderBy($"{request.SortMember} {request.SortDirection}");

            return adsOptions;
        }

        #endregion Public Methods
    }
}