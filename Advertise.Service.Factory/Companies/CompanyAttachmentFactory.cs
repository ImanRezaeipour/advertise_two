using Advertise.Core.Models.CompanyAttachment;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Companies;
using Advertise.Service.Services.List;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Advertise.Core.Exceptions;
using Advertise.Core.Helpers;
using Advertise.Core.Models.CompanyAttachmentFile;
using AutoMapper.QueryableExtensions;
using Advertise.Core.Utilities;
using Advertise.Core.Types;
using Advertise.Service.Services.WebContext;

namespace Advertise.Service.Factories.Companies
{

    public class CompanyAttachmentFactory : ICompanyAttachmentFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly ICompanyAttachmentService _companyAttachmentService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IWebContextManager _webContextManager;
        private readonly ICompanyAttachmentFilService _companyAttachmentFilService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyAttachmentService"></param>
        /// <param name="listManager"></param>
        /// <param name="commonService"></param>
        /// <param name="mapper"></param>
        public CompanyAttachmentFactory(ICompanyAttachmentService companyAttachmentService, IListManager listManager, ICommonService commonService, IMapper mapper, IWebContextManager webContextManager, ICompanyAttachmentFilService companyAttachmentFilService)
        {
            _companyAttachmentService = companyAttachmentService;
            _listManager = listManager;
            _commonService = commonService;
            _mapper = mapper;
            _webContextManager = webContextManager;
            _companyAttachmentFilService = companyAttachmentFilService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyAttachmentId"></param>
        /// <returns></returns>
        public async Task<CompanyAttachmentEditViewModel> PrepareEditViewModelAsync(Guid companyAttachmentId, bool applyCurrentUser = false)
        {
            var result = await _companyAttachmentService.IsMineAsync(companyAttachmentId);
            if (!result)
                throw new FactoryException("عدم دسترسی به این فایل");

            var companyAttachment = await _companyAttachmentService.FindByIdAsync(companyAttachmentId);
            var viewModel = _mapper.Map<CompanyAttachmentEditViewModel>(companyAttachment);

            if (applyCurrentUser)
                viewModel.IsMine = true;

            return viewModel;
        }


        public async Task<CompanyAttachmentListViewModel> PrepareListViewModelAsync(CompanyAttachmentSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            var companyAttachments = await _companyAttachmentService.GetByRequestAsync(request);
            request.TotalCount = await _companyAttachmentService.CountByRequestAsync(request);

            var companyAttachmentViewModel = _mapper.Map<IList<CompanyAttachmentViewModel>>(companyAttachments);
            var companyAttachmentList = new CompanyAttachmentListViewModel
            {
                SearchRequest = request,
                CompanyAttachments = companyAttachmentViewModel,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
                StateList = EnumHelper.CastToSelectListItems<StateType>()// await _listManager.GetStateListAsync()
            };

            if(isCurrentUser)
            {
                companyAttachmentList.IsMine = true;
                companyAttachmentList.CompanyAttachments.ForEach(p => p.IsMine = false);
            }

            return companyAttachmentList;
        }


        public async Task<CompanyAttachmentDetailViewModel> PrepareDetailViewModelAsync(Guid companyAttachmentId)
        {
            var companyAttachment = await _companyAttachmentService.FindByIdAsync(companyAttachmentId);

            var viewModel=  _mapper.Map<CompanyAttachmentDetailViewModel>(companyAttachment);
            var request = new CompanyAttachmentFileSearchRequest
            {
                CompanyAttachmentId = companyAttachmentId
            };
            viewModel.Files = _mapper.Map<IList<CompanyAttachmentFileViewModel>>(await _companyAttachmentFilService.GetByRequestAsync(request));
            return viewModel;
        }
        #endregion Public Methods
    }
}