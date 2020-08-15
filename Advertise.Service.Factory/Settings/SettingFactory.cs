using Advertise.Core.Models.Setting;
using Advertise.Service.Services.Settings;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace Advertise.Service.Factories.Settings
{

    public class SettingFactory : ISettingFactory
    {
        #region Private Fields

        private readonly IMapper _mapper;
        private readonly SettingService _settingService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="settingService"></param>
        /// <param name="mapper"></param>
        public SettingFactory(SettingService settingService, IMapper mapper)
        {
            _settingService = settingService;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<SettingEditViewModel> PrepareEditViewModel()
        {
            var setting = await _settingService.GetFirstAsync();
            var viewModel = setting != null ? _mapper.Map<SettingEditViewModel>(setting) : new SettingEditViewModel();

            return viewModel;
        }

        #endregion Public Methods
    }
}