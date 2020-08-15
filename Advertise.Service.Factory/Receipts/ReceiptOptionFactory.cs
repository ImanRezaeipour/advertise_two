using Advertise.Core.Models.ReceiptOption;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Receipts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Advertise.Service.Factories.Receipts
{
    /// <summary>
    /// کلاس مهیا کننده مدل برای ویو ها
    /// </summary>
    public class ReceiptOptionFactory : IReceiptOptionFactory
    {
        #region Private Fields

        private readonly ICommonService _commonService;
        private readonly IListManager _listManager;
        private readonly IMapper _mapper;
        private readonly IReceiptOptionService _receiptOptionService;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="commonService"></param>
        /// <param name="listManager"></param>
        /// <param name="mapper"></param>
        /// <param name="receiptOptionService"></param>
        public ReceiptOptionFactory(ICommonService commonService, IListManager listManager, IMapper mapper, IReceiptOptionService receiptOptionService)
        {
            _commonService = commonService;
            _listManager = listManager;
            _mapper = mapper;
            _receiptOptionService = receiptOptionService;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// آماده سازی مدل برای لیست محصولات فروخته شده
        /// </summary>
        /// <param name="request">درخواست</param>
        /// <param name="isCurrentUser">آیا برای کاربر جاری است</param>
        /// <param name="userId">شناسه کاربر</param>
        /// <returns></returns>
        public async Task<ReceiptOptionListViewModel> PrepareListViewModel(ReceiptOptionSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.UserId = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _receiptOptionService.CountByRequestAsync(request);
            var receiptPayments = await _receiptOptionService.GetByRequestAsync(request);
            var receiptPaymentsViewModel = _mapper.Map<List<ReceiptOptionViewModel>>(receiptPayments);
            var listViewModel = new ReceiptOptionListViewModel
            {
                ReceiptOptions = receiptPaymentsViewModel,
                SearchRequest = request,
                PageSizeList = await _listManager.GetPageSizeListAsync(),
                SortDirectionList = await _listManager.GetSortDirectionListAsync(),
            };

            if (isCurrentUser)
                listViewModel.IsMine = true;

            return listViewModel;
        }

        #endregion Public Methods
    }
}