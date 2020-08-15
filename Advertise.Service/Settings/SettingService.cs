using Advertise.Core.Domains.Settings;
using Advertise.Core.Models.Setting;
using Advertise.Data.DbContexts;
using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Advertise.Service.Managers.Events;

namespace Advertise.Service.Services.Settings
{

    public class SettingService : ISettingService
    {

        #region Private Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly IMapper _mapper;
        private readonly IDbSet<Setting> _settingRepositiry;
        private readonly IUnitOfWork _unitOfWork;

        #endregion Private Fields

        #region Public Constructors

        ///  <summary>
        ///
        ///  </summary>
        ///  <param name="unitOfWork"></param>
        ///  <param name="mapper"></param>
        /// <param name="eventPublisher"></param>
        public SettingService(IUnitOfWork unitOfWork, IMapper mapper, IEventPublisher eventPublisher)
        {
            _unitOfWork = unitOfWork;
            _settingRepositiry = unitOfWork.Set<Setting>();
            _mapper = mapper;
            _eventPublisher = eventPublisher;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task EditByViewModel(SettingEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var setting = await _settingRepositiry.FirstOrDefaultAsync(model => model.Id == viewModel.Id);
            if (setting == null)
            {
                var addSetting = _mapper.Map<Setting>(viewModel);
                _settingRepositiry.Add(addSetting);

                await _unitOfWork.SaveAllChangesAsync();

                _eventPublisher.EntityInserted(addSetting);
            }
            else
            {
                _mapper.Map(viewModel, setting);

                await _unitOfWork.SaveAllChangesAsync();

                _eventPublisher.EntityUpdated(setting);
            }
        }


        public SettingViewModel GetFirst()
        {
            var setting = _settingRepositiry.AsNoTracking().FirstOrDefault();
            return  _mapper.Map<SettingViewModel>(setting);
            
        }
        /// <inheritdoc />
        /// <summary>
        /// دریافت تنظیمات
        /// </summary>
        /// <returns></returns>
        public async Task<Setting> GetFirstAsync()
        {
           return  await _settingRepositiry.AsNoTracking().FirstOrDefaultAsync();
            
        }

        #endregion Public Methods

    }
}