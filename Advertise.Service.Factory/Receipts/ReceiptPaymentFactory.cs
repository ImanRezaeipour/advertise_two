using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advertise.Core.Models.Product;
using Advertise.Core.Models.ReceiptPayment;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.List;
using Advertise.Service.Services.Receipts;
using AutoMapper;

namespace Advertise.Service.Factories.Receipts
{

    public class ReceiptPaymentFactory : IReceiptPaymentFactory
    {
        #region Private Fields

        private readonly IReceiptPaymentService _receiptPaymentService;
        private readonly IReceiptService _receiptService;
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        private readonly IListManager _listManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="receiptService"></param>
        /// <param name="receiptPaymentService"></param>
        public ReceiptPaymentFactory(IReceiptService receiptService, IReceiptPaymentService receiptPaymentService, ICommonService commonService, IMapper mapper, IListManager listManager)
        {
            _receiptService = receiptService;
            _receiptPaymentService = receiptPaymentService;
            _commonService = commonService;
            _mapper = mapper;
            _listManager = listManager;
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="authority"></param>
        /// <returns></returns>
        public async Task<ReceiptPaymentCompleteViewModel> PrepareCompleteViewModelAsync(string authority)
        {
            var payment = await _receiptPaymentService.FindByAuthorityCodeAsync(authority);
            if (payment == null)
                return null;

            var reciept = await _receiptService.FindByIdAsync(payment.ReceiptId.GetValueOrDefault());
            if (reciept == null)
                return null;

            var viewModel = new ReceiptPaymentCompleteViewModel
            {
                InvoiceNumber = reciept.InvoiceNumber,
            };
            if (payment.IsComplete == true & payment.IsSuccess == true)
            {
                viewModel.Message = "پرداخت شما با موفقیت انجام شده است.";
                viewModel.Color = "Green";
                return viewModel;
            }
            if (payment.IsComplete == true & payment.IsSuccess == false)
            {
                viewModel.Message = "متاسفانه پرداخت شما توسط درگاه بانکی با موفقیت انجام نشده است";
                viewModel.Color = "Red";
                return viewModel;
            }
            viewModel.Message = "پرداخت شما کامل نشده است، لطفا نسبت به تکمیل آن اقدام نمائید";
            viewModel.Color = "Blue";

            return viewModel;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="isCurrentUser"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<ReceiptPaymentListViewModel> PrepareListViewModelAsync(ReceiptPaymentSearchRequest request, bool isCurrentUser = false, Guid? userId = null)
        {
            request.CreatedById = await _commonService.GetUserIdAsync(isCurrentUser, userId);
            request.TotalCount = await _receiptPaymentService.CountByRequestAsync(request);
            var receiptPayments = await _receiptPaymentService.GetByRequestAsync(request);
            var receiptPaymentsViewModel = _mapper.Map<List<ReceiptPaymentViewModel>>(receiptPayments);
            var listViewModel = new ReceiptPaymentListViewModel
            {
                ReceiptPayments = receiptPaymentsViewModel,
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