using Advertise.Core.Models.SeoSetting;
using Advertise.Core.Types;
using Advertise.Core.Utilities;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Seo;
using AutoMapper;
using System.Threading.Tasks;
using Advertise.Core.Helpers;

namespace Advertise.Service.Factories.Seos
{

    public class SeoSettingFactory : ISeoSettingFactory
    {
        #region Private Fields

        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly ISeoSettingService _seoSettingService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="seoSettingService"></param>
        /// <param name="mapper"></param>
        /// <param name="listManager"></param>
        public SeoSettingFactory(ISeoSettingService seoSettingService, IMapper mapper, IListManager listManager)
        {
            _seoSettingService = seoSettingService;
            _mapper = mapper;
            _listManager = listManager;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<SeoSettingEditViewModel> PrepareEditViewModelAsync(SeoSettingEditViewModel viewModelPrepare = null)
        {
            var seoSetting = await _seoSettingService.GetFirstAsync();
            var viewModel =viewModelPrepare ??( seoSetting != null ? _mapper.Map<SeoSettingEditViewModel>(seoSetting) : new SeoSettingEditViewModel());
            viewModel.WwwRequirementList = EnumHelper.CastToSelectListItems<ActiveType>(); //await _listManager.GetWwwRequirementListAsync();

            return viewModel;
        }

        #endregion Public Methods
    }
}