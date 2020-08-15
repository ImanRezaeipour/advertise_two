using Advertise.Core.Domains.Seos;
using Advertise.Core.Models.SeoSetting;
using Advertise.Data.DbContexts;
using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Service.Aspects.Validations;
using Advertise.Service.Managers.Events;
using Advertise.Service.Validators.Seo;

namespace Advertise.Service.Services.Seo
{
    /// <summary>
    ///
    /// </summary>
    public class SeoSettingService : ISeoSettingService
    {
        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<SeoSetting> _seoSettingRepository;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        ///  <summary>
        ///
        ///  </summary>
        ///  <param name="unitOfWork"></param>
        ///  <param name="mapper"></param>
        /// <param name="eventPublisher"></param>
        public SeoSettingService(IUnitOfWork unitOfWork, IMapper mapper, IEventPublisher eventPublisher)
        {
            _unitOfWork = unitOfWork;
            _seoSettingRepository = unitOfWork.Set<SeoSetting>();
            _mapper = mapper;
            _eventPublisher = eventPublisher;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [Validation(typeof(SeoSettingEditValidator),"Edit")]
        public async Task EditByViewModelAsync(SeoSettingEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var seoSetting = await _seoSettingRepository.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            if (seoSetting == null)
            {
                var addSeoSetting = _mapper.Map<SeoSetting>(viewModel);
                _seoSettingRepository.Add(addSeoSetting);

                await _unitOfWork.SaveAllChangesAsync();

                _eventPublisher.EntityInserted(addSeoSetting);
            }
            else
            {
                _mapper.Map(viewModel, seoSetting);

                await _unitOfWork.SaveAllChangesAsync();

                _eventPublisher.EntityUpdated(seoSetting);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public SeoSettingViewModel GetFirst()
        {
            var seoSetting = _seoSettingRepository.AsNoTracking().FirstOrDefault();
            return _mapper.Map<SeoSettingViewModel>(seoSetting);
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<SeoSetting> GetFirstAsync()
        {
            return await _seoSettingRepository.AsNoTracking().FirstOrDefaultAsync();
        }

        #endregion Public Methods
    }
}