using Advertise.Core.Models.CompanyVideo;
using Advertise.Core.Types;
using Advertise.Core.Utilities;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.List;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Helpers;

namespace Advertise.Service.Factories.Companies
{

    public class CompanyVideoFactory : ICompanyVideoFactory
    {
        #region Private Fields

        private readonly ICompanyVideoService _companyVideoService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyVideoService"></param>
        /// <param name="mapper"></param>
        /// <param name="listManager"></param>
        public CompanyVideoFactory(ICompanyVideoService companyVideoService, IMapper mapper, IListManager listManager, IWebContextManager webContextManager)
        {
            _companyVideoService = companyVideoService;
            _mapper = mapper;
            _listManager = listManager;
            _webContextManager = webContextManager;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyVideoId"></param>
        /// <returns></returns>
        public async Task<CompanyVideoEditViewModel> PrepareEditViewModelAsync(Guid companyVideoId, bool applyCurrentUser = false)
        {
            var companyVideo = await _companyVideoService.FindByIdAsync(companyVideoId);
            var viewModel = _mapper.Map<CompanyVideoEditViewModel>(companyVideo);

            if (applyCurrentUser)
                viewModel.IsMine = true;

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<CompanyVideoListViewModel> PrepareListViewModelAsync(CompanyVideoSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            if (isCurrentUser)
                request.CreatedById = _webContextManager.CurrentUserId;
            else if (userId != null)
                request.CreatedById = userId;
            else
                request.CreatedById = null;
            request.TotalCount = await _companyVideoService.CountByRequestAsync(request);
            var companyVideos = await _companyVideoService.GetByRequestAsync(request);
            var companyVideoViewModel = _mapper.Map<IList<CompanyVideoViewModel>>(companyVideos);
            var companyVideoList = new CompanyVideoListViewModel
            {
                SearchRequest = request,
                CompanyVideos = companyVideoViewModel,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
                StateList = EnumHelper.CastToSelectListItems<StateType>()//await _listManager.GetStateListAsync()
            };

            if (isCurrentUser)
            {
                companyVideoList.IsMine = true;
                companyVideoList.CompanyVideos.ForEach(p => p.IsMine = true);
            }

            return companyVideoList;
        }

        public async Task<CompanyVideoDetailViewModel> PrepareDetailViewModelAsync(Guid companyVideoId)
        {
            var companyVideo = await _companyVideoService.FindByIdAsync(companyVideoId);

            var viewModel = _mapper.Map<CompanyVideoDetailViewModel>(companyVideo);
            var request = new CompanyVideoSearchRequest
            {
                CompanyId = _webContextManager.CurrentCompanyId,
                State = StateType.Approved
            };
            viewModel.Galleries = _mapper.Map<IList<CompanyVideoViewModel>>(await _companyVideoService.GetByRequestAsync(request));
            return viewModel;
        }

        #endregion Public Methods
    }
}