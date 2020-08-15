using Advertise.Core.Models.Complaint;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Complaints;
using Advertise.Service.Services.List;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertise.Service.Factories.Complaints
{

    public class ComplaintFactory : IComplaintFactory
    {

        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IComplaintService _complaintService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="complaintService"></param>
        /// <param name="commonService"></param>
        /// <param name="listManager"></param>
        /// <param name="mapper"></param>
        public ComplaintFactory(IComplaintService complaintService, ICommonService commonService, IListManager listManager, IMapper mapper)
        {
            _complaintService = complaintService;
            _commonService = commonService;
            _listManager = listManager;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<ComplaintDetailViewModel> PrepareDetailViewModelAsync(Guid companyId)
        {
            var complaint = await _complaintService.FindByIdAsync(companyId);
            var viewModel = _mapper.Map<ComplaintDetailViewModel>(complaint);

            return viewModel;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ComplaintListViewModel> PrepareListViewModelAsync(ComplaintSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _complaintService.CountByRequestAsync(request);
            var complaints = await _complaintService.GetByRequestAsync(request);
            var complaintViewModel = _mapper.Map<IList<ComplaintViewModel>>(complaints);
            var companyList = new ComplaintListViewModel
            {
                SearchRequest = request,
                Complaints = complaintViewModel
            };
            companyList.PageSizeList = await _listManager.GetPageSizeListAsync();
            companyList.SortDirectionList = await _listManager.GetSortDirectionListAsync();
            companyList.SortMemberList = await _listManager.GetSortMemberListByTitleAsync();

            return companyList;
        }

        #endregion Public Methods

    }
}