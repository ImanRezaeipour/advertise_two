using Advertise.Core.Models.SeoUrl;
using Advertise.Core.Types;
using Advertise.Core.Utilities;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Seo;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Helpers;

namespace Advertise.Service.Factories.Seos
{

    public class SeoUrlFactory : ISeoUrlFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        private readonly ISeoUrlService _seoUrlService;
        private readonly IListManager _listManager;

        #endregion Private Fields

        #region Public Constructors

        ///  <summary>
        ///
        ///  </summary>
        ///  <param name="seoUrlService"></param>
        ///  <param name="mapper"></param>
        ///  <param name="commonService"></param>
        /// <param name="listManager"></param>
        public SeoUrlFactory(ISeoUrlService seoUrlService, IMapper mapper, ICommonService commonService, IListManager listManager)
        {
            _seoUrlService = seoUrlService;
            _mapper = mapper;
            _commonService = commonService;
            _listManager = listManager;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<SeoUrlEditViewModel> PrepareEditViewModelAsync(Guid id, SeoUrlEditViewModel viewModelPrepare = null)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            var seoUrl = await _seoUrlService.FindByIdAsync(id);
            var viewModel = viewModelPrepare ?? _mapper.Map<SeoUrlEditViewModel>(seoUrl);
            viewModel.RedirectionTypeList = EnumHelper.CastToSelectListItems<RedirectionType>(); //await _listManager.GetRedirectionTypeListAsync();

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<SeoUrlListViewModel> PrepareListViewModelAsync(SeoUrlSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _seoUrlService.CountByRequestAsync(request);
            var seoUrls = await _seoUrlService.GetByRequestAsync(request);
            var seoUrlsViewModel = _mapper.Map<List<SeoUrlViewModel>>(seoUrls);
            var viewModel = new SeoUrlListViewModel
            {
                SeoUrls = seoUrlsViewModel,
                SearchRequest = request
            };

            viewModel.PageSizeList = await _listManager.GetPageSizeListAsync();
            viewModel.SortDirectionList = await _listManager.GetSortDirectionListAsync();

            return viewModel;
        }


        public async Task<SeoUrlCreateViewModel> PrepareCreateViewModelAsync(SeoUrlCreateViewModel viewModelPrepare= null)
        {
            var viewModel = new SeoUrlCreateViewModel();

            viewModel.RedirectionTypeList = EnumHelper.CastToSelectListItems<RedirectionType>();// await _listManager.GetRedirectionTypeListAsync();
            
            return viewModel;
        }

        #endregion Public Methods
    }
}