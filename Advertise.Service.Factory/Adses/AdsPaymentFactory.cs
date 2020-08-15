using Advertise.Core.Extensions;
using Advertise.Core.Models.AdsPayment;
using Advertise.Service.Factories.AdsPayment;
using Advertise.Service.Services.Ads;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Advertise.Service.Factories.Adses
{
    public class AdsPaymentFactory : IAdsPaymentFactory
    {
        #region Private Fields

        private readonly IAdsPaymentService _adsPaymentService;
        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;

        #endregion Private Fields

        #region Public Constructors

        public AdsPaymentFactory(ICommonService commonService, IMapper mapper, IAdsPaymentService adsPaymentService, IListManager listManager)
        {
            _commonService = commonService;
            _mapper = mapper;
            _adsPaymentService = adsPaymentService;
            _listManager = listManager;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<AdsPaymentListViewModel> PrepareListViewModel(AdsPaymentSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            var requestBanner = new AdsPaymentSearchRequest
            {
                CreatedById = request.CreatedById,
                IsApprove = request.IsApprove,
            };
            var list = await _adsPaymentService.QueryByRequest(requestBanner)
                .Include(model => model.Ads)
                .Where(model => model.Ads.IsApprove == true || model.IsComplete == true && model.IsSuccess == true)
                .ToPagedListAsync(request);
            var bannerPayments = _mapper.Map<IList<AdsPaymentViewModel>>(list);
            request.TotalCount = await _adsPaymentService.CountByRequestAsync(request);

            var adsViewModel = new AdsPaymentListViewModel
            {
                Adses = bannerPayments,
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SearchRequest = request
            };

            if (isCurrentUser)
            {
                adsViewModel.IsMine = true;
                adsViewModel.Adses.ForEach(p => p.IsMine = true);
            }

            return adsViewModel;
        }

        #endregion Public Methods
    }
}