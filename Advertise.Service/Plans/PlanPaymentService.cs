using Advertise.Core.Domains.Plans;
using Advertise.Core.Domains.Users;
using Advertise.Core.Exceptions;
using Advertise.Core.Extensions;
using Advertise.Core.Models.Common;
using Advertise.Core.Models.PlanPayment;
using Advertise.Core.Types;
using Advertise.Data.DbContexts;
using Advertise.Service.Services.Common;
using Advertise.Service.Services.Users;
using Advertise.Service.Services.WebContext;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using Advertise.Core.Configuration;
using Advertise.Service.Managers.PaymentGateway;

namespace Advertise.Service.Services.Plans
{

    public class PlanPaymentService : IPlanPaymentService
    {
        #region Private Fields

        private readonly IAccountService _accountService;
        private readonly IConfigurationManager _configurationManager;
        private readonly IZarinpalGatewayManager _paymentGatewayManager;
        private readonly IPlanDiscountService _planDiscountService;
        private readonly IDbSet<PlanPayment> _planPaymentRepository;
        private readonly IPlanService _planService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly IWebContextManager _webContextManager;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        ///
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="webContextManager"></param>
        /// <param name="paymentGatewayManager"></param>
        /// <param name="configurationManager"></param>
        /// <param name="userService"></param>
        /// <param name="planService"></param>
        public PlanPaymentService(IUnitOfWork unitOfWork, IWebContextManager webContextManager, IZarinpalGatewayManager paymentGatewayManager, IConfigurationManager configurationManager, IUserService userService, IPlanService planService, IPlanDiscountService planDiscountService, IAccountService accountService)
        {
            _planPaymentRepository = unitOfWork.Set<PlanPayment>();
            _unitOfWork = unitOfWork;
            _webContextManager = webContextManager;
            _paymentGatewayManager = paymentGatewayManager;
            _configurationManager = configurationManager;
            _userService = userService;
            _planService = planService;
            _planDiscountService = planDiscountService;
            _accountService = accountService;
        }

        #endregion Public Constructors

        #region Public Methods


        public async Task<PaymentResult> CallbackByViewModelAsync(PlanPaymentCallbackViewModel viewModel)
        {
            switch (viewModel.Pay)
            {
                case PayType.Zarinpal:
                    return await CallbackWithZarinpalByViewModelAsync(viewModel);

                default:
                    return await CallbackWithZarinpalByViewModelAsync(viewModel);
            }
        }


        public async Task<PaymentResult> CallbackWithZarinpalByViewModelAsync(PlanPaymentCallbackViewModel viewModel)
        {
            if (string.IsNullOrEmpty(viewModel.Status))
                throw new ArgumentNullException(nameof(viewModel.Status));

            if (string.IsNullOrEmpty(viewModel.Authority))
                throw new ArgumentNullException(nameof(viewModel.Authority));

            var planPayment = await FindByAuthorityCodeAsync(viewModel.Authority);
            if (planPayment == null)
                return PaymentResult.Failed();

            var zarinpal = _paymentGatewayManager.ZarinpalGateway();
            long referenceCode;
            var status = zarinpal.PaymentVerification(_configurationManager.MerchantCode, planPayment.AuthorityCode, (int)planPayment.Amount.GetValueOrDefault(), out referenceCode);

            planPayment.ReferenceCode = (int?)referenceCode;
            planPayment.StatusCode = status;
            planPayment.IsComplete = true;

            switch (status)
            {
                case 100:
                case 101:
                    planPayment.IsSuccess = true;
                    await _unitOfWork.SaveAllChangesAsync(auditUserId: _webContextManager.CurrentUserId);

                    var currentUserId = _webContextManager.CurrentUserId;
                    var plan = await _planService.FindByIdAsync(planPayment.PlanId.Value);
                    var userRole = new UserRole
                    {
                        UserId = currentUserId,
                        RoleId = plan.RoleId.Value
                    };
                    await _userService.AddToRoleByIdAsync(currentUserId, userRole);
                    await _accountService.SignOutCurrentUserAsync();
                    await _accountService.SignInByIdAsync(currentUserId);

                    return PaymentResult.Success;

                // case -1: // اطلاعات ارسال شده ناقص است
                // case -2: // IP و يا مرچنت كد پذيرنده صحيح نيست
                // case -3: // با توجه به محدوديت هاي شاپرك امكان پرداخت با رقم درخواست شده ميسر نمي باشد
                // case -4: // سطح تاييد پذيرنده پايين تر از سطح نقره اي است
                // case -11: // درخواست مورد نظر يافت نشد
                // case -12: // امكان ويرايش درخواست ميسر نمي باشد
                // case -21: // هيچ نوع عمليات مالي براي اين تراكنش يافت نشد
                // case -22: // تراكنش نا موفق ميباشد
                // case -33: // رقم تراكنش با رقم پرداخت شده مطابقت ندارد.
                // case -34: // سقف تقسيم تراكنش از لحاظ تعداد يا رقم عبور نموده است
                // case -40: // اجازه دسترسي به متد مربوطه وجود ندارد
                // case -41: // اطلاعات ارسال شده مربوط به  AdditionalDataغيرمعتبر ميباشد
                // case -42: // مدت زمان معتبر طول عمر شناسه پرداخت بايد بين  30دقيه تا  45روز مي باشد
                // case -54: // درخواست مورد نظر آرشيو شده است
                default:
                    planPayment.IsSuccess = false;
                    await _unitOfWork.SaveAllChangesAsync(auditUserId: _webContextManager.CurrentUserId);
                    return PaymentResult.Failed();
            }
        }


        public async Task<int> CountByRequestAsync(PlanPaymentSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).CountAsync();
        }


        public async Task<PaymentResult> CreateByViewModelAsync(PlanPyamentCreateViewModel viewModel)
        {
            var plan = await _planService.FindByCodeAsync(viewModel.Code);
            if (plan == null)
                throw new ServiceException();

            viewModel.Amount = plan.Price;
            if (viewModel.DiscountCode != null)
            {
                var discount = await _planDiscountService.GetPercentByCodeAsync(viewModel.DiscountCode);
                if (discount > 0)
                {
                    var price = (viewModel.Amount * discount) / 100;
                    viewModel.Amount = viewModel.Amount - price;
                }
            }

            switch (viewModel.Pay)
            {
                case PayType.Zarinpal:
                    return await CreateWithZarinpalByViewModelAsync(viewModel);

                default:
                    return await CreateWithZarinpalByViewModelAsync(viewModel);
            }
        }


        public async Task<PaymentResult> CreateWithZarinpalByViewModelAsync(PlanPyamentCreateViewModel viewModel)
        {
            var user = await _userService.FindByUserIdAsync(Guid.Empty, true);
            var plan = await _planService.FindByCodeAsync(viewModel.Code);
            if (plan == null)
                return PaymentResult.Failed();

            var zarinpal = _paymentGatewayManager.ZarinpalGateway();
            string authorityCode;
            var status = zarinpal.PaymentRequest(_configurationManager.MerchantCode, Convert.ToInt32(viewModel.Amount),
                _configurationManager.PaymentDescription, user.Email, user.Meta.PhoneNumber,
                _configurationManager.PlanPaymentCallbackUrl, out authorityCode);

            var planPayment = new PlanPayment
            {
                PlanId = plan.Id,
                AuthorityCode = authorityCode,
                StatusCode = status,
                Amount = viewModel.Amount,
                CreatedById = _webContextManager.CurrentUserId,
                CreatedOn =  DateTime.Now
            };
            _planPaymentRepository.Add(planPayment);
            await _unitOfWork.SaveAllChangesAsync(auditUserId: _webContextManager.CurrentUserId);

            switch (status)
            {
                case 100:
                    return PaymentResult.Succeed(_configurationManager.ZarinpalGateway.PlusWord(authorityCode));

                default:
                    return PaymentResult.Failed();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="authorityCode"></param>
        /// <returns></returns>
        public async Task<PlanPayment> FindByAuthorityCodeAsync(string authorityCode)
        {
            return await _planPaymentRepository.FirstOrDefaultAsync(model => model.AuthorityCode == authorityCode);
        }


        public async Task<IList<PlanPayment>> GetByRequestAsync(PlanPaymentSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return await QueryByRequest(request).ToPagedListAsync(request);
        }


        public IQueryable<PlanPayment> QueryByRequest(PlanPaymentSearchRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var planPayments = _planPaymentRepository.AsNoTracking().AsQueryable();
            if (request.CreatedById != null)
                planPayments = planPayments.Where(model => model.CreatedById == request.CreatedById);
            if (string.IsNullOrEmpty(request.SortMember))
                request.SortMember = SortMember.CreatedOn;
            if (string.IsNullOrEmpty(request.SortDirection))
                request.SortDirection = SortDirection.Asc;
            planPayments = planPayments.OrderBy($"{request.SortMember} {request.SortDirection}");

            return planPayments;
        }

        #endregion Public Methods
    }
}