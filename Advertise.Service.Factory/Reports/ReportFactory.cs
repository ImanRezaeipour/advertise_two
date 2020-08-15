using Advertise.Core.Models.Report;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Reports;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertise.Service.Factories.Reports
{

    public class ReportFactory : IReportFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IReportService _reportService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="commonService"></param>
        /// <param name="listManager"></param>
        /// <param name="reportService"></param>
        /// <param name="mapper"></param>
        public ReportFactory(ICommonService commonService, IListManager listManager, IReportService reportService, IMapper mapper)
        {
            _commonService = commonService;
            _listManager = listManager;
            _reportService = reportService;
            _mapper = mapper;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ReportListViewModel> PrepareListViewModelAsync(ReportSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _reportService.CountByRequestAsync(request);
            var reports = await _reportService.GetByRequestAsync(request);
            var reportsViewModel = _mapper.Map<List<ReportViewModel>>(reports);
            var viewModel = new ReportListViewModel
            {
                Reports = reportsViewModel,
                SearchRequest = request,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync()
            };

            return viewModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="viewModelPrepare"></param>
        /// <returns></returns>
        public async Task<ReportEditViewModel> PrepareEditViewModelAsync(Guid id, ReportEditViewModel viewModelPrepare = null)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            var report = await _reportService.FindByIdAsync(id);
            var viewModel = viewModelPrepare ?? _mapper.Map<ReportEditViewModel>(report);

            return viewModel;
        }


        public async Task<ReportParameterViewModel> PrepareReportParameter(Guid id)
        {
            var viewModel = new ReportParameterViewModel
            {
                Id = id
            };
            return viewModel;
        }

        #endregion Public Methods
    }
}